using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gce.Class;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Rendering;
using Gce.Windows;
using Gce.pop_upWindows;
using Gce_Common;
using Gce.MoreDocumentsWindows;

namespace Gce
{
    public partial class Gce : Office2007Form
    {
        FormAdaptive Fad = new FormAdaptive();

        private Dictionary<string, string> tablItemDit = new Dictionary<string, string>();
        public Gce()
        {
            InitializeComponent();
        }

        private void Gce_Load(object sender, EventArgs e)
        {
            this.SetForm();
        }

        void SetForm()
        {
            formDepot.Gce = this;
            //formDepot.productionEfficiency = new productionEfficiency(this);
        }
        public void Setbar_txtb_user(string username)
        {
            this.bar_txtb_user.Text = username;
            bar_txtb_user.Refresh();//刷新控件
        }

        private void Gce_SizeChanged(object sender, EventArgs e)
        {
            //Fad.controlAutoSize(this);
        }

        /// <summary>
        /// 多文档实现
        /// </summary>
        /// <param name="caption">窗体名称</param>
        /// <param name="formType">窗体类型</param>
        public void SetMdiForm(string caption,Type formType)
        {
            bool IsOpened = false;
            //
            foreach (SuperTabItem tabitem in superTabControl1.Tabs)
            {
                if (tabitem.Name == caption)
                {
                    superTabControl1.SelectedTab = tabitem;
                    IsOpened = true;
                    break;
                }
            }
            //
            if (!IsOpened)
            {
                Office2007Form form = ChildWinManagement.LoadMdiForm(this, formType)
                    as Office2007Form;

                SuperTabItem tabitem = superTabControl1.CreateTab(caption);
                tabitem.Name = caption;
                tabitem.Text = caption;

                form.FormBorderStyle = FormBorderStyle.None;
                form.TopLevel = false;
                form.Visible = true;
                form.Dock = DockStyle.Fill;
                
                tabitem.AttachedControl.Controls.Add(form);

                superTabControl1.SelectedTab = tabitem;

                if (!tablItemDit.ContainsKey(tabitem.Text))
                {
                    tablItemDit.Add(tabitem.Text, form.Name);
                }

            }
        }
        private void btn_LeviteOrder_Click(object sender, EventArgs e)
        {
            if (!(UsersHelp.systemAdimin || UsersHelp.LeviteOrder))
            {
                MessageBox.Show("抱歉，您没有访问此功能的权限");
                return;
            }

            ProcurementOrder lo = new ProcurementOrder(this);
            lo.MdiParent = this;
            SetMdiForm(lo.Text, typeof(ProcurementOrder));
        }

        private void ScanQrCode_Click(object sender, EventArgs e)
        {
            if (!(UsersHelp.systemAdimin || UsersHelp.ScanQrCode))
            {
                MessageBox.Show("抱歉，您没有访问此功能的权限");
                return;
            }

            QrCodeScanning qcs = new QrCodeScanning(this);
            qcs.MdiParent = this;
            SetMdiForm(qcs.Text,typeof(QrCodeScanning));
        }

        private void btn_IncomingInspection_Click(object sender, EventArgs e)
        {
            if (!(UsersHelp.systemAdimin || UsersHelp.IncomingInspection))
            {
                MessageBox.Show("抱歉，您没有访问此功能的权限");
                return;
            }
            
            IncomingInspection iip = new IncomingInspection(this);
            iip.MdiParent = this;
            SetMdiForm(iip.Text,typeof(IncomingInspection));
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (!(UsersHelp.systemAdimin || UsersHelp.Production_efficiency_management))
            {
                MessageBox.Show("抱歉，您没有访问此功能的权限");
                return;
            }
            
            productionEfficiency pe = new productionEfficiency(this);
            pe.MdiParent = this;
            SetMdiForm(pe.Text,pe.GetType());
        }

