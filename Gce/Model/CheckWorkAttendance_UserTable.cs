using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gce_Model
{
    public class CheckWorkAttendance_UserTable
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set;}
        /// <summary>
        /// 机器码
        /// </summary>
        public string iMachineNumber { get; set; }
        /// <summary>
        /// 查询时间
        /// </summary>
        public string InputDate { get; set; }
        /// <summary>
        /// 签到时间
        /// </summary>
        public string workDates { get; set; }
    }
}
