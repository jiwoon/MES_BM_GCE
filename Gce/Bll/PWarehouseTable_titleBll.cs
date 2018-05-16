using Gce_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gce_Dal;

namespace Gce_Bll
{
    public class PWarehouseTable_titleBll
    {
        PWarehouseTable_titleDal pwd = new PWarehouseTable_titleDal();
        /// <summary>
        /// 根据FID查询
        /// </summary>
        /// <param name="FID"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<PWarehouseTable_title> selectPWarehouseTable_titleBll(string FID, string SQLCommand)
        {
            return pwd.selectPWarehouseTable_titleDal(FID, SQLCommand);
        }
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="PWtable"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool insertPWarehouseTable_titleBll(PWarehouseTable_title PWtable, string SQLCommand)
        {
            if (pwd.insertPWarehouseTable_titleDal(PWtable, SQLCommand) > 0)
            {
                return true;
            }
            else return false;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="PWtable"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool updatePWarehouseTable_titleBll(string ID, string WarehouseName, string SQLCommand)
        {
            if (pwd.updatePWarehouseTable_titleDal(ID,WarehouseName, SQLCommand) > 0)
            {
                return true;
            }
            else return false;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool deletePWarehouseTable_titleBll(string ID, string SQLCommand)
        {
            if (pwd.deletePWarehouseTable_titleDal(ID, SQLCommand) > 0)
            {
                return true;
            }
            else return false;
        }
    }
}
