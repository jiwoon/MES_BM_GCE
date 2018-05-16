using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gce_Model;
using System.Data;
using System.Data.SqlClient;

namespace Gce_Dal
{
    public class PWarehouseTable_DetailedDal
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="pware"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int insertPWarehouseTable_DetailedDal(PWarehouseTable_Detailed pware,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@PurchaseReceiptID",SqlDbType.VarChar,100){Value=pware.PurchaseReceiptID},
                new SqlParameter("@PurchaseNo",SqlDbType.VarChar,80){Value=pware.PurchaseNo},
                new SqlParameter("@SupplierName",SqlDbType.VarChar,80){Value=pware.SupplierName},
                new SqlParameter("@BatchNo",SqlDbType.VarChar,80){Value=pware.BatchNo},
                new SqlParameter("@MaterialCode",SqlDbType.VarChar,80){Value=pware.MaterialCode},
                new SqlParameter("@MaterialName",SqlDbType.VarChar,80){Value=pware.MaterialName},
                new SqlParameter("@MaterialSpecifications",SqlDbType.VarChar,80){Value=pware.MaterialSpecifications},
                new SqlParameter("@ProductQuantity",SqlDbType.Int){Value=pware.ProductQuantity},
                new SqlParameter("@note",SqlDbType.VarChar,200){Value=pware.note},
                new SqlParameter("@StorageAddress",SqlDbType.VarChar,255){Value=pware.StorageAddress},
                new SqlParameter("@UserName",SqlDbType.VarChar,50){Value=pware.UserName}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="MaterialName"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<PickingOutModel> PWarehouseTable_DetailedPWarehouseTable_PickingOutSUMTop1Dal(string MaterialName,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            List<PickingOutModel> list = new List<PickingOutModel>();

            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@MaterialName",SqlDbType.VarChar,80){Value=MaterialName}
            };
            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text, pms))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new PickingOutModel()
                            {
                                PurchaseNo = reader.IsDBNull(0) ? "" : reader.GetString(0),
                                SupplierName = reader.GetString(1),
                                BatchNo = reader.GetString(2),
                                MaterialCode = reader.GetString(3),
                                MaterialName = reader.GetString(4),
                                MaterialSpecifications = reader.GetString(5),
                                ProductQuantity = reader.GetInt32(6),
                                note = reader.GetString(7)
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
        /// 查询仓库内货物名称
        /// </summary>
        /// <param name="MaterialName"></param>
        /// <param name="MaterialCode"></param>
        /// <param name="SupplierName"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<string> selectPWarehouseTable_DetailedMaterialNameDal(string MaterialName,string MaterialCode,string SupplierName,string SQLCommand)
        {
            StringBuilder sql = new StringBuilder(SQLhelp.GetSQLCommand(SQLCommand));
            List<string> rlist = new List<string>();
            List<SqlParameter> listsqlpar = new List<SqlParameter>();
            List<string> whereList = new List<string>(); 

            if (MaterialName.Length > 0)
            {
                whereList.Add(" MaterialName=@MaterialName ");
                listsqlpar.Add(new SqlParameter("@MaterialName", SqlDbType.VarChar, 80) { Value = MaterialName }); 
            }
            if (MaterialCode.Length > 0)
            {
                whereList.Add(" MaterialCode=@MaterialCode ");
                listsqlpar.Add(new SqlParameter("@MaterialCode", SqlDbType.VarChar, 80) { Value = MaterialCode });
            }
            if (SupplierName.Length > 0)
            {
                whereList.Add(" SupplierName=@SupplierName ");
                listsqlpar.Add(new SqlParameter("@SupplierName", SqlDbType.VarChar, 80) { Value = SupplierName });
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
                                rlist.Add(reader.IsDBNull(0) ? "" : reader.GetString(0));
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
                                rlist.Add(reader.IsDBNull(0) ? "" : reader.GetString(0));
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
        /// <summary>
        /// 查询库存数量
        /// </summary>
        /// <param name="MaterialName"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public ck_StockModel selectPWarehouseTable_DetailedProductQuantityDal(string MaterialName,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            ck_StockModel list=new ck_StockModel();

            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@MaterialName",SqlDbType.VarChar,80){Value=MaterialName}
            };

            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text, pms))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.MaterialName=reader.IsDBNull(0)?"":reader.GetString(0);
                            list.ProductQuantity = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);                           
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

        public List<PWarehouseTable_Detailed> selectPWarehouseTable_DetailedDal(string MaterialName, string MaterialCode, string SupplierName,DateTime beginTime,DateTime endTime, string SQLCommand)
        {
            StringBuilder sql = new StringBuilder(SQLhelp.GetSQLCommand(SQLCommand));
            List<PWarehouseTable_Detailed> rlist = new List<PWarehouseTable_Detailed>();
            List<SqlParameter> listsqlpar = new List<SqlParameter>();
            List<string> whereList = new List<string>();

            if (MaterialName.Length > 0)
            {
                whereList.Add(" MaterialName=@MaterialName ");
                listsqlpar.Add(new SqlParameter("@MaterialName", SqlDbType.VarChar, 80) { Value = MaterialName });
            }
            if (MaterialCode.Length > 0)
            {
                whereList.Add(" MaterialCode=@MaterialCode ");
                listsqlpar.Add(new SqlParameter("@MaterialCode", SqlDbType.VarChar, 80) { Value = MaterialCode });
            }
            if (SupplierName.Length > 0)
            {
                whereList.Add(" SupplierName=@SupplierName ");
                listsqlpar.Add(new SqlParameter("@SupplierName", SqlDbType.VarChar, 80) { Value = SupplierName });
            }
            if (beginTime.Year.ToString() != "1")
            {
                whereList.Add(" UpdateTime>=@UpdateTime ");
                listsqlpar.Add(new SqlParameter("@UpdateTime", SqlDbType.DateTime) { Value = beginTime });
            }
            if (endTime.Year.ToString() != "1")
            {
                whereList.Add(" UpdateTime<=@UpdateTime1 ");
                listsqlpar.Add(new SqlParameter("@UpdateTime1", SqlDbType.DateTime) { Value = endTime });
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
                                rlist.Add(new PWarehouseTable_Detailed()
                                {
                                    PurchaseReceiptID=reader.GetString(0),
                                    PurchaseNo=reader.GetString(1),
                                    SupplierName=reader.GetString(2),
                                    BatchNo=reader.GetString(3),
                                    MaterialCode=reader.GetString(4),
                                    MaterialName=reader.GetString(5),
                                    MaterialSpecifications = reader.GetString(6),
                                    ProductQuantity=reader.GetInt32(7),
                                    note=reader.GetString(8),
                                    Updatetime=reader.GetDateTime(9),
                                    StorageAddress = reader.IsDBNull(10) ? "" : reader.GetString(10),
                                    UserName=reader.IsDBNull(11)?"":reader.GetString(11)
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
                                rlist.Add(new PWarehouseTable_Detailed()
                                {
                                    PurchaseReceiptID = reader.GetString(0),
                                    PurchaseNo = reader.GetString(1),
                                    SupplierName = reader.GetString(2),
                                    BatchNo = reader.GetString(3),
                                    MaterialCode = reader.GetString(4),
                                    MaterialName = reader.GetString(5),
                                    MaterialSpecifications = reader.GetString(6),
                                    ProductQuantity = reader.GetInt32(7),
                                    note = reader.GetString(8),
                                    Updatetime = reader.GetDateTime(9),
                                    StorageAddress = reader.IsDBNull(10) ? "" : reader.GetString(10),
                                    UserName = reader.IsDBNull(11) ? "" : reader.GetString(11)
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
    }
}
