using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gce_Model
{
    public class selectPurchaseReceiptCheckQualifiedModel
    {
        /// <summary>
        /// 测试时间
        /// </summary>
        public DateTime QualifiedTime2 { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string PurchaseNo { get; set; }
        /// <summary>
        /// 物料编码
        /// </summary>
        public string MaterialCode { get; set; }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string MaterialName { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        public string SupplierName { get; set; }
        /// <summary>
        /// 来料数量
        /// </summary>
        public int ProductQuantity1 { get; set; }
        /// <summary>
        /// 检查数量
        /// </summary>
        public int CheckNumber { get; set; }
        /// <summary>
        /// 合格率
        /// </summary>
        public string QualifiedRate { get; set; }
        /// <summary>
        /// 异常类别
        /// </summary>
        public string classType { get; set; }
        /// <summary>
        /// 问题描述
        /// </summary>
        public string ProblemDescription { get; set; }
        /// <summary>
        /// 质检员名
        /// </summary>
        public string CheckQualifiedUserName { get; set; }
        /// <summary>
        /// 是否合格
        /// </summary>
        public string WhetherQualified { get; set; }
        /// <summary>
        /// 是否特采
        /// </summary>
        public string CheckSpecialMining { get; set; }
        /// <summary>
        /// 责任归属
        /// </summary>
        public string AttributionResponsibility { get; set; }
        /// <summary>
        /// 8D报告回复
        /// </summary>
        public string Presentation8D { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string note { get; set; }
    }
}
