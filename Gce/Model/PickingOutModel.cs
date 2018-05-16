using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gce_Model
{
    public class PickingOutModel
    {
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
        /// 备注
        /// </summary>
        public string note { get; set; }
    }
}
