using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gce_Model;
using System.Data;
using System.Data.SqlClient;

namespace Gce_Dal
{
    public class PEncodingSettingDal
    {
        /// <summary>
        /// 查询异常配置表
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<PEncodingSetting> selectPEncodingSettingDal(string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            List<PEncodingSetting> list = new List<PEncodingSetting>();

            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new PEncodingSetting()
                            {
                                BarcodeEncoding=reader.GetString(0),
                                ProblemDescription=reader.GetString(1),
                                ES_ExceptionTypes=reader.GetString(2)
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
        /// 插入异常配置表
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int insertPEncodingSettingDal(List<PEncodingSetting> list, string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@be",SqlDbType.VarChar,100){Value=list[0].BarcodeEncoding},
                new SqlParameter("@pd",SqlDbType.VarChar,200){Value=list[0].ProblemDescription},
                new SqlParameter("@eet",SqlDbType.VarChar,80){Value=list[0].ES_ExceptionTypes}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }
        /// <summary>
        /// 检查是否已存在编码 
        /// </summary>
        /// <param name="barcodeEncoding"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int checkedPEncodingSettingDal(string barcodeEncoding,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@be",SqlDbType.VarChar,100){Value=barcodeEncoding}
            };

            return Convert.ToInt32(SQLhelp.ExecuteScalar(sql, CommandType.Text, pms));
        }
        /// <summary>
        /// 删除异常配置
        /// </summary>
        /// <param name="BarcodeEncoding"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int deletePEncodingSettingDal(string BarcodeEncoding, string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@be",SqlDbType.VarChar,100){Value=BarcodeEncoding}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }
        /// <summary>
        /// 按主键为条件查询异常配置表
        /// </summary>
        /// <param name="BarcodeEncoding"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<PEncodingSetting> ConditionsSelectPEncodingSettingDal(string BarcodeEncoding,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            List<PEncodingSetting> list = new List<PEncodingSetting>();

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@be",SqlDbType.VarChar,100){Value=BarcodeEncoding}
            };

            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text, pms))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new PEncodingSetting()
                            {
                                BarcodeEncoding=reader.GetString(0),
                                ProblemDescription=reader.GetString(1),
                                ES_ExceptionTypes=reader.GetString(2)
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
