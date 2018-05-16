using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gce_Model;
using System.Data.SqlClient;
using System.Data;

namespace Gce_Dal
{
    public class ProductionLinePC_titleDal
    {
        public List<ProductionLinePC_title> selectProductionLinePC_titleDal(string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            List<ProductionLinePC_title> list = new List<ProductionLinePC_title>();
            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new ProductionLinePC_title()
                            {
                                CompanyName = reader.IsDBNull(1) ? "" : reader.GetString(1),
                                LineName = reader.IsDBNull(0) ? "" : reader.GetString(0)
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
        public int insertProductionLinePC_titleDal(List<ProductionLinePC_title> list, string SQLCommand, string newLineName)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            SqlParameter[] pms;
            if (newLineName == "")
            {
                pms = new SqlParameter[]{
                new SqlParameter("@ln",SqlDbType.VarChar,80){Value=list[0].LineName},
                new SqlParameter("@cn",SqlDbType.VarChar,50){Value=list[0].CompanyName}
            };
            }
            else
            {
                pms = new SqlParameter[]{
                new SqlParameter("@ln",SqlDbType.VarChar,80){Value=list[0].LineName},
                new SqlParameter("@cn",SqlDbType.VarChar,50){Value=list[0].CompanyName},
                new SqlParameter("@nln",SqlDbType.VarChar,50){Value=newLineName}
            };
            }

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }

        public List<string> selectProductionLinePC_titleLineNameDal(string CompanyName,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            List<string> list = new List<string>();

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@companyname",SqlDbType.VarChar,50){Value=CompanyName}
            };
            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text, pms))
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

        public int CheckProductionLinePC_titleDal(string LineName,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
            
                new SqlParameter("@line",SqlDbType.VarChar,80){Value=LineName}
            };

            return Convert.ToInt32( SQLhelp.ExecuteScalar(sql, CommandType.Text, pms));
        }
    }
}
