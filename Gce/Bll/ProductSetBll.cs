using Model;
using Gce_Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gce_Model;

namespace Bll
{
    public class ProductSetBll
    {
        ProductSetDal psd = new ProductSetDal();
        public List<ProductSet> SelectProductSetBll(string SQLCommand)
        {
            return psd.SelectProductSetDal(SQLCommand);
        }
        /// <summary>
        /// 插入一条记录到ProductSet表
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int InsertProductSetBll(List<ProductSet> list, string SQLCommand)
        {
            
            return psd.InsertProductSetDal(list, SQLCommand);
        }
        /// <summary>
        /// 更改ProductSet表的一条记录
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int UpdateProductSetBll(List<ProductSet> list,string SQLCommand)
        {
            return psd.UpdateProductSetBll(list,SQLCommand);
        }
        /// <summary>
        /// 删除ProductSet表中的一条数据
        /// </summary>
        /// <param name="i"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int DaleteProductSetBll(int i,string SQLCommand)
        {
            return psd.DaleteProductSetDal(i, SQLCommand);
        }
        public List<ProductSet> selectProductClassBll(string SQLCommand, string txt_productClass)
        {
            return psd.selectProductClassDal(SQLCommand, txt_productClass);
        } 
        /// <summary>
        /// 查询生产类型
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<string> selectProductTypeBll(string SQLCommand)
        {
            return psd.selectProductTypeDal(SQLCommand);
        }
        /// <summary>
        /// 字符串分解
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public List<int> DecompositionStringOfProductSet(string str,List<ProductionType> listPt)
        {
            List<int> list = new List<int>();

            string str1;
            string str2 = "";

            while (str.Length != 0)
            {
                int i = str.IndexOf(":");
                int j = str.IndexOf("@@");
                if (j != -1)
                {
                    str2 = str.Substring(0, i - 1);
                    str1 = str.Substring(i + 1, j - i - 1);
                    str = str.Remove(0, j + 2);
                }
                else
                {
                    str1 = str.Substring(i + 1, str.Length - i - 1);
                    str = str.Remove(0, str.Length);
                }
                foreach (ProductionType item in listPt)
                {


                    if (item.ProductType == str2)
                    {
                        list.Add(Convert.ToInt32(str1));
                    }
                }
            }

            
            //if (list.Count != listpt.Count)
            //{
            //    if (list.Count > listpt.Count)
            //    {
            //        for (int i = 0; i < list.Count; i++)
            //        {

            //        }
            //    }
            //    else
            //    {

            //    }
            //}
            return list;
        }
        /// <summary>
        /// 合并字符串
        /// </summary>
        /// <param name="list"></param>
        /// <param name="typelist"></param>
        /// <returns></returns>
        public string MergeStringOfProductSet(List<string> list,List<string> typelist)
        {
            if (list.Count <= 0 || typelist.Count <= 0)
            {
                return "";
            }
            string str = "";
            for (int i = 0; i < list.Count; i++)
            {
                str += typelist[i] + ":" + list[i] + "@@";
            }
            return str;
        }

        public List<ProductSet> SelectProductTop1Bll(string SQLCommand)
        {
            return psd.SelectProductTop1Dal(SQLCommand);
        }
    }
}
