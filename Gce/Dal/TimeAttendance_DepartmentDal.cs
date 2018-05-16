using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Gce_Model;

namespace Gce_Dal
{
    public class TimeAttendance_DepartmentDal
    {
        /// <summary>
        /// 根据父级部门ID查询
        /// </summary>
        /// <param name="ParentDepartmentNo"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<TimeAttendance_Department> selectTimeAttendance_DepartmentParentDepartmentNoDal(string ParentDepartmentNo, string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            List<TimeAttendance_Department> list = new List<TimeAttendance_Department>();

            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@ParentDepartmentNo",SqlDbType.VarChar,50){Value=ParentDepartmentNo}
            };

            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text, pms))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new TimeAttendance_Department()
                            {
                                DepartmentNo = reader.GetString(0),
                                DepartmentName = reader.IsDBNull(1) ? "" : reader.GetString(1),
                                ParentDepartmentNo = reader.IsDBNull(2) ? "" : reader.GetString(2),
                                ParentDepartmentName = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                NumberOfStaff = reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                                InTheNumberOfStaff = reader.IsDBNull(5) ? 0 : reader.GetInt32(5),
                                ExceedNumberOfStaff = reader.IsDBNull(6) ? 0 : reader.GetInt32(6),
                                note = reader.IsDBNull(7) ? "" : reader.GetString(7)
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

        public List<TimeAttendance_Department> selectAllTimeAttendance_EmployeeParentDepartmentNoDal(string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            List<TimeAttendance_Department> list = new List<TimeAttendance_Department>();

            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new TimeAttendance_Department()
                            {
                                DepartmentNo = reader.GetString(0),
                                DepartmentName = reader.IsDBNull(1) ? "" : reader.GetString(1)
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
        /// 插入
        /// </summary>
        /// <param name="data"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int insertTimeAttendance_DepartmentDal(TimeAttendance_Department data,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@DepartmentNo",SqlDbType.VarChar,50){Value=data.DepartmentNo},
                new SqlParameter("@DepartmentName",SqlDbType.VarChar,80){Value=data.DepartmentName},
                new SqlParameter("@ParentDepartmentNo",SqlDbType.VarChar,50){Value=data.ParentDepartmentNo},
                new SqlParameter("@ParentDepartmentName",SqlDbType.VarChar,80){Value=data.ParentDepartmentName},
                new SqlParameter("@NumberOfStaff",SqlDbType.Int){Value=data.NumberOfStaff},
                new SqlParameter("@InTheNumberOfStaff",SqlDbType.Int){Value=data.InTheNumberOfStaff},
                new SqlParameter("@ExceedNumberOfStaff",SqlDbType.Int){Value=data.ExceedNumberOfStaff},
                new SqlParameter("@note",SqlDbType.VarChar,255){Value=data.note}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="data"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int updateTimeAttendance_DepartmentDal(TimeAttendance_Department data, string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@DepartmentNo",SqlDbType.VarChar,50){Value=data.DepartmentNo},
                new SqlParameter("@DepartmentName",SqlDbType.VarChar,80){Value=data.DepartmentName},
                new SqlParameter("@NumberOfStaff",SqlDbType.Int){Value=data.NumberOfStaff},
                new SqlParameter("@InTheNumberOfStaff",SqlDbType.Int){Value=data.InTheNumberOfStaff},
                new SqlParameter("@ExceedNumberOfStaff",SqlDbType.Int){Value=data.ExceedNumberOfStaff},
                new SqlParameter("@note",SqlDbType.VarChar,255){Value=data.note}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="data"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int deleteTimeAttendance_DepartmentDal(TimeAttendance_Department data, string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@DepartmentNo",SqlDbType.VarChar,50){Value=data.DepartmentNo}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }
    }
}
