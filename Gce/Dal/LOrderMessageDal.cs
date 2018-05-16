using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Gce_Dal
{
    public class LOrderMessageDal
    {
        /// <summary>
        /// 查询ZhiDan号总数
        /// </summary>
        /// <param name="strOrder"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public string selectSumZhiDanNumberDal(string strOrder,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            SqlParameter[] pms = new SqlParameter[]{
              new SqlParameter("@zhidan",SqlDbType.VarChar,100){Value="%" + strOrder + "%"}  
            };
            return Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text, pms));
        }
    }
}
