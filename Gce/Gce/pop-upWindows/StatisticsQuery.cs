using Bll;
using DevComponents.DotNetBar;
using Gce_Common;
using Gce_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Gce.pop_upWindows
{
    public partial class StatisticsQuery : Office2007Form
    {
        PurchaseReceiptBll prb = new PurchaseReceiptBll();

        SynchronizationContext my_Syscontext = null;

        Thread th;

        //List<StatisticsQueryModel> DataList = new List<StatisticsQueryModel>();
        public StatisticsQuery()
        {
            InitializeComponent();
        }

        private void dataGridViewX1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(this.dataGridViewX1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, CultureInfo.CurrentUICulture),
                e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            }
        }

        private void dataGridViewX1_SelectionChanged(object sender, EventArgs e)
        {
            this.dataGridViewX1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        void Loead()
        {
            DataGridViewTextBoxColumn newcol = new DataGridViewTextBoxColumn();
            newcol.HeaderText = "供应商名";
            newcol.Name = "SupplierName";
            newcol.DataPropertyName = "SupplierName";
            newcol.Width = 150;
            newcol.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol.Tag = 0;
            this.dataGridViewX1.Columns.Insert(0, newcol);

            DataGridViewTextBoxColumn newcol1 = new DataGridViewTextBoxColumn();
            newcol1.HeaderText = "来料数量";
            newcol1.Name = "sumNumber";
            newcol1.DataPropertyName = "sumNumber";
            newcol1.Width = 120;
            newcol1.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol1.Tag = 1;
            this.dataGridViewX1.Columns.Insert(1, newcol1);

            DataGridViewTextBoxColumn newcol2 = new DataGridViewTextBoxColumn();
            newcol2.HeaderText = "最终判定";
            newcol2.Name = "FinalJudgment";
            newcol2.DataPropertyName = "FinalJudgment";
            newcol2.Width = 120;
            newcol2.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol2.Tag = 2;
            this.dataGridViewX1.Columns.Insert(2, newcol2);


            DataGridViewTextBoxColumn newcol3 = new DataGridViewTextBoxColumn();
            newcol3.HeaderText = "合格数";
            newcol3.Name = "QualifiedNumber";
            newcol3.DataPropertyName = "QualifiedNumber";
            newcol3.Width = 120;
            newcol3.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol3.Tag = 3;
            this.dataGridViewX1.Columns.Insert(3, newcol3);

            DataGridViewTextBoxColumn newcol4 = new DataGridViewTextBoxColumn();
            newcol4.HeaderText = "不合格数";
            newcol4.Name = "NotQualifiedNumber";
            newcol4.DataPropertyName = "NotQualifiedNumber";
            newcol4.Width = 120;
            newcol4.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol4.Tag = 4;
            this.dataGridViewX1.Columns.Insert(4, newcol4);

            DataGridViewTextBoxColumn newcol5 = new DataGridViewTextBoxColumn();
            newcol5.HeaderText = "合格率";
            newcol5.Name = "QualifiedRate";
            newcol5.DataPropertyName = "QualifiedRate";
            newcol5.Width = 120;
            newcol5.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol5.Tag = 5;
            this.dataGridViewX1.Columns.Insert(5, newcol5);

            DataGridViewTextBoxColumn newcol6 = new DataGridViewTextBoxColumn();
            newcol6.HeaderText = "目标";
            newcol6.Name = "MuBiao";
            newcol6.DataPropertyName = "MuBiao";
            newcol6.Width = 120;
            newcol6.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol6.Tag = 6;
            this.dataGridViewX1.Columns.Insert(6, newcol6);

            DataGridViewTextBoxColumn newcol15 = new DataGridViewTextBoxColumn();
            newcol15.HeaderText = "";
            newcol15.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            newcol15.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewX1.Columns.Insert(7, newcol15);


        }

        bool Message1()
        {
            if (input_QualifiedRate.Text == "")
            {
                MessageBox.Show("目标不能为空！");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btni_query_Click(object sender, EventArgs e)
        {
            if (Message1()) return;

            DateTime beginTime = Dti_Begin.Value;
            DateTime endTime = Dti_End.Value;
            int number = input_QualifiedRate.Value;

            lab_message.Text ="正在查询...";
            th = new Thread(delegate()
            {
                Query(number, beginTime, endTime);
            });
            th.IsBackground = true;
            th.Start();
        }

        void Query(int Number,DateTime beginTime, DateTime endTime)
        {
            my_Syscontext.Post(SetDGV, prb.selectPurchaseReceiptCheckQualifiedStatisticsBll(Number,beginTime, endTime, "selectPurchaseReceiptCheckQualifiedStatistics"));
        }

        void SetDGV(object o)
        {
            List<StatisticsQueryModel> list = o as List<StatisticsQueryModel>;
            dataGridViewX1.DataSource = list;
            lab_message.Text = "完成";
        }

        private void StatisticsQuery_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            DateTime startTime = new DateTime(dt.Year, dt.Month, dt.Day);
            DateTime endTime = new DateTime(dt.Year, dt.Month, dt.Day);
            Dti_Begin.Value = startTime;
            Dti_End.Value = endTime;
            my_Syscontext = SynchronizationContext.Current;
            Loead();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewX1.CurrentRow == null)
            {
                MessageBox.Show("没有可导出的数据!");
                return;
            }
            if (ExcelHelperForCs.ExportToExcel(dataGridViewX1) != null)
            {
                MessageBox.Show("导出完成");
            }
        }
    }
}
