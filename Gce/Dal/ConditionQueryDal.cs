using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Gce_Model;
using System.Data.SqlClient;
using System.Data;

namespace Gce_Dal
{
    //条件查询窗口Dal
    public class ConditionQueryDal
    {
        /// <summary>
        /// 单号查询
        /// </summary>
        /// <param name="SQLCommand">SQL命令</param>
        /// <param name="txt_Order">订单号</param>
        /// <param name="begintime">开始时间</param>
        /// <param name="endtime">结束时间</param>
        /// <returns>List<productionOrder></returns>
        public List<productionOrder> selectOrderDal(string SQLCommand, string txt_Order, string SoftModel, DateTime begintime, DateTime endtime)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            if (txt_Order != "")
            {
                sql += " and zOrder like" + "'%" + txt_Order + "%'";
            }
            //if (SoftModel != "")
            //{
            //    sql += " and SoftModel= " + "'" + SoftModel + "'";
            //}
            sql += " order by zOrder  drop table #t ";
            List<productionOrder> list = new List<productionOrder>();

            SqlParameter[] pms = new SqlParameter[]{
              new SqlParameter("@begintime",SqlDbType.DateTime2){Value=begintime},
              new SqlParameter("@endtime",SqlDbType.DateTime2){Value=endtime}
            }; 
            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text,pms))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new productionOrder()
                            {
                                Order = reader.IsDBNull(0)?"":reader.GetString(0)
                            });
                        }
                    }
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].Order == "")
                        {
                            list.Remove(list[i]);
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

        public List<productionOrder> selectOrder1Dal(string SQLCommand, string CompanyName, DateTime begintime, DateTime endtime)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            List<productionOrder> list = new List<productionOrder>();

            SqlParameter[] pms = new SqlParameter[]{
              new SqlParameter("@begin",SqlDbType.DateTime2){Value=begintime},
              new SqlParameter("@end",SqlDbType.DateTime2){Value=endtime},
              new SqlParameter("@pn",SqlDbType.VarChar,20){Value=CompanyName}
            };
            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text, pms))
                { 
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new productionOrder()
                            {
                                Order = reader.IsDBNull(0) ? "" : reader.GetString(0)
                            });
                        }
                    }
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].Order == "")
                        {
                            list.Remove(list[i]);
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
        /// 机型查询
        /// </summary>
        /// <param name="SQLCommand">SQL命令</param>
        /// <param name="txt_SoftModel"></param>
        /// <returns></returns>
        public List<ProductionSoftModel> selectSoftModelDal(string SQLCommand, string txt_SoftModel,string Order,DateTime begin,DateTime end)
        { 
              string sql = SQLhelp.GetSQLCommand(SQLCommand);
            if (txt_SoftModel != "")
            {
                sql += " and SoftModel like" + "'%" + txt_SoftModel + "%'";
            }
            if (Order != "")
            {
                sql += " and ZhiDan=" + "'" + Order + "'";
            }
            List<ProductionSoftModel> list = new List<ProductionSoftModel>();

            SqlParameter[] pms = new SqlParameter[]{
              new SqlParameter("@begintime",SqlDbType.DateTime2){Value=begin},
              new SqlParameter("@endtime",SqlDbType.DateTime2){Value=end}
            }; 
            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text,pms))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new ProductionSoftModel()
                            {
                                SoftModel = reader.GetString(0)
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
        /// 查找包装总数
        /// </summary>
        /// <param name="strOrder"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int selectSumCartonBoxTwentyNumberDal(string strOrder,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
              new SqlParameter("@zhidan",SqlDbType.VarChar,80){Value=strOrder}  
            };
            return Convert.ToInt32(SQLhelp.ExecuteScalar(sql, CommandType.Text, pms));
        }
  
    }
}
