using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gce_Model;
using Gce_Dal;

namespace Gce_Bll
{
    public class PWorkScheduleBll
    {
        PWorkScheduleDal pwd = new PWorkScheduleDal();
        public bool insertPWorkScheduleBll(List<PWorkSchedule> list,string SQLCommand)
        {
            if (pwd.insertPWorkScheduleDal(list, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除上班时间类型
        /// </summary>
        /// <param name="CompanyName"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool deletePWorkScheduleBll(string CompanyName, string SQLCommand)
        {
            if (pwd.deletePWorkScheduleDal(CompanyName, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 查询上班类型
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<PWorkSchedule> selectPWorkScheduleBll(string SQLCommand)
        {
            return pwd.selectPWorkScheduleDal(SQLCommand);
        }
        /// <summary>
        /// 初始化公司上班类型
        /// </summary>
        /// <param name="SQLCommand">SQL命令</param>
        /// <returns></returns>
        //public string Top1_PWorkScheduleBll(string SQLCommand)
        //{
        //    return pwd.Top1_PWorkScheduleDal(SQLCommand);
        //}
    }
}
