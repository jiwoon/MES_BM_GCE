using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gce_Model
{
    public class IncomingWarehousingModel
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
        /// 数量
        /// </summary>
        public int ProductQuantity1 { get; set; }
        /// <summary>
        /// 挑选合格数
        /// </summary>
        public int ChooseNumber { get; set; }
        /// <summary>
        /// 最近一次更新时间
        /// </summary>
        public DateTime Updatetime1 { get; set; }
        /// <summary>
        /// 是否特采
        /// </summary>
        public string CheckSpecialMining { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string note { get; set; }
    }
}
