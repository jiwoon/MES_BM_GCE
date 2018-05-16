using System;
using System.Collections.Generic;
using System.Linq;
using Gce_Model;
using Gce_Dal;
using System.Text;

namespace Gce_Bll
{
    public class ProductionLinePCBll
    {
        ProductionLinePCDal pcd=new ProductionLinePCDal();
        public List<ProductionLinePC> selectProductionLinePCBll(string LineName,string SQLCommand)
        {
            return pcd.selectProductionLinePCDal(LineName, SQLCommand);
        }

        public bool insertProductionLinePCBll(List<ProductionLinePC> list,string SQLCommand)
        {
            if (pcd.insertProductionLinePCDal(list, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool selectCountProductionLinePCBll(List<ProductionLinePC> list, string SQLCommand)
        {
            if (pcd.selectCountProductionLinePCDal(list, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新ProductionLinePCBll
        /// </summary>
        /// <param name="pc">未修改前PC名</param>
        /// <param name="list">修改后数据集合</param>
        /// <param name="SQLCommand">SQL命令</param>
        /// <returns></returns>
        public bool UpdateProductionLinePCBll(string pc, List<ProductionLinePC> list, string SQLCommand)
        {
            if (pcd.UpdateProductionLinePCDal(pc, list, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<string> selectProductionLinePCBll1(string LineName, string SQLCommand)
        {
            List<string> list = new List<string>();
             List<ProductionLinePC> listppc = new List<ProductionLinePC>();
             listppc = pcd.selectProductionLinePCDal(LineName, SQLCommand);

             if (!(listppc.Count > 0))
             {
                 return new List<string>();
             }
             foreach (ProductionLinePC item in listppc)
             {
                 list.Add(item.Pcname);
             }
             return list;
        }

        /// <summary>
        /// 截取计算机名称
        /// </summary>
        /// <param name="str">计算机名包含IP地址</param>
        /// <returns>string</returns>
        public string getComputerName(string str)
        {
            string str1 = "";
            if (str == "" || str == null)
            {
                return "";
            }
            int i = str.IndexOf("IP1:");
            if (i > 0)
            {
                str1 = str.Substring(0, i);
            }
            return str1;
        }

    }
}
