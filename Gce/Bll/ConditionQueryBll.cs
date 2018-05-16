using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Gce_Dal;
using Gce_Model;

namespace Bll
{
    public class ConditionQueryBll
    {
        ConditionQueryDal cqd = new ConditionQueryDal();
        /// <summary>
        /// 订单号查询Bll
        /// </summary>
        /// <param name="SQLCommand">SQL命令</param>
        /// <returns>List<productionOrder></returns>
        public List<productionOrder> selectOrderBll(string SQLCommand, string txt_Order, string SoftModel, DateTime begintime, DateTime endtime)
        {
            try
            {
                return cqd.selectOrderDal(SQLCommand, txt_Order, SoftModel, begintime, endtime);
            }
            catch
            {
                throw;
            }
        }
        //public List<string> selectTop10Cbe_CondiyionsBll(string Cbe_Condiyions, string SQLCommand)
        //{ 
        //    return cqd.selectTop10Cbe_CondiyionsDal(Cbe_Condiyions,SQLCommand);
        //}
        /// <summary>
        /// 机型查询Bll
        /// </summary>
        /// <param name="SQLCommand">SQL命令</param>
        /// <param name="txt_SoftModel">txt_SoftModel文本框文本</param>
        /// <returns></returns>
        public List<ProductionSoftModel> selectSoftModelBll(string SQLCommand, string txt_SoftModel,string Order,DateTime begin,DateTime end)
        {
            try
            {
                return cqd.selectSoftModelDal(SQLCommand, txt_SoftModel, Order, begin, end);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 以单号查询包装的总数
        /// </summary>
        /// <param name="strOrder"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int selectSumCartonBoxTwentyNumberBll(string strOrder,string SQLCommand)
        {
            try
            {
                return cqd.selectSumCartonBoxTwentyNumberDal(strOrder, SQLCommand);
            }
            catch
            {
                throw;
            }
        }

        public List<productionOrder> selectOrder1Bll(string SQLCommand, string CompanyName, DateTime begintime, DateTime endtime)
        {
            try
            {
                return cqd.selectOrder1Dal(SQLCommand, CompanyName, begintime, endtime);
            }
            catch
            {
                throw;
            }
        }
    }
}
