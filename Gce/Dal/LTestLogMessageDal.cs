using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Gce_Model;

namespace Gce_Dal
{
    public class LTestLogMessageDal
    {
        ProductionSplitTimeRecordDal pstrd = new ProductionSplitTimeRecordDal();
        /// <summary>
        /// 查询失败产品表
        /// </summary>
        /// <param name="order">zhidan号</param>
        /// <param name="timeBegin">开始时间</param>
        /// <param name="timeEnd">结束时间</param>
        /// <param name="SQLCommand">SQL语句</param>
        /// <returns>int</returns>
        public int selectLTestLogMessageDal(string order, string SoftModel, DateTime timeBegin, DateTime timeEnd, string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            if (order != "")
            {
                sql += " and llm.ZhiDan=  "+"'"+ order+"'";
            }
            if (SoftModel != "")
            {
                sql += " and llm.SoftModel= "+"'"+ SoftModel +"'";
            }
            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@TimeBegin",SqlDbType.DateTime){Value=timeBegin},
                new SqlParameter("@TimeEnd",SqlDbType.DateTime){Value=timeEnd}
            };

            try
            {

                return Convert.ToInt32(SQLhelp.ExecuteScalar(sql, CommandType.Text, pms)); ;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 查询错误信息
        /// </summary>
        /// <param name="order"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<BadMachineFrmModel> selectMessageDal(string order,DateTime begintime,DateTime endtime,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            List<BadMachineFrmModel> list = new List<BadMachineFrmModel>();
            if (sql == "")
            {
                return list;
            }
            SqlParameter[] pms = new SqlParameter[] { 
                new SqlParameter("@zhidan",SqlDbType.VarChar,100){Value=order},
                new SqlParameter("@begintime",SqlDbType.DateTime){Value=begintime},
                new SqlParameter("@endtime",SqlDbType.DateTime){Value=endtime}
            };
            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text, pms))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read()) 
                        {
                            list.Add(new BadMachineFrmModel()
                            {
                                ZhiDan = reader.IsDBNull(0) ? "" : reader.GetString(0),
                                SoftModel = reader.IsDBNull(1) ? "" : reader.GetString(1),
                                Version = reader.IsDBNull(2) ? "" : reader.GetString(2),
                                SN = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                ErrorMessage = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                Computer =reader.IsDBNull(5) ? "" : reader.GetString(5),
                                TestTime = reader.GetDateTime(6)
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
