using DevComponents.DotNetBar;
using Gce.pop_upWindows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gce_Model;
using Gce_Bll;
using System.Threading;
using Gce_Common;

namespace Gce.MoreDocumentsWindows
{
    public partial class PMCplan : Office2007Form
    {
        //上下文变量
        SynchronizationContext m_SyncContext = null;
        //线程
        Thread th;

        //数据源集合
        List<PMCplan_table> DataList = new List<PMCplan_table>();
        Dictionary<string, Dictionary<string, double>> DataDic = new Dictionary<string, Dictionary<string, double>>();

        //类对象
        PMCplan_tableBll pmctablebll = new PMCplan_tableBll();
        PRequiredTime_DetailedBll PRebll = new PRequiredTime_DetailedBll();

        private Gce gce;

        bool Flag = true;
        public PMCplan(Gce g)
        {
            InitializeComponent();
            this.gce = g;
            //同步UI主线程的上下文
            m_SyncContext = SynchronizationContext.Current;
        }

        private void btni_PMCplanInput_Click(object sender, EventArgs e)
        {
            if (!(UsersHelp.systemAdimin || UsersHelp.PMCplan_PMC_plan_entry))
            {
                MessageBox.Show("抱歉，您没有使用该功能的权限");
                return;
            }
            
            PMCplanIput pmcplaninput = new PMCplanIput();
            pmcplaninput.ShowDialog();
        }

        private void PMCplan_Load(object sender, EventArgs e)
        {
            SetDataGridView();
            InitializationContrls1();
        }

        private void btni_Query_Click(object sender, EventArgs e)
        {
            if (th != null)
            {
                th.Abort();
            }

            List<PMCplan_table> list = GetDataList();

            gce.Setlb_QueryState("正在查询...");

            th = new Thread(delegate()
            {
                this.selectPMCplan_tableUI(list);
            });
            th.IsBackground = true;
            th.Start();
        }

        void selectPMCplan_tableUI(List<PMCplan_table> list)
        {
            List<PMCplan_table> PMCList = new List<PMCplan_table>();
            PMCList = pmctablebll.selectPMCplan_tableBll(list, "selectPMCplan_table");

            List<PRequiredTime_Detailed> ReList = new List<PRequiredTime_Detailed>();
            ReList = PRebll.selectPRequiredTime_DetailedBll("selectPRequiredTime_Detailed");//查找工位所需时间集

            Dictionary<string, Dictionary<string, double>> dic = new Dictionary<string, Dictionary<string, double>>();


            foreach (PMCplan_table item in PMCList)
            {
                Dictionary<string, double> dic1 = new Dictionary<string, double>();
                foreach (PRequiredTime_Detailed item1 in ReList)
                {
                    if (item1.RequiredTimeGUID == item.RequiredTimeGUID)
                    {
                        dic1.Add(item1.ProductType, item1.RequiredTime);
                    }
                }
                dic.Add(item.RequiredTimeGUID, dic1);
            }

            m_SyncContext.Post(SetDataGridViewData, PMCList);
            m_SyncContext.Post(SetDataDic, dic);
        }

        void SetDataGridViewData(object o)
        {
            List<PMCplan_table> list = o as List<PMCplan_table>;
            this.dataGridViewX1.DataSource = new List<PMCplan_table>();
            DataList = list;
            this.dataGridViewX1.DataSource = DataList;
            gce.Setlb_QueryState("完成");
        }

        void SetDataDic(object o)
        {
            DataDic = o as Dictionary<string, Dictionary<string, double>>;
        }
        List<PMCplan_table> GetDataList()
        {
            List<PMCplan_table> list = new List<PMCplan_table>();
            list.Add(new PMCplan_table()
            {
                CorporateName=comb_companyName.Text.Trim(),
                CustomerName=txt_customer.Text.Trim(),
                TotalOrder=input_totalOrder.Value,
                ZhiDan=txt_ZhiDan.Text.Trim(),
                ShippingDate=dti_shippingData.Value,
                UpdateTime=dti_updateTime.Value
            });

            return list;
        }
        void InitializationContrls1()
        {
            PWorkScheduleBll pwsb = new PWorkScheduleBll();
            List<PWorkSchedule> list = pwsb.selectPWorkScheduleBll("selectPWorkSchedule");
            List<string> strlist = new List<string>();
            foreach (PWorkSchedule item in list)
            {
                strlist.Add(item.CompanyName);
            }

            if (strlist.Count > 0)
            {
                comb_companyName.DataSource = strlist;
            }
            comb_companyName.Text = "";
        }

