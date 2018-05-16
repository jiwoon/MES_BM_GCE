using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Gce_Dal;
using System.Windows.Forms;
using Gce_Model;

namespace Bll 
{
    public class PurchaseReceiptBll
    {
        PurchaseReceiptDal prd1 = new PurchaseReceiptDal();
        /// <summary>
        /// 扫描二维码后给PurchaseReceipt类属性赋值
        /// </summary>
        /// <param name="list">二维码中的信息集合</param>
        public void SetQrcodeStrBll(List<string> list)
        {
            List<PurchaseReceipt> listPR = new List<PurchaseReceipt>();
            try
            {
                listPR.Add(new PurchaseReceipt()
                {
                    PurchaseNo = list[0],
                    SupplierName = list[1],
                    BatchNo = list[2],
                    MaterialCode = list[3],
                    MaterialName = list[4],
                    MaterialSpecifications = list[5],
                    ProductQuantity = Convert.ToInt32(list[6]),
                    CheckAudit = "未审核",
                    CheckQualified = "未检测",
                    CheckSpecialMining = "未检测",
                    note = ""
                });
                PurchaseReceiptDal prd = new PurchaseReceiptDal();
                prd.SetQrcodeStrDal(listPR);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message+"\t\n"+"格式不对，请输入正确二维码信息格式！");
            }
        }
        /// <summary>
        /// 删除一条采购入库数据
        /// </summary>
        /// <param name="list"></param>
        public void DeletePurchaseReceiptRowBll(List<string> list)
        {
            PurchaseReceiptDal prd = new PurchaseReceiptDal();
            prd.DeletePurchaseReceiptRowDal(list);
        }

