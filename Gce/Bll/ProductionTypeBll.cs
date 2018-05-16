using Gce_Dal;
using Gce_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gce_Bll
{
    public class ProductionTypeBll
    {
        ProductionTypeDal ptd = new ProductionTypeDal();
        /// <summary>
        /// 查询工位表
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<ProductionType> selectProductionTypeBll(string SQLCommand)
        {
            return ptd.selectProductionTypeDal(SQLCommand);
        }
        /// <summary>
        /// 标记工位的上班类型
        /// </summary>
        /// <param name="CompanyName">公布名称</param>
        /// <param name="producttype">工位类型</param>
        /// <param name="SQLCommand">SQL命令</param>
        public void updateProductionTypeOnWorkTimeTypeBll(string CompanyName, string producttype, string SQLCommand)
        {
            ptd.updateProductionTypeOnWorkTimeTypeDal(CompanyName,producttype,SQLCommand);
        }

        public List<string> selectProductionTypeProductTypeBll(string CompanyName, string SQLCommand)
        {
            return ptd.selectProductionTypeProductTypeDal(CompanyName, SQLCommand);
        }

        /// <summary>
        /// 查询生产类型
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<string> selectProductTypeBll(string SQLCommand)
        {
            return ptd.selectProductTypeDal(SQLCommand);
        }
        /// <summary>
        /// 根据公司名查找工位名
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<string> selectProductionTypeOnWorkTimeTypeBll(string OnWorkTimeType, string SQLCommand)
        {
            return ptd.selectProductionTypeOnWorkTimeTypeDal(OnWorkTimeType, SQLCommand);
        }
    }
}
