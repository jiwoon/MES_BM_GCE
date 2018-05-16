using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gce_Model
{
    public class MachineSelectionModel
    {
        /// <summary>
        /// 工号
        /// </summary>
        public string JobNumber { get; set; }
        /// <summary>
        /// 中文名
        /// </summary>
        public string ChineseName { get; set; }
        /// <summary>
        /// 逻辑卡号
        /// </summary>
        public string LogicalCardNumber { get; set; }
        /// <summary>
        /// 物理卡号
        /// </summary>
        public string PhysicalCardNumber { get; set; }
    }
}
