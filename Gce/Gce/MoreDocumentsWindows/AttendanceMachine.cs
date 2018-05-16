using DevComponents.DotNetBar;
using Gce_Bll;
using Gce_Common;
using Gce_Model;
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
using zkemkeeper;

namespace Gce.MoreDocumentsWindows
{
    public partial class AttendanceMachine : Office2007Form
    {
        SynchronizationContext My_context = null;

        Gce G;

        public zkemkeeper.CZKEMClass axCZKEM1 = new zkemkeeper.CZKEMClass();

        TimeAttendance_AttendanceInformation_machineBll taiBll = new TimeAttendance_AttendanceInformation_machineBll();
        TimeAttendance_AttendanceScheduleBll tasBll = new TimeAttendance_AttendanceScheduleBll();
        List<TimeAttendance_AttendanceInformation_machine> dataList = new List<TimeAttendance_AttendanceInformation_machine>();

        string state = "browse";

        bool Insertbool = false;
        public AttendanceMachine()
        {
            InitializeComponent();
        }

        public AttendanceMachine(Gce g)
        {
            InitializeComponent();
            this.G = g;
        }

        private void btn_TestConnection_Click(object sender, EventArgs e)
        {
            if (axCZKEM1.Connect_Net(txt_IPAddress.Text.Trim(), 4370))
            {
                MessageBox.Show("连接成功");
            }
            else MessageBox.Show("连接失败");
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (txt_MachineCoding.Text.Trim() == "") return;

            if (axCZKEM1.Connect_Net(txt_IPAddress.Text.Trim(), 4370))
            {
                if (axCZKEM1.SetDeviceTime(Convert.ToInt32(txt_MachineCoding.Text.Trim())))
                {
                    MessageBox.Show("校验成功");
                }
                else MessageBox.Show("校验失败");
            }            
        }

        private void btni_edit_Click(object sender, EventArgs e)
        {
            if (txt_MachineCoding.Text.Trim() == "")
            {
                MessageBox.Show("编辑时机器编码不能为空！");
                return;
            }

            state = "modify";

            updateCotrls();
        }

        bool Message1()
        {
            if (txt_MachineCoding.Text == "")
            {
                MessageBox.Show("机器编码不能为空！");
                return true;
            }
            else if (txt_IPAddress.Text == "")
            {
                MessageBox.Show("IP地址不能为空！");
                return true;
            }
            else if (com_machine.Text == "")
            {
                MessageBox.Show("机器位置不能为空！");
                return true;
            }
            else if (com_MachineUse.Text == "")
            {
                MessageBox.Show("机器用途不能为空！");
                return true;
            }
            else return false;
        }

        TimeAttendance_AttendanceInformation_machine GetTimeAttendance_AttendanceInformation_machine()
        {
            TimeAttendance_AttendanceInformation_machine tai = new TimeAttendance_AttendanceInformation_machine()
            {
                MachineID=txt_MachineCoding.Text.Trim(),
                BaudRate=txt_BaudRate.Text.Trim(),
                IPAddress=txt_IPAddress.Text.Trim(),
                ComInterface=com_COMmouth.Text.Trim(),
                MachinePosition=com_machine.Text.Trim(),
                MachineUse=com_MachineUse.Text.Trim()
            };

            return tai;
        }

        private void btni_save_Click(object sender, EventArgs e)
        {
            
            if (state == "insert")
            {
                G.Setlb_QueryState("正在保存...");
                if (Message1()) return;

                if (taiBll.insertTimeAttendance_AttendanceInformation_machineBll(GetTimeAttendance_AttendanceInformation_machine(), "insertTimeAttendance_AttendanceInformation_machine"))
                {
                    SetDataGridView();
                    state = "browse";

                    updateCotrls();
                    G.Setlb_QueryState("完成");
                }
            }
            else if (state == "modify")
            {
                G.Setlb_QueryState("正在保存...");
                if (Message1()) return;

                if (taiBll.insertTimeAttendance_AttendanceInformation_machineBll(GetTimeAttendance_AttendanceInformation_machine(), "updateTimeAttendance_AttendanceInformation_machine"))
                {
                    SetDataGridView();
                    state = "browse";

                    updateCotrls();
                    G.Setlb_QueryState("完成");
                }
            }
        }

        void SetDataGridView()
        {
            dataGridViewX1.DataSource = new List<TimeAttendance_AttendanceInformation_machine>();

            dataList = taiBll.selectTimeAttendance_AttendanceInformation_machineBll("selectTimeAttendance_AttendanceInformation_machine");

            dataGridViewX1.DataSource = dataList;
        }

        private void btni_cancle_Click(object sender, EventArgs e)
        {
            state = "browse";

            updateCotrls();
        }