        public List<IncomingInspectionModel> selectPurchaseNoPurchaseReceiptBll(string SQLCommand)
        {
            return prd1.selectPurchaseNoPurchaseReceiptDal(SQLCommand); 
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLComand"></param>
        /// <returns></returns>
        public bool insertPurchaseReceiptBll(List<PurchaseReceipt> list, string SQLCommand)
        {
            if (prd1.insertPurchaseReceiptDal(list, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新PurchaseReceipt
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLComand"></param>
        /// <returns></returns>
        public bool updatePurchaseReceiptBll(List<PurchaseReceipt> list, string SQLCommand)
        {
            if (prd1.updatePurchaseReceiptDal(list, SQLCommand) > 0)
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
        /// <param name="PurchaseReceiptID"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool deletePurchaseReceiptBll(string PurchaseReceiptID, string SQLCommand)
        {
            if (prd1.deletePurchaseReceiptDal(PurchaseReceiptID, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 质检更新合格率
        /// </summary>
        /// <param name="incoming"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool updatePurchaseReceiptQualifiedBll(IncomingInspectionModel incoming, bool WhetherQualified, string SQLCommand)
        {
            if (prd1.updatePurchaseReceiptQualifiedDal(incoming,WhetherQualified, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }   

        /// <summary>
        /// 解码二维码
        /// </summary>
        /// <param name="strQr"></param>
        /// <returns></returns>
        public List<string> GetQr(string strQr)
        {
            try
            {

                List<string> list = new List<string>();
                string str1;
                while (strQr.Length != 0)
                {
                    int i = strQr.IndexOf("：");
                    int j = strQr.IndexOf("@");
                    if (i == -1)
                    {
                        i = strQr.IndexOf(":");
                    }
                    if (j != -1)
                    {
                        str1 = strQr.Substring(i + 1, j - i - 1);
                        strQr = strQr.Remove(0, j + 1);
                    }
                    else
                    {
                        str1 = strQr.Substring(i + 1, strQr.Length - i - 1);
                        strQr = strQr.Remove(0, strQr.Length);
                    }

                    list.Add(str1);
                }
                return list;     
            }
            catch
            {
                MessageBox.Show("条码信息格式出错");
                return new List<string>();
            }
        }
        /// <summary>
        /// 加载财务录入功能查询
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<FinancialInputERPModel> selectPurchaseReceiptFinancialEntryBll(string SQLCommand)
        {
            return prd1.selectPurchaseReceiptFinancialEntryDal(SQLCommand);
        }
        /// <summary>
        /// 财务录入ERP更新
        /// </summary>
        /// <param name="finerp"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool updatePurchaseReceiptFinancialEntryBll(FinancialInputERPModel finerp, string SQLCommand)
        {
            if (prd1.updatePurchaseReceiptFinancialEntryDal(finerp, SQLCommand) > 0)
            {
                return true;
            }
            else return false;
        }
        /// <summary>
        /// 审核查询
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<IncomingAuditModel> selectPurchaseReceiptIncomingAuditBll(string SQLCommand)
        {
            return prd1.selectPurchaseReceiptIncomingAuditDal(SQLCommand);
        }
        /// <summary>
        /// 审核更新
        /// </summary>
        /// <param name="PurchaseReceiptID"></param>
        /// <param name="CheckSpecialMining"></param>
        /// <param name="CheckAuditUserName"></param>
        /// <param name="WhetherQualified"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool updatePurchaseReceiptIncomingAuditBll(string PurchaseReceiptID, string CheckAudit, string CheckSpecialMining, string CheckAuditUserName, string note, string AttributionResponsibility, string Presentation8D, bool WhetherQualified, string ReturnGoods, string SQLCommand)
        {
            if (prd1.updatePurchaseReceiptIncomingAuditDal(PurchaseReceiptID, CheckAudit, CheckSpecialMining, CheckAuditUserName, note, AttributionResponsibility, Presentation8D, WhetherQualified, ReturnGoods, SQLCommand) > 0)
            {
                return true;
            }
            else return false;
        }
        /// <summary>
        /// 扫码查询挑选信息
        /// </summary>
        /// <param name="PurchaseNo"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<ChooseModel> selectPurchaseReceiptChooseDal(string SQLCommand)
        {
            return prd1.selectPurchaseReceiptChooseDal(SQLCommand);
        }
        /// <summary>
        /// 挑选更新
        /// </summary>
        /// <param name="PurchaseReceiptID"></param>
        /// <param name="ChooseNumber"></param>
        /// <param name="NotChooseNumber"></param>
        /// <param name="ChooseTime1"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool updatePurchaseReceiptChooseBll(string PurchaseReceiptID, int ChooseNumber, int NotChooseNumber, string ChooseName, DateTime ChooseTime1, string SQLCommand)
        {
            if (prd1.updatePurchaseReceiptChooseDal(PurchaseReceiptID, ChooseNumber, NotChooseNumber, ChooseName , ChooseTime1, SQLCommand) > 0)
            {
                return true;
            }
            else return false;
        }
        /// <summary>
        /// 来料入库查询
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<IncomingWarehousingModel> selectPurchaseReceiptWhetherBll(string SQLCommand)
        {
            return prd1.selectPurchaseReceiptWhetherDal(SQLCommand);
        }
        /// <summary>
        /// 标记已入库
        /// </summary>
        /// <param name="PurchaseReceiptID"></param>
        /// <param name="Storage"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool updatePurchaseReceiptStorageBll(string PurchaseReceiptID, string Storage, string SQLCommand)
        {
            if (prd1.updatePurchaseReceiptStorageDal(PurchaseReceiptID, Storage, SQLCommand) > 0)
            {
                return true;
            }
            else return false;
        }
        /// <summary>
        /// 查询退货信息
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<PWarehouseTable_ReturnGoods> selectPurchaseReceiptReturnGoodsBll(string SQLCommand)
        {
            return prd1.selectPurchaseReceiptReturnGoodsDal(SQLCommand);
        }
        /// <summary>
        /// 退货更新
        /// </summary>
        /// <param name="PurchaseReceiptID"></param>
        /// <param name="ReturnGoods"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public bool updatePurchaseReceiptReturnGoodsBll(string PurchaseReceiptID, string ReturnGoods, string SQLCommand)
        {
            if (prd1.updatePurchaseReceiptReturnGoodsDal(PurchaseReceiptID, ReturnGoods, SQLCommand) > 0)
            {
                return true;
            }
            else return false;
        }
        /// <summary>
        /// 质检汇总查询
        /// </summary>
        /// <param name="list"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<selectPurchaseReceiptCheckQualifiedModel> selectPurchaseReceiptCheckQualifiedBll(List<selectPurchaseReceiptCheckQualifiedModel> list, DateTime beginTime, DateTime endTime, string SQLCommand)
        {
            return prd1.selectPurchaseReceiptCheckQualifiedDal(list, beginTime, endTime, SQLCommand);
        }
        /// <summary>
        /// 质检统计查询
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<StatisticsQueryModel> selectPurchaseReceiptCheckQualifiedStatisticsBll(int Number,DateTime beginTime, DateTime endTime, string SQLCommand)
        {
            return prd1.selectPurchaseReceiptCheckQualifiedStatisticsDal(Number,beginTime, endTime, SQLCommand);
        }
    }
}