        void SetDataGridView()
        {
            DataGridViewTextBoxColumn newcol = new DataGridViewTextBoxColumn();
            newcol.HeaderText = "公司名称";
            newcol.DataPropertyName = "CorporateName";
            newcol.Name = "CorporateName";

            this.dataGridViewX1.Columns.Insert(0, newcol);

            DataGridViewTextBoxColumn newcol1 = new DataGridViewTextBoxColumn();
            newcol1.HeaderText = "订单号";
            newcol1.DataPropertyName = "ZhiDan";
            newcol1.Name = "ZhiDan";

            this.dataGridViewX1.Columns.Insert(1, newcol1);

            DataGridViewTextBoxColumn newcol2 = new DataGridViewTextBoxColumn();
            newcol2.HeaderText = "客户名称";
            newcol2.DataPropertyName = "CustomerName";
            newcol2.Name = "CustomerName";

            this.dataGridViewX1.Columns.Insert(2, newcol2);

            DataGridViewTextBoxColumn newcol5 = new DataGridViewTextBoxColumn();
            newcol5.HeaderText = "订单总数";
            newcol5.DataPropertyName = "TotalOrder";
            newcol5.Name = "TotalOrder";

            this.dataGridViewX1.Columns.Insert(3, newcol5);

            DataGridViewTextBoxColumn newcol3 = new DataGridViewTextBoxColumn();
            newcol3.HeaderText = "出货日期";
            newcol3.DataPropertyName = "ShippingDate";
            newcol3.Name = "ShippingDate";

            this.dataGridViewX1.Columns.Insert(4, newcol3);

            DataGridViewTextBoxColumn newcol8 = new DataGridViewTextBoxColumn();
            newcol8.HeaderText = "更新时间";
            newcol8.DataPropertyName = "UpdateTime";
            newcol8.Name = "UpdateTime";
            newcol8.Visible = true;

            this.dataGridViewX1.Columns.Insert(5, newcol8);

            DataGridViewTextBoxColumn newcol6 = new DataGridViewTextBoxColumn();
            newcol6.HeaderText = "GUID";
            newcol6.DataPropertyName = "RequiredTimeGUID";
            newcol6.Name = "RequiredTimeGUID";
            newcol6.Visible = false;

            this.dataGridViewX1.Columns.Insert(6, newcol6);

            DataGridViewTextBoxColumn newcol7 = new DataGridViewTextBoxColumn();
            newcol7.HeaderText = "创建时间";
            newcol7.DataPropertyName = "CreationTime";
            newcol7.Name = "CreationTime";
            newcol7.Visible = false;

            this.dataGridViewX1.Columns.Insert(7, newcol7);

            DataGridViewTextBoxColumn newcol4 = new DataGridViewTextBoxColumn();
            newcol4.HeaderText = "备注";
            newcol4.DataPropertyName = "Remarks";
            newcol4.Name = "Remarks";
            newcol4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            this.dataGridViewX1.Columns.Insert(8, newcol4);
        }

        void KillThread()
        {
            if (th != null)
            {
                th.Abort();
            }
        }

        private void PMCplan_FormClosed(object sender, FormClosedEventArgs e)
        {
            KillThread();//释放线程资源
        }

        private void dataGridViewX1_SelectionChanged(object sender, EventArgs e)
        {
            this.dataGridViewX1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (dataGridViewX1.Rows.Count > 0 && Flag)
            {
                this.Settxt_ProductionRequired(DataList[this.dataGridViewX1.CurrentRow.Index].RequiredTimeGUID);
            }
            else
            {
                Flag = true;
            }
        }

