using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gce_Model;
using System.Data.SqlClient;
using System.Data;

namespace Gce_Dal
{
    public class PWorkScheduleDal
    {
        public int insertPWorkScheduleDal(List<PWorkSchedule> list,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[] { 
                new SqlParameter("@companyname",SqlDbType.VarChar,50){Value=list[0].CompanyName},
                new SqlParameter("@moringon",SqlDbType.VarChar,50){Value=list[0].MorningOnWorkTime},
                new SqlParameter("@morningun",SqlDbType.VarChar,50){Value=list[0].MorningUnderWorkTime},
                new SqlParameter("@afteron",SqlDbType.VarChar,50){Value=list[0].AfternoonOnWorkTime},
                new SqlParameter("@afterun",SqlDbType.VarChar,50){Value=list[0].AfternoonUnderWorkTime},
                new SqlParameter("@nighton",SqlDbType.VarChar,50){Value=list[0].NightOnWorkTime},
                new SqlParameter("@flag",SqlDbType.VarChar,50){Value=list[0].Flag}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }

        public int deletePWorkScheduleDal(string CompanyName,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[] { 
                new SqlParameter("@cn",SqlDbType.VarChar,50){Value=CompanyName}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }

        public List<PWorkSchedule> selectPWorkScheduleDal(string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            List<PWorkSchedule> list = new List<PWorkSchedule>();

            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new PWorkSchedule()
                            {
                                CompanyName = reader.IsDBNull(0) ? "" : reader.GetString(0),
                                MorningOnWorkTime = reader.IsDBNull(1) ? "" : reader.GetString(1),
                                MorningUnderWorkTime = reader.IsDBNull(2) ? "" : reader.GetString(2),
                                AfternoonOnWorkTime = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                AfternoonUnderWorkTime = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                NightOnWorkTime = reader.IsDBNull(5) ? "" : reader.GetString(5),
                                Flag = reader.GetBoolean(7)
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

        //public string Top1_PWorkScheduleDal(string SQLCommand)
        //{
        //    string sql = SQLhelp.GetSQLCommand(SQLCommand);

        //    return SQLhelp.ExecuteScalar(sql, CommandType.Text) as string;
        //}
    }
}
