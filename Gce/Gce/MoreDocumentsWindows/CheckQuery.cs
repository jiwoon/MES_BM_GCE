using Bll;
using DevComponents.DotNetBar;
using Gce.pop_upWindows;
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

namespace Gce.MoreDocumentsWindows
{
    public partial class CheckQuery : Office2007Form
    {

        private Gce G;

        private Thread th;

        private PurchaseReceiptBll prBll = new PurchaseReceiptBll();

        SynchronizationContext my_Syscontext = null;

        public CheckQuery()
        {
            InitializeComponent();
        }

        public CheckQuery(Gce g)
        {
            InitializeComponent();
            this.G = g;
        }

        private void btni_query_Click(object sender, EventArgs e)
        {
            List<selectPurchaseReceiptCheckQualifiedModel> list = new List<selectPurchaseReceiptCheckQualifiedModel>();
            list.Add(new selectPurchaseReceiptCheckQualifiedModel()
            {
                PurchaseNo=TxtBox_PurchaseNo.Text.Trim(),
                MaterialCode=TxtBox_MaterialCode.Text.Trim(),
                MaterialName=TxtBox_MaterialName.Text.Trim(),
                SupplierName=TxtBox_SupplierName.Text.Trim(),
                QualifiedRate=input_QualifiedRate.Text.Trim()
            });

            DateTime beginTime = Dti_Begin.Value;
            DateTime endTime = Dti_End.Value;

            G.Setlb_QueryState("正在查询...");
            th = new Thread(delegate(){
                Query(list,beginTime,endTime);
            });
            th.IsBackground = true;
            th.Start();
        }

        void Query(List<selectPurchaseReceiptCheckQualifiedModel> list,DateTime beginTime,DateTime endTime)
        {
            my_Syscontext.Post(SetDGV, prBll.selectPurchaseReceiptCheckQualifiedBll(list, beginTime, endTime, "selectPurchaseReceiptCheckQualified"));
        }

        private void CheckQuery_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            DateTime startTime = new DateTime(dt.Year, dt.Month, dt.Day, 00, 00, 00);
            DateTime endTime = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
            Dti_Begin.Value = startTime;
            Dti_End.Value = endTime;
            my_Syscontext = SynchronizationContext.Current;
            Loead();
        }

