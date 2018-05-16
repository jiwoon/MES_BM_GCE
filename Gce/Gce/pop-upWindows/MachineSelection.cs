using DevComponents.DotNetBar;
using Gce_Bll;
using Gce_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gce.pop_upWindows
{
    public partial class MachineSelection : Office2007Form
    {

        public zkemkeeper.CZKEMClass axCZKEM1 = new zkemkeeper.CZKEMClass();
        TimeAttendance_AttendanceInformation_machineBll taiBll = new TimeAttendance_AttendanceInformation_machineBll();
        List<TimeAttendance_AttendanceInformation_machine> dataList = new List<TimeAttendance_AttendanceInformation_machine>();
        List<TimeAttendance_AttendanceInformation_machine> dataList2 = new List<TimeAttendance_AttendanceInformation_machine>();
        List<MachineSelectionModel> machList;

        string FormText = "";
        public MachineSelection()
        {
            InitializeComponent();
        }

        public MachineSelection(string formtext, List<MachineSelectionModel> machlist)
        {
            InitializeComponent();
            this.FormText = formtext;
            this.machList = machlist;
        }

        private void MachineSelection_Load(object sender, EventArgs e)
        {
            this.Text = FormText;
            this.GetData();
        }

        void GetData()
        {
            dataList = taiBll.selectTimeAttendance_AttendanceInformation_machineBll("selectTimeAttendance_AttendanceInformation_machine");

            if (dataList.Count <= 0)
            {
                return;
            }
            int point = 6;
            for (int i = 0; i < dataList.Count; i++)
            {
                point += 36;
                CheckBox cb = new CheckBox();
                cb.Text = dataList[i].MachinePosition;
                cb.Name = "cb"+i.ToString();
                cb.Tag = i;
                cb.Checked = true;
                cb.Location = new Point(20, point);

                panelEx2.Controls.Add(cb);
            }
        }

        private void btn_Concle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            dataList2.Clear();

            foreach (CheckBox item in panelEx2.Controls)
            {
                if (item.Checked)
                {
                    dataList2.Add(dataList[Convert.ToInt32(item.Tag)]);
                }
            }

            if (dataList2.Count > 0)
            {
                if (FormText == "清卡")
                {
                    foreach (TimeAttendance_AttendanceInformation_machine item in dataList2)
                    {
                        if (axCZKEM1.Connect_Net(item.IPAddress, 4370))
                        {

                            if (axCZKEM1.SSR_DeleteEnrollDataExt(Convert.ToInt32(item.MachineID), machList[0].LogicalCardNumber, 12))//0005903520//清卡
                            {
                                //MessageBox.Show("清卡成功");
                            }
                            else MessageBox.Show("{0}考勤机清卡失败", item.MachinePosition);
                        }
                        else MessageBox.Show("{0}考勤机连接异常", item.MachinePosition);
                    }

                }
                else if (FormText == "发卡")
                {
                    foreach (TimeAttendance_AttendanceInformation_machine item in dataList2)
                    {
                        if (axCZKEM1.Connect_Net(item.IPAddress, 4370))
                        {

                            if (axCZKEM1.SetStrCardNumber(machList[0].PhysicalCardNumber))//0005903520//发卡
                            {
                                if (axCZKEM1.SSR_SetUserInfo(Convert.ToInt32(item.MachineID), machList[0].LogicalCardNumber, machList[0].ChineseName, "", 0, true))
                                {
                                    //MessageBox.Show("发卡成功");
                                }
                                else MessageBox.Show("{0}考勤机发卡失败", item.MachinePosition);
                            }
                        }
                        else MessageBox.Show("{0}考勤机连接异常",item.MachinePosition);
                    }
                }
            }
            
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (buttonX1.Text == "全不选")
            {
                foreach (CheckBox item in panelEx2.Controls)
                {
                    item.Checked = false;
                }
                buttonX1.Text = "全选";
            }
            else
            {
                foreach (CheckBox item in panelEx2.Controls)
                {
                    item.Checked = true;
                }
                buttonX1.Text = "全不选";
            }
        }
    }
}
