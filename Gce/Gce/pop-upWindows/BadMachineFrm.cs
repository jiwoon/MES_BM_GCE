using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gce_Model;
using Gce_Bll;
using Bll;
using System.Globalization;
using Gce_Common;

namespace Gce.pop_upWindows
{
    public partial class BadMachineFrm : Office2007Form
    {
        LTestLogMessageBll ltlmb = new LTestLogMessageBll();

        private string ProductionType;
        private string Order;
        private DateTime BeginTime;
        private DateTime EndTime;
        private List<ProductionType> listpt;

        private List<BadMachineFrmModel> listData = new List<BadMachineFrmModel>();
        public BadMachineFrm(string productType,string order ,List<ProductionType> list,DateTime begintime,DateTime endtime)
        {
            this.ProductionType = productType;
            this.Order = order;
            this.BeginTime = begintime;
            this.EndTime = endtime;
            listpt = list;
            InitializeComponent();
        }

        private void BadMachineFrm_Load(object sender, EventArgs e)
        {
            labelX1.Text = ProductionType;
            textBoxX1.Text = Order;

            for (int i = 0; i < listpt.Count; i++)
            {
                if (ProductionType == listpt[i].ProductType)
                {
                    listData = ltlmb.selectMessageBll(Order,BeginTime,EndTime ,listpt[i].Command2);
                    SetDataGridView(listData);
                }
            }
        }
        private void SetDataGridView(List<BadMachineFrmModel> list)
        {
            dataGridViewX1.DataSource = list;
        }

        private void dataGridViewX1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(this.dataGridViewX1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, CultureInfo.CurrentUICulture),
                e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            }
        }

        private void btn_DataOut_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewX1.CurrentRow == null)
            {
                MessageBox.Show("没有可导出的数据!");
                return;
            }
            ExcelHelperForCs.ExportToExcel(dataGridViewX1);
            MessageBox.Show("导出完成");
        }


    }
}