        void Settxt_ProductionRequired(string GUID)
        {
            Dictionary<string, double> dic = new Dictionary<string, double>();
            string str = "";
            if (DataDic.ContainsKey(GUID))
            {
                dic = DataDic[GUID];

                foreach (var item in dic)
                {
                    str += item.Key + ":" + Convert.ToString(item.Value) + "(小时)" + "\r\n";
                }
            }
            txt_ProductionRequired.Text = str;
        }

        private void btni_dataOut_Click(object sender, EventArgs e)
        {
            if (!(UsersHelp.systemAdimin || UsersHelp.PMCplan_DataOute))
            {
                MessageBox.Show("抱歉，您没有使用该功能的权限");
                return;
            }
            
            if (this.dataGridViewX1.CurrentRow == null)
            {
                MessageBox.Show("没有可导出的数据!");
                return;
            }
            ExcelHelperForCs.ExportToExcel(dataGridViewX1);
            MessageBox.Show("导出完成");
        }

        private void btni_delete_Click(object sender, EventArgs e)
        {
            if (!(UsersHelp.systemAdimin || UsersHelp.PMCplan_Delete))
            {
                MessageBox.Show("抱歉，您没有使用该功能的权限");
                return;
            }
            
            if (this.dataGridViewX1.Rows.Count <= 0)
            {
                return;
            }
            int i = this.dataGridViewX1.CurrentRow.Index;
            if (pmctablebll.checkedPMCplan_tableBll(DataList[i].CorporateName, DataList[i].ZhiDan, "checkedPMCplan_table"))
            {
                if (pmctablebll.deletePMCplan_tableBll(DataList[i].CorporateName, DataList[i].ZhiDan, "deletePMCplan_table"))
                {                    
                    Dictionary<string, double> dic = new Dictionary<string, double>();
                    dic = DataDic[DataList[i].RequiredTimeGUID];
                    foreach (var item in dic)
                    {
                        PRebll.deletePRequiredTime_DetailedDal(item.Key, DataList[i].RequiredTimeGUID, "deletePRequiredTime_Detailed");
                    }
                    DataDic.Remove(DataList[i].RequiredTimeGUID);

                    this.dataGridViewX1.DataSource = new List<PMCplan_table>();//解除数据源绑定
                    DataList.RemoveAt(i);//删除数据源数据
                    this.dataGridViewX1.DataSource = DataList;//重新绑定数据源
                    gce.Setlb_QueryState("删除成功");
                
                }
                else
                {
                    gce.Setlb_QueryState("删除失败");
                }
            }
            else
            {
                MessageBox.Show("该记录不存在或已被删除!");
            }
        }

        private void btni_modify_Click(object sender, EventArgs e)
        {
            if (!(UsersHelp.systemAdimin || UsersHelp.PMCplan_Modify))
            {
                MessageBox.Show("抱歉，您没有使用该功能的权限");
                return;
            }
            
            List<PMCplan_table> list = new List<PMCplan_table>();
            list.Add(DataList[this.dataGridViewX1.CurrentRow.Index]);
            PMCplanIput pmcplanIput = new PMCplanIput(DataDic[list[0].RequiredTimeGUID], list[0].RequiredTimeGUID, DataDic, list, true, this);
            pmcplanIput.ShowDialog();
        }

        public void UpdateDataList(List<PMCplan_table> list,List<PRequiredTime_Detailed> list1,string guid)
        {
            int i = this.dataGridViewX1.CurrentRow.Index;//获得当前选中行的索引

            this.dataGridViewX1.DataSource = new List<PMCplan_table>();
            DataList[i] = list[0];
            this.dataGridViewX1.DataSource = DataList;

            Dictionary<string, double> dic = new Dictionary<string, double>();
            foreach (PRequiredTime_Detailed item in list1)
            {
                dic.Add(item.ProductType, item.RequiredTime);
            }
            DataDic.Remove(guid);
            //DataDic.Add(list1[0].RequiredTimeGUID, dic);

            Settxt_ProductionRequired(list1[0].RequiredTimeGUID);
        }

    }
}
