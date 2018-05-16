using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gce_Model;
using System.Data;
using System.Data.SqlClient;

namespace Gce_Dal
{
    public class PTypesWorkDal
    {
        /// <summary>
        /// 查询表中所有数据
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<PTypesWork> selectPTypesWorkDal(string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            List<PTypesWork> list = new List<PTypesWork>();
            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new PTypesWork()
                            {
                                TypesWork = reader.GetString(0)
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
        /// 向表中插入一条数据
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int insertPTypesWorkDal(List<PTypesWork> list,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@typeswork",SqlDbType.VarChar,50){Value=list[0].TypesWork}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }
        /// <summary>
        /// 检查表中是否存在某条数据
        /// </summary>
        /// <param name="typeswork"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int checkedPTypesWorkDal(string typeswork,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@typeswork",SqlDbType.VarChar,50){Value=typeswork}
            };

            return Convert.ToInt32(SQLhelp.ExecuteScalar(sql, CommandType.Text, pms));
        }
        /// <summary>
        /// 更新表中一条数据
        /// </summary>
        /// <param name="oldTypesWork"></param>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int updatePTypesWorkDal(string oldTypesWork,List<PTypesWork> list,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@typeswork",SqlDbType.VarChar,50){Value=list[0].TypesWork},
                new SqlParameter("@typeswork1",SqlDbType.VarChar,50){Value=oldTypesWork}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }
    }
}
