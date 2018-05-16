using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Gce_Model;
using Model;

namespace Gce_Dal
{
    public class ProductionEfficiencySummaryDal
    {
        /// <summary>
        /// 插入ProductionEfficiencySummary表
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int InsertProductionEfficiencySummaryDal(List<ProductionEfficiencyModel> list,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@ProductionClass",SqlDbType.VarChar,20){Value=list[0].ProductionClass},
                new SqlParameter("@ZhiDan",SqlDbType.VarChar,100){Value=list[0].Order},
                new SqlParameter("@SoftModel",SqlDbType.VarChar,100){Value=list[0].SoftModel},
                new SqlParameter("@ProductClass",SqlDbType.VarChar,80){Value=list[0].ProductClass},
                new SqlParameter("@Hours",SqlDbType.Int){Value=list[0].Hours},
                new SqlParameter("@actualHours",SqlDbType.Int){Value=list[0].actualHours},
                new SqlParameter("@Ratio",SqlDbType.Float){Value=list[0].Ratio},
                new SqlParameter("@sumHours",SqlDbType.Float){Value=list[0].sumHours},
                new SqlParameter("@sum",SqlDbType.Int){Value=list[0].sum},
                new SqlParameter("@FailureRate",SqlDbType.Float){Value=list[0].FailureRate},
                new SqlParameter("@FailureNuber",SqlDbType.Int){Value=list[0].FailureNuber}
            };
            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }
    }
}
