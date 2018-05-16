using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gce_Model
{
    public class PWorkSchedule
    {
        public string CompanyName { get; set; }

        public string MorningOnWorkTime { get; set; }
        
        public string MorningUnderWorkTime { get; set; }

        public string AfternoonOnWorkTime { get; set; }

        public string AfternoonUnderWorkTime { get; set; }

        public string NightOnWorkTime { get; set; }

        public bool Flag { get; set; }
    }
}
