using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gce_Model;
using Gce_Dal;

namespace Gce_Bll
{
    public class PWarehouseTable_ReturnGoodsBll
    {
        PWarehouseTable_ReturnGoodsDal pwareDal = new PWarehouseTable_ReturnGoodsDal();
        /// <summary>
        /// 退货表插入
        /// </summary>
        /// <param name="pware"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool insertPWarehouseTable_ReturnGoodsBll(PWarehouseTable_ReturnGoods pware, string SQLCommand)
        {
            if (pwareDal.insertPWarehouseTable_ReturnGoodsDal(pware, SQLCommand) > 0)
            {
                return true;
            }
            else return false;
        }
    }
}
