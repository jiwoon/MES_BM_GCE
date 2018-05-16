using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Gce_Model;

namespace Gce_Dal
{
    public class TimeAttendance_AttendanceScheduleDal
    {
        /// <summary>
        /// 增改
        /// </summary>
        /// <param name="data"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int insertTimeAttendance_AttendanceScheduleDal(TimeAttendance_AttendanceSchedule data,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@JobNumber",SqlDbType.VarChar,50){Value=data.JobNumber},
                new SqlParameter("@Name",SqlDbType.VarChar,80){Value=data.Name},
                new SqlParameter("@AttendanceTime",SqlDbType.DateTime){Value=data.AttendanceTime},
                new SqlParameter("@UpdateTime",SqlDbType.DateTime){Value=data.UpdateTime},
                new SqlParameter("@MachineID",SqlDbType.VarChar,50){Value=data.MachineID},
                new SqlParameter("@MachinePosition",SqlDbType.VarChar,50){Value=data.MachinePosition},
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }
    }
}
