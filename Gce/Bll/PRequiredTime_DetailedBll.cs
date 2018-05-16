using Gce_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gce_Dal;

namespace Gce_Bll
{
    public class PRequiredTime_DetailedBll
    {
        PRequiredTime_DetailedDal prdd = new PRequiredTime_DetailedDal();
        /// <summary>
        /// 向PRequiredTime_Detailed表插入数据
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool insertPRequiredTime_DetailedBll(List<PRequiredTime_Detailed> list, string SQLCommand)
        {
            if (prdd.insertPRequiredTime_DetailedDal(list, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ProductType"></param>
        /// <param name="RequiredTimeGUID"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool deletePRequiredTime_DetailedDal(string ProductType, string RequiredTimeGUID, string SQLCommand)
        {
            if (prdd.deletePRequiredTime_DetailedDal(ProductType, RequiredTimeGUID, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 查找工位所需时间集
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<PRequiredTime_Detailed> selectPRequiredTime_DetailedBll(string SQLCommand)
        {
            return prdd.selectPRequiredTime_DetailedDal(SQLCommand);
        }
    }
}
        