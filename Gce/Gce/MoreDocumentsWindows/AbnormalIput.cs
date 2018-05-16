using DevComponents.DotNetBar;
using Gce.Windows;
using Gce_Bll;
using Gce_Model;
using Gce_Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gce.pop_upWindows;
using Model;
using Bll;
using System.Globalization;

namespace Gce.MoreDocumentsWindows
{
    public partial class AbnormalIput : Office2007Form
    {
        //类对象
        PStaffResumeBll psrb = new PStaffResumeBll();
        ProductionLinePC_titleBll plPC = new ProductionLinePC_titleBll();
        PAbnormalInputBll pib = new PAbnormalInputBll();
        PEncodingSettingBll pesb = new PEncodingSettingBll();
        ConditionQueryBll cqb = new ConditionQueryBll();
        PAbnormalInputBll paib = new PAbnormalInputBll();

        //数据源集合
        List<PAbnormalInput> datasList = new List<PAbnormalInput>();

        //条件查询集合
        List<selectConditionsQueryPStaffResumeModel2> QueryList = new List<selectConditionsQueryPStaffResumeModel2>();
        List<productionOrder> polist = new List<productionOrder>();

        //录入状态
        string InsertState = "scanning";
        //保存状态
        string state = "insert";

        bool clear1 = false;
        public AbnormalIput()
        {
            InitializeComponent();
        }

        public AbnormalIput(string str)
        {
            clear1 = true;
            InitializeComponent();
            this.state = str;
        }
        private void btni_ScansInput_Click(object sender, EventArgs e)
        {
            InsertState = "scanning";
            UpdateBtni();
        }

        private void bnti_Manually_Click(object sender, EventArgs e)
        {
            InsertState = "manual";
            UpdateBtni();
        }

        void UpdateBtni()
        {
            if (InsertState == "scanning")
            {
                btni_ScansInput.ForeColor = Color.Orange;
                btni_Manually.ForeColor = Color.Navy;
                btni_save.Enabled = false;
            }
            else if (InsertState == "manual")
            {
                btni_ScansInput.ForeColor = Color.Navy;
                btni_Manually.ForeColor = Color.Orange;
                btni_save.Enabled = true;
            }
        }

        private void AbnormalIput_Load(object sender, EventArgs e)
        {
            UpdateBtni();
            SetDataGridView();
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

            if (state == "modify")
            {
                this.dataGridViewX1.DataSource = datasList;
            }

        }

        private void txt_SchoolPersonnel_ButtonCustomClick(object sender, EventArgs e)
        {
            List<string> strlist = new List<string>();
            strlist.Add("姓名");
            strlist.Add("工号");
            strlist.Add("公司名称");
            if (QueryList.Count > 0)
            {
                ConditionsQuery cq = new ConditionsQuery("录入人员姓名与所属公司", strlist, QueryList,this);
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

        private void btni_save_Click(object sender, EventArgs e)
        {
            if (InsertState == "manual")
            {
                this.save1();
            }
        }

        void save1()
        {
            if (Message1())
            {
                if (state=="insert")
                {
                    lbi_message.Text = "正在保存";
                    List<PAbnormalInput> list = new List<PAbnormalInput>();
                    list.Add(GetPAbnormalInput());

                    if (pib.insertPAbnormalInputBll(list, "insertPAbnormalInput"))
                    {
                        lbi_message.Text = "保存成功";
                        this.dataGridViewX1.DataSource = new List<PAbnormalInput>();
                        datasList.Add(GetPAbnormalInput());
                        this.dataGridViewX1.DataSource = datasList;
                        this.dataGridViewX1.Refresh();
                    }
                    else
                    {
                        lbi_message.Text = "保存失败";
                    }
                }
                else
                {
                    lbi_message.Text = "正在保存";
                    List<PAbnormalInput> list = new List<PAbnormalInput>();
                    list.Add(GetPAbnormalInput());

                    if (pib.UpdatePAbnormalInputBll(dataGridViewX1.CurrentRow.Cells["ID"].Value.ToString(), list, "UpdatePAbnormalInput"))
                    {
                        lbi_message.Text = "更新成功";

                        datasList[dataGridViewX1.CurrentRow.Index] = GetPAbnormalInput();

                        this.dataGridViewX1.DataSource = new List<PAbnormalInput>();
                        this.dataGridViewX1.DataSource = datasList;
                        this.dataGridViewX1.Refresh();
                    }
                    else
                    {
                        lbi_message.Text = "更新失败";
                    }
                }
            }
        }
        bool Message1()
        {
            if (txt_Zhidan.Text == "")
            {
                MessageBox.Show("单号不能为空!");
                return false;
            }
            else if (txt_Workstation.Text == "")
            {
                MessageBox.Show("工站不能为空!");
                return false;
            }
            else if (txt_problem.Text == "")
            {
                MessageBox.Show("问题描述不能为空!");
                return false;
            }
            else if (txt_SchoolPersonnel.Text == "")
            {
                MessageBox.Show("录入人员不能为空!");
                return false;
            }
            else if (txt_CompanyName.Text == "")
            {
                MessageBox.Show("公司名称不能为空!");
                return false;
            }
            else if (cb_LineName.Text == "")
            {
                MessageBox.Show("产线名称不能为空!");
                return false;
            }
            else
            {
                return true;
            }
        }
        //获得PAbnormalInput对象
        PAbnormalInput GetPAbnormalInput()
        {
            PAbnormalInput pai = new PAbnormalInput();
            pai.ZhiDan = txt_Zhidan.Text.Trim();
            pai.SchoolPersonnel = txt_SchoolPersonnel.Text.Trim();
            pai.CompanyName = txt_CompanyName.Text.Trim();
            pai.LineOf = cb_LineName.Text.Trim();
            pai.WorkStation = txt_Workstation.Text.Trim();
            pai.ProblemDescription = txt_problem.Text.Trim();
            pai.ExceptionTypes = comb_Exception.Text.Trim();
            pai.Node1 = txt_node.Text.Trim();

            return pai;
        }

        private void btni_dataOut_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewX1.CurrentRow == null)
            {
                MessageBox.Show("没有可导出的数据!");
                return;
            }
            ExcelHelperForCs.ExportToExcel(dataGridViewX1);
            MessageBox.Show("导出完成");
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
            txt_node.Text = pi.Node1;
        }

