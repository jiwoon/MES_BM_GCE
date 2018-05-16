using Gce_Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;

namespace Gce_Dal
{
    public class PUsers_Function_DetailedDal
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int insertPUsers_Function_DetailedDal(List<PUsers_Function_Detailed> list,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@UserName",SqlDbType.VarChar,50){Value=list[0].UserName},
                new SqlParameter("@FunctionName",SqlDbType.VarChar,50){Value=list[0].FunctionName},
                new SqlParameter("@FunctionJurisdiction",SqlDbType.Bit){Value=list[0].FunctionJurisdiction},
                new SqlParameter("@FunctionGUID",SqlDbType.VarChar,100){Value=list[0].FunctionGUID},
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
        /// 查询
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<PUsers_Function_Detailed> selectPUsers_Function_DetailedDal(string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            List<PUsers_Function_Detailed> list = new List<PUsers_Function_Detailed>();

            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new PUsers_Function_Detailed()
                            {
                                UserName=reader.GetString(0),
                                FunctionName=reader.GetString(1),
                                FunctionJurisdiction=reader.GetBoolean(2),
                                FunctionGUID=reader.GetString(3)
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
        /// 登录查询
        /// </summary>
        /// <param name="username"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<PUsers_Function_Detailed> selectPUsers_Function_DetailedLoginDal(string SQLCommand, string username)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            List<PUsers_Function_Detailed> list = new List<PUsers_Function_Detailed>();

            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@UserName",SqlDbType.VarChar,50){Value=username}
            };

            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text,pms))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new PUsers_Function_Detailed()
                            {
                                UserName = reader.GetString(0),
                                FunctionName = reader.GetString(1),
                                FunctionJurisdiction = reader.GetBoolean(2),
                                FunctionGUID = reader.GetString(3)
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
        /// 修改权限
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int updatePUsers_Function_DetailedDal(List<PUsers_Function_Detailed> list,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@UserName",SqlDbType.VarChar,50){Value=list[0].UserName},
                new SqlParameter("@FunctionGUID",SqlDbType.VarChar,100){Value=list[0].FunctionGUID},
                new SqlParameter("@FunctionName",SqlDbType.VarChar,50){Value=list[0].FunctionName},
                new SqlParameter("@NewFunctionJurisdiction",SqlDbType.Bit){Value=list[0].FunctionJurisdiction}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }
    }
}
