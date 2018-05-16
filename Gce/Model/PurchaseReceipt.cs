using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class PurchaseReceipt
    {
        /// <summary>
        /// 时间序列号
        /// </summary>
        public string PurchaseReceiptID { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string PurchaseNo { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        public string SupplierName { get; set; }
        /// <summary>
        /// 物料批次号
        /// </summary>
        public string BatchNo { get; set; }
        /// <summary>
        /// 物料编码
        /// </summary>
        public string MaterialCode { get; set; }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string MaterialName { get; set; }
        /// <summary>
        /// 物料规格
        /// </summary>
        public string MaterialSpecifications { get; set; }
        /// <summary>
        /// 二维码标记数量
        /// </summary>
        public int ProductQuantity { get; set; }
        /// <summary>
        /// 确定数量数量
        /// </summary>
        public int ProductQuantity1 { get; set; }

        /// <summary>
        /// 扫码时间
        /// </summary>
        public DateTime ScanningTime { get; set; }

        /// <summary>
        /// 第一次提交更新时间
        /// </summary>
        public DateTime Updatetime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string note { get; set; }

        /// <summary>
        /// 最近一次更新时间
        /// </summary>
        public DateTime Updatetime1 { get; set; }
        /// <summary>
        /// 审核
        /// </summary>
        public string CheckAudit { get; set; }
        /// <summary>
        /// 是否检测合格率
        /// </summary>
        public string CheckQualified { get; set; }
        /// <summary>
        /// 是否特采
        /// </summary>
        public string CheckSpecialMining { get; set; }
        /// <summary>
        /// 绑定用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 审核人名
        /// </summary>
        public string CheckAuditUserName { get; set; }
        /// <summary>
        /// 质检员名
        /// </summary>
        public string CheckQualifiedUserName { get; set; }
        /// <summary>
        /// 特采决策人名
        /// </summary>
        public string CheckSpecialMiningUserName { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public int OrderState { get; set; }
        /// <summary>
        /// 财务录入状态
        /// </summary>
        public string FinancialEntry { get; set; }
        /// <summary>
        /// 财务录入人员名字（账号）
        /// </summary>
        public string FinancialEntryName { get; set; }
        /// <summary>
        /// 财务录入时间
        /// </summary>
        public DateTime FinancialEntryTime { get; set; }
    }
}
