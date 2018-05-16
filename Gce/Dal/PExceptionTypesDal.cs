using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Gce_Dal
{
    public class PExceptionTypesDal
    {
        /// <summary>
        ///像异常类型表插入信息
        /// </summary>
        /// <param name="ExceptionTypes"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int insertPExceptionTypesDal(string ExceptionTypes,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@et",SqlDbType.VarChar,80){Value=ExceptionTypes}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }
        /// <summary>
        /// 查询异常类型表
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<string> selectPExceptionTypesDal(string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            List<string> list = new List<string>();
            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
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

        public int checkedPExceptionTypesDal(string ExceptionTypes,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@et",SqlDbType.VarChar,80){Value=ExceptionTypes}
            };

            return Convert.ToInt32(SQLhelp.ExecuteScalar(sql, CommandType.Text, pms));
        }
    }
}
