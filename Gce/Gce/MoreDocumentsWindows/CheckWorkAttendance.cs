using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gce.MoreDocumentsWindows
{
    public partial class CheckWorkAttendance : Office2007Form
    {

        Gce G;
        public CheckWorkAttendance()
        {
            InitializeComponent();
        }

        public CheckWorkAttendance(Gce g)
        {
            InitializeComponent();

            this.G = g;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            G.ShowSectorStructure_form();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            G.ShowEmployee_file();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            G.showAttendanceMachine();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            G.showDailyAttendance();
            //MessageBox.Show(dateTimeInput1.Value.DayOfWeek.ToString());
            //dateTimeInput1.CustomFormat = "yyyy-MM-dddd";
            //dateTimeInput1.Value = DateTime.Now;
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {

        }
    }
}
