using DevComponents.DotNetBar;
using Gce.MoreDocumentsWindows;
using Gce.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gce.pop_upWindows
{
    public partial class TimedRefreshCondition : Office2007Form
    {

        private productionEfficiency Peff;
        private ProductionSplitTimeRecord Psrd;

        private string Lab;
        public TimedRefreshCondition(string lab,productionEfficiency peff)
        {
            InitializeComponent();
            this.Peff = peff;
            this.Lab = lab;
        }
        public TimedRefreshCondition(string lab, ProductionSplitTimeRecord psrd)
        {
            InitializeComponent();
            this.Psrd = psrd;
            this.Lab = lab;
        }

        public TimedRefreshCondition()
        {
            InitializeComponent();
        }
        private void TimedRefreshCondition_Load(object sender, EventArgs e)
        {
            this.Load1();
        }

        void Load1()
        {
            labelX1.Text = Lab;
            integerInput1.Location = new Point(labelX1.Width + labelX1.Location.X, 41);
            labelX2.Location = new Point(integerInput1.Width + integerInput1.Location.X, 45);
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {            
            this.OKclick();
        }

        void OKclick()
        {
            switch (Lab)
            {
                case "生产效能定时":
                    Peff.timer1Start(integerInput1.Value * 60000);
                    this.Close();
                    break;
                case "分时段记录定时":
                    Psrd.timer1Start(integerInput1.Value * 60000);
                    this.Close();
                    break;
            }
        }
        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
