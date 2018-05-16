using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gce_Dal;

namespace Gce_Bll
{
    public class PExceptionTypesBll
    {
        PExceptionTypesDal ptd = new PExceptionTypesDal();
        /// <summary>
        /// 向异常类型表插入信息 
        /// </summary>
        /// <param name="ExceptionTypes"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool insertPExceptionTypesBll(string ExceptionTypes,string SQLCommand)
        {
            if (ptd.insertPExceptionTypesDal(ExceptionTypes, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 查询异常类型表
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<string> selectPExceptionTypesBll(string SQLCommand)
        {
            return ptd.selectPExceptionTypesDal(SQLCommand);
        }
        /// <summary>
        /// 检查是否已存在该类型
        /// </summary>
        /// <param name="ExceptionTypes"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool checkedPExceptionTypesBll(string ExceptionTypes,string SQLCommand)
        {
            if (ptd.checkedPExceptionTypesDal(ExceptionTypes, SQLCommand) > 0)
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
