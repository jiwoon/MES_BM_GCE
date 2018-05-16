using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gce_Model;
using System.Data.SqlClient;
using System.Data;

namespace Gce_Dal
{
    public class ProductionSplitTimeRecordDal
    {

        public List<PeriodTimeTypeModel> selectPeriodTimeTypeModelDal(string SQLCommand,DateTime beginTime,DateTime endTime,bool flag)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            List<PeriodTimeTypeModel> list = new List<PeriodTimeTypeModel>();

            SqlParameter[] pms = new SqlParameter[] { 
                new SqlParameter("@begintime",SqlDbType.DateTime){Value=beginTime},
                new SqlParameter("@endtime",SqlDbType.DateTime){Value=endTime},
                new SqlParameter("@f",SqlDbType.Bit){Value=flag}
            };
            try
            {
                using(SqlDataReader reader=SQLhelp.ExecuteReader(sql,CommandType.Text,pms))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new PeriodTimeTypeModel()
                            {
                                ZhiDan=reader.IsDBNull(0)?"":reader.GetString(0),
                                Computer = GetComputerName(reader.IsDBNull(1) ? "" : reader.GetString(1)),
                                TestTime=reader.GetDateTime(2),
                                SoftModel=reader.IsDBNull(3)?"":reader.GetString(3)
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
        /// 截取计算机名，去除IP地址
        /// </summary>
        /// <param name="ComputerName"></param>
        /// <returns></returns>
        public string GetComputerName(string ComputerName)
        {
            if (ComputerName == "")
            {
                return "";
            }

            int i = ComputerName.IndexOf("IP1:");
            if (i > 0)
            {
                return ComputerName.Substring(0, i);
            }
            else
            {
                return ComputerName;
            }
        }
    }
}
