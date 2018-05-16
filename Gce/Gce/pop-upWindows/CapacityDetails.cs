using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Gce.Windows
{
    public partial class CapacityDetails : Office2007Form
    {
        List<string> xlist = new List<string>();
        List<int> ylist = new List<int>();
        string ProductionClass;
        public CapacityDetails(string str,List<string> xlist,List<int> ylist)
        {
            this.ProductionClass = str;
            this.ylist = ylist;
            this.xlist = xlist;
            InitializeComponent();
        }

        private void CapacityDetails_Load(object sender, EventArgs e)
        {
            chart1.Series["Series1"].LegendText = ProductionClass;
            chart1.Series["Series1"].Points.DataBindXY(xlist, ylist);
            chart1.Series["Series1"].Label = "#VAL";
            chart1.Series["Series1"].IsValueShownAsLabel = true;
            chart1.Series[0].ToolTip = "#VALX";

            //chart1.ChartAreas[0].AxisX.Interval = 1;
            //chart1.ChartAreas[0].AxisX.IntervalOffset = 1;
            //chart1.ChartAreas[0].AxisX.LabelStyle.IsStaggered = true;
            //Series series = new Series("test");
            //series.IsVisibleInLegend = false;

            //chart1.Series.Add(series);
        }
    }
}
