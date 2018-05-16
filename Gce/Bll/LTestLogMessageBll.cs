using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gce_Dal;
using Gce_Model;

namespace Bll
{
    public class LTestLogMessageBll
    {
        LTestLogMessageDal ltlmd = new LTestLogMessageDal();
        ProductionSplitTimeRecordDal pstrd = new ProductionSplitTimeRecordDal();
        /// <summary>
        /// 查询失败产品表失败数量
        /// </summary>
        /// <param name="order">zhidan号</param>
        /// <param name="timeBegin">开始时间</param>
        /// <param name="timeEnd">结束时间</param>
        /// <param name="SQLCommand">SQL语句</param>
        /// <returns>int</returns>
        public int selectLTestLogMessageBll(string order, string SoftModel, DateTime timeBegin, DateTime timeEnd, string SQLCommand)
        {
            int i = ltlmd.selectLTestLogMessageDal(order,SoftModel,timeBegin,timeEnd,SQLCommand);
            if (i > 0)
            {
                return i;
            }
            else
            {
                return 0;
            }
        }
        public List<BadMachineFrmModel> selectMessageBll(string order,DateTime begintime,DateTime endtime, string SQLCommand)
        {
            List<BadMachineFrmModel> list = new List<BadMachineFrmModel>();

            list = ltlmd.selectMessageDal(order, begintime, endtime,SQLCommand);

            foreach (BadMachineFrmModel item in list)
            {
                item.Computer = pstrd.GetComputerName(item.Computer);
            }

            return list;
        }
    }
}
