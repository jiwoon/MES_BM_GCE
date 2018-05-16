using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gce_Model;
using System.Data;
using System.Data.SqlClient;

namespace Gce_Dal
{
    public class PAbnormalInputDal
    {
        /// <summary>
        /// 插入异常录入表
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int insertPAbnormalInputDal(List<PAbnormalInput> list,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@zhidan",SqlDbType.VarChar,100){Value=list[0].ZhiDan},
                new SqlParameter("@school",SqlDbType.VarChar,20){Value=list[0].SchoolPersonnel},
                new SqlParameter("@company",SqlDbType.VarChar,80){Value=list[0].CompanyName},
                new SqlParameter("@line",SqlDbType.VarChar,80){Value=list[0].LineOf},
                new SqlParameter("@workstation",SqlDbType.VarChar,50){Value=list[0].WorkStation},
                new SqlParameter("@problem",SqlDbType.VarChar,200){Value=list[0].ProblemDescription},
                new SqlParameter("@exception",SqlDbType.VarChar,80){Value=list[0].ExceptionTypes},
                new SqlParameter("@node",SqlDbType.VarChar,200){Value=list[0].Node1}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }

        /// <summary>
        /// 检测是否存在单号
        /// </summary>
        /// <param name="Zhidan"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int CheckedPAbnormalInputDal(string Zhidan, string problem, string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@zhidan",SqlDbType.VarChar,100){Value=Zhidan},
                new SqlParameter("@problem",SqlDbType.VarChar,200){Value=problem}
            };

            return Convert.ToInt32(SQLhelp.ExecuteScalar(sql, CommandType.Text, pms));
        }
        /// <summary>
        /// 更新异常录入信息
        /// </summary>
        /// <param name="oldZhidan"></param>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int UpdatePAbnormalInputDal(int ID, List<PAbnormalInput> list, string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@zhidan",SqlDbType.VarChar,100){Value=list[0].ZhiDan},
                new SqlParameter("@school",SqlDbType.VarChar,20){Value=list[0].SchoolPersonnel},
                new SqlParameter("@company",SqlDbType.VarChar,80){Value=list[0].CompanyName},
                new SqlParameter("@line",SqlDbType.VarChar,80){Value=list[0].LineOf},
                new SqlParameter("@workstation",SqlDbType.VarChar,50){Value=list[0].WorkStation},
                new SqlParameter("@problem",SqlDbType.VarChar,200){Value=list[0].ProblemDescription},
                new SqlParameter("@exception",SqlDbType.VarChar,80){Value=list[0].ExceptionTypes},
                new SqlParameter("@node",SqlDbType.VarChar,200){Value=list[0].Node1},
                new SqlParameter("@id",SqlDbType.VarChar,100){Value=ID}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }
        /// <summary>
        /// 多条件查询PAbnormalInput表
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns> 
        public List<PAbnormalInput> selectPAbnormalInputDal(List<PAbnormalInput> list,DateTime beginTime,DateTime endTime,string SQLCommand)
        {
            List<PAbnormalInput> rlist = new List<PAbnormalInput>();

            StringBuilder sql = new StringBuilder(SQLhelp.GetSQLCommand(SQLCommand));
            List<SqlParameter> listsqlpar = new List<SqlParameter>();
            List<string> whereList = new List<string>();

            if (list.Count > 0)
            { 
                if (list[0].ZhiDan.Length > 0)
                {
                    whereList.Add(" ZhiDan=@zhidan ");
                    listsqlpar.Add(new SqlParameter("@zhidan", SqlDbType.VarChar, 100) { Value = list[0].ZhiDan });
                }
                if (list[0].SchoolPersonnel.Length > 0)
                {
                    whereList.Add(" SchoolPersonnel=@school ");
                    listsqlpar.Add(new SqlParameter("@school", SqlDbType.VarChar, 20) { Value = list[0].SchoolPersonnel });
                }
                if (list[0].CompanyName.Length > 0)
                {
                    whereList.Add(" CompanyName=@company ");
                    listsqlpar.Add(new SqlParameter("@company", SqlDbType.VarChar, 80) { Value = list[0].CompanyName });
                }
                if (list[0].LineOf.Length > 0)
                {
                    whereList.Add(" LineOf=@lineof ");
                    listsqlpar.Add(new SqlParameter("@lineof", SqlDbType.VarChar, 80) { Value = list[0].LineOf });
                }
                if (list[0].WorkStation.Length > 0)
                {
                    whereList.Add(" WorkStation=@workstation ");
                    listsqlpar.Add(new SqlParameter("@workstation", SqlDbType.VarChar, 50) { Value = list[0].WorkStation });
                }
                if (list[0].ProblemDescription.Length > 0)
                {
                    whereList.Add(" ProblemDescription=@proble ");
                    listsqlpar.Add(new SqlParameter("@proble", SqlDbType.VarChar, 200) { Value = list[0].ProblemDescription });
                }
                if (list[0].ExceptionTypes.Length > 0)
                {
                    whereList.Add(" ExceptionTypes=@exception ");
                    listsqlpar.Add(new SqlParameter("@exception", SqlDbType.VarChar, 80) { Value = list[0].ExceptionTypes });
                }
                if (list[0].Node1.Length > 0)
                {
                    whereList.Add(" Node1=@node ");
                    listsqlpar.Add(new SqlParameter("@node", SqlDbType.VarChar, 200) { Value = list[0].Node1 });
                }

                if (list[0].ID > 0)
                {
                    whereList.Add(" ID=@id ");
                    listsqlpar.Add(new SqlParameter("@id", SqlDbType.Int) { Value = list[0].ID });
                }

            }
                if (beginTime.Year.ToString() != "1")
                {
                    whereList.Add(" UpdateTime>=@time ");
                    listsqlpar.Add(new SqlParameter("@time", SqlDbType.DateTime) { Value = beginTime });
                }
                if (endTime.Year.ToString() != "1")
                {
                    whereList.Add(" UpdateTime<=@time1 ");
                    listsqlpar.Add(new SqlParameter("@time1", SqlDbType.DateTime) { Value = endTime });
                }
                if (whereList.Count > 0)
                {
                    sql.Append(" where ");//只要有查询条件，就拼接一个where
                    //然后把后面的查询条件连起来
                    sql.Append(string.Join(" and ", whereList));
                    sql.Append(" order by UpdateTime ");
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
                                    rlist.Add(new PAbnormalInput()
                                    {
                                        ID=reader.GetInt32(0),
                                        ZhiDan=reader.GetString(1),
                                        SchoolPersonnel=reader.GetString(2),
                                        CompanyName=reader.GetString(3),
                                        LineOf=reader.GetString(4),
                                        WorkStation=reader.GetString(5),
                                        ProblemDescription=reader.GetString(6),
                                        ExceptionTypes=reader.GetString(7),
                                        Node1=reader.GetString(8)
                                    });
                                }
                            }
                            return rlist;
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
                                    rlist.Add(new PAbnormalInput()
                                    {
                                        ZhiDan = reader.GetString(0),
                                        SchoolPersonnel = reader.GetString(1),
                                        CompanyName = reader.GetString(2),
                                        LineOf = reader.GetString(3),
                                        WorkStation = reader.GetString(4),
                                        ProblemDescription = reader.GetString(5),
                                        ExceptionTypes = reader.GetString(6),
                                        Node1 = reader.GetString(7)
                                    });
                                }
                            }
                            return rlist;
                        }
                    }
                    catch
                    {
                        throw;
                    }
                }
               
        }
        //删除
        public int deletePAbnormalInputDal(int ID,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@id",SqlDbType.Int){Value=ID}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }
    }
}
