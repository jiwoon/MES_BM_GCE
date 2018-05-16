using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gce_Model;
using Gce_Dal;

namespace Gce_Bll
{
    public class PWarehouseTable_DetailedBll
    {
        PWarehouseTable_DetailedDal pwarDal = new PWarehouseTable_DetailedDal();
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="pware"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool insertPWarehouseTable_DetailedBll(PWarehouseTable_Detailed pware, string SQLCommand)
        {
            if (pwarDal.insertPWarehouseTable_DetailedDal(pware, SQLCommand) > 0)
            {
                return true;
            }
            else return false;
        }
        /// <summary>
        /// 查询仓库剩余数量
        /// </summary>
        /// <param name="MaterialName"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<PickingOutModel> PWarehouseTable_DetailedPWarehouseTable_PickingOutSUMTop1Bll(string MaterialName, string SQLCommand)
        {
            return pwarDal.PWarehouseTable_DetailedPWarehouseTable_PickingOutSUMTop1Dal(MaterialName, SQLCommand);
        }
        /// <summary>
        ///  查询仓库内货物名称
        /// </summary>
        /// <param name="MaterialName"></param>
        /// <param name="MaterialCode"></param>
        /// <param name="SupplierName"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<string> selectPWarehouseTable_DetailedMaterialNameBll(string MaterialName, string MaterialCode, string SupplierName, string SQLCommand)
        {
            return pwarDal.selectPWarehouseTable_DetailedMaterialNameDal(MaterialName, MaterialCode, SupplierName, SQLCommand);
        }
        /// <summary>
        /// 查询数量
        /// </summary>
        /// <param name="MaterialName"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public ck_StockModel selectPWarehouseTable_DetailedProductQuantityBll(string MaterialName, string SQLCommand)
        {
            return pwarDal.selectPWarehouseTable_DetailedProductQuantityDal(MaterialName, SQLCommand);
        }
        /// <summary>
        /// 入库明细
        /// </summary>
        /// <param name="MaterialName"></param>
        /// <param name="MaterialCode"></param>
        /// <param name="SupplierName"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<PWarehouseTable_Detailed> selectPWarehouseTable_DetailedBll(string MaterialName, string MaterialCode, string SupplierName,DateTime beginTime,DateTime endTime, string SQLCommand)
        {
            return pwarDal.selectPWarehouseTable_DetailedDal(MaterialName, MaterialCode, SupplierName, beginTime, endTime, SQLCommand);
        }
    }
}
