using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gce_Model;
using System.Data;
using System.Data.SqlClient;

namespace Gce_Dal
{
    public class PMCplan_tableDal
    {
        /// <summary>
        /// PMC计划表插入数据
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int insertPMCplan_tableDal(List<PMCplan_table> list,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@corporatename",SqlDbType.VarChar,50){Value=list[0].CorporateName},
                new SqlParameter("@zhidan",SqlDbType.VarChar,100){Value=list[0].ZhiDan},
                new SqlParameter("@totalorder",SqlDbType.Int){Value=list[0].TotalOrder},
                new SqlParameter("@requiretimeguid",SqlDbType.VarChar,80){Value=list[0].RequiredTimeGUID},
                new SqlParameter("@customername",SqlDbType.VarChar,80){Value=list[0].CustomerName},
                new SqlParameter("@shippingdate",SqlDbType.DateTime){Value=list[0].ShippingDate},
                new SqlParameter("@remarks",SqlDbType.VarChar,200){Value=list[0].Remarks},
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }
        /// <summary>
        /// 检查数据是否存在
        /// </summary>
        /// <param name="CorporateName"></param>
        /// <param name="ZhiDan"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int checkedPMCplan_tableDal(string CorporateName, string ZhiDan, string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@corporatename",SqlDbType.VarChar,50){Value=CorporateName},
                new SqlParameter("@zhidan",SqlDbType.VarChar,100){Value=ZhiDan}
            };

            return Convert.ToInt32(SQLhelp.ExecuteScalar(sql, CommandType.Text, pms));
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int updatePMCplan_tableDal(string oldCorporateName, string oldZhiDan, List<PMCplan_table> list, string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@corporatename",SqlDbType.VarChar,50){Value=list[0].CorporateName},
                new SqlParameter("@zhidan",SqlDbType.VarChar,100){Value=list[0].ZhiDan},
                new SqlParameter("@totalorder",SqlDbType.Int){Value=list[0].TotalOrder},
                new SqlParameter("@requiretimeguid",SqlDbType.VarChar,80){Value=list[0].RequiredTimeGUID},
                new SqlParameter("@customername",SqlDbType.VarChar,80){Value=list[0].CustomerName},
                new SqlParameter("@shippingdate",SqlDbType.DateTime){Value=list[0].ShippingDate},
                new SqlParameter("@remarks",SqlDbType.VarChar,200){Value=list[0].Remarks},
                new SqlParameter("@corporatename1",SqlDbType.VarChar,50){Value=oldCorporateName},
                new SqlParameter("@zhidan1",SqlDbType.VarChar,100){Value=oldZhiDan}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms); 
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="CorporateName"></param>
        /// <param name="ZhiDan"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int deletePMCplan_tableDal(string CorporateName, string ZhiDan, string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@corporatename",SqlDbType.VarChar,50){Value=CorporateName},
                new SqlParameter("@zhidan",SqlDbType.VarChar,100){Value=ZhiDan}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }

        public List<PMCplan_table> selectPMCplan_tableDal(List<PMCplan_table> list,string SQLCommand)
        {
            List<PMCplan_table> retList = new List<PMCplan_table>();

            StringBuilder sql = new StringBuilder(SQLhelp.GetSQLCommand(SQLCommand));
            List<SqlParameter> listsqlpar = new List<SqlParameter>();
            List<string> whereList = new List<string>();

            if (list.Count > 0)
            {
                if (list[0].CustomerName.Length > 0)
                {
                    whereList.Add(" CustomerName=@customername ");
                    listsqlpar.Add(new SqlParameter("@customername", SqlDbType.VarChar, 80) { Value = list[0].CustomerName });
                }
                if (list[0].CorporateName.Length > 0)
                {
                    whereList.Add(" CorporateName=@corporatename ");
                    listsqlpar.Add(new SqlParameter("@corporatename", SqlDbType.VarChar, 50) { Value = list[0].CorporateName });
                }
                if (list[0].ZhiDan.Length > 0)
                {
                    whereList.Add(" ZhiDan=@zhidan ");
                    listsqlpar.Add(new SqlParameter("@zhidan", SqlDbType.VarChar, 100) { Value = list[0].ZhiDan });
                }
                if (list[0].TotalOrder > 0)
                {
                    whereList.Add(" TotalOrder=@totalorder ");
                    listsqlpar.Add(new SqlParameter("@totalorder", SqlDbType.Int) { Value = list[0].TotalOrder });
                }
                if (list[0].ShippingDate.Year.ToString() != "1")
                {
                    whereList.Add(" ShippingDate=@shippingdate ");
                    listsqlpar.Add(new SqlParameter("@shippingdate", SqlDbType.DateTime) { Value = list[0].ShippingDate });
                }
                if (list[0].UpdateTime.Year.ToString() != "1")
                {
                    whereList.Add(" UpdateTime=@updatetime ");
                    listsqlpar.Add(new SqlParameter("@updatetime", SqlDbType.DateTime) { Value = list[0].UpdateTime });
                }
            }
            if (whereList.Count > 0)
            {
                sql.Append(" where ");//只要有查询条件，就拼接一个where
                //然后把后面的查询条件连起来
                sql.Append(string.Join(" and ", whereList));
            }
            if (listsqlpar.Count > 0)
            {
                SqlParameter[] pms = listsqlpar.ToArray();

                try
                {
                    using (SqlDataReader reader = SQLhelp.ExecuteReader(sql.ToString(), CommandType.Text, pms))
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                retList.Add(new PMCplan_table()
                                {
                                    CorporateName=reader.GetString(0),
                                    ZhiDan=reader.GetString(1),
                                    TotalOrder=reader.GetInt32(2),
                                    RequiredTimeGUID=reader.GetString(3),
                                    CustomerName=reader.GetString(4),
                                    ShippingDate=reader.GetDateTime(5),
                                    Remarks=reader.IsDBNull(6)?"":reader.GetString(6),
                                    CreationTime=reader.GetDateTime(7),
                                    UpdateTime=reader.GetDateTime(8),
                                });
                            }
                        }
                        return retList;
                    }
                }
                catch
                {
                    throw;
                }
            }
            else
            {
                try
                {
                    using (SqlDataReader reader = SQLhelp.ExecuteReader(sql.ToString(), CommandType.Text))
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                retList.Add(new PMCplan_table()
                                {
                                    CorporateName = reader.GetString(0),
                                    ZhiDan = reader.GetString(1),
                                    TotalOrder = reader.GetInt32(2),
                                    RequiredTimeGUID = reader.GetString(3),
                                    CustomerName = reader.GetString(4),
                                    ShippingDate = reader.GetDateTime(5),
                                    Remarks = reader.IsDBNull(6) ? "" : reader.GetString(6),
                                    CreationTime = reader.GetDateTime(7),
                                    UpdateTime = reader.GetDateTime(8),
                                });
                            }
                        }
                        return retList;
                    }
                }
                catch
                {
                    throw;
                }
            }
        }   
    }
}
