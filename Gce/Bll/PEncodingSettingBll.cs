using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gce_Model;
using Gce_Dal;

namespace Gce_Bll
{
    public class PEncodingSettingBll
    {
        PEncodingSettingDal pesd=new PEncodingSettingDal();
        /// <summary>
        /// 查询异常配置表
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<PEncodingSetting> selectPEncodingSettingBll(string SQLCommand)
        {
            return pesd.selectPEncodingSettingDal(SQLCommand);
        }
        /// <summary>
        /// 插入异常配置表
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool insertPEncodingSettingBll(List<PEncodingSetting> list,string SQLCommand)
        {
            if (pesd.insertPEncodingSettingDal(list, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 检查是否已存在编码
        /// </summary>
        /// <param name="barcodeEncoding"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool checkedPEncodingSettingBll(string barcodeEncoding,string SQLCommand)
        {
            if (pesd.checkedPEncodingSettingDal(barcodeEncoding, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除异常配置表
        /// </summary>
        /// <param name="BarcodeEncoding"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool deletePEncodingSettingBll(string BarcodeEncoding,string SQLCommand)
        {
            if (pesd.deletePEncodingSettingDal(BarcodeEncoding, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 按主键为条件查询异常配置表
        /// </summary>
        /// <param name="BarcodeEncoding"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<PEncodingSetting> ConditionsSelectPEncodingSettingBll(string BarcodeEncoding,string SQLCommand)
        {
            return pesd.ConditionsSelectPEncodingSettingDal(BarcodeEncoding, SQLCommand);
        }
    }
}
    