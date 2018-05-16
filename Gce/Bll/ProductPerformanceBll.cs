using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Gce_Dal;

namespace Bll
{
    public class ProductPerformanceBll
    {
        ProductPerformanceDal ppd = new ProductPerformanceDal();
        /// <summary>
        /// 返回ProductPerformance数据集合
        /// </summary>
        /// <param name="SQLCommandTest"></param>
        /// <returns></returns>
        public List<ProductPerformance> GetProductPerformanceBll(string order, string SoftModel, bool flag, DateTime timeBegin, DateTime timeEnd, string SQLCommand)
        {
            return ppd.GetProductPerformanceDal(order,SoftModel,flag, timeBegin, timeEnd, SQLCommand);
        }
    }
}
