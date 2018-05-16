using Gce_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Gce_Dal
{
    public class PFunctionMenuDal
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<PFunctionMenu> selectPFunctionMenuFID0Dal(string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            List<PFunctionMenu> list = new List<PFunctionMenu>();
            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new PFunctionMenu()
                            {
                                ID = reader.GetString(0),
                                FunctionName = reader.GetString(1),
                                FID = reader.GetString(2)
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

        public List<PFunctionMenu> selectPFunctionMenuFID00Dal(string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            List<PFunctionMenu> list = new List<PFunctionMenu>();

            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new PFunctionMenu()
                            {
                                ID=reader.GetString(0),
                                FunctionName=reader.GetString(1),
                                FID=reader.GetString(2)
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
