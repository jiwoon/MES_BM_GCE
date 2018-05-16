using Gce_Dal;
using Gce_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gce_Bll
{
    public class TimeAttendance_Employee_FileBll
    {
        TimeAttendance_Employee_FileDal TaefDal = new TimeAttendance_Employee_FileDal();

        public List<TimeAttendance_Employee_File> selectTimeAttendance_Employee_FileDepartmentNoBll(string MinimalSector, string SQLCommand)
        {
            return TaefDal.selectTimeAttendance_Employee_FileDepartmentNoDal(MinimalSector, SQLCommand);
        }
        /// <summary>
        /// 插入员工档案表
        /// </summary>
        /// <param name="data"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool insertTimeAttendance_Employee_FileBll(TimeAttendance_Employee_File data, string SQLCommand)
        {
            if (TaefDal.insertTimeAttendance_Employee_FileDal(data, SQLCommand) > 0)
                return true;
            else return false;
        }

        public bool insertTimeAttendance_Employee_File1Bll(TimeAttendance_Employee_File data, string SQLCommand)
        {
            if (TaefDal.insertTimeAttendance_Employee_File1Dal(data, SQLCommand) > 0)
                return true;
            else return false;
        }

        public bool updateTimeAttendance_Employee_File1Bll(TimeAttendance_Employee_File data, string SQLCommand)
        {
            if (TaefDal.updateTimeAttendance_Employee_File1Dal(data, SQLCommand) > 0)
                return true;
            else return false;
        }

        public List<TimeAttendance_Employee_File> LikeSelectTimeAttendance_Employee_File1Bll(string JobNumberRoChineseName, string SQLCommand)
        {
            return TaefDal.LikeSelectTimeAttendance_Employee_File1Dal(JobNumberRoChineseName, SQLCommand);
        }

        public List<TimeAttendance_Employee_File> selectAllTimeAttendance_Employee_File1Bll(string SQLCommand)
        {
            return TaefDal.selectAllTimeAttendance_Employee_File1Dal(SQLCommand);
        }
    }
}
