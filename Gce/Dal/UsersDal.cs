using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gce_Model;
using System.Data.SqlClient;
using System.Data;

namespace Gce_Dal
{
    public class UsersDal
    {
        /// <summary>
        /// 登录查询
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="SQLCommand">SQL语句</param>
        /// <returns>List<Users></returns>
        public List<Users> UsersLoginDal(string username,string password,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            List<Users> list = new List<Users>();

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@username",SqlDbType.VarChar,50){Value=username},
                new SqlParameter("@password",SqlDbType.VarChar,80){Value=password}
            };
            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text, pms))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new Users()
                            {
                                UserName = reader.GetString(0),
                                UserPassword = reader.GetString(1),
                                systemAdimin = reader.GetBoolean(2),
                                Limite=reader.GetBoolean(3),
                                Department=reader.IsDBNull(4)?"":reader.GetString(4),
                                AddUser=reader.GetBoolean(5)
                            });
                        }
                    }
                }
                return list;
            }
            catch
            {
                throw;
            }

        }
        /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="SQLCommand">SQK命令</param>
        /// <returns>int</returns>
        public int checkUserNemeDal(string UserName,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@username",SqlDbType.VarChar,50){Value=UserName}
            };

            return (int)SQLhelp.ExecuteScalar(sql, CommandType.Text, pms);
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int insertUsersDal(List<Users> list,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@UserName",SqlDbType.VarChar,50){Value=list[0].UserName},
                new SqlParameter("@UserPassword",SqlDbType.VarChar,100){Value=list[0].UserPassword},
                new SqlParameter("@systemAdimin",SqlDbType.Bit){Value=list[0].systemAdimin},
                new SqlParameter("@Limite",SqlDbType.Bit){Value=list[0].Limite},
                new SqlParameter("@Department",SqlDbType.VarChar,100){Value=list[0].Department},
                new SqlParameter("@AddUser",SqlDbType.Bit){Value=list[0].AddUser}
            };
            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Userpassword"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int UpdatePasswordDal(string UserName,string Userpassword,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@username",SqlDbType.VarChar,50){Value=UserName},
                new SqlParameter("@password",SqlDbType.VarChar,100){Value=Userpassword}
            };
            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }

        public List<string> selectDistinctPUsersDal(string SQLCommand)
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

        public List<Users> selectPUsersDal(string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            List<Users> list = new List<Users>();
            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new Users()
                            {
                                UserName=reader.GetString(0),
                                UserPassword=reader.GetString(1),
                                systemAdimin=reader.GetBoolean(2),
                                Limite=reader.GetBoolean(3),
                                Department=reader.IsDBNull(4)?"":reader.GetString(4),
                                AddUser=reader.GetBoolean(5)
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
        /// 修改用户表权限
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Limite"></param>
        /// <param name="SQLComman"></param>
        /// <returns></returns>
        public int updatePUsersDal(string UserName,bool Limite, string SQLComman)
        {
            string sql = SQLhelp.GetSQLCommand(SQLComman);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@UserName",SqlDbType.VarChar,50){Value=UserName},
                new SqlParameter("@Limite",SqlDbType.Bit){Value=Limite}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }
    }
}
