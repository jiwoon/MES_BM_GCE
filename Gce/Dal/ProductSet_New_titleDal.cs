using Gce_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Gce_Dal
{
    public class ProductSet_New_titleDal
    {
        /// <summary>
        /// 查询产能配置抬头表
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<ProductSet_New_title> selectProductSet_New_titleDal(string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            List<ProductSet_New_title> list = new List<ProductSet_New_title>();

            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new ProductSet_New_title()
                            {
                                Id=reader.GetInt32(0),
                                ProductClass=reader.GetString(1),
                                UpdateTime=reader.GetDateTime(2)
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
        /// 检查产能设置抬头表
        /// </summary>
        /// <param name="ProductClass"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int checkProductSet_New_titleDal(string ProductClass,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@productcalss",SqlDbType.VarChar,100){Value=ProductClass}
            };

            return Convert.ToInt32(SQLhelp.ExecuteScalar(sql, CommandType.Text, pms));
        }
        /// <summary>
        /// 插入产能配置抬头表
        /// </summary>
        /// <param name="ProductClass"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int insertProductSet_New_titleDal(string ProductClass,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@productcalss",SqlDbType.VarChar,100){Value=ProductClass}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }
        /// <summary>
        /// 删除产能配置表中的数据
        /// </summary>
        /// <param name="ProductClass"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int deleteProductSet_New_titleDal(string ProductClass,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@productcalss",SqlDbType.VarChar,100){Value=ProductClass}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }
        /// <summary>
        /// 查询产能抬头表Top1
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public string selectProductSet_New_titleTop1Dal(string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            return SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
        }
    }
}
