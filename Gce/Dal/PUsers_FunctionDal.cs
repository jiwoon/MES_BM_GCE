using Gce_Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Gce_Dal
{
    public class PUsers_FunctionDal
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int insertPUsers_FunctionDal(List<PUsers_Function> list,string SQLCommand)
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
        public List<PUsers_Function> selectPUsers_FunctionDal(string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            List<PUsers_Function> list = new List<PUsers_Function>();

            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new PUsers_Function()
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

        public List<PUsers_Function> selectPUsers_FunctionLoginDal(string SQLCommand, string username)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            List<PUsers_Function> list = new List<PUsers_Function>();


            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@UserName",SqlDbType.VarChar,50){Value=username}
            };

            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text, pms))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new PUsers_Function()
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
        public int updatePUsers_FunctionDal(List<PUsers_Function> list,string SQLCommand)
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
    