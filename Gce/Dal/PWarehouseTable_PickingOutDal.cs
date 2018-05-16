using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gce_Model;
using System.Data;
using System.Data.SqlClient;

namespace Gce_Dal
{
    public class PWarehouseTable_PickingOutDal
    {
        /// <summary>
        /// 查询货物剩余数量
        /// </summary>
        /// <param name="MaterialName"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int PWarehouseTable_DetailedPWarehouseTable_PickingOutSUMDal(string MaterialName,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@MaterialName",SqlDbType.VarChar,80){Value=MaterialName}
            };

            return (int)SQLhelp.ExecuteScalar(sql, CommandType.Text, pms);
        }
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="pware"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int insertPWarehouseTable_PickingOutDal(PWarehouseTable_PickingOut pware, string SQLCommand)
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
                new SqlParameter("@UserName",SqlDbType.VarChar,50){Value=pware.UserName},
            };

            try
            {
                return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
