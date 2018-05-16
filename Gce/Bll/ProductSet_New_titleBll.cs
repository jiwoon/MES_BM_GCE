using Gce_Dal;
using Gce_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gce_Bll
{
    public class ProductSet_New_titleBll
    {
        ProductSet_New_titleDal psnd = new ProductSet_New_titleDal();

        public List<ProductSet_New_title> selectProductSet_New_titleBll(string SQLCommand)
        {
            return psnd.selectProductSet_New_titleDal(SQLCommand);
        }
        /// <summary>
        /// 检查产能设置抬头表
        /// </summary>
        /// <param name="ProductClass"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool checkProductSet_New_titleBll(string ProductClass, string SQLCommand)
        {
            if (psnd.checkProductSet_New_titleDal(ProductClass, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 插入产能配置抬头表
        /// </summary>
        /// <param name="ProductClass"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool insertProductSet_New_titleBll(string ProductClass, string SQLCommand)
        {
            if (psnd.insertProductSet_New_titleDal(ProductClass, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除产能配置抬头表中的数据
        /// </summary>
        /// <param name="ProductClass"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool deleteProductSet_New_titleBll(string ProductClass, string SQLCommand)
        {
            if (psnd.deleteProductSet_New_titleDal(ProductClass, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 查询产能配置抬头表Top1
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public string selectProductSet_New_titleTop1Bll(string SQLCommand)
        {
            return psnd.selectProductSet_New_titleTop1Dal(SQLCommand);
        }
    }
}