        private void btni_delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否删除？", "系统提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                G.Setlb_QueryState("正在删除...");
                try
                {
                    if (taiBll.deleteTimeAttendance_AttendanceInformation_machineBll(dataList[dataGridViewX1.CurrentRow.Index].MachineID, "deleteTimeAttendance_AttendanceInformation_machine"))
                    {
                        G.Setlb_QueryState("完成");
                    }
                    else MessageBox.Show("删除失败");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btni_NewMachine_Click(object sender, EventArgs e)
        {
            state = "insert";

            Insertbool = true;

            clearControls();

            updateCotrls();
        }

        void clearControls()
        {
            txt_MachineCoding.Text = "";
            txt_IPAddress.Text = "";
            txt_BaudRate.Text = "";
            com_COMmouth.Text = "";
            com_machine.Text = "";
            com_MachineUse.Text = "";
        }

        void updateCotrls()
        {
            if (state == "browse")
            {

                btni_save.Enabled = false;
                btni_cancle.Enabled = false;
                btni_delete.Enabled = true;
                btni_edit.Enabled = true;

                btni_DataInput.Enabled = true;
                btni_DataOut.Enabled = true;
                btni_NewMachine.Enabled = true;

                txt_MachineCoding.Enabled = false;
                txt_IPAddress.Enabled = false;
                txt_BaudRate.Enabled = false;
                com_COMmouth.Enabled = false;
                com_machine.Enabled = false;
                com_MachineUse.Enabled = false;

                expandablePanel1.Enabled = true;
            }
            else if (state == "modify")
            {

                btni_save.Enabled = true;
                btni_cancle.Enabled = true;
                btni_delete.Enabled = false;
                btni_edit.Enabled = false;
                btni_NewMachine.Enabled = false;

                btni_DataInput.Enabled = false;
                btni_DataOut.Enabled = false;

                txt_MachineCoding.Enabled = true;
                txt_IPAddress.Enabled = true;
                txt_BaudRate.Enabled = true;
                com_COMmouth.Enabled = true;
                com_machine.Enabled = true;
                com_MachineUse.Enabled = true;

                expandablePanel1.Enabled = false;
            }
            else
            {

                btni_save.Enabled = true;
                btni_cancle.Enabled = true;
                btni_delete.Enabled = false;
                btni_edit.Enabled = false;
                btni_NewMachine.Enabled = false;

                btni_DataInput.Enabled = false;
                btni_DataOut.Enabled = false;

                txt_MachineCoding.Enabled = true;
                txt_IPAddress.Enabled = true;
                txt_BaudRate.Enabled = true;
                com_COMmouth.Enabled = true;
                com_machine.Enabled = true;
                com_MachineUse.Enabled = true;

                expandablePanel1.Enabled = false;
            }
        }

        private void AttendanceMachine_Load(object sender, EventArgs e)
        {
            My_context = SynchronizationContext.Current;
            updateCotrls();
            Loead();
            SetDataGridView();
        }

        private void btn_ChangeMachineCoding_Click(object sender, EventArgs e)
        {
            if (txt_MachineCoding.Text.Trim()=="")
            {
                MessageBox.Show("机器编码不能为空");
            }

            axCZKEM1.MachineNumber = Convert.ToInt32(txt_MachineCoding.Text.Trim());
            MessageBox.Show("OK");
        }

        void Loead()
        {
            DataGridViewTextBoxColumn newcol = new DataGridViewTextBoxColumn();
            newcol.HeaderText = "机器编号";
            newcol.Name = "MachineID";
            newcol.DataPropertyName = "MachineID";
            newcol.Width = 150;
            newcol.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol.Tag = 0;
            this.dataGridViewX1.Columns.Insert(0, newcol);

            DataGridViewTextBoxColumn newcol1 = new DataGridViewTextBoxColumn();
            newcol1.HeaderText = "COM口";
            newcol1.Name = "ComInterface";
            newcol1.DataPropertyName = "ComInterface";
            newcol1.Width = 120;
            newcol1.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol1.Tag = 1;
            this.dataGridViewX1.Columns.Insert(1, newcol1);

            DataGridViewTextBoxColumn newcol2 = new DataGridViewTextBoxColumn();
            newcol2.HeaderText = "波特率";
            newcol2.Name = "BaudRate";
            newcol2.DataPropertyName = "BaudRate";
            newcol2.Width = 120;
            newcol2.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol2.Tag = 2;
            this.dataGridViewX1.Columns.Insert(2, newcol2);


            DataGridViewTextBoxColumn newcol3 = new DataGridViewTextBoxColumn();
            newcol3.HeaderText = "IP地址";
            newcol3.Name = "IPAddress";
            newcol3.DataPropertyName = "IPAddress";
            newcol3.Width = 120;
            newcol3.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol3.Tag = 3;
            this.dataGridViewX1.Columns.Insert(3, newcol3);

            DataGridViewTextBoxColumn newcol4 = new DataGridViewTextBoxColumn();
            newcol4.HeaderText = "机器位置";
            newcol4.Name = "MachinePosition";
            newcol4.DataPropertyName = "MachinePosition";
            newcol4.Width = 120;
            newcol4.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol4.Tag = 4;
            this.dataGridViewX1.Columns.Insert(4, newcol4);

            DataGridViewTextBoxColumn newcol5 = new DataGridViewTextBoxColumn();
            newcol5.HeaderText = "机器用途";
            newcol5.Name = "MachineUse";
            newcol5.DataPropertyName = "MachineUse";
            newcol5.Width = 120;
            newcol5.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol5.Tag = 5;
            this.dataGridViewX1.Columns.Insert(5, newcol5);

            DataGridViewTextBoxColumn newcol6 = new DataGridViewTextBoxColumn();
            newcol6.HeaderText = "";
            newcol6.Width = 120;
            newcol6.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            newcol6.Tag = 6;
            this.dataGridViewX1.Columns.Insert(6, newcol6);

        }

        private void dataGridViewX1_SelectionChanged(object sender, EventArgs e)
        {
            this.dataGridViewX1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if(!Insertbool)
            {
                SetDataGridView(dataList[dataGridViewX1.CurrentRow.Index]);
            }

            Insertbool = false;
        }

        void SetDataGridView(TimeAttendance_AttendanceInformation_machine data)
        {
            if (data == null) return;

            txt_MachineCoding.Text = data.MachineID;
            txt_IPAddress.Text = data.IPAddress;
            txt_BaudRate.Text = data.BaudRate;
            com_COMmouth.Text = data.ComInterface;
            com_machine.Text = data.MachinePosition;
            com_MachineUse.Text = data.MachineUse;
        }

        private void dataGridViewX1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(this.dataGridViewX1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, CultureInfo.CurrentUICulture),
                e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            }
        }

