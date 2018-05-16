using DevComponents.DotNetBar;
using Gce_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gce_Bll;
using System.Globalization;
using System.Threading;
using Gce.pop_upWindows;
using Gce_Common;
using Gce.Windows;

namespace Gce.MoreDocumentsWindows
{
    public partial class EmployeeExperience : Office2007Form
    {
        Gce gce;

        //线程安全上下文
        SynchronizationContext m_SyncContext = null;

        //线程
        Thread th = null;

        //类对象
        PStaffResumeBll psrb = new PStaffResumeBll();
        PTypesWorkBll ptwb = new PTypesWorkBll();
        PWorkScheduleBll pwsb = new PWorkScheduleBll();

        //数据集合
        List<PStaffResume> DataList = new List<PStaffResume>();//datagridview数据源集合

        //条件查询集合
        List<selectConditionsQueryPStaffResumeModel> QueryList = new List<selectConditionsQueryPStaffResumeModel>();

        //状态
        string state = "browse";
        bool clear1 = false;//标志是否可以清空查询条件 
        public EmployeeExperience(Gce G)
        {
            InitializeComponent();
            this.gce = G;
        }

        void SetDataGridViewColumns()
        {

            DataGridViewTextBoxColumn newcol1 = new DataGridViewTextBoxColumn();
            newcol1.HeaderText = "姓名";
            newcol1.Name = "Name";
            newcol1.DataPropertyName = "Name";

            this.dataGridViewX1.Columns.Insert(0, newcol1);

            DataGridViewTextBoxColumn newcol2 = new DataGridViewTextBoxColumn();
            newcol2.HeaderText = "工号";
            newcol2.Name = "WorkNumber";
            newcol2.DataPropertyName = "WorkNumber";

            this.dataGridViewX1.Columns.Insert(1, newcol2);

            DataGridViewTextBoxColumn newcol3 = new DataGridViewTextBoxColumn();
            newcol3.HeaderText = "性别";
            newcol3.Name = "Gender";
            newcol3.DataPropertyName = "Gender";

            this.dataGridViewX1.Columns.Insert(2, newcol3);

            DataGridViewTextBoxColumn newcol4 = new DataGridViewTextBoxColumn();
            newcol4.HeaderText = "年龄";
            newcol4.Name = "Age";
            newcol4.DataPropertyName = "Age";

            this.dataGridViewX1.Columns.Insert(3, newcol4);

            DataGridViewTextBoxColumn newcol5 = new DataGridViewTextBoxColumn();
            newcol5.HeaderText = "工种";
            newcol5.Name = "WorkTypes";
            newcol5.DataPropertyName = "WorkTypes";

            this.dataGridViewX1.Columns.Insert(4, newcol5);

            DataGridViewTextBoxColumn newcol6 = new DataGridViewTextBoxColumn();
            newcol6.HeaderText = "级别";
            newcol6.Name = "Levels";
            newcol6.DataPropertyName = "Levels";

            this.dataGridViewX1.Columns.Insert(5, newcol6);

            DataGridViewTextBoxColumn newcol7 = new DataGridViewTextBoxColumn();
            newcol7.HeaderText = "入厂时间";
            newcol7.Name = "FactoryTime";
            newcol7.DataPropertyName = "FactoryTime";

            this.dataGridViewX1.Columns.Insert(6, newcol7);

            DataGridViewTextBoxColumn newcol = new DataGridViewTextBoxColumn();
            newcol.HeaderText = "公司名称";
            newcol.Name = "CompanyName";
            newcol.DataPropertyName = "CompanyName";

            this.dataGridViewX1.Columns.Insert(7, newcol);

            DataGridViewTextBoxColumn newcol8 = new DataGridViewTextBoxColumn();
            newcol8.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            this.dataGridViewX1.Columns.Insert(8, newcol8);

        }

