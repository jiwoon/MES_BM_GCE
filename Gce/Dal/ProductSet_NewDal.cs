using Gce_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Gce_Dal
{
    public class ProductSet_NewDal
    {
        /// <summary>
        /// 查询产品配置表明细
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<ProductSet_New> selectProductSet_NewDal(string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            List<ProductSet_New> list = new List<ProductSet_New>();
            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new ProductSet_New()
                            {
                                ProductClass=reader.GetString(0),
                                Stations=reader.GetString(1),
                                EfficiencyQuantity=reader.IsDBNull(2)?"0":reader.GetString(2),
                                TheNumberOf=reader.IsDBNull(3)?"0":reader.GetString(3),
                                UpdateTime=reader.GetDateTime(4)
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
        /// 插入产能配置表
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int insertProductSet_NewDal(List<ProductSet_New> list,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@productcalss",SqlDbType.VarChar,100){Value=list[0].ProductClass},
                new SqlParameter("@stations",SqlDbType.VarChar,50){Value=list[0].Stations},
                new SqlParameter("@efficiencyquantity",SqlDbType.VarChar,100){Value=list[0].EfficiencyQuantity},
                new SqlParameter("@thenumberof",SqlDbType.VarChar,100){Value=list[0].TheNumberOf}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }
        /// <summary>
        /// 检查产能配置表
        /// </summary>
        /// <param name="ProductClass"></param>
        /// <param name="Stations"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int checkProductSet_NewDal(string ProductClass,string Stations,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@productcalss",SqlDbType.VarChar,100){Value=ProductClass},
                new SqlParameter("@stations",SqlDbType.VarChar,50){Value=Stations}
            };

            return Convert.ToInt32(SQLhelp.ExecuteScalar(sql, CommandType.Text, pms));
        }
        /// <summary>
        /// 修改产能设置表
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int updateProductSet_NewDal(List<ProductSet_New> list,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@productcalss",SqlDbType.VarChar,100){Value=list[0].ProductClass},
                new SqlParameter("@stations",SqlDbType.VarChar,50){Value=list[0].Stations},
                new SqlParameter("@efficiencyquantity",SqlDbType.VarChar,100){Value=list[0].EfficiencyQuantity},
                new SqlParameter("@thenumberof",SqlDbType.VarChar,100){Value=list[0].TheNumberOf}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }
        /// <summary>
        /// 删除产能配置表中的数据
        /// </summary>
        /// <param name="ProductClass"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int deleteProductSet_NewDal(string ProductClass,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@productcalss",SqlDbType.VarChar,100){Value=ProductClass}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }
        /// <summary>
        /// 根据生产类型删除产能配置表数据
        /// </summary>
        /// <param name="ProductClass"></param>
        /// <param name="Stations"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int deleteProductSet_NewStationsDal(string ProductClass,string Stations,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@productcalss",SqlDbType.VarChar,100){Value=ProductClass},
                new SqlParameter("@stations",SqlDbType.VarChar,50){Value=Stations}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }
        /// <summary>
        /// 根据类型查询产能配置表
        /// </summary>
        /// <param name="ProductClass"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<ProductSet_New> selectProductClassDal(string ProductClass,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            List<ProductSet_New> list = new List<ProductSet_New>();

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@productclass",SqlDbType.VarChar,100){Value=ProductClass}
            };

            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text, pms))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new ProductSet_New()
                            {
                                ProductClass = reader.GetString(0),
                                Stations = reader.GetString(1),
                                EfficiencyQuantity = reader.IsDBNull(2) ? "0" : reader.GetString(2),
                                TheNumberOf = reader.IsDBNull(3) ? "0" : reader.GetString(3),
                                UpdateTime = reader.GetDateTime(4)
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
        /// 根据单号查找数据
        /// </summary>
        /// <param name="ZhiDan"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<ProductSet_New> selectProductSet_NewForProductClassDal(string ZhiDan,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            List<ProductSet_New> list = new List<ProductSet_New>();

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@zhidan",SqlDbType.VarChar,80){Value=ZhiDan}
            };
            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text, pms))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new ProductSet_New()
                            {
                                ProductClass = reader.GetString(0),
                                Stations = reader.GetString(1),
                                EfficiencyQuantity = reader.IsDBNull(2) ? "0" : reader.GetString(2),
                                TheNumberOf = reader.IsDBNull(3) ? "0" : reader.GetString(3),
                                UpdateTime = reader.GetDateTime(4)
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
    }
}
    