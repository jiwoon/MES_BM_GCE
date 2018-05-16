using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gce_Model
{
    public class TimeAttendance_AttendanceInformation_machine
    {
        /// <summary>
        /// 机器编码
        /// </summary>
        public string MachineID { get; set; }
        /// <summary>
        /// COM口
        /// </summary>
        public string ComInterface { get; set; }
        /// <summary>
        /// 波特率
        /// </summary>
        public string BaudRate { get; set; }
        /// <summary>
        /// IP地址
        /// </summary>
        public string IPAddress { get; set; }
        /// <summary>
        /// 机器位置
        /// </summary>
        public string MachinePosition { get; set; }
        /// <summary>
        /// 机器用途
        /// </summary>
        public string MachineUse { get; set; }
    }
}
