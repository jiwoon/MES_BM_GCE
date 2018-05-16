using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gce_Model;
using Gce_Dal;


namespace Gce_Bll
{
    public class PWarehouseTable_PickingOutBll
    {
        PWarehouseTable_PickingOutDal pwareDal = new PWarehouseTable_PickingOutDal();
        /// <summary>
        /// 查询货物剩余数量
        /// </summary>
        /// <param name="MaterialName"></param>
        /// <param name="SQLCommand"></param> 
        /// <returns></returns>
        public int PWarehouseTable_DetailedPWarehouseTable_PickingOutSUMBll(string MaterialName, string SQLCommand)
        {
            return pwareDal.PWarehouseTable_DetailedPWarehouseTable_PickingOutSUMDal(MaterialName, SQLCommand);
        }
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="pware"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool insertPWarehouseTable_PickingOutBll(PWarehouseTable_PickingOut pware, string SQLCommand)
        {
            if (pwareDal.insertPWarehouseTable_PickingOutDal(pware, SQLCommand) > 0)
            {
                return true;
            }
            else return false;
        }
    }
}
