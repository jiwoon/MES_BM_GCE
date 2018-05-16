using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gce_Model;
using Gce_Dal;

namespace Gce_Bll
{
    public class ProductionSplitTimeRecordBll
    {
        ProductionSplitTimeRecordDal pesd = new ProductionSplitTimeRecordDal();

        public List<PeriodTimeTypeModel> selectPeriodTimeTypeModelBll(string SQLCommand,DateTime beginTime,DateTime endTime,bool flag)
        {
            return pesd.selectPeriodTimeTypeModelDal(SQLCommand, beginTime, endTime,flag);
        }
    }
}
