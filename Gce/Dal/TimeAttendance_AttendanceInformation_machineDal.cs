using Gce_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Gce_Dal
{
    public class TimeAttendance_AttendanceInformation_machineDal
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="data"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int insertTimeAttendance_AttendanceInformation_machineDal(TimeAttendance_AttendanceInformation_machine data,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@MachineID",SqlDbType.VarChar,50){Value=data.MachineID},
                new SqlParameter("@ComInterface",SqlDbType.VarChar,50){Value=data.ComInterface},
                new SqlParameter("@BaudRate",SqlDbType.VarChar,50){Value=data.BaudRate},
                new SqlParameter("@IPAddress",SqlDbType.VarChar,50){Value=data.IPAddress},
                new SqlParameter("@MachinePosition",SqlDbType.VarChar,80){Value=data.MachinePosition},
                new SqlParameter("@MachineUse",SqlDbType.VarChar,50){Value=data.MachineUse},
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }

        public List<TimeAttendance_AttendanceInformation_machine> selectTimeAttendance_AttendanceInformation_machineDal(string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            List<TimeAttendance_AttendanceInformation_machine> list = new List<TimeAttendance_AttendanceInformation_machine>();

            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new TimeAttendance_AttendanceInformation_machine()
                            {
                                MachineID=reader.GetString(0),
                                ComInterface=reader.IsDBNull(1)?"":reader.GetString(1),
                                BaudRate = reader.IsDBNull(2) ? "" : reader.GetString(2),
                                IPAddress = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                MachinePosition = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                MachineUse = reader.IsDBNull(5) ? "" : reader.GetString(5),
                            });
                        }
                    }
                    return list;
                }
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="MachineID"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int deleteTimeAttendance_AttendanceInformation_machineDal(string MachineID, string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@MachineID",SqlDbType.VarChar,50){Value=MachineID}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }
    }
}
