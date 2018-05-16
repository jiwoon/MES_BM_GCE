using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gce_Dal;
using Gce_Model;
using System.Data.SqlClient;
using System.Data;

namespace Gce_Dal
{
    public class PCapacityConfigurationDal
    {
        /// <summary>
        /// 向PCapacityConfiguration表插入数据
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int InsertPCapacityConfigurationDal(List<PCapacityConfiguration> list,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[] { 
                new SqlParameter("@zd",SqlDbType.VarChar,80){Value=list[0].ZhiDan},
                new SqlParameter("@pc",SqlDbType.VarChar,100){Value=list[0].ProductClass}
            };
            try
            {
                return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
            }
            catch
            {
                throw;
            }
        }

        public Object selectPCapacityConfigurationProductClassDal(string txtOrder,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[] { 
                new SqlParameter("@zd",SqlDbType.VarChar,80){Value=txtOrder}
            };
            try
            {
                return SQLhelp.ExecuteScalar(sql, CommandType.Text, pms);
            }
            catch 
            { 
                throw; 
            }
        }

        public int selectPCapacityConfigurationNumberDal(string txtOrder,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[] { 
                new SqlParameter("@zhidan",SqlDbType.VarChar,80){Value=txtOrder}
            };
            try
            {
                return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<PCapacityConfiguration> selectPCapacityConfigurationDal(string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            List<PCapacityConfiguration> list = new List<PCapacityConfiguration>();
            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new PCapacityConfiguration
                                {
                                    ZhiDan=reader.GetString(0),
                                    ProductClass=reader.GetString(1)
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
        /// <param name="ZhiDan">订单号</param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int deletePCapacityConfigurationDal(string ZhiDan,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@zd",SqlDbType.VarChar,80){Value=ZhiDan}
            };
            try
            {
                return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
            }
            catch
            {
                throw;
            }
        }
    }
}
