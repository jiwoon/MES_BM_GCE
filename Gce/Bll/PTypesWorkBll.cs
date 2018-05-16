using Gce_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gce_Dal;

namespace Gce_Bll
{
    public class PTypesWorkBll
    {
        PTypesWorkDal ptwd = new PTypesWorkDal();
        /// <summary>
        /// 查找PTypesWork表
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<PTypesWork> selectPTypesWorkDal(string SQLCommand)
        {
            return ptwd.selectPTypesWorkDal(SQLCommand);            
        }
        /// <summary>
        /// 向表中插入一条数据
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool insertPTypesWorkBll(List<PTypesWork> list, string SQLCommand)
        {
            if (ptwd.insertPTypesWorkDal(list, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 检查表中是否存在某条数据
        /// </summary>
        /// <param name="typeswork"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool checkedPTypesWorkBll(string typeswork,string SQLCommand)
        {
            if (ptwd.checkedPTypesWorkDal(typeswork, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新表中一条数据
        /// </summary>
        /// <param name="oldTypesWork"></param>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool updatePTypesWorkBll(string oldTypesWork, List<PTypesWork> list, string SQLCommand)
        {
            if (ptwd.updatePTypesWorkDal(oldTypesWork, list, SQLCommand) > 0)
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
