using Gce_Dal;
using Gce_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gce_Bll
{
    public class TimeAttendance_DepartmentBll
    {
        TimeAttendance_DepartmentDal TadDal = new TimeAttendance_DepartmentDal();
        /// <summary>
        /// 根据父级部门ID查询
        /// </summary>
        /// <param name="ParentDepartmentNo"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<TimeAttendance_Department> selectTimeAttendance_DepartmentParentDepartmentNoBll(string ParentDepartmentNo, string SQLCommand)
        {
            return TadDal.selectTimeAttendance_DepartmentParentDepartmentNoDal(ParentDepartmentNo, SQLCommand);
        }
        /// <summary>
        /// 插入部门表
        /// </summary>
        /// <param name="data"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool insertTimeAttendance_DepartmentBll(TimeAttendance_Department data, string SQLCommand)
        {
            if (TadDal.insertTimeAttendance_DepartmentDal(data, SQLCommand) > 0)
                return true;
            else
                return false;
        }

        public bool updateTimeAttendance_DepartmentDal(TimeAttendance_Department data, string SQLCommand)
        {
            if (TadDal.updateTimeAttendance_DepartmentDal(data, SQLCommand) > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="data"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool deleteTimeAttendance_DepartmentDal(TimeAttendance_Department data, string SQLCommand)
        {
            if (TadDal.deleteTimeAttendance_DepartmentDal(data, SQLCommand) > 0)
                return true;
            else
                return false;
        }
        public List<TimeAttendance_Department> selectAllTimeAttendance_EmployeeParentDepartmentNoBll(string SQLCommand)
        {
            return TadDal.selectAllTimeAttendance_EmployeeParentDepartmentNoDal(SQLCommand);
        }

    }
}
