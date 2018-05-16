using Gce_Dal;
using Gce_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gce_Bll
{
    public class TimeAttendance_AttendanceInformation_machineBll
    {
        TimeAttendance_AttendanceInformation_machineDal taid = new TimeAttendance_AttendanceInformation_machineDal();
        /// <summary>
        /// 新增 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool insertTimeAttendance_AttendanceInformation_machineBll(TimeAttendance_AttendanceInformation_machine data, string SQLCommand)
        {
            if (taid.insertTimeAttendance_AttendanceInformation_machineDal(data, SQLCommand) > 0)
                return true;
            else return false;
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<TimeAttendance_AttendanceInformation_machine> selectTimeAttendance_AttendanceInformation_machineBll(string SQLCommand)
        {
            return taid.selectTimeAttendance_AttendanceInformation_machineDal(SQLCommand); ;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="MachineID"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool deleteTimeAttendance_AttendanceInformation_machineBll(string MachineID, string SQLCommand)
        {
            if (taid.deleteTimeAttendance_AttendanceInformation_machineDal(MachineID, SQLCommand) > 0)
                return true;
            else return false;
        }
    }
}
