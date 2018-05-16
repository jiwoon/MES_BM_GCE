using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gce_Model
{
    public class StatisticsQueryModel
    {
        /// <summary>
        /// 公司名
        /// </summary>
        public string SupplierName { get; set; }
        /// <summary>
        /// 来料数量
        /// </summary>
        public int sumNumber { get; set; }
        /// <summary>
        /// 最终判定
        /// </summary>
        public int FinalJudgment { get; set; }
        /// <summary>
        /// 合格数
        /// </summary>
        public int QualifiedNumber { get; set; }
        /// <summary>
        /// 不合格数
        /// </summary>
        public int NotQualifiedNumber { get; set; }
        /// <summary>
        /// 合格率
        /// </summary>
        public string QualifiedRate { get; set; }
        /// <summary>
        /// 目标
        /// </summary>
        public string MuBiao { get; set; }
    }
}
