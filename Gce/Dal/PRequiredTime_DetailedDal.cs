using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gce_Model;
using System.Data;
using System.Data.SqlClient;

namespace Gce_Dal
{
    public class PRequiredTime_DetailedDal
    {
        /// <summary>
        /// 向PRequiredTime_Detailed表插入数据
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int insertPRequiredTime_DetailedDal(List<PRequiredTime_Detailed> list,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@producttype",SqlDbType.VarChar,20){Value=list[0].ProductType},
                new SqlParameter("@requiretimeguid",SqlDbType.VarChar,80){Value=list[0].RequiredTimeGUID},
                new SqlParameter("@requiredtime",SqlDbType.Float){Value=list[0].RequiredTime}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ProductType"></param>
        /// <param name="RequiredTimeGUID"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int deletePRequiredTime_DetailedDal(string ProductType, string RequiredTimeGUID,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@producttype",SqlDbType.VarChar,20){Value=ProductType},
                new SqlParameter("@requiretimeguid1",SqlDbType.VarChar,80){Value=RequiredTimeGUID},
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<PRequiredTime_Detailed> selectPRequiredTime_DetailedDal(string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            List<PRequiredTime_Detailed> list = new List<PRequiredTime_Detailed>();

            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new PRequiredTime_Detailed()
                            {
                                ProductType=reader.GetString(0),
                                RequiredTimeGUID=reader.GetString(1),
                                RequiredTime=reader.GetDouble(2)
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
