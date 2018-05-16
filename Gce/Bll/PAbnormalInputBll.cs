using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gce_Dal;
using Gce_Model;

namespace Gce_Bll
{
    public class PAbnormalInputBll
    {
        PAbnormalInputDal pid = new PAbnormalInputDal();
        /// <summary>
        /// 插入异常录入表
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool insertPAbnormalInputBll(List<PAbnormalInput> list, string SQLCommand)
        {
            if (pid.insertPAbnormalInputDal(list, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 检测单号是否已存在
        /// </summary>
        /// <param name="Zhidan"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool CheckedPAbnormalInputBll(string Zhidan,string problem, string SQLCommand)
        {
            if (pid.CheckedPAbnormalInputDal(Zhidan,problem, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新异常录入信息
        /// </summary>
        /// <param name="oldZhidan"></param>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool UpdatePAbnormalInputBll(string ID, List<PAbnormalInput> list, string SQLCommand)
        {
            if (pid.UpdatePAbnormalInputDal(Convert.ToInt32(ID), list, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 多条件查询PAbnormalInput表
        /// </summary>
        /// <param name="list"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<PAbnormalInput> selectPAbnormalInputBll(List<PAbnormalInput> list, DateTime beginTime, DateTime endTime, string SQLCommand)
        {
            return pid.selectPAbnormalInputDal(list,beginTime,endTime, SQLCommand);
        }
        //删除
        public bool deletePAbnormalInputBll(int ID, string SQLCommand)
        {
            if (pid.deletePAbnormalInputDal(ID, SQLCommand) > 0)
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
