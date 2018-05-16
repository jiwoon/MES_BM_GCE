using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Gce_Dal
{
    public class ClassType_tableDal
    {
        /// <summary>
        /// 查询异常类型表
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<string> selectClassType_tableDal(string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            List<string> list = new List<string>();
            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text))
                {
                    if (reader.HasRows)
                    { 
                        while(reader.Read())
                        {
                            list.Add(reader.GetString(0));
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
        /// 增加异常类别
        /// </summary>
        /// <param name="classType"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int insertClassType_tableDal(string classType,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@classType",SqlDbType.VarChar,80){Value=classType}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }
    }
}
