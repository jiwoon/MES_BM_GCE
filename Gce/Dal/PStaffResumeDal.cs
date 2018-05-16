using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gce_Model;
using System.Data;
using System.Data.SqlClient;

namespace Gce_Dal
{
    public class PStaffResumeDal
    {
        /// <summary>
        /// 检查姓名工号是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <param name="worknumber"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int checkedPStaffResumeDal(string name,string worknumber,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@name",SqlDbType.VarChar,20){Value=name},
                new SqlParameter("@worknumber",SqlDbType.VarChar,50){Value=worknumber}
            };

            return Convert.ToInt32(SQLhelp.ExecuteScalar(sql, CommandType.Text, pms));
        }
        /// <summary>
        /// 插入一条员工信息
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int insertPStaffResumeDal(List<PStaffResume> list,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@name",SqlDbType.VarChar,20){Value=list[0].Name},
                new SqlParameter("@worknumber",SqlDbType.VarChar,50){Value=list[0].WorkNumber},
                new SqlParameter("@gender",SqlDbType.VarChar,4){Value=list[0].Gender},
                new SqlParameter("@age",SqlDbType.VarChar,6){Value=list[0].Age},
                new SqlParameter("@worktype",SqlDbType.VarChar,80){Value=list[0].WorkTypes},
                new SqlParameter("@levels",SqlDbType.VarChar,50){Value=list[0].Levels},
                new SqlParameter("@factorytime",SqlDbType.DateTime){Value=list[0].FactoryTime},
                new SqlParameter("@companyname",SqlDbType.VarChar,120){Value=list[0].CompanyName}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }
        /// <summary>
        /// 更新员工信息
        /// </summary>
        /// <param name="oldName"></param>
        /// <param name="oldWorkNumber"></param>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int updatePStaffResumeDal(string oldName,string oldWorkNumber,List<PStaffResume> list,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@name",SqlDbType.VarChar,20){Value=list[0].Name},
                new SqlParameter("@worknumber",SqlDbType.VarChar,50){Value=list[0].WorkNumber},
                new SqlParameter("@gender",SqlDbType.VarChar,4){Value=list[0].Gender},
                new SqlParameter("@age",SqlDbType.VarChar,6){Value=list[0].Age},
                new SqlParameter("@worktype",SqlDbType.VarChar,80){Value=list[0].WorkTypes},
                new SqlParameter("@levels",SqlDbType.VarChar,50){Value=list[0].Levels},
                new SqlParameter("@factorytime",SqlDbType.DateTime){Value=list[0].FactoryTime},
                new SqlParameter("@companyname",SqlDbType.VarChar,120){Value=list[0].CompanyName},
                new SqlParameter("@name1",SqlDbType.VarChar,20){Value=oldName},
                new SqlParameter("@worknumber1",SqlDbType.VarChar,50){Value=oldWorkNumber}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }
        /// <summary>
        /// 查询员工信息
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<PStaffResume> selectPStaffResumeDal(List<PStaffResume> list,string SQLCommand)
        {
            List<PStaffResume> returnList = new List<PStaffResume>();

            StringBuilder sql = new StringBuilder(SQLhelp.GetSQLCommand(SQLCommand));
            List<SqlParameter> listsqlpar = new List<SqlParameter>();
            List<string> whereList = new List<string>();
            if (list.Count > 0)
            {
                if (list[0].Name.Length > 0)
                {
                    whereList.Add(" Name=@name ");
                    listsqlpar.Add(new SqlParameter("@name", SqlDbType.VarChar, 20) { Value = list[0].Name });
                }
                if (list[0].WorkNumber.Length > 0)
                {
                    whereList.Add(" WorkNumber=@worknumber ");
                    listsqlpar.Add(new SqlParameter("@worknumber", SqlDbType.VarChar, 50) { Value = list[0].WorkNumber });
                }
                if (list[0].Gender.Length > 0)
                {
                    whereList.Add(" Gender=@gender ");
                    listsqlpar.Add(new SqlParameter("@gender", SqlDbType.VarChar, 4) { Value = list[0].Gender });
                }
                if (list[0].Age.Length > 0)
                {
                    whereList.Add(" Age=@age");
                    listsqlpar.Add(new SqlParameter("@age", SqlDbType.VarChar, 6) { Value = list[0].Age });
                }
                if (list[0].WorkTypes.Length > 0)
                {
                    whereList.Add(" WorkTypes=@worktypes ");
                    listsqlpar.Add(new SqlParameter("@worktypes", SqlDbType.VarChar, 80) { Value = list[0].WorkTypes });
                }
                if (list[0].Levels.Length > 0)
                {
                    whereList.Add(" Levels=@levels ");
                    listsqlpar.Add(new SqlParameter("@levels", SqlDbType.VarChar, 50) { Value = list[0].Levels });
                }
                if (list[0].FactoryTime.Year.ToString() != "1")
                {
                    whereList.Add(" FactoryTime=@factorytime ");
                    listsqlpar.Add(new SqlParameter("@factorytime", SqlDbType.DateTime) { Value = list[0].FactoryTime });
                }
                if (list[0].CompanyName.Length > 0)
                {
                    whereList.Add(" CompanyName=@companyname ");
                    listsqlpar.Add(new SqlParameter("@companyname", SqlDbType.VarChar, 120) { Value = list[0].CompanyName });
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
                                returnList.Add(new PStaffResume()
                                {
                                    Name = reader.IsDBNull(0) ? "" : reader.GetString(0),
                                    WorkNumber = reader.IsDBNull(1) ? "" : reader.GetString(1),
                                    Gender = reader.IsDBNull(2) ? "" : reader.GetString(2),
                                    Age = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                    WorkTypes = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                    Levels = reader.IsDBNull(5) ? "" : reader.GetString(5),
                                    FactoryTime = reader.GetDateTime(6),
                                    CompanyName =reader.GetString(7)
                                });
                            }
                        }
                        return returnList;
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
                                returnList.Add(new PStaffResume()
                                {
                                    Name = reader.IsDBNull(0) ? "" : reader.GetString(0),
                                    WorkNumber = reader.IsDBNull(1) ? "" : reader.GetString(1),
                                    Gender = reader.IsDBNull(2) ? "" : reader.GetString(2),
                                    Age = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                    WorkTypes = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                    Levels = reader.IsDBNull(5) ? "" : reader.GetString(5),
                                    FactoryTime = reader.GetDateTime(6),
                                    CompanyName = reader.GetString(7)
                                });
                            }
                        }
                        return returnList;
                    }
                }
                catch
                {
                    throw;
                }
            }
        }
        /// <summary>
        /// 删除员工信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="worknumber"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int deletePStaffResumeDal(string name,string worknumber,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@name",SqlDbType.VarChar,20){Value=name},
                new SqlParameter("@worknumber",SqlDbType.VarChar,50){Value=worknumber}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }
        /// <summary>
        /// 查询条件
        /// </summary>
        /// <param name="SQLComand"></param>
        /// <returns></returns>
        public List<selectConditionsQueryPStaffResumeModel> selectConditionsQueryPStaffResumeDal(string SQLComand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLComand);

            List<selectConditionsQueryPStaffResumeModel> list = new List<Gce_Model.selectConditionsQueryPStaffResumeModel>();
            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new selectConditionsQueryPStaffResumeModel()
                            {
                                Name=reader.GetString(0),
                                WorkNumber=reader.GetString(1)
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
        /// 查询条件
        /// </summary>
        /// <param name="SQLComand"></param>
        /// <returns></returns>
        public List<selectConditionsQueryPStaffResumeModel2> selectConditionsQueryPStaffResumeDal2(string SQLComand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLComand);

            List<selectConditionsQueryPStaffResumeModel2> list = new List<Gce_Model.selectConditionsQueryPStaffResumeModel2>();
            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new selectConditionsQueryPStaffResumeModel2()
                            {
                                Name = reader.GetString(0),
                                WorkNumber = reader.GetString(1),
                                CompanyName = reader.GetString(2)
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
