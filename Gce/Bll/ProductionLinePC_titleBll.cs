using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gce_Dal;
using Gce_Model;

namespace Gce_Bll
{
    public class ProductionLinePC_titleBll
    {
        ProductionLinePC_titleDal pc_dal = new ProductionLinePC_titleDal();

        public List<ProductionLinePC_title> selectProductionLinePC_titleBll(string SQLCommand)
        {
            return pc_dal.selectProductionLinePC_titleDal(SQLCommand);
        }
        /// <summary>
        /// 插入数据到ProductionLinePC_title表
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool insertProductionLinePC_titleBll(List<ProductionLinePC_title> list, string SQLCommand, string newLineName)
        {
            if (pc_dal.insertProductionLinePC_titleDal(list, SQLCommand,newLineName) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<string> selectProductionLinePC_titleLineNameBll(string CompanyName, string SQLCommand)
        {
            return pc_dal.selectProductionLinePC_titleLineNameDal(CompanyName, SQLCommand);
        }

        public int CheckProductionLinePC_titleBll(string LineName,string SQLCommand)
        {
            return pc_dal.CheckProductionLinePC_titleDal(LineName, SQLCommand);
        }
    }
}
