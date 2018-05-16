using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gce_Model
{
    public class PMCplan_table
    {
        public string CorporateName { get; set; }

        public string ZhiDan { get; set; }

        public int TotalOrder { get; set; }

        public string RequiredTimeGUID { get; set; }

        public string CustomerName { get; set; }

        public DateTime ShippingDate { get; set; }

        public string Remarks { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}
