using Gce_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gce_Dal;

namespace Gce_Bll
{
    public class PUsers_FunctionBll
    {
        PUsers_FunctionDal puf = new PUsers_FunctionDal();
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool insertPUsers_FunctionBll(List<PUsers_Function> list, string SQLCommand)
        {
            if (puf.insertPUsers_FunctionDal(list, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<PUsers_Function> selectPUsers_FunctionBll(string SQLCommand)
        {
            return puf.selectPUsers_FunctionDal(SQLCommand);
        }
        /// <summary>
        /// 用户登录权限查询
        /// </summary>
        /// <param name="username"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<PUsers_Function> selectPUsers_FunctionLoginBll(string SQLCommand, string username)
        {
            return puf.selectPUsers_FunctionLoginDal(SQLCommand, username);
        }
        /// <summary>
        /// 修改主功能权限
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool updatePUsers_FunctionBll(List<PUsers_Function> list, string SQLCommand)
        {
            if (puf.updatePUsers_FunctionDal(list,SQLCommand) > 0)
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
