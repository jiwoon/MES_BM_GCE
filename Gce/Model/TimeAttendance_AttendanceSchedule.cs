using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gce_Model
{
    public class TimeAttendance_AttendanceSchedule
    {
        /// <summary>
        /// 工号
        /// </summary>
        public string JobNumber { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 考勤时间
        /// </summary>
        public DateTime AttendanceTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 机器编号
        /// </summary>
        public string MachineID { get; set; }
        /// <summary>
        /// 机器位置
        /// </summary>
        public string MachinePosition { get; set; }
    }
}
