using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gce_Model;
using System.Data.SqlClient;
using System.Data;

namespace Gce_Dal
{
    public class ProductionLinePCDal
    {
        public List<ProductionLinePC> selectProductionLinePCDal(string LineName,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            List<ProductionLinePC> list = new List<ProductionLinePC>();

            SqlParameter[] pms = new SqlParameter[] { 
                new SqlParameter("@ln",SqlDbType.VarChar,80){Value=LineName}
            };

            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text, pms))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new ProductionLinePC() { 
                                Pcname=reader.IsDBNull(0)?"":reader.GetString(0),
                                ProductType=reader.IsDBNull(1)?"":reader.GetString(1),
                                LineName=reader.IsDBNull(2)?"":reader.GetString(2),
                                CompanyName=reader.IsDBNull(3)?"":reader.GetString(3)
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

        public int insertProductionLinePCDal(List<ProductionLinePC> list,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@pcname",SqlDbType.VarChar,100){Value=list[0].Pcname},
                new SqlParameter("@producttype",SqlDbType.VarChar,20){Value=list[0].ProductType},
                new SqlParameter("@linename",SqlDbType.VarChar,80){Value=list[0].LineName},
                new SqlParameter("@companyname",SqlDbType.VarChar,50){Value=list[0].CompanyName}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }

        public int selectCountProductionLinePCDal(List<ProductionLinePC> list, string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            int i = 0;
            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@pcname",SqlDbType.VarChar,100){Value=list[0].Pcname},
                new SqlParameter("@producttype",SqlDbType.VarChar,20){Value=list[0].ProductType},
                new SqlParameter("@linename",SqlDbType.VarChar,80){Value=list[0].LineName},
                new SqlParameter("@companyname",SqlDbType.VarChar,50){Value=list[0].CompanyName}
            };
            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text, pms))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            i = reader.GetInt32(0);
                        }
                    }
                }
            }
            catch
            {
                throw;
            }

            return i;//Convert.ToInt32(SQLhelp.ExecuteScalar(sql, CommandType.Text, pms));
        }
        /// <summary>
        /// 更新ProductionLinePC
        /// </summary>
        /// <param name="pc">旧PC名</param>
        /// <param name="list">改变数据集</param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int UpdateProductionLinePCDal(string pc,List<ProductionLinePC> list,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@pcname",SqlDbType.VarChar,100){Value=list[0].Pcname},
                new SqlParameter("@type",SqlDbType.VarChar,20){Value=list[0].ProductType},
                new SqlParameter("@ln",SqlDbType.VarChar,80){Value=list[0].LineName},
                new SqlParameter("@cn",SqlDbType.VarChar,50){Value=list[0].CompanyName},
                new SqlParameter("@pn",SqlDbType.VarChar,100){Value=pc}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }

    }
}