        private void EmployeeExperience_Load(object sender, EventArgs e)
        {
            this.UpdateControl();
            this.SetDataGridViewColumns();
            Setcb_WorkTypes(ptwb.selectPTypesWorkDal("selectPTypesWork"));
            Setcb_CompanyName(pwsb.selectPWorkScheduleBll("selectPWorkSchedule"));
            this.ClearControls();
            m_SyncContext = SynchronizationContext.Current;//获取主线程同步的上下文
        }
        /// <summary>
        /// 更新按钮控件状态
        /// </summary>
        void UpdateControl()
        {
            if (state == "browse")
            {
                btni_Query.Enabled = true;
                btni_Insert.Enabled = true;
                btni_Save.Enabled = false;
                btni_Cancel.Enabled = false;
                btni_Modify.Enabled = true;
                btni_Delete.Enabled = true;
            }
            else
            {
                btni_Query.Enabled = false;
                btni_Insert.Enabled = false;
                btni_Save.Enabled = true;
                btni_Cancel.Enabled = true;
                btni_Modify.Enabled = false;
                btni_Delete.Enabled = false;
            }
        }
        void Setcb_WorkTypes(List<PTypesWork> list)
        {
            if (list.Count > 0)
            {
                List<string> strlist = new List<string>();
                for (int i = 0; i < list.Count; i++)
                {
                    strlist.Add(list[i].TypesWork);
                }
                cb_WorkTypes.DataSource = strlist;
            }
        }

        void Setcb_CompanyName(List<PWorkSchedule> list)
        {

            if (list.Count > 0)
            {
                List<string> strlist = new List<string>();
                foreach (var item in list)
                {
                    strlist.Add(item.CompanyName);
                }
                cb_CompanyName.DataSource = strlist;
            }
        }
        /// <summary>
        /// 清空输入控件
        /// </summary>
        void ClearControls()
        {
            txt_Name.Text = "";
            txt_WorkNumber.Text = "";
            cb_Gender.Text = "";
            cb_Levels.Text = "";
            cb_WorkTypes.Text = "";
            cb_CompanyName.Text = "";

            Inpu_Age.Text = "";
            dt_FactoryTime.Text = "";

            List<PStaffResume> list=new List<PStaffResume>();
            dataGridViewX1.DataSource = list;
        }
        private void btni_Insert_Click(object sender, EventArgs e)
        {
            if (!(UsersHelp.systemAdimin || UsersHelp.StaffResume_New))
            {
                MessageBox.Show("抱歉，您没有使用该功能的权限");
                return;
            }
            
            state = "insert";
            clear1 = true;//标志是否可以清空查询条件 
            this.ClearControls();

            this.UpdateControl();
        }

        private void btni_Cancel_Click(object sender, EventArgs e)
        {
            state = "browse";

            dataGridViewX1.DataSource = DataList;
            this.UpdateControl();
        }

        private void btni_Modify_Click(object sender, EventArgs e)
        {
            if (!(UsersHelp.systemAdimin || UsersHelp.StaffResume_Modify))
            {
                MessageBox.Show("抱歉，您没有使用该功能的权限");
                return;
            }
            
            state = "modify";

            this.UpdateControl();
        }
        /// <summary>
        /// 选中一行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewX1_SelectionChanged(object sender, EventArgs e)
        {
            this.dataGridViewX1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (DataList.Count > 0 && !clear1)
            {
                if (!(dataGridViewX1.CurrentRow.Index > DataList.Count))
                {
                    List<PStaffResume> list = new List<PStaffResume>();
                    list.Add(DataList[dataGridViewX1.CurrentRow.Index]);
                    this.SetContorlsInput(list);
                }
            }
            clear1 = false;
        }

        private void btni_Query_Click(object sender, EventArgs e)
        {
            DataList.Clear();

            List<PStaffResume> listinsert = new List<PStaffResume>();
            listinsert.Add(new PStaffResume()
            {
                Name = txt_Name.Text.Trim(),
                WorkNumber = txt_WorkNumber.Text.Trim(),
                Gender = cb_Gender.Text.Trim(),
                Age = Inpu_Age.Text.Trim(),
                WorkTypes = cb_WorkTypes.Text.Trim(),
                Levels = cb_Levels.Text.Trim(),
                FactoryTime = dt_FactoryTime.Value,
                CompanyName = cb_CompanyName.Text.Trim()
            });
            gce.Setlb_QueryState("正在查询...");
            if (th != null)
            {
                th.Abort();
            }

            th = new Thread(delegate()
            {
                Query1(listinsert);
            });
            th.IsBackground = true;
            th.Start();
        }

        void Query1(List<PStaffResume> list)
        {
            PStaffResumeBll pstaff = new PStaffResumeBll();

            m_SyncContext.Post(Query1SetGridview, pstaff.selectPStaffResumeBll(list, "selectPStaffResume"));

        }

