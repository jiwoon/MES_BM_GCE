using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gce_Model;
using System.Data;
using System.Data.SqlClient;

namespace Gce_Dal
{
    public class PWarehouseTable_titleDal
    {
        /// <summary>
        /// 根据FID查询
        /// </summary>
        /// <param name="FID"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<PWarehouseTable_title> selectPWarehouseTable_titleDal(string FID,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            List<PWarehouseTable_title> list = new List<PWarehouseTable_title>();

            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@FID",SqlDbType.VarChar,80){Value=FID}
            };

            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text, pms))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new PWarehouseTable_title()
                            {
                                ID=reader.GetString(0),
                                WarehouseName=reader.GetString(1),
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
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="PWtable"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int insertPWarehouseTable_titleDal(PWarehouseTable_title PWtable,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@ID",SqlDbType.VarChar,80){Value=PWtable.ID},
                new SqlParameter("@WarehouseName",SqlDbType.VarChar,100){Value=PWtable.WarehouseName},
                new SqlParameter("@FID",SqlDbType.VarChar,80){Value=PWtable.FID}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="PWtable"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int updatePWarehouseTable_titleDal(string ID, string WarehouseName, string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@ID",SqlDbType.VarChar,80){Value=ID},
                new SqlParameter("@WarehouseName",SqlDbType.VarChar,100){Value=WarehouseName}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int deletePWarehouseTable_titleDal(string ID,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms=new SqlParameter[]
            {
                new SqlParameter("@ID",SqlDbType.VarChar,80){Value=ID}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);

        }
    }
}
