using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gce_Dal;

namespace Gce_Bll
{
    public class ClassType_tableBll
    {
        ClassType_tableDal ctDal = new ClassType_tableDal();
        /// <summary>
        ///查询异常类型表
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<string> selectClassType_tableDal(string SQLCommand)
        {
            try
            {
                return ctDal.selectClassType_tableDal(SQLCommand);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 增加异常类别
        /// </summary>
        /// <param name="classType"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool insertClassType_tableBll(string classType, string SQLCommand)
        {
            try
            {
                if (ctDal.insertClassType_tableDal(classType, SQLCommand) > 0)
                {
                    return true;
                }
                else return false;
            }
            catch
            {
                throw;
            }
        }   
    }   
}
