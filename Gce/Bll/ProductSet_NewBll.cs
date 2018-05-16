using Gce_Dal;
using Gce_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gce_Bll
{
    public class ProductSet_NewBll
    {
        ProductSet_NewDal productSeyDal = new ProductSet_NewDal();
        /// <summary>
        /// 查询产能配置表明细
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<ProductSet_New> selectProductSet_NewBll(string SQLCommand)
        {
            return productSeyDal.selectProductSet_NewDal(SQLCommand);
        }
        /// <summary>
        /// 插入产能配置表
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool insertProductSet_NewBll(List<ProductSet_New> list, string SQLCommand)
        {
            if (productSeyDal.insertProductSet_NewDal(list, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 检查产能配置表
        /// </summary>
        /// <param name="ProductClass"></param>
        /// <param name="Stations"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool checkProductSet_NewBll(string ProductClass, string Stations, string SQLCommand)
        {
            if (productSeyDal.checkProductSet_NewDal(ProductClass, Stations, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新产能配置表
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool updateProductSet_NewBll(List<ProductSet_New> list, string SQLCommand)
        {
            if (productSeyDal.updateProductSet_NewDal(list, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除产能配置表中的数据
        /// </summary>
        /// <param name="ProductClass"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool deleteProductSet_NewBll(string ProductClass, string SQLCommand)
        {
            if (productSeyDal.deleteProductSet_NewDal(ProductClass, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 根据生产类型删除产能配置表中的
        /// </summary>
        /// <param name="ProductClass"></param>
        /// <param name="Stations"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool deleteProductSet_NewStationsBll(string ProductClass, string Stations, string SQLCommand)
        {
            if (productSeyDal.deleteProductSet_NewStationsDal(ProductClass, Stations, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 根据类型查询产能配置表
        /// </summary>
        /// <param name="ProductClass"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<ProductSet_New> selectProductClassBll(string ProductClass, string SQLCommand)
        {
            return productSeyDal.selectProductClassDal(ProductClass, SQLCommand);
        }
        /// <summary>
        /// 拿到生产类型的键值队集合
        /// </summary>
        /// <param name="ZhiDan"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public Dictionary<string, double> selectProductSet_NewForProductClassBll(double Number,string ZhiDan, string SQLCommand)
        {
            return GetDicList(productSeyDal.selectProductSet_NewForProductClassDal(ZhiDan, SQLCommand),Number);
        }
        /// <summary>
        /// 集合分类
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        Dictionary<string, double> GetDicList(List<ProductSet_New> list,double Number)
        {
            Dictionary<string, double> dic = new Dictionary<string, double>();
            foreach (ProductSet_New item in list)
            {
                if (item.EfficiencyQuantity != null)
                {
                    dic.Add(item.Stations,GetNumber( Number ,item.EfficiencyQuantity));
                }
                else
                {
                    dic.Add("", 0);
                }
            }

            return dic;
        }

        double GetNumber(double Number,string eff)
        {
            double db = 0;

            db = Number / Convert.ToDouble(eff);            

            return Convert.ToDouble(db.ToString("F2"));
        }
    }
}
