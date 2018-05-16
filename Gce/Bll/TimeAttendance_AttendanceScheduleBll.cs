using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gce_Dal;
using Gce_Model;

namespace Gce_Bll
{
    public class TimeAttendance_AttendanceScheduleBll
    {
        TimeAttendance_AttendanceScheduleDal tasDal = new TimeAttendance_AttendanceScheduleDal();
        /// <summary>
        /// 增加、修改
        /// </summary>
        /// <param name="data"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool insertTimeAttendance_AttendanceScheduleBll(TimeAttendance_AttendanceSchedule data, string SQLCommand)
        {
            if (tasDal.insertTimeAttendance_AttendanceScheduleDal(data, SQLCommand) > 0)
                return true;
            else return false;
        }
    }
}
