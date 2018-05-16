using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gce_Dal;
using Gce_Model;

namespace Gce_Bll
{
    public class PMCplan_tableBll
    {
        PMCplan_tableDal PMCtable = new PMCplan_tableDal();
        /// <summary>
        /// PMC计划录入表插入数据
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool insertPMCplan_tableBll(List<PMCplan_table> list, string SQLCommand)
        {
            if (PMCtable.insertPMCplan_tableDal(list, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 检查数据是否存在
        /// </summary>
        /// <param name="CorporateName"></param>
        /// <param name="ZhiDan"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool checkedPMCplan_tableBll(string CorporateName, string ZhiDan, string SQLCommand)
        {
            if (PMCtable.checkedPMCplan_tableDal(CorporateName, ZhiDan, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool updatePMCplan_tableBll(string oldCorporateName, string oldZhiDan, List<PMCplan_table> list, string SQLCommand)
        {
            if (PMCtable.updatePMCplan_tableDal(oldCorporateName,oldZhiDan,list, SQLCommand) > 0)
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
        /// <param name="CorporateName"></param>
        /// <param name="ZhiDan"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool deletePMCplan_tableBll(string CorporateName, string ZhiDan, string SQLCommand)
        {
            if (PMCtable.deletePMCplan_tableDal(CorporateName, ZhiDan, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 查找PMC录入表
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<PMCplan_table> selectPMCplan_tableBll(List<PMCplan_table> list, string SQLCommand)
        {
            return PMCtable.selectPMCplan_tableDal(list, SQLCommand);
        }
    }
}
