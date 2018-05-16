using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace Gce_Dal
{
    public class ProductPerformanceDal
    {
        /// <summary>
        /// 查询TestOrder,TestTime
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<ProductPerformance> GetProductPerformanceDal(string order, string SoftModel,bool flag , DateTime timeBegin, DateTime timeEnd, string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            List<ProductPerformance> list = new List<ProductPerformance>();
            #region 旧式
            //if (order != "")
            //{
            //    sql += " and ZhiDan=@order ";
            //}
            //if (SoftModel != "")
            //{
            //    sql += " and SoftModel=@softmodel ";
            //}
            ////if (flag)
            ////{
            ////    sql += " and TestTime>=@timebegin and TestTime<=@timeend ";
            ////}
            //sql += " order by TestTime ";
            //SqlParameter[] pms;
            //List<ProductPerformance> list = new List<ProductPerformance>();
            //if (order != ""&&SoftModel=="")
            //{
            //    pms = new SqlParameter[]{
            //    new SqlParameter("@order",SqlDbType.VarChar,100){Value=order},
            //    new SqlParameter("@timebegin",SqlDbType.DateTime){Value=timeBegin},
            //    new SqlParameter("@timeend",SqlDbType.DateTime){Value=timeEnd}
            //};
            //}
            //else if (order == "" && SoftModel != "")
            //{
            //    pms = new SqlParameter[]{
            //    new SqlParameter("@softmodel",SqlDbType.VarChar,100){Value=SoftModel},
            //    new SqlParameter("@timebegin",SqlDbType.DateTime){Value=timeBegin},
            //    new SqlParameter("@timeend",SqlDbType.DateTime){Value=timeEnd}
            //};
            //}
            //else
            //{
            //    pms = new SqlParameter[]{
            //    new SqlParameter("@order",SqlDbType.VarChar,100){Value=order},
            //    new SqlParameter("@softmodel",SqlDbType.VarChar,20){Value=SoftModel},
            //    new SqlParameter("@timebegin",SqlDbType.DateTime){Value=timeBegin},
            //    new SqlParameter("@timeend",SqlDbType.DateTime){Value=timeEnd}
            //};
            //}
            #endregion

            SqlParameter[] pms = new SqlParameter[] { 
                new SqlParameter("@bt",SqlDbType.Bit){Value=flag},
                new SqlParameter("@ord",SqlDbType.VarChar,100){Value=order},
                new SqlParameter("@sof",SqlDbType.VarChar,20){Value=SoftModel},
                new SqlParameter("@begin",SqlDbType.DateTime){Value=timeBegin},
                new SqlParameter("@end",SqlDbType.DateTime){Value=timeEnd}
            };
            
            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text,pms))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new ProductPerformance() {
                                Order = reader.IsDBNull(0) ? "" : reader.GetString(0),
                                Time = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1),
                                SoftModel = reader.IsDBNull(2)?"":reader.GetString(2),
                                Computer=reader.IsDBNull(3)?"":reader.GetString(3)
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