        void Query1SetGridview(object o)
        {
            DataList = o as List<PStaffResume>;

            dataGridViewX1.DataSource = DataList;

            dataGridViewX1.Refresh();
            gce.Setlb_QueryState("完成");
        }

        private void btni_Save_Click(object sender, EventArgs e)
        {
            gce.Setlb_QueryState("正在保存...");
            if (state == "insert")
            {
                this.MessageUI();
                if (!psrb.checkedPStaffResumeBll(txt_Name.Text.Trim(), txt_WorkNumber.Text.Trim(), "checkedPStaffResume"))
                {
                    List<PStaffResume> listinsert = new List<PStaffResume>();
                    listinsert.Add(new PStaffResume(){
                        Name=txt_Name.Text.Trim(),
                        WorkNumber=txt_WorkNumber.Text.Trim(),
                        Gender=cb_Gender.Text.Trim(),
                        Age=Inpu_Age.Text.Trim(),
                        WorkTypes=cb_WorkTypes.Text.Trim(),
                        Levels=cb_Levels.Text.Trim(),
                        FactoryTime=dt_FactoryTime.Value,
                        CompanyName=cb_CompanyName.Text.Trim()
                    });
                    if (!psrb.insertPStaffResumeBll(listinsert, "insertPStaffResume"))
                    {
                        gce.Setlb_QueryState("保存失败!或已存在该员工信息");
                        return;
                    }
                    this.SetDatagridviewDataS(listinsert);
                    state = "browse";
                    this.UpdateControl();
                    gce.Setlb_QueryState("保存成功");
                }
                else
                {
                    MessageBox.Show("该员工姓名与工号已存在！");
                    return;
                }

            }
            if (state == "modify")
            { 
                this.MessageUI();

                List<PStaffResume> listOldData = new List<PStaffResume>();
                listOldData.Add(DataList[dataGridViewX1.CurrentRow.Index]);

                if (psrb.checkedPStaffResumeBll(listOldData[0].Name, listOldData[0].WorkNumber, "checkedPStaffResume"))
                {
                    List<PStaffResume> listmodify = new List<PStaffResume>();
                    listmodify.Add(new PStaffResume()
                    {
                        Name = txt_Name.Text.Trim(),
                        WorkNumber = txt_WorkNumber.Text.Trim(),
                        Gender = cb_Gender.Text.Trim(),
                        Age = Inpu_Age.Text.Trim(),
                        WorkTypes = cb_WorkTypes.Text.Trim(),
                        Levels = cb_Levels.Text.Trim(),
                        FactoryTime = dt_FactoryTime.Value,
                        CompanyName = cb_CompanyName.Text.Trim()
                    });

                    if (!psrb.updatePStaffResumeBll(listOldData[0].Name, listOldData[0].WorkNumber, listmodify, "updatePStaffResume"))
                    {
                        gce.Setlb_QueryState("保存失败!或已存在该员工信息");
                        return;
                    }
                    this.SetDatagridviewDataS(listmodify);
                    state = "browse";
                    this.UpdateControl();
                    gce.Setlb_QueryState("保存成功");
                }
                else
                {
                    MessageBox.Show("该员工姓名与工号不存在！");
                    return;
                }
            }
        }

        void MessageUI()
        {
            if (txt_Name.Text == "")
            {
                MessageBox.Show("姓名不能为空！");
                return;
            }
            if (txt_WorkNumber.Text == "")
            {
                MessageBox.Show("工号不能为空！");
                return;
            }
            if (cb_Gender.Text == "")
            {
                MessageBox.Show("性别不能为空！");
                return;
            }
            if (Inpu_Age.Text == "")
            {
                MessageBox.Show("年龄不能为空！");
                return;
            }
            if (cb_WorkTypes.Text == "")
            {
                MessageBox.Show("工作种类不能为空！");
                return;
            }
            if (cb_Gender.Text == "")
            {
                MessageBox.Show("级别不能为空！");
                return;
            }

            if (dt_FactoryTime.Text == "")
            {
                MessageBox.Show("入厂时间不能为空！");
                return;
            }
        }

