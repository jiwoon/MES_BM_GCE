using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gce_Model;
using Gce_Dal;

namespace Gce_Bll
{
    public class PCapacityConfigurationBll
    {
        PCapacityConfigurationDal pcd = new PCapacityConfigurationDal();
        /// <summary>
        /// 向PCapacityConfiguration表插入数据
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int InsertPCapacityConfigurationBll(List<PCapacityConfiguration> list,string SQLCommand)
        {
            return pcd.InsertPCapacityConfigurationDal(list, SQLCommand);
        }

        public string selectPCapacityConfigurationProductClassBll(string txtorder,string SQLCommadn)
        {
            if (pcd.selectPCapacityConfigurationProductClassDal(txtorder, SQLCommadn) != null)
            {
                return pcd.selectPCapacityConfigurationProductClassDal(txtorder, SQLCommadn).ToString();
            }
            else
            {
                return "";
            }            
        }
        /// <summary>
        /// 判断是否存已配置标准产能
        /// </summary>
        /// <param name="txtOrder"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool selectPCapacityConfigurationNumberBll(string txtOrder,string SQLCommand)
        {
            if (pcd.selectPCapacityConfigurationNumberDal(txtOrder, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        ///查询所有数据
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<PCapacityConfiguration> selectPCapacityConfigurationBll(string SQLCommand)
        {
            return pcd.selectPCapacityConfigurationDal(SQLCommand);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ZhiDan">订单号</param>
        /// <param name="SQLCommand">SQL命令</param>
        /// <returns></returns>
        public bool deletePCapacityConfigurationBll(string ZhiDan, string SQLCommand)
        {
            if (pcd.deletePCapacityConfigurationDal(ZhiDan, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