        private void 登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login lg = new Login(this);
            lg.ShowDialog();
        }
        public void Setlb_QueryState(string str)
        {
            lb_QueryState.Text = str;
            lb_QueryState.Visible = true;
            lb_QueryState.ForeColor = Color.White;
            metroStatusBar1.Refresh();//刷新控件
        }
        public void lb_QueryStateVisible()
        {
            lb_QueryState.Text = "";
            lb_QueryState.Visible = false;
            metroStatusBar1.Refresh();//刷新控件
        }

        private void superTabControl1_TabItemClose(object sender, SuperTabStripTabItemCloseEventArgs e)
        {
            string selectedTab = e.Tab.Text;//获取当前TabItem的显示文本

            string controlName = null;

            tablItemDit.TryGetValue(selectedTab, out controlName);//获取当前TabItem中内嵌的Form的Name属性值

            Form frm = this.superTabControl1.Controls.Find(controlName, true)[0] as Form;//获取内嵌的Form对象

            frm.Close(); //调用form的close事件，即触发了内嵌窗体的关闭事件
        }

        private void Gce_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("是否退出系统？", "系统提示", MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void 添加用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(UsersHelp.systemAdimin || UsersHelp.AddUser))
            {
                MessageBox.Show("抱歉，您没有添加用户的权限");
                return;
            }
            AddUser au = new AddUser();
            au.ShowDialog();
        }

        private void 系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UsersHelp.checkLogin)
            {
                添加用户ToolStripMenuItem.Enabled = true;
                修改密码ToolStripMenuItem.Enabled = true;
                注销用户ToolStripMenuItem.Enabled = true;
                登录ToolStripMenuItem.Text = "切换用户";
            }
            else
            {
                添加用户ToolStripMenuItem.Enabled = false;
                修改密码ToolStripMenuItem.Enabled = false;
                注销用户ToolStripMenuItem.Enabled = false;
                登录ToolStripMenuItem.Text = "登录";
            }
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdatePassword up = new UpdatePassword();
            up.ShowDialog();
        }

        private void 注销用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsersHelp.Userslist.Clear();
            UsersHelp.checkLogin = false;
            this.bar_txtb_user.Text = "";

            //foreach (SuperTabItem tabitem in superTabControl1.Tabs)
            //{
            //    if (tabitem.Name != "主界面")
            //    {
            //        tabitem.Close();                   
            //    }
            //}
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 系统ToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            if (UsersHelp.checkLogin)
            {
                添加用户ToolStripMenuItem.Enabled = true;
                修改密码ToolStripMenuItem.Enabled = true;
                注销用户ToolStripMenuItem.Enabled = true;
                登录ToolStripMenuItem.Text = "切换用户";
            }
            else
            {
                添加用户ToolStripMenuItem.Enabled = false;
                修改密码ToolStripMenuItem.Enabled = false;
                注销用户ToolStripMenuItem.Enabled = false;
                登录ToolStripMenuItem.Text = "登录";
            }
        }
        private void btn_Dayparting_Click(object sender, EventArgs e)
        {
            if (!(UsersHelp.systemAdimin || UsersHelp.Dayparting))
            {
                MessageBox.Show("抱歉，您没有访问此功能的权限");
                return;
            }
            
            ProductionSplitTimeRecord psr = new ProductionSplitTimeRecord(this);
            psr.MdiParent = this;
            SetMdiForm(psr.Text, typeof(ProductionSplitTimeRecord));
        }

        public void Jump_productionEfficiency(DateTime BeginTime,DateTime EndTime)
        {

        }

        private void btn_StaffResume_Click(object sender, EventArgs e)
        {
            if (!(UsersHelp.systemAdimin || UsersHelp.StaffResume))
            {
                MessageBox.Show("抱歉，您没有访问此功能的权限");
                return;
            }

            EmployeeExperience eexper = new EmployeeExperience(this);
            eexper.MdiParent = this;
            SetMdiForm(eexper.Text, typeof(EmployeeExperience));
        }

        private void btn_abnormal_Click(object sender, EventArgs e)
        {
            if (!(UsersHelp.systemAdimin || UsersHelp.abnormal))
            {
                MessageBox.Show("抱歉，您没有访问此功能的权限");
                return;
            }

            AbnormalIputQury aq = new AbnormalIputQury(this);
            aq.MdiParent = this;
            SetMdiForm(aq.Text, typeof(AbnormalIputQury));
        }

        private void tabItem1_MouseEnter(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = tabItem1;
        }

        private void tabItem2_MouseEnter(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = tabItem2;
        }

        private void tabItem3_MouseEnter(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = tabItem3;
        }

        private void tabItem4_MouseEnter(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = tabItem4;
        }

        private void btn_PMCplan_Click(object sender, EventArgs e)
        {
            if (!(UsersHelp.systemAdimin || UsersHelp.PMCplan))
            {
                MessageBox.Show("抱歉，您没有访问此功能的权限");
                return;
            }
            
            PMCplan pmcplan = new PMCplan(this);
            pmcplan.MdiParent = this;
            SetMdiForm(pmcplan.Text, typeof(PMCplan));
        }

        private void 权限管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(UsersHelp.systemAdimin || UsersHelp.Limite))
            {
                MessageBox.Show("抱歉，您没有访问此功能的权限");
                return;
            }

            PrivilegeManagement pm = new PrivilegeManagement();
            pm.ShowDialog();
        }
        /// <summary>
        /// 财务录入ERP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_FinancialInputERP_Click(object sender, EventArgs e)
        {
            FinancialInputERP ferp = new FinancialInputERP(this);
            ferp.MdiParent = this;
            SetMdiForm(ferp.Text, typeof(FinancialInputERP));
        }

        private void btn_IncomingExamine_Click(object sender, EventArgs e)
        {
            IncomingAudit Inca = new IncomingAudit(this);
            Inca.MdiParent = this;
            SetMdiForm(Inca.Text, typeof(IncomingAudit));
        }

        private void btn_Choose_Click(object sender, EventArgs e)
        {
            Choose choo = new Choose(this);
            choo.MdiParent = this;
            SetMdiForm(choo.Text, typeof(Choose));
        }

        private void btn_IncomingWarehousing_Click(object sender, EventArgs e)
        {
            IncomingWarehousing Iware = new IncomingWarehousing(this);
            Iware.MdiParent = this;
            SetMdiForm(Iware.Text, typeof(IncomingWarehousing));
        }

        private void btn_ReturnGoods_Click(object sender, EventArgs e)
        {
            ReturnGoods returnGoods = new ReturnGoods(this);
            returnGoods.MdiParent = this;
            SetMdiForm(returnGoods.Text, typeof(ReturnGoods));
        }

        private void btn_PickingOut_Click(object sender, EventArgs e)
        {
            PickingOut picking = new PickingOut(this);
            picking.MdiParent = this;
            SetMdiForm(picking.Text, typeof(PickingOut));
        }

        private void btn_CheckQuery_Click(object sender, EventArgs e)
        {

            CheckQuery cq = new CheckQuery(this);
            cq.MdiParent = this;
            SetMdiForm(cq.Text, typeof(CheckQuery));
        }

        private void 人事管理界面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckWorkAttendance cwa = new CheckWorkAttendance(this);
            cwa.MdiParent = this;
            SetMdiForm(cwa.Text, typeof(CheckWorkAttendance));
        }

        public void ShowSectorStructure_form()
        {
            SectorStructure_form cwa = new SectorStructure_form(this);
            cwa.MdiParent = this;
            SetMdiForm(cwa.Text, typeof(SectorStructure_form));
        }

        private void tabItem5_MouseEnter(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = tabItem5;
        }

        public void ShowEmployee_file()
        {
            Employee_file ef = new Employee_file(this);
            ef.MdiParent = this;
            SetMdiForm(ef.Text, typeof(Employee_file));
        }

        public void showAttendanceMachine()
        {
            AttendanceMachine am = new AttendanceMachine(this);
            am.MdiParent = this;
            SetMdiForm(am.Text, typeof(AttendanceMachine));
        }

        public void showDailyAttendance()
        {
            DailyAttendance am = new DailyAttendance();
            am.MdiParent = this;
            SetMdiForm(am.Text, typeof(DailyAttendance));
        }
    }
}