        void SetDatagridviewDataS(List<PStaffResume> list)
        {
            if (state == "insert")
            {
                DataList = list;
                dataGridViewX1.DataSource = DataList;
                dataGridViewX1.Refresh();
            }
            else if (state == "modify")
            {
                DataList[dataGridViewX1.CurrentRow.Index] = list[0];
                dataGridViewX1.DataSource = DataList;
                dataGridViewX1.Refresh();
            }
        }

        private void cb_Gender_TextChanged(object sender, EventArgs e)
        {
            if (cb_Gender.Text != "男" && cb_Gender.Text != "女")
            {
                cb_Gender.Text = "";
            }
        }

        private void dataGridViewX1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(this.dataGridViewX1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, CultureInfo.CurrentUICulture),
                e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            }
        }
        /// <summary>
        /// 给输入控件赋值
        /// </summary>
        /// <param name="list"></param>
        void SetContorlsInput(List<PStaffResume> list)
        {
            if (list.Count > 0)
            {
                txt_Name.Text = list[0].Name;
                txt_WorkNumber.Text = list[0].WorkNumber;
                cb_Gender.Text = list[0].Gender.Trim();
                cb_Levels.Text = list[0].Levels;
                cb_WorkTypes.Text = list[0].WorkTypes;
                cb_CompanyName.Text = list[0].CompanyName;

                Inpu_Age.Text = list[0].Age;
                dt_FactoryTime.Value = list[0].FactoryTime;

            }
        }

        private void btni_Delete_Click(object sender, EventArgs e)
        {
            if (!(UsersHelp.systemAdimin || UsersHelp.StaffResume_Delete))
            {
                MessageBox.Show("抱歉，您没有使用该功能的权限");
                return;
            }
            
            if (MessageBox.Show("确定删除该员工信息？", "系统提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                gce.Setlb_QueryState("正在删除...");
                List<PStaffResume> listOldData = new List<PStaffResume>();
                listOldData.Add(DataList[dataGridViewX1.CurrentRow.Index]);
                //int i = dataGridViewX1.CurrentRow.Index;
                if (psrb.deletePStaffResumeBll(listOldData[0].Name, listOldData[0].WorkNumber, "deletePStaffResume"))
                {
                    clear1 = true;//标志是否可以清空查询条件 
                    listOldData.Clear();
                    foreach (PStaffResume item in DataList)
                    {
                        if (item.WorkNumber != DataList[dataGridViewX1.CurrentRow.Index].WorkNumber)
                        {
                            listOldData.Add(item);
                        }
                    }

                    gce.Setlb_QueryState("删除成功");
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

        private void btni_Clear_Click(object sender, EventArgs e)
        {
            clear1 = true;
            this.ClearControls();
        }

        private void EmployeeExperience_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (th != null)
            {
                th.Abort();
            }
        }

        private void EmployeeExperience_FormClosing(object sender, FormClosingEventArgs e)
        {
            gce.lb_QueryStateVisible();
        }

        private void btni_WorkType_Click(object sender, EventArgs e)
        {
            if(!(UsersHelp.systemAdimin||UsersHelp.StaffResume_Job_allocation))
            {
                MessageBox.Show("抱歉，您没有使用该功能的权限");
                return;
            }
            
            TypesWorkform tw = new TypesWorkform();
            tw.ShowDialog();
        }

        private void btni_Outdata_Click(object sender, EventArgs e)
        {
            if (!(UsersHelp.systemAdimin || UsersHelp.StaffResume_DataOut))
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

        private void txt_Name_ButtonCustomClick(object sender, EventArgs e)
        {

            List<string> strlist = new List<string>();
            strlist.Add("姓名");
            strlist.Add("工号");
            if (QueryList.Count > 0)
            {
                ConditionsQuery cq = new ConditionsQuery("姓名工号查询", strlist, QueryList, this);
                cq.ShowDialog();
            }
            else
            {
                QueryList = psrb.selectConditionsQueryPStaffResumeBll("selectConditionsQueryPStaffResume");
                ConditionsQuery cq = new ConditionsQuery("姓名工号查询", strlist, QueryList, this);
                cq.ShowDialog();
            }
        }

        public void SetNameAndWorkNumber(List<selectConditionsQueryPStaffResumeModel> list)
        {
            txt_Name.Text = list[0].Name;
            txt_WorkNumber.Text = list[0].WorkNumber;
        }
    }
}
