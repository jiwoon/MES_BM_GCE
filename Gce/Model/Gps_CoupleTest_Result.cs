using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Gps_CoupleTest_Result
    {
        public int Id { get; set; }

        public string SN { get; set; }

        public string IMEI { get; set; }

        public string ZhiDan { get; set; }

        public string SoftModel { get; set; }

        public string Version { get; set; }

        public int Result { get; set; }

        public string TesterId { get; set; }

        public DateTime TestTime { get; set; }

        public string Remark { get; set; }

        public DateTime _MASK_FROM_V2 { get; set; }
    }
}
