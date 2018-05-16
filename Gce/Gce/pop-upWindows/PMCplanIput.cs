using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gce_Bll;
using Gce_Model;
using Gce.MoreDocumentsWindows;

namespace Gce.pop_upWindows
{
    public partial class PMCplanIput : Office2007Form
    {

        //
        ProductSet_NewBll psnb = new ProductSet_NewBll();
        PMCplan_tableBll PMCtableBll = new PMCplan_tableBll();
        PRequiredTime_DetailedBll prdb = new PRequiredTime_DetailedBll();
        private PMCplan pmc;

        //集合
        Dictionary<string, double> dataDic = new Dictionary<string, double>();
        Dictionary<string, Dictionary<string, double>> dataDicS = new Dictionary<string, Dictionary<string, double>>();
        List<PMCplan_table> dataDGVlist = new List<PMCplan_table>();

        string GUID;

        string state = "browse";

        bool Flag = false;
        bool Jump = false;
        public PMCplanIput(Dictionary<string, double> datadic,string guid, Dictionary<string, Dictionary<string, double>> datadics, List<PMCplan_table> datadgvlist, bool jump,PMCplan pmcplan)
        {
            InitializeComponent();
            this.dataDic = datadic;
            this.dataDicS = datadics;
            this.dataDGVlist = datadgvlist;
            this.Jump = jump;
            this.pmc = pmcplan;
            this.GUID = guid;
        }

        public PMCplanIput()
        {
            InitializeComponent();
        }
        private void PMCplanIput_Load(object sender, EventArgs e)
        {
            if (Jump)
            {
                state = "modify";
            }
            InitializationContrls1();
            UpdateControls();
            this.SetDataGridView();
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

            DataGridViewTextBoxColumn newcol4 = new DataGridViewTextBoxColumn();
            newcol4.HeaderText = "备注";
            newcol4.DataPropertyName = "Remarks";
            newcol4.Name = "Remarks";
            newcol4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            this.dataGridViewX1.Columns.Insert(5, newcol4);

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

            DataGridViewTextBoxColumn newcol8 = new DataGridViewTextBoxColumn();
            newcol8.HeaderText = "更新时间";
            newcol8.DataPropertyName = "UpdateTime";
            newcol8.Name = "UpdateTime";
            newcol8.Visible = false;

            this.dataGridViewX1.Columns.Insert(8, newcol8);

            if (Jump)
            {
                this.dataGridViewX1.DataSource = dataDGVlist;
            }
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
        }
        void ControlsClear()
        {
            comb_companyName.Text = "";
            txt_ZhiDan.Text = "";
            txt_customer.Text = "";
            txt_Node.Text = "";
            txt_ProductionRequired.Text = "";
            input_totalOrder.Text = "";
            dti_shippingData.Text = "";
        }
        void UpdateControls()
        {
            if (Flag)
            {
                ControlsClear();
            }
            if (state == "browse")
            {
                btni_Create.Enabled = true;
                btni_Save.Enabled = false;
                btni_cancel.Enabled = false;
                btni_modify.Enabled = true;
                btni_delete.Enabled = true;

                comb_companyName.Enabled = false;
                txt_customer.Enabled = false;
                txt_ZhiDan.Enabled = false;
                txt_ProductionRequired.Enabled = false;
                txt_Node.Enabled = false;

                Flag = false;
                input_totalOrder.Enabled = false;
                dti_shippingData.Enabled = false;

                this.dataGridViewX1.Enabled = true;
            }
            else
            {
                btni_Create.Enabled = false;
                btni_Save.Enabled = true;
                btni_cancel.Enabled = true;
                btni_modify.Enabled = false;
                btni_delete.Enabled = false;

                if (state == "modify")
                {
                    comb_companyName.Enabled = false;
                    txt_ZhiDan.Enabled = false;
                }
                else
                {
                    comb_companyName.Enabled = true;
                    txt_ZhiDan.Enabled = true;
                    
                }
                txt_customer.Enabled = true;
                txt_ProductionRequired.Enabled = false;
                txt_Node.Enabled = true;

                input_totalOrder.Enabled = true;
                dti_shippingData.Enabled = true;

                this.dataGridViewX1.Enabled = false;
            }
        }

        private void btni_Create_Click(object sender, EventArgs e)
        {
            state = "insert";

            Flag = true;

            UpdateControls();
        }

        private void btni_cancel_Click(object sender, EventArgs e)
        {
            state = "browse";

            UpdateControls();
        }

        private void btni_modify_Click(object sender, EventArgs e)
        {
            state = "modify";

            UpdateControls();
        }

