using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gce_Dal;
using Gce_Model;

namespace Gce_Bll
{
    public class PStaffResumeBll
    {
        PStaffResumeDal psrd = new PStaffResumeDal();
        /// <summary>
        /// 检查是否已存在该员工
        /// </summary>
        /// <param name="name"></param>
        /// <param name="worknumber"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool checkedPStaffResumeBll(string name, string worknumber, string SQLCommand)
        {
            if (psrd.checkedPStaffResumeDal(name, worknumber, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 插入员工信息
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool insertPStaffResumeBll(List<PStaffResume> list, string SQLCommand)
        {
            if (psrd.insertPStaffResumeDal(list, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新员工信息
        /// </summary>
        /// <param name="oldName"></param>
        /// <param name="oldWorkNumber"></param>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool updatePStaffResumeBll(string oldName, string oldWorkNumber, List<PStaffResume> list, string SQLCommand)
        {
            if (psrd.updatePStaffResumeDal(oldName, oldWorkNumber, list, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 查询员工信息 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<PStaffResume> selectPStaffResumeBll(List<PStaffResume> list, string SQLCommand)
        {
            return psrd.selectPStaffResumeDal(list, SQLCommand);
        }
        /// <summary>
        /// 删除员工信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="worknumber"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool deletePStaffResumeBll(string name, string worknumber, string SQLCommand)
        {
            if (psrd.deletePStaffResumeDal(name, worknumber, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 查询条件
        /// </summary>
        /// <param name="SQLComand"></param>
        /// <returns></returns>
        public List<selectConditionsQueryPStaffResumeModel> selectConditionsQueryPStaffResumeBll(string SQLComand)
        {
            return psrd.selectConditionsQueryPStaffResumeDal(SQLComand);
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        /// <param name="SQLComand"></param>
        /// <returns></returns>
        public List<selectConditionsQueryPStaffResumeModel2> selectConditionsQueryPStaffResumeBll2(string SQLComand)
        {
            return psrd.selectConditionsQueryPStaffResumeDal2(SQLComand);
        }
    }
}
