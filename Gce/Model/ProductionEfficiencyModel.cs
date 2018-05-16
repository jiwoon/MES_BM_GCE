using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ProductionEfficiencyModel
    {
        public string ProductionClass { get; set; }

        public string Order { get; set; }

        public string SoftModel { get; set; }

        public string ProductClass { get; set; }

        public string TheNumberOf { get; set; }

        public string Hours { get; set; }

        public string actualHours { get; set; }

        public string PerCapitaProductivity { get; set; }

        public string Ratio { get; set; }

        public string sumHours { get; set; }

        public string sumWorkingHours { get; set; }

        public string sum { get; set; }

        public string FailureNuber { get; set; }

        public string FailureRate { get; set; }

        public string StraightRate { get; set; }

        public string sumOrder { get; set; }

        public string OrderStartTime { get; set; }

        public string OrderOverTime { get; set; }

        public List<string> listX { get; set; }

        public List<int> listY { get; set; }
    }
}
