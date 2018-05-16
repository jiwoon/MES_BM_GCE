using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Gce_Dal
{
    public class ProductSetDal
    {
        /// <summary>
        /// 加载ProductSet表
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<ProductSet> SelectProductSetDal(string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            List<ProductSet> list = new List<ProductSet>();

            List<string> Column_namelist = new List<string>();
           // Column_namelist = this.selectColumn_nameDal("selectColumn_name");//读取表列名
            try
            {                
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text))
                {
                    if (reader.HasRows)
                    { 
                        while(reader.Read())
                        {
                            list.Add(new ProductSet() { 
                                ProductClass=reader.IsDBNull(1)?"":reader.GetString(1),
                                station1=reader.IsDBNull(2)?"":reader.GetString(2),
                                Numberof1=reader.IsDBNull(3)?"":reader.GetString(3),
                                Id=reader.IsDBNull(0)?0:reader.GetInt32(0)
                            });
                        }
                        return list;
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
        /// 向ProductSet表插入一条数据
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int InsertProductSetDal(List<ProductSet> list,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@pc",SqlDbType.VarChar,50){Value=list[0].ProductClass},
                new SqlParameter("@s1",SqlDbType.VarChar,200){Value=list[0].station1},
                new SqlParameter("@n1",SqlDbType.VarChar,200){Value=list[0].Numberof1}
            };
            
            try
            {
                return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
            }
            catch
            {
                return -1;
            }
        }
        /// <summary>
        /// 向ProductSet表修改一条数据
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int UpdateProductSetBll(List<ProductSet> list,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
              new SqlParameter("@pc",SqlDbType.VarChar,80){Value=list[0].ProductClass},
              new SqlParameter("@s1",SqlDbType.VarChar,200){Value=list[0].station1},
              new SqlParameter("@n1",SqlDbType.VarChar,200){Value=list[0].Numberof1},
              new SqlParameter("@id",SqlDbType.Int){Value=list[0].Id}
            };
            try
            {
                return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
            }
            catch
            {
                return -1;
            }
        }
        public int DaleteProductSetDal(int i,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@id",SqlDbType.Int){Value=i}
            };
            try
            {
                return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 查询ProductSet中的ProductClass列
        /// </summary>
        /// <param name="SQLCommand">SQL命令</param>
        /// <returns>List<ProductSet></returns>
        public List<ProductSet> selectProductClassDal(string SQLCommand, string txt_productClass)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            //if (txt_productClass != "")
            //{
            //    sql += " where ProductClass like " + "'%" + txt_productClass + "%'";
            //}
            List<ProductSet> list = new List<ProductSet>();

            SqlParameter[] pms = new SqlParameter[] { 
                new SqlParameter("@pc",SqlDbType.VarChar,50){Value=txt_productClass}
            };
            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text,pms))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new ProductSet()
                            {
                                ProductClass = reader.GetString(1),
                                station1=reader.IsDBNull(2)?"":reader.GetString(2),
                                Numberof1=reader.IsDBNull(3)?"":reader.GetString(3),
                                Id = reader.GetInt32(0)
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
        /// 查询ProductSet表列名
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        private List<string> selectColumn_nameDal(string SQLCommand)
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

        public List<ProductSet> SelectProductTop1Dal(string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            List<ProductSet> list = new List<ProductSet>();
            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new ProductSet()
                            {
                                ProductClass = reader.GetString(1),
                                station1 = reader.IsDBNull(2) ? "" : reader.GetString(2),
                                Numberof1 = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                Id = reader.GetInt32(0)
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
    