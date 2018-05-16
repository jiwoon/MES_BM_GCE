using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gce_Dal;
using Gce_Model;

namespace Gce_Bll
{
    public class PFunctionMenuBll
    {
        PFunctionMenuDal pfmd = new PFunctionMenuDal();
        /// <summary>
        /// 查询主要功能权限名
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<PFunctionMenu> selectPFunctionMenuFID0Bll(string SQLCommand)
        {
            return pfmd.selectPFunctionMenuFID0Dal(SQLCommand);
        }

        public List<PFunctionMenu> selectPFunctionMenuFID00Bll(string SQLCommand)
        {
            return pfmd.selectPFunctionMenuFID00Dal(SQLCommand);
        }
    }
}
