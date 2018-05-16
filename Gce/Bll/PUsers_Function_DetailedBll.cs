using Gce_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gce_Dal;

namespace Gce_Bll
{
    public class PUsers_Function_DetailedBll
    {
        PUsers_Function_DetailedDal pufd = new PUsers_Function_DetailedDal();
        public bool insertPUsers_Function_DetailedBll(List<PUsers_Function_Detailed> list, string SQLCommand)
        {
            if (pufd.insertPUsers_Function_DetailedDal(list, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<PUsers_Function_Detailed> selectPUsers_Function_DetailedBll(string SQLCommand)
        {
            return pufd.selectPUsers_Function_DetailedDal(SQLCommand);
        }

        /// <summary>
        /// 用户登录查询
        /// </summary>
        /// <param name="username"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<PUsers_Function_Detailed> selectPUsers_Function_DetailedLoginBll(string SQLCommand, string username)
        {
            return pufd.selectPUsers_Function_DetailedLoginDal(SQLCommand, username);
        }
        /// <summary>
        /// 修改次功能权限
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool updatePUsers_Function_DetailedBll(List<PUsers_Function_Detailed> list, string SQLCommand)
        {
            if (pufd.updatePUsers_Function_DetailedDal(list, SQLCommand) > 0)
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
    