        private void btni_clear_Click(object sender, EventArgs e)
        {
            clear1 = false;

            clearControlsBtni();
        }

        void clearControlsBtni()
        {
            txt_Zhidan.Text = "";
            txt_SchoolPersonnel.Text = "";
            txt_CompanyName.Text = "";
            cb_LineName.Text = "";
            txt_Workstation.Text = "";
            txt_problem.Text = "";
            comb_Exception.Text = "";
            txt_node.Text = "";
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            ExceptionConfiguration ec = new ExceptionConfiguration();
            ec.ShowDialog();
        }

        bool SetControlsproblem(List<PEncodingSetting> list)
        {
            if (!(list.Count > 0))
            {
                return false;
            }
            txt_problem.Text = list[0].ProblemDescription;
            comb_Exception.Text = list[0].ES_ExceptionTypes;
            return true;
        }

        private void txt_Zhidan_ButtonCustomClick(object sender, EventArgs e)
        {

            DateTime endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            DateTime beginTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00, 00, 00);

            List<string> strlist = new List<string>();
            strlist.Add("订单号");
            if (polist.Count > 0)
            {
                ConditionsQuery cq = new ConditionsQuery("订单号查询", strlist, polist, this);
                cq.ShowDialog();
            }
            else
            {
                polist = cqb.selectOrderBll("selectzOrderAndSoftModel", "", "", beginTime, endTime);
                ConditionsQuery cq = new ConditionsQuery("订单号查询", strlist, polist, this);
                cq.ShowDialog();
            }
        }

        public void setTxt_Order(string order)
        {
            txt_Zhidan.Text = order;
        }

        public void Update1(DateTime beginTime,DateTime endTime,List<PAbnormalInput> list)
        {
             
            datasList = paib.selectPAbnormalInputBll(list, beginTime, endTime, "selectPAbnormalInput");
        }

        private void dataGridViewX1_SelectionChanged_1(object sender, EventArgs e)
        {
             this.dataGridViewX1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
             if (datasList.Count > 0 && clear1)
             {
                 if (!(dataGridViewX1.CurrentRow.Index > datasList.Count))
                 {
                     this.SetControsBtni(datasList[dataGridViewX1.CurrentRow.Index]);
                 }
             }
             clear1 = false;
        }

        private void dataGridViewX1_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(this.dataGridViewX1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, CultureInfo.CurrentUICulture),
                e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            }
        }

        private void txt_problem_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (InsertState == "scanning")
                {

                    if (e.KeyValue == 13)
                    {
                        if (SetControlsproblem(pesb.ConditionsSelectPEncodingSettingBll(txt_problem.Text.Trim(), "ConditionsSelectPEncodingSetting")))
                        {
                            this.save1();
                        }
                        txt_problem.SelectAll(); 
                    }
                }
                else
                {

                    if (e.KeyValue == 13)
                    {
                        SetControlsproblem(pesb.ConditionsSelectPEncodingSettingBll(txt_problem.Text.Trim(), "ConditionsSelectPEncodingSetting"));
                        txt_problem.SelectAll();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
