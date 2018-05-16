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
using Model;
using Bll;
using System.Threading;
using Gce_Bll;
using Gce_Model;

namespace Gce.Windows
{
    public partial class QrCodeScanning : Office2007Form
    {
        SynchronizationContext My_context;

        Gce G;

        PWarehouseTable_DetailedBll pwaBll = new PWarehouseTable_DetailedBll();

        Thread th1;

        public QrCodeScanning()
        {
            InitializeComponent();
        }

        public QrCodeScanning(Gce g)
        {
            InitializeComponent();
            this.G = g;
        }

        private void QrCodeScanning_Load(object sender, EventArgs e)
        {
            ck_Stock.Checked = true;
            My_context = SynchronizationContext.Current;
            setDateTime();
        }
        private void setDateTime()
        {
            DateTime dt = DateTime.Now;
            DateTime startTime = new DateTime(dt.Year, dt.Month, dt.Day, 00, 00, 00);
            DateTime endTime = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
            Dti_Begin.Value = startTime;
            Dti_End.Value = endTime;
        }

        private void btni_query_Click(object sender, EventArgs e)
        {
            if (ck_Stock.Checked)
            {
                if (th1 != null)
                {
                    th1.Abort();
                }
                G.Setlb_QueryState("正在查询...");
                th1 = new Thread(delegate()
                {
                    Query(txt_MaterialName.Text.Trim(), txt_MaterialCode.Text.Trim(), txt_SupplierName.Text.Trim(), pwaBll);
                });
                th1.IsBackground = true;
                th1.Start();
            }

            if (ck_WarehousingDetails.Checked)
            {
                if (th1 != null)
                {
                    th1.Abort();
                }
                G.Setlb_QueryState("正在查询...");

                th1 = new Thread(delegate()
                {
                    Query1(txt_MaterialName.Text.Trim(), txt_MaterialCode.Text.Trim(), txt_SupplierName.Text.Trim(), pwaBll,Dti_Begin.Value,Dti_End.Value);
                });
                th1.IsBackground = true;
                th1.Start();
            }

            if (ck_MaterialList.Checked)
            {
                if (th1 != null)
                {
                    th1.Abort();
                }
                G.Setlb_QueryState("正在查询...");
                th1 = new Thread(delegate()
                {
                    Query2(txt_MaterialName.Text.Trim(), txt_MaterialCode.Text.Trim(), txt_SupplierName.Text.Trim(), pwaBll, Dti_Begin.Value, Dti_End.Value);
                });
                th1.IsBackground = true;
                th1.Start();
            }
        }
        /// <summary>
        /// 库存
        /// </summary>
        /// <param name="MaterialName"></param>
        /// <param name="MaterialCode"></param>
        /// <param name="SupplierName"></param>
        /// <param name="pwabll"></param>
        void Query(string MaterialName, string MaterialCode, string SupplierName, PWarehouseTable_DetailedBll pwabll)
        {

            List<string> strList = pwabll.selectPWarehouseTable_DetailedMaterialNameBll(MaterialName, MaterialCode, SupplierName, "selectPWarehouseTable_DetailedMaterialName");
            
            if (strList.Count <= 0)
            {
                return;
            }
            List<ck_StockModel> datalist = new List<ck_StockModel>();

            foreach (string item in strList)
            {
                datalist.Add(pwabll.selectPWarehouseTable_DetailedProductQuantityBll(item, "selectPWarehouseTable_DetailedProductQuantity"));
            }
            My_context.Post(SetDataGridCk_Stock, datalist);
        }
        /// <summary>
        /// 入库明细
        /// </summary>
        /// <param name="MaterialName"></param>
        /// <param name="MaterialCode"></param>
        /// <param name="SupplierName"></param>
        /// <param name="pwabll"></param>
        /// <param name="BeginTime"></param>
        /// <param name="EndTime"></param>
        void Query1(string MaterialName, string MaterialCode, string SupplierName, PWarehouseTable_DetailedBll pwabll,DateTime BeginTime,DateTime EndTime)
        {
            My_context.Post(SetDataGridCk_WarehousingDetails, pwabll.selectPWarehouseTable_DetailedBll(MaterialName, MaterialCode, SupplierName, BeginTime, EndTime, "selectPWarehouseTable_Detailed"));

        }

