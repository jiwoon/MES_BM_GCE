using DevComponents.DotNetBar;
using Gce.Windows;
using Gce_Bll;
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
    public partial class DataOutForm : Office2007Form
    {
        private productionEfficiency productionEF;
        private string ProductionTypeName;

        ProductionTypeBll ptb = new ProductionTypeBll();

        //bool DataOut = false;
        public DataOutForm(string produtype,productionEfficiency productionEf)
        {
            InitializeComponent();
            this.productionEF = productionEf;
            this.ProductionTypeName = produtype;
        }

        private void DataOutForm_Load(object sender, EventArgs e)
        {
            this.Setcomb_Type();
        }

        void Setcomb_Type()
        {
            List<string> strlist = new List<string>();
            strlist.Add("所有工位");
            strlist.AddRange(ptb.selectProductionTypeOnWorkTimeTypeBll(ProductionTypeName, "selectProductionTypeOnWorkTimeType"));
            comb_Type.DataSource = strlist;
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {            
            productionEF.DataOut(comb_Type.Text.Trim(), inter_Min.Value, check_BlankLine.Checked);
            this.Close();
        }
    }
}