        private void Dgv_IncomingInspection_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(this.dataGridViewX1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, CultureInfo.CurrentUICulture),
                e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            }
        }

        void SetDGV(object o)
        {
            List<selectPurchaseReceiptCheckQualifiedModel> list = o as List<selectPurchaseReceiptCheckQualifiedModel>;
            dataGridViewX1.DataSource = list;
            G.Setlb_QueryState("完成");
        }

        void Loead()
        {
            DataGridViewTextBoxColumn newcol = new DataGridViewTextBoxColumn();
            newcol.HeaderText = "检验时间";
            newcol.Name = "QualifiedTime2";
            newcol.DataPropertyName = "QualifiedTime2";
            newcol.Width = 150;
            newcol.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol.Tag = 0;
            this.dataGridViewX1.Columns.Insert(0, newcol);

            DataGridViewTextBoxColumn newcol1 = new DataGridViewTextBoxColumn();
            newcol1.HeaderText = "订单号";
            newcol1.Name = "PurchaseNo";
            newcol1.DataPropertyName = "PurchaseNo";
            newcol1.Width = 120;
            newcol1.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol1.Tag = 1;
            this.dataGridViewX1.Columns.Insert(1, newcol1);

            DataGridViewTextBoxColumn newcol2 = new DataGridViewTextBoxColumn();
            newcol2.HeaderText = "物料编码";
            newcol2.Name = "MaterialCode";
            newcol2.DataPropertyName = "MaterialCode";
            newcol2.Width = 120;
            newcol2.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol2.Tag = 2;
            this.dataGridViewX1.Columns.Insert(2, newcol2);


            DataGridViewTextBoxColumn newcol3 = new DataGridViewTextBoxColumn();
            newcol3.HeaderText = "物料名称";
            newcol3.Name = "MaterialName";
            newcol3.DataPropertyName = "MaterialName";
            newcol3.Width = 120;
            newcol3.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol3.Tag = 3;
            this.dataGridViewX1.Columns.Insert(3, newcol3);

            DataGridViewTextBoxColumn newcol4 = new DataGridViewTextBoxColumn();
            newcol4.HeaderText = "供应商";
            newcol4.Name = "SupplierName";
            newcol4.DataPropertyName = "SupplierName";
            newcol4.Width = 120;
            newcol4.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol4.Tag = 4;
            this.dataGridViewX1.Columns.Insert(4, newcol4);

            DataGridViewTextBoxColumn newcol5 = new DataGridViewTextBoxColumn();
            newcol5.HeaderText = "来料数量";
            newcol5.Name = "ProductQuantity1";
            newcol5.DataPropertyName = "ProductQuantity1";
            newcol5.Width = 120;
            newcol5.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol5.Tag = 5;
            this.dataGridViewX1.Columns.Insert(5, newcol5);

            DataGridViewTextBoxColumn newcol11 = new DataGridViewTextBoxColumn();
            newcol11.HeaderText = "检查数量";
            newcol11.Name = "CheckNumber";
            newcol11.DataPropertyName = "CheckNumber";
            newcol11.Width = 120;
            newcol11.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol11.Tag = 11;
            this.dataGridViewX1.Columns.Insert(6, newcol11);

            DataGridViewTextBoxColumn newcol6 = new DataGridViewTextBoxColumn();
            newcol6.HeaderText = "合格率";
            newcol6.Name = "QualifiedRate";
            newcol6.DataPropertyName = "QualifiedRate";
            newcol6.Width = 120;
            newcol6.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol6.Tag = 6;
            this.dataGridViewX1.Columns.Insert(7, newcol6);

            DataGridViewTextBoxColumn newcol12 = new DataGridViewTextBoxColumn();
            newcol12.HeaderText = "异常类别";
            newcol12.Name = "classType";
            newcol12.DataPropertyName = "classType";
            newcol12.Width = 120;
            newcol12.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol12.Tag = 12;
            this.dataGridViewX1.Columns.Insert(8, newcol12);

            DataGridViewTextBoxColumn newcol13 = new DataGridViewTextBoxColumn();
            newcol13.HeaderText = "问题描述";
            newcol13.Name = "ProblemDescription";
            newcol13.DataPropertyName = "ProblemDescription";
            newcol13.Width = 120;
            newcol13.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol13.Tag = 13;
            this.dataGridViewX1.Columns.Insert(9, newcol13);

            DataGridViewTextBoxColumn newcol7 = new DataGridViewTextBoxColumn();
            newcol7.HeaderText = "质检人员";
            newcol7.Name = "CheckQualifiedUserName";
            newcol7.DataPropertyName = "CheckQualifiedUserName";
            newcol7.Width = 120;
            newcol7.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol7.Tag = 7;
            this.dataGridViewX1.Columns.Insert(10, newcol7);

            DataGridViewTextBoxColumn newcol8 = new DataGridViewTextBoxColumn();
            newcol8.HeaderText = "是否合格";
            newcol8.Name = "WhetherQualified";
            newcol8.DataPropertyName = "WhetherQualified";
            newcol8.Width = 120;
            newcol8.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol8.Tag = 8;
            //newcol8.Visible = false;
            this.dataGridViewX1.Columns.Insert(11, newcol8);

            DataGridViewTextBoxColumn newcol9 = new DataGridViewTextBoxColumn();
            newcol9.HeaderText = "是否特采";
            newcol9.Name = "CheckSpecialMining";
            newcol9.DataPropertyName = "CheckSpecialMining";
            newcol9.Width = 120;
            newcol9.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol9.Tag = 9;
            this.dataGridViewX1.Columns.Insert(12, newcol9);

            DataGridViewTextBoxColumn newcol16 = new DataGridViewTextBoxColumn();
            newcol16.HeaderText = "责任归属";
            newcol16.Name = "AttributionResponsibility";
            newcol16.DataPropertyName = "AttributionResponsibility";
            newcol16.Width = 120;
            newcol16.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol16.Tag = 16;
            this.dataGridViewX1.Columns.Insert(13, newcol16);

            DataGridViewTextBoxColumn newcol17 = new DataGridViewTextBoxColumn();
            newcol17.HeaderText = "8D报告回复";
            newcol17.Name = "Presentation8D";
            newcol17.DataPropertyName = "Presentation8D";
            newcol17.Width = 120;
            newcol17.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol17.Tag = 17;
            this.dataGridViewX1.Columns.Insert(14, newcol17);

            DataGridViewTextBoxColumn newcol10 = new DataGridViewTextBoxColumn();
            newcol10.HeaderText = "备注";
            newcol10.Name = "note";
            newcol10.DataPropertyName = "note";
            newcol10.Width = 120;
            newcol10.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol10.Tag = 10;
            this.dataGridViewX1.Columns.Insert(15, newcol10);



            //DataGridViewTextBoxColumn newcol11 = new DataGridViewTextBoxColumn();
            //newcol11.HeaderText = "最近一次更新时间";
            //newcol11.Name = "Updatetime1";
            //newcol11.DataPropertyName = "Updatetime1";
            //newcol11.Width = 120;
            //newcol11.SortMode = DataGridViewColumnSortMode.NotSortable;
            //newcol11.Tag = 11;
            //this.dataGridViewX1.Columns.Insert(11, newcol11);

            DataGridViewTextBoxColumn newcol15 = new DataGridViewTextBoxColumn();
            newcol15.HeaderText = "";
            newcol15.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            newcol15.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewX1.Columns.Insert(16, newcol15);


        }

        private void dataGridViewX1_SelectionChanged(object sender, EventArgs e)
        {
            this.dataGridViewX1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btni_StatisticsQuery_Click(object sender, EventArgs e)
        {
            StatisticsQuery sq = new StatisticsQuery();
            sq.ShowDialog();
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
