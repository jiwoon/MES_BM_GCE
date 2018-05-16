using DevComponents.DotNetBar;
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
    public partial class Production_Screen : Office2007Form
    {
        private productionEfficiency Production;

        private string Lab1;
        private string Lab2;
        private int Number;
        public Production_Screen()
        {
            InitializeComponent();
        }

        public Production_Screen(string lab1,string lab2,productionEfficiency production,int number)
        {
            InitializeComponent();
            this.Production = production;
            this.Lab1 = lab1;
            this.Lab2 = lab2;
            this.Number = number;
        }
        private void Production_Screen_Load(object sender, EventArgs e)
        {
            this.SetLab();
        }

        void SetLab()
        {
            this.labelX1.Text = this.Lab1;
            this.labelX2.Text = this.Lab2;

            integerInput1.Location = new Point(this.labelX1.Width + this.labelX1.Location.X,33);
            labelX2.Location = new Point(this.integerInput1.Width + this.integerInput1.Location.X, 38);

            if (this.Number == 3)
            {
                this.checkBoxX1.Visible = true;
                this.checkBoxX2.Visible = true;

                this.checkBoxX1.Checked = true;
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Production.radialMI_Standard_Click_1(Convert.ToString(this.integerInput1.Value),Number,checkBoxX1.Checked);
            this.Close();
        }

        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            this.checkBoxX2.Checked = !this.checkBoxX1.Checked;
        }

        private void checkBoxX2_CheckedChanged(object sender, EventArgs e)
        {
            this.checkBoxX1.Checked = !this.checkBoxX2.Checked;
        }
    }
}
    