using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gce_Dal;
using Model;

namespace Gce_Bll
{
    public class ProductionEfficiencySummaryBll
    {
        ProductionEfficiencySummaryDal pesd = new ProductionEfficiencySummaryDal();
        public int InsertProductionEfficiencySummaryBll(List<ProductionEfficiencyModel> list, string SQLCommand)
        {
            return pesd.InsertProductionEfficiencySummaryDal(list, SQLCommand);
        }
    }
}
