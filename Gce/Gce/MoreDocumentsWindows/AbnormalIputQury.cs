using Bll;
using DevComponents.DotNetBar;
using Gce.pop_upWindows;
using Gce.Windows;
using Gce_Bll;
using Gce_Common;
using Gce_Model;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Gce.MoreDocumentsWindows
{
    public partial class AbnormalIputQury : Office2007Form
    {
        SynchronizationContext m_SyncContext = null; //上下文

        //类对象
        PStaffResumeBll psrb = new PStaffResumeBll();
        PAbnormalInputBll paib = new PAbnormalInputBll();
        PExceptionTypesBll ptb = new PExceptionTypesBll();
        ConditionQueryBll cqb = new ConditionQueryBll();
        ProductionLinePC_titleBll plPC = new ProductionLinePC_titleBll();
        Gce gce;

        //数据源集合
        List<PAbnormalInput> DataList = new List<PAbnormalInput>();
        List<string> combList = new List<string>();

        //条件查询集合
        List<selectConditionsQueryPStaffResumeModel2> QueryList = new List<selectConditionsQueryPStaffResumeModel2>();
        List<productionOrder> polist = new List<productionOrder>();

        //线程
        Thread th;

        bool clear1 = false;
        public AbnormalIputQury(Gce g)
        {
            InitializeComponent();
            gce = g;
            m_SyncContext = SynchronizationContext.Current;//获取主线程同步的上下文
        }

        private void txt_SchoolPersonnel_ButtonCustomClick(object sender, EventArgs e)
        {
            List<string> strlist = new List<string>();
            strlist.Add("姓名");
            strlist.Add("公司名称");
            if (QueryList.Count > 0)
            {
                ConditionsQuery cq = new ConditionsQuery("录入人员姓名与所属公司", strlist, QueryList, this);
                cq.ShowDialog();
            }
            else
            {
                QueryList = psrb.selectConditionsQueryPStaffResumeBll2("selectConditionsQueryPStaffResume2");
                ConditionsQuery cq = new ConditionsQuery("录入人员姓名与所属公司", strlist, QueryList, this);
                cq.ShowDialog();
            }
        }

        public void SetNameAndCompanyName(List<selectConditionsQueryPStaffResumeModel2> list)
        {
            txt_SchoolPersonnel.Text = list[0].Name;
            txt_CompanyName.Text = list[0].CompanyName;
            if (txt_CompanyName.Text != "")
            {
                cb_LineName.DataSource = plPC.selectProductionLinePC_titleLineNameBll(txt_CompanyName.Text.Trim(), "selectProductionLinePC_titleLineName");
            }
        }

        private void btni_abnormalInput_Click(object sender, EventArgs e)
        {
            if (!(UsersHelp.systemAdimin || UsersHelp.abnormal_Defective_product_entry))
            {
                MessageBox.Show("抱歉，您没有使用该功能的权限");
                return;
            }
            
            AbnormalIput Ai = new AbnormalIput();
            Ai.ShowDialog();
        }

        private void btni_query_Click(object sender, EventArgs e)
        {
            if (DataList.Count > 0)
            {
                DataList.Clear();
            }
            gce.Setlb_QueryState("正在查询...");//刷新主界面提示
            this.Query1();
        }
        //查询
        void Query1()
        {
            List<PAbnormalInput> list = new List<PAbnormalInput>();
            list.Add(new PAbnormalInput()
            {
                ZhiDan = txt_Zhidan.Text.Trim(),
                SchoolPersonnel = txt_SchoolPersonnel.Text.Trim(),
                CompanyName = txt_CompanyName.Text.Trim(),
                LineOf = cb_LineName.Text.Trim(),
                WorkStation = txt_Workstation.Text.Trim(),
                ProblemDescription = txt_problem.Text.Trim(),
                ExceptionTypes = comb_Exception.Text.Trim(),
                Node1 = ""
            });

            DateTime beginTime = new DateTime(dti_begin.Value.Year, dti_begin.Value.Month, dti_begin.Value.Day, 00, 00, 00);
            DateTime endTime = new DateTime(dti_end.Value.Year, dti_end.Value.Month, dti_end.Value.Day, 23, 59, 59);

            if (th != null)
            {
                th.Abort();
            }
            th = new Thread(delegate()//用委托向后台线程传参
            {
                selectPAbnormalInput(list, beginTime, endTime);
            });
            th.IsBackground = true;//标记为后台线程
            th.Start();//打开线程
        }

        private void AbnormalIputQury_Load(object sender, EventArgs e)
        {
            InitializationControls();
        }

        void InitializationControls()
        {
            dti_begin.Value = DateTime.Now;
            dti_end.Value = DateTime.Now;
            SetDataGridView();
            DateTime beginTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00, 00, 00);
            DateTime endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            DataList = paib.selectPAbnormalInputBll(new List<PAbnormalInput>(), beginTime, endTime, "selectPAbnormalInput");
            this.dataGridViewX1.DataSource = DataList;
            //查找异常类型
            combList = ptb.selectPExceptionTypesBll("selectPExceptionTypes");
            //绑定异常类型控件数据源
            comb_Exception.DataSource = combList;
            //异常类型初始化为空
            comb_Exception.Text = "";
        }

        void SetDataGridView()
        {
            DataGridViewTextBoxColumn newcol = new DataGridViewTextBoxColumn();
            newcol.HeaderText = "订单号";
            newcol.Name = "ZhiDan";
            newcol.DataPropertyName = "ZhiDan";

            this.dataGridViewX1.Columns.Insert(0, newcol);

            DataGridViewTextBoxColumn newcol1 = new DataGridViewTextBoxColumn();
            newcol1.HeaderText = "录入人员";
            newcol1.Name = "SchoolPersonnel";
            newcol1.DataPropertyName = "SchoolPersonnel";

            this.dataGridViewX1.Columns.Insert(1, newcol1);

            DataGridViewTextBoxColumn newcol2 = new DataGridViewTextBoxColumn();
            newcol2.HeaderText = "公司名称";
            newcol2.Name = "CompanyName";
            newcol2.DataPropertyName = "CompanyName";

            this.dataGridViewX1.Columns.Insert(2, newcol2);

            DataGridViewTextBoxColumn newcol3 = new DataGridViewTextBoxColumn();
            newcol3.HeaderText = "产线名称";
            newcol3.Name = "LineOf";
            newcol3.DataPropertyName = "LineOf";

            this.dataGridViewX1.Columns.Insert(3, newcol3);

            DataGridViewTextBoxColumn newcol4 = new DataGridViewTextBoxColumn();
            newcol4.HeaderText = "工站";
            newcol4.Name = "WorkStation";
            newcol4.DataPropertyName = "WorkStation";

            this.dataGridViewX1.Columns.Insert(4, newcol4);

            DataGridViewTextBoxColumn newcol5 = new DataGridViewTextBoxColumn();
            newcol5.HeaderText = "异常类型";
            newcol5.Name = "ExceptionTypes";
            newcol5.DataPropertyName = "ExceptionTypes";

            this.dataGridViewX1.Columns.Insert(5, newcol5);

            DataGridViewTextBoxColumn newcol6 = new DataGridViewTextBoxColumn();
            newcol6.HeaderText = "问题描述";
            newcol6.Name = "ProblemDescription";
            newcol6.DataPropertyName = "ProblemDescription";

            this.dataGridViewX1.Columns.Insert(6, newcol6);

            DataGridViewTextBoxColumn newcol7 = new DataGridViewTextBoxColumn();
            newcol7.HeaderText = "备注";
            newcol7.Name = "Node1";
            newcol7.DataPropertyName = "Node1";
            newcol7.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            this.dataGridViewX1.Columns.Insert(7, newcol7);

            DataGridViewTextBoxColumn newcol8 = new DataGridViewTextBoxColumn();
            newcol8.HeaderText = "";
            newcol8.Name = "ID";
            newcol8.DataPropertyName = "ID";
            newcol8.Visible = false;

            this.dataGridViewX1.Columns.Insert(8, newcol8);


        }
        void selectPAbnormalInput(List<PAbnormalInput> datalist,DateTime beginTime,DateTime endTime)
        {

            m_SyncContext.Post(UpdateDgv, paib.selectPAbnormalInputBll(datalist, beginTime, endTime, "selectPAbnormalInput"));
             
        }


        void UpdateDgv(object o)
        {
            DataList = o as List<PAbnormalInput>;

            dataGridViewX1.DataSource = new List<PAbnormalInput>();
            dataGridViewX1.DataSource = DataList;
            gce.Setlb_QueryState("完成");//刷新主界面提示
        }
        private void dataGridViewX1_SelectionChanged(object sender, EventArgs e)
        {
            this.dataGridViewX1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (DataList.Count > 0 && !clear1)
            {
                try
                {
                    if (!(dataGridViewX1.CurrentRow.Index > DataList.Count))
                    {
                        this.SetControsBtni(DataList[dataGridViewX1.CurrentRow.Index]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            clear1 = false;
        }

        void SetControsBtni(PAbnormalInput pi)
        {
            txt_Zhidan.Text = pi.ZhiDan;
            txt_SchoolPersonnel.Text = pi.SchoolPersonnel;
            txt_CompanyName.Text = pi.CompanyName;
            cb_LineName.Text = pi.LineOf;
            txt_Workstation.Text = pi.WorkStation;
            txt_problem.Text = pi.ProblemDescription;
            comb_Exception.Text = pi.ExceptionTypes;
        }
        private void dataGridViewX1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(this.dataGridViewX1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, CultureInfo.CurrentUICulture),
                e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            }
        }

        private void txt_Zhidan_ButtonCustomClick(object sender, EventArgs e)
        {

            DateTime endTime = new DateTime(dti_end.Value.Year, dti_end.Value.Month, dti_end.Value.Day, 23, 59, 59);
            DateTime beginTime = new DateTime(dti_begin.Value.Year, dti_begin.Value.Month, dti_begin.Value.Day, 00, 00, 00);

            List<string> strlist = new List<string>();
            strlist.Add("订单号");

            polist = cqb.selectOrderBll("selectzOrderAndSoftModel", "", "", beginTime, endTime);
            ConditionsQuery cq = new ConditionsQuery("订单号查询", strlist, polist, this);
            cq.ShowDialog();
        }

        private void AbnormalIputQury_FormClosed(object sender, FormClosedEventArgs e)
        {
            gce.lb_QueryStateVisible();//刷新主界面提示
        }

        public void setTxt_Order(string str)
        { 
            txt_Zhidan.Text=str;
        }

        private void btni_clear_Click(object sender, EventArgs e)
        {
            clear1 = true;
            ClearBtni();
        }

        void ClearBtni()
        {
            txt_Zhidan.Text = "";
            txt_SchoolPersonnel.Text = "";
            txt_CompanyName.Text = "";
            cb_LineName.Text = "";
            txt_Workstation.Text = "";
            txt_problem.Text = "";
            comb_Exception.Text = "";
        }

        private void btni_dataOut_Click(object sender, EventArgs e)
        {
            if (!(UsersHelp.systemAdimin || UsersHelp.abnormal_DataOut))
            {
                MessageBox.Show("抱歉，您没有使用该功能的权限");
                return;
            }
            
            if (this.dataGridViewX1.CurrentRow == null)
            {
                MessageBox.Show("没有可导出的数据!");
                return;
            }
            if(ExcelHelperForCs.ExportToExcel(dataGridViewX1)==null)
            {
                MessageBox.Show("导出完成");
            }

        }
        //修改
        private void btni_modify_Click(object sender, EventArgs e)
        {
            if (!(UsersHelp.systemAdimin || UsersHelp.abnormal_Modify))
            {
                MessageBox.Show("抱歉，您没有使用该功能的权限");
                return;
            }
            
            if (dataGridViewX1.Rows.Count > 0)
            {
                List<PAbnormalInput> list=new List<PAbnormalInput>();
                list.Add(DataList[this.dataGridViewX1.CurrentRow.Index]);
                DateTime endTime = new DateTime(dti_end.Value.Year, dti_end.Value.Month, dti_end.Value.Day, 23, 59, 59);
                DateTime beginTime = new DateTime(dti_begin.Value.Year, dti_begin.Value.Month, dti_begin.Value.Day, 00, 00, 00);
                AbnormalIput ai = new AbnormalIput("modify");
                ai.Update1(beginTime, endTime, list);
                ai.ShowDialog();
            }
        }
        //删除
        private void btni_delete_Click(object sender, EventArgs e)
        {
            if (!(UsersHelp.systemAdimin || UsersHelp.abnormal_Delete))
            {
                MessageBox.Show("抱歉，您没有使用该功能的权限");
                return;
            }

            if (MessageBox.Show("确定删除此条记录？", "系统提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                gce.Setlb_QueryState("正在删除...");
                List<PAbnormalInput> listOldData = new List<PAbnormalInput>();
                listOldData.Add(DataList[this.dataGridViewX1.CurrentRow.Index]);

                if (paib.deletePAbnormalInputBll(listOldData[0].ID, "deletePAbnormalInput"))
                {
                    clear1 = true;//标志是否可以清空查询条件 
                    listOldData.Clear();
                    foreach (PAbnormalInput item in DataList)
                    {
                        if (item.ID != DataList[dataGridViewX1.CurrentRow.Index].ID )
                        {
                            listOldData.Add(item);
                        }
                    }

                    gce.Setlb_QueryState("完成");
                    DataList = listOldData;
                    dataGridViewX1.DataSource = DataList;
                    dataGridViewX1.Refresh();
                }
                else
                {
                    gce.Setlb_QueryState("删除失败");
                }
            }
        }

        private void 分类显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassificationDisplay cd = new ClassificationDisplay(this.DataList);
            cd.ShowDialog();
        }
    }
}
