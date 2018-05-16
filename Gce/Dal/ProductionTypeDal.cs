using Gce_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Gce_Dal
{
    public class ProductionTypeDal
    {
        /// <summary>
        /// 查询工位表
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<ProductionType> selectProductionTypeDal(string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            List<ProductionType> list = new List<ProductionType>();
            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new ProductionType()
                            {
                                ProductType = reader.GetString(0).Trim(),
                                Command = reader.IsDBNull(1) ? "" : reader.GetString(1),
                                Command1 = reader.IsDBNull(2) ? "" : reader.GetString(2),
                                Command2 = reader.IsDBNull(3)?"":reader.GetString(3),
                                OnWorkTimeType = reader.IsDBNull(4)?"":reader.GetString(4),
                                Command3=reader.IsDBNull(5)?"":reader.GetString(5),
                                OnWorkTimeTypeNight = reader.IsDBNull(6)?"":reader.GetString(6)
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

        public int updateProductionTypeOnWorkTimeTypeDal(string CompanyName, string producttype,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@onwork",SqlDbType.VarChar,50){Value=CompanyName},
                new SqlParameter("@pt",SqlDbType.VarChar,20){Value=producttype}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }

        public List<string> selectProductionTypeProductTypeDal(string CompanyName,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            List<string> list = new List<string>();

            SqlParameter[] pms = new SqlParameter[] { 
                new SqlParameter("@onwork",SqlDbType.VarChar,50){Value=CompanyName}
            };
            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text, pms))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(reader.IsDBNull(0) ? "" : reader.GetString(0));
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
        /// 查询生产类型
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<string> selectProductTypeDal(string SQLCommand)
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
                            list.Add(reader.IsDBNull(0) ? "" : reader.GetString(0).Trim());
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
        /// 根据公司名查找工位
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<string> selectProductionTypeOnWorkTimeTypeDal(string OnWorkTimeType, string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            List<string> list = new List<string>();

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@OnWorkTimeType",SqlDbType.VarChar,50){Value=OnWorkTimeType}
            };
            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text,pms))
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
    }
}