        private void btni_delete_Click(object sender, EventArgs e)
        {
            if (PMCtableBll.checkedPMCplan_tableBll(comb_companyName.Text.Trim(), txt_ZhiDan.Text.Trim(), "checkedPMCplan_table"))
            {
                if (PMCtableBll.deletePMCplan_tableBll(comb_companyName.Text.Trim(), txt_ZhiDan.Text.Trim(), "deletePMCplan_table"))
                {
                    int i = this.dataGridViewX1.CurrentRow.Index;
                    Dictionary<string, double> dic = new Dictionary<string, double>();
                    dic = dataDicS[dataDGVlist[i].RequiredTimeGUID];
                    foreach (var item in dic)
                    {
                        prdb.deletePRequiredTime_DetailedDal(item.Key, dataDGVlist[i].RequiredTimeGUID, "deletePRequiredTime_Detailed");
                    }
                    dataDicS.Remove(dataDGVlist[i].RequiredTimeGUID);

                    this.dataGridViewX1.DataSource = new List<PMCplan_table>();//解除数据源绑定
                    dataDGVlist.RemoveAt(i);//删除数据源数据
                    this.dataGridViewX1.DataSource = dataDGVlist;//重新绑定数据源
                    this.lableMessage("删除成功");
                    ControlsClear();
                }
                else
                {
                    this.lableMessage("删除失败");
                }
            }
            else
            {
                MessageBox.Show("该记录不存在或已被删除!");
            }
        }

        private void input_totalOrder_Leave(object sender, EventArgs e)
        {
            this.Settxt_ProductRequired();
        }

        void Settxt_ProductRequired()
        {
            txt_ProductionRequired.Text = "";
            if (input_totalOrder.Text == "" || txt_ZhiDan.Text == "")
            {
                return;
            }
            dataDic = psnb.selectProductSet_NewForProductClassBll(Convert.ToDouble(input_totalOrder.Value), txt_ZhiDan.Text.Trim(), "selectProductSet_NewForProductClass");
            string str = "";
            foreach (var item in dataDic)
            {
                str += item.Key + ":" + Convert.ToString(item.Value) + "(小时)" + "\r\n";
            }


            txt_ProductionRequired.Text = str;
        }

        private void txt_ZhiDan_Leave(object sender, EventArgs e)
        {
            this.Settxt_ProductRequired();
        }

        private void btni_Save_Click(object sender, EventArgs e)
        {
            this.sava1();
        }

        void sava1()
        {
            if (txt_ProductionRequired.Text == "") this.Settxt_ProductRequired();            

            if (state == "insert")
            {
                this.lableMessage("正在保存..");

                if (!MessageSave()) return;

                Guid guid = Guid.NewGuid();

                List<PMCplan_table> list = new List<PMCplan_table>();
                list.Add(new PMCplan_table()
                {
                    CorporateName = comb_companyName.Text.Trim(),
                    ZhiDan = txt_ZhiDan.Text.Trim(),
                    TotalOrder = input_totalOrder.Value,
                    RequiredTimeGUID = guid.ToString(),
                    CustomerName = txt_customer.Text.Trim(),
                    ShippingDate = dti_shippingData.Value,
                    Remarks = txt_Node.Text.Trim()
                });
                try
                {
                    if (PMCtableBll.insertPMCplan_tableBll(list, "insertPMCplan_table"))
                    {
                        dataDicS.Add(guid.ToString(), dataDic);//以GUID为键存储工位所需时间的集合
                        List<PRequiredTime_Detailed> list1 = new List<PRequiredTime_Detailed>();
                        try
                        {
                            //循环插入工位所需时间
                            foreach (var item in dataDic)
                            {
                                list1.Clear();

                                list1.Add(new PRequiredTime_Detailed()
                                {
                                    ProductType = item.Key,
                                    RequiredTimeGUID = guid.ToString(),
                                    RequiredTime = item.Value
                                });

                                prdb.insertPRequiredTime_DetailedBll(list1, "insertPRequiredTime_Detailed");
                                SetDataList(list[0]);
                                state = "browse";
                                UpdateControls();
                            }
                            this.lableMessage("完成");
                        }
                        catch (Exception e)//捕获异常并抛出
                        {
                            MessageBox.Show(e.Message);
                            this.lableMessage("保存失败");
                        }
                    }
                    else
                    {
                        this.lableMessage("保存失败");
                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show("计划可能已经被录入" + "\r\n" + e.Message);
                    this.lableMessage("保存失败");
                }


            }
            else if (state == "modify")
            {
                this.lableMessage("正在保存..");
                if (!MessageSave())
                {
                    return;
                }
                Guid guid = Guid.NewGuid();
                List<PMCplan_table> list = new List<PMCplan_table>();
                list.Add(new PMCplan_table()
                {
                    CorporateName = comb_companyName.Text.Trim(),
                    ZhiDan = txt_ZhiDan.Text.Trim(),
                    TotalOrder = input_totalOrder.Value,
                    RequiredTimeGUID = guid.ToString(),
                    CustomerName = txt_customer.Text.Trim(),
                    ShippingDate = dti_shippingData.Value,
                    Remarks = txt_Node.Text.Trim()
                });
                try
                {
                    //检查修改的计划是否存在
                    if (PMCtableBll.checkedPMCplan_tableBll(comb_companyName.Text.Trim(), txt_ZhiDan.Text.Trim(), "checkedPMCplan_table"))
                    {
                        //修改计划
                        if (PMCtableBll.updatePMCplan_tableBll(comb_companyName.Text.Trim(), txt_ZhiDan.Text.Trim(), list, "updatePMCplan_table"))
                        {
                            Dictionary<string,double> dic=new Dictionary<string,double>();
                            dic=dataDicS[dataDGVlist[this.dataGridViewX1.CurrentRow.Index].RequiredTimeGUID];
                            foreach (var item in dic)
                            {
                                prdb.deletePRequiredTime_DetailedDal(item.Key, dataDGVlist[this.dataGridViewX1.CurrentRow.Index].RequiredTimeGUID, "deletePRequiredTime_Detailed");
                            }
                            dataDicS.Remove(dataDGVlist[this.dataGridViewX1.CurrentRow.Index].RequiredTimeGUID);
                            dataDicS.Add(guid.ToString(), dataDic);
                            List<PRequiredTime_Detailed> list1 = new List<PRequiredTime_Detailed>();
                            try
                            {
                                //循环插入工位所需时间
                                foreach (var item in dataDic)
                                {
                                    list1.Clear();

                                    list1.Add(new PRequiredTime_Detailed()
                                    {
                                        ProductType = item.Key,
                                        RequiredTimeGUID = guid.ToString(),
                                        RequiredTime = item.Value
                                    });

                                    prdb.insertPRequiredTime_DetailedBll(list1, "insertPRequiredTime_Detailed");
                                    SetDataList(list[0]);
                                    state = "browse";
                                    UpdateControls();
                                }
                                this.lableMessage("完成");
                                if (Jump)
                                {
                                    list[0].UpdateTime = DateTime.Now;
                                    pmc.UpdateDataList(list,list1,GUID);
                                    this.Close();
                                }
                            }
                            catch (Exception e)//捕获异常并抛出
                            {
                                MessageBox.Show(e.Message);
                                this.lableMessage("保存失败");
                            }            
                        }
                    }
                    else
                    {
                        MessageBox.Show("该计划不存在或已被删除！");
                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        void SetDataList(PMCplan_table PR)
        {
            if (state == "insert")
            {
                dataDGVlist.Add(PR);
                this.dataGridViewX1.DataSource = new List<PMCplan_table>();
                this.dataGridViewX1.DataSource = dataDGVlist;
            }
            else if (state == "modify")
            {
                dataDGVlist[this.dataGridViewX1.CurrentRow.Index] = PR;
                this.dataGridViewX1.DataSource = new List<PMCplan_table>();
                this.dataGridViewX1.DataSource = dataDGVlist;
            }
        }
        bool MessageSave()
        {
            if (comb_companyName.Text == "")
            {
                MessageBox.Show("公司名称不能为空！");
                return false;
            }
            else if (txt_customer.Text == "")
            {
                MessageBox.Show("客户名称不能为空！");
                return false;
            }
            else if (txt_ZhiDan.Text == "")
            {
                MessageBox.Show("单号不能为空！");
                return false;
            }
            else if (input_totalOrder.Text == "")
            {
                MessageBox.Show("订单总数不能为空！");
                return false;
            }
            else if (dti_shippingData.Text == "")
            {
                MessageBox.Show("出货日期不能为空！");
                return false;
            }
            else if (txt_ProductionRequired.Text == "")
            {
                MessageBox.Show("生产所需时间(小时)不能为空！");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void dataGridViewX1_SelectionChanged(object sender, EventArgs e)
        {
            this.dataGridViewX1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (dataDGVlist.Count > 0 && !Flag)
            {
                SetControls(this.dataDGVlist[this.dataGridViewX1.CurrentRow.Index]);//选择一行时给控件赋值
            }

            Flag = false;
        }

        void SetControls(PMCplan_table pmc)
        {
            comb_companyName.Text = pmc.CorporateName;
            txt_ZhiDan.Text = pmc.ZhiDan;
            txt_customer.Text = pmc.CustomerName;
            txt_Node.Text = pmc.Remarks;
            input_totalOrder.Value = pmc.TotalOrder;
            dti_shippingData.Value = pmc.ShippingDate;

            Dictionary<string, double> dic = new Dictionary<string, double>();
            
            string str = "";
            if (dic.ContainsKey(pmc.RequiredTimeGUID))
            {
                dic = dataDicS[pmc.RequiredTimeGUID];
                foreach (var item in dic)
                {
                    str += item.Key + ":" + Convert.ToString(item.Value) + "(小时)" + "\r\n";
                }
            }
            txt_ProductionRequired.Text = str;
        }

        void lableMessage(string str)
        {
            lab_Message.Text = str;
            bar1.Refresh();
        }

        private void btn_call_Click(object sender, EventArgs e)
        {
            ParametersCall pc = new ParametersCall(txt_ZhiDan.Text.Trim());
            pc.ShowDialog();
        }
    }

}