        private void btn_TestAllConnection_Click(object sender, EventArgs e)
        {
            checkAllConnect();
        }

        void checkAllConnect()
        {
            if (dataList.Count <= 0)
            {
                MessageBox.Show("没有可连接的机器");
                return;
            }

            foreach (TimeAttendance_AttendanceInformation_machine item in dataList)
            {
                if (!axCZKEM1.Connect_Net(item.IPAddress, 4370))
                {
                    MessageBox.Show("机器编号为：{0}连接失败", item.MachineID);
                }
            }
            MessageBox.Show("测试完成");
        }

        private void btn_InspectionAllTime_Click(object sender, EventArgs e)
        {
            InspectionAllTime();
        }

        void InspectionAllTime()
        {
            if (dataList.Count <= 0)
            {
                MessageBox.Show("没有可校正的机器");
                return;
            }
            foreach (TimeAttendance_AttendanceInformation_machine item in dataList)
            {
                if (axCZKEM1.Connect_Net(txt_IPAddress.Text.Trim(), 4370))
                {
                    if (!axCZKEM1.SetDeviceTime(Convert.ToInt32(txt_MachineCoding.Text.Trim())))
                    {
                        MessageBox.Show("机器编码为:{0}；校验失败", item.MachineID);
                    }
                }
                else
                {
                    MessageBox.Show("机器编码为:{0}；连接失败", item.MachineID);
                }
            }
            MessageBox.Show("校验完成");
        }

        private void btni_DataOut_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewX1.CurrentRow == null)
            {
                MessageBox.Show("没有可导出的数据!");
                return;
            }
            if (ExcelHelperForCs.ExportToExcel(dataGridViewX1) == null)
            {
                MessageBox.Show("导出完成");
            }
        }

        private void btn_AcceptedData_Click(object sender, EventArgs e)
        {
            G.Setlb_QueryState("正在获取...");
            Thread th = new Thread(delegate()
            {
                AcceptedData();
            });

            th.IsBackground = true;
            th.Start();


        }

        void AcceptedData()
        {
            if (dataList.Count <= 0)
            {
                MessageBox.Show("无获取数据的机器，请添加!");
                return;
            }

            List<TimeAttendance_AttendanceSchedule> list = new List<TimeAttendance_AttendanceSchedule>();

            foreach (TimeAttendance_AttendanceInformation_machine item in dataList)
            {
                if (axCZKEM1.Connect_Net(item.IPAddress, 4370))
                {
                    list.AddRange(AttendanceMachineHelp.GetUserData(axCZKEM1,item.MachineID,true,item.IPAddress,item.MachinePosition));
                }
                else MessageBox.Show("连接失败");
            }

            foreach (TimeAttendance_AttendanceSchedule item in list)
            {
                try
                {
                    tasBll.insertTimeAttendance_AttendanceScheduleBll(item, "insertTimeAttendance_AttendanceSchedule");
                }
                catch//(Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    continue;
                }
            }

            My_context.Post(Thread1,new object());

        }

        void Thread1(object o)
        {
            G.Setlb_QueryState("完成");
        }

        private void btn_ClearData_Click(object sender, EventArgs e)
        {
            if (dataList.Count <= 0)
            {
                MessageBox.Show("无获取数据的机器，请添加!");
                return;
            }

            TimeAttendance_AttendanceInformation_machine data = dataList[dataGridViewX1.CurrentRow.Index];

            if (data == null)
            {
                return;
            }
            if (axCZKEM1.Connect_Net(data.IPAddress, 4370))
            {
                if (MessageBox.Show("是否删除此机器内的考勤记录？", "系统提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    G.Setlb_QueryState("正在删除...");
                    if (axCZKEM1.ClearGLog(Convert.ToInt32(data.MachineID)))
                    {
                        G.Setlb_QueryState("完成");
                    }
                    else MessageBox.Show("删除失败");
                }
            }

            
        }
    }
}