        void Query2(string MaterialName, string MaterialCode, string SupplierName, PWarehouseTable_DetailedBll pwabll, DateTime BeginTime, DateTime EndTime)
        {
            My_context.Post(SetDataGridCk_WarehousingDetails, pwabll.selectPWarehouseTable_DetailedBll(MaterialName, MaterialCode, SupplierName, BeginTime, EndTime, "selectPWarehouseTable_PickingOut"));

        }

        void SetDataGridCk_Stock(object o)
        {
            List<ck_StockModel> DataList = o as List<ck_StockModel>;
            Loead1();
            if (DataList.Count == 0)
            {
                dataGridViewX1.DataSource = new List<ck_StockModel>();
                G.Setlb_QueryState("完成");
            }
            else
            {
                dataGridViewX1.DataSource = DataList;
                G.Setlb_QueryState("完成");
            }
        }

        void SetDataGridCk_WarehousingDetails(object o)
        {
            List<PWarehouseTable_Detailed> DataList = o as List<PWarehouseTable_Detailed>;
            Loead();
            if (DataList.Count == 0)
            {
                dataGridViewX1.DataSource = new List<PWarehouseTable_Detailed>();
                G.Setlb_QueryState("完成");
            }
            else
            {
                dataGridViewX1.DataSource = DataList;
                G.Setlb_QueryState("完成");
            }
            
            
        }

        private void ck_Stock_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_Stock.Checked)
            {
                ck_MaterialList.Checked = false;
                ck_WarehousingDetails.Checked = false;
            }
        }

        private void ck_WarehousingDetails_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_WarehousingDetails.Checked)
            {
                ck_Stock.Checked = false;
                ck_MaterialList.Checked = false;
            }
        }

        private void ck_MaterialList_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_MaterialList.Checked)
            {
                ck_Stock.Checked = false;
                ck_WarehousingDetails.Checked = false;
            }
        }

        void Loead()
        {
            this.dataGridViewX1.Columns.Clear();

            DataGridViewTextBoxColumn newcol = new DataGridViewTextBoxColumn();
            newcol.HeaderText = "序号";
            newcol.Name = "PurchaseReceiptID";
            newcol.DataPropertyName = "PurchaseReceiptID";
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
            newcol2.HeaderText = "供应商";
            newcol2.Name = "SupplierName";
            newcol2.DataPropertyName = "SupplierName";
            newcol2.Width = 120;
            newcol2.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol2.Tag = 2;
            this.dataGridViewX1.Columns.Insert(2, newcol2);


            DataGridViewTextBoxColumn newcol3 = new DataGridViewTextBoxColumn();
            newcol3.HeaderText = "物料批次号";
            newcol3.Name = "BatchNo";
            newcol3.DataPropertyName = "BatchNo";
            newcol3.Width = 120;
            newcol3.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol3.Tag = 3;
            this.dataGridViewX1.Columns.Insert(3, newcol3);

            DataGridViewTextBoxColumn newcol4 = new DataGridViewTextBoxColumn();
            newcol4.HeaderText = "物料编码";
            newcol4.Name = "MaterialCode";
            newcol4.DataPropertyName = "MaterialCode";
            newcol4.Width = 120;
            newcol4.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol4.Tag = 4;
            this.dataGridViewX1.Columns.Insert(4, newcol4);

            DataGridViewTextBoxColumn newcol5 = new DataGridViewTextBoxColumn();
            newcol5.HeaderText = "物料名称";
            newcol5.Name = "MaterialName";
            newcol5.DataPropertyName = "MaterialName";
            newcol5.Width = 120;
            newcol5.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol5.Tag = 5;
            this.dataGridViewX1.Columns.Insert(5, newcol5);

            DataGridViewTextBoxColumn newcol6 = new DataGridViewTextBoxColumn();
            newcol6.HeaderText = "物料规格";
            newcol6.Name = "MaterialSpecifications";
            newcol6.DataPropertyName = "MaterialSpecifications";
            newcol6.Width = 120;
            newcol6.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol6.Tag = 6;
            this.dataGridViewX1.Columns.Insert(6, newcol6);

            DataGridViewTextBoxColumn newcol7 = new DataGridViewTextBoxColumn();
            newcol7.HeaderText = "数量";
            newcol7.Name = "ProductQuantity";
            newcol7.DataPropertyName = "ProductQuantity";
            newcol7.Width = 120;
            newcol7.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol7.Tag = 7;
            this.dataGridViewX1.Columns.Insert(7, newcol7);

            DataGridViewTextBoxColumn newcol14 = new DataGridViewTextBoxColumn();
            newcol14.HeaderText = "操作员";
            newcol14.Name = "UserName";
            newcol14.DataPropertyName = "UserName";
            newcol14.Width = 120;
            newcol14.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol14.Tag = 14;
            //newcol11.Visible = false;
            this.dataGridViewX1.Columns.Insert(8, newcol14);

            DataGridViewTextBoxColumn newcol11 = new DataGridViewTextBoxColumn();
            newcol11.HeaderText = "备注";
            newcol11.Name = "note";
            newcol11.DataPropertyName = "note";
            newcol11.Width = 120;
            newcol11.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol11.Tag = 11;
            //newcol11.Visible = false;
            this.dataGridViewX1.Columns.Insert(9, newcol11);

            DataGridViewTextBoxColumn newcol16 = new DataGridViewTextBoxColumn();
            newcol16.HeaderText = "更新时间";
            newcol16.Name = "UpdateTime";
            newcol16.DataPropertyName = "UpdateTime";
            newcol16.Width = 120;
            newcol16.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol16.Tag = 16;
            this.dataGridViewX1.Columns.Insert(10, newcol16);

            DataGridViewTextBoxColumn newcol13 = new DataGridViewTextBoxColumn();
            newcol13.HeaderText = "储存地址";
            newcol13.Name = "StorageAddress";
            newcol13.DataPropertyName = "StorageAddress";
            newcol13.Width = 120;
            newcol13.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol13.Tag = 13;
            newcol13.Visible = false;
            this.dataGridViewX1.Columns.Insert(11, newcol13);

            DataGridViewTextBoxColumn newcol12 = new DataGridViewTextBoxColumn();
            newcol12.HeaderText = "";
            newcol12.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            newcol12.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewX1.Columns.Insert(12, newcol12);


        }

        void Loead1()
        {
            this.dataGridViewX1.Columns.Clear();

            DataGridViewTextBoxColumn newcol = new DataGridViewTextBoxColumn();
            newcol.HeaderText = "物料名称";
            newcol.Name = "MaterialName";
            newcol.DataPropertyName = "MaterialName";
            newcol.Width = 150;
            newcol.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol.Tag = 0;
            this.dataGridViewX1.Columns.Insert(0, newcol);

            DataGridViewTextBoxColumn newcol1 = new DataGridViewTextBoxColumn();
            newcol1.HeaderText = "数量";
            newcol1.Name = "ProductQuantity";
            newcol1.DataPropertyName = "ProductQuantity";
            newcol1.Width = 120;
            newcol1.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol1.Tag = 1;
            this.dataGridViewX1.Columns.Insert(1, newcol1);

            DataGridViewTextBoxColumn newcol12 = new DataGridViewTextBoxColumn();
            newcol12.HeaderText = "";
            newcol12.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            newcol12.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewX1.Columns.Insert(2, newcol12);
        }

    }
}
