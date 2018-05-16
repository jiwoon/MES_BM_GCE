using DevComponents.DotNetBar;
using Gce.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gce_Model;
using Gce_Bll;
using Bll;
using Gce_Common;
using Gce.pop_upWindows;

namespace Gce.MoreDocumentsWindows
{
    public partial class FinancialInputERP : Office2007Form
    {
        Gce G;
        /// <summary>
        /// 业务逻辑层对象
        /// </summary>
        PurchaseReceiptBll prb = new PurchaseReceiptBll();
        /// <summary>
        /// 数据源集合
        /// </summary>
        List<FinancialInputERPModel> DataList = new List<FinancialInputERPModel>();
        public FinancialInputERP()
        {
            InitializeComponent();
        }

        public FinancialInputERP(Gce g)
        {
            InitializeComponent();
            this.G = g;
        }

        private void FinancialInputERP_Load(object sender, EventArgs e)
        {
            this.Loead();
            this.Loead1();
        }

        void Loead1()
        {
            DataList = prb.selectPurchaseReceiptFinancialEntryBll("selectPurchaseReceiptFinancialEntry");
            dataGridViewX1.DataSource = DataList;
        }

        void Loead()
        {
            DataGridViewTextBoxColumn newcol = new DataGridViewTextBoxColumn();
            newcol.HeaderText = "序号";
            newcol.Name = "PurchaseReceiptID";
            newcol.DataPropertyName = "PurchaseReceiptID";
            newcol.Width = 150;
            newcol.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol.Tag = 0;
            this.dataGridViewX1.Columns.Insert(0, newcol);

            DataGridViewTextBoxColumn newcol1 = new DataGridViewTextBoxColumn();
            newcol1.HeaderText = "采购订单号";
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
            newcol7.HeaderText = "二维码标记数量";
            newcol7.Name = "ProductQuantity";
            newcol7.DataPropertyName = "ProductQuantity";
            newcol7.Width = 120;
            newcol7.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol7.Tag = 7;
            this.dataGridViewX1.Columns.Insert(7, newcol7);

            //DataGridViewTextBoxColumn newcol8 = new DataGridViewTextBoxColumn();
            //newcol8.HeaderText = "二维码标记数量";
            //newcol8.Name = "ProductQuantity";
            //newcol8.DataPropertyName = "ProductQuantity";
            //newcol8.Width = 120;
            //newcol8.SortMode = DataGridViewColumnSortMode.NotSortable;
            //newcol8.Tag = 8;
            //this.dataGridViewX1.Columns.Insert(8, newcol8);

            DataGridViewTextBoxColumn newcol8 = new DataGridViewTextBoxColumn();
            newcol8.HeaderText = "确定数量数量";
            newcol8.Name = "ProductQuantity1";
            newcol8.DataPropertyName = "ProductQuantity1";
            newcol8.Width = 120;
            newcol8.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol8.Tag = 8;
            this.dataGridViewX1.Columns.Insert(8, newcol8);

            DataGridViewTextBoxColumn newcol9 = new DataGridViewTextBoxColumn();
            newcol9.HeaderText = "最近一次更新时间";
            newcol9.Name = "Updatetime1";
            newcol9.DataPropertyName = "Updatetime1";
            newcol9.Width = 120;
            newcol9.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol9.Tag = 9;
            this.dataGridViewX1.Columns.Insert(9, newcol9);

            DataGridViewTextBoxColumn newcol10 = new DataGridViewTextBoxColumn();
            newcol10.HeaderText = "备注";
            newcol10.Name = "note";
            newcol10.DataPropertyName = "note";
            newcol10.Width = 120;
            newcol10.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol10.Tag = 10;
            this.dataGridViewX1.Columns.Insert(10, newcol10);

            DataGridViewTextBoxColumn newcol11 = new DataGridViewTextBoxColumn();
            newcol11.HeaderText = "紧急程度";
            newcol11.Name = "OrderState";
            newcol11.DataPropertyName = "OrderState";
            newcol11.Width = 120;
            newcol11.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol11.Tag = 11;
            newcol11.Visible = false;
            this.dataGridViewX1.Columns.Insert(11, newcol11);

            DataGridViewTextBoxColumn newcol12 = new DataGridViewTextBoxColumn();
            newcol12.HeaderText = "财务录入ERP状态";
            newcol12.Name = "FinancialEntry";
            newcol12.DataPropertyName = "FinancialEntry";
            newcol12.Width = 120;
            newcol12.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol12.Tag = 12;
            newcol12.Visible = false;
            this.dataGridViewX1.Columns.Insert(12, newcol12);

            DataGridViewTextBoxColumn newcol13 = new DataGridViewTextBoxColumn();
            newcol13.HeaderText = "财务录入ERP状态";
            newcol13.Name = "FinancialEntry";
            newcol13.DataPropertyName = "FinancialEntry";
            newcol13.Width = 120;
            newcol13.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol13.Tag = 13;
            newcol13.Visible = false;
            this.dataGridViewX1.Columns.Insert(13, newcol13);

            DataGridViewTextBoxColumn newcol15 = new DataGridViewTextBoxColumn();
            newcol15.HeaderText = "录入人员名";
            newcol15.Name = "FinancialEntryName";
            newcol15.DataPropertyName = "FinancialEntryName";
            newcol15.Width = 120;
            newcol15.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol15.Tag = 14;
            newcol15.Visible = false;
            this.dataGridViewX1.Columns.Insert(14, newcol15);

            DataGridViewTextBoxColumn newcol14 = new DataGridViewTextBoxColumn();
            newcol14.HeaderText = "录入时间";
            newcol14.Name = "FinancialEntryTime";
            newcol14.DataPropertyName = "FinancialEntryTime";
            newcol14.Width = 120;
            newcol14.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol14.Tag = 14;
            newcol14.Visible = false;
            this.dataGridViewX1.Columns.Insert(15, newcol14);

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
            if (DataList.Count > 0)
            {
                this.SetTxtBox(DataList[dataGridViewX1.CurrentRow.Index]);
            }
            else
            {
                this.clearTxtBox();
            }
        }

        /// <summary>
        /// 给输入框控件赋值
        /// </summary>
        /// <param name="IIM"></param>
        void SetTxtBox(FinancialInputERPModel IIM)
        {

            TxtBox_PurchaseReceiptID.Text = IIM.PurchaseReceiptID;
            TxtBox_PurchaseNo.Text = IIM.PurchaseNo;
            TxtBox_SupplierName.Text = IIM.SupplierName;
            TxtBox_BatchNo.Text = IIM.BatchNo;
            TxtBox_MaterialCode.Text = IIM.MaterialCode;
            TxtBox_MaterialName.Text = IIM.MaterialName;
            TxtBox_MaterialSpecifications.Text = IIM.MaterialSpecifications;
            ip_ProductQuantity.Text = IIM.ProductQuantity.ToString();
            ip_ProductQuantity1.Text = IIM.ProductQuantity1.ToString();
            comb_state.SelectedIndex = IIM.OrderState;
            comb_FinancialEntry.SelectedIndex = IIM.FinancialEntry == "" ? 0 : 1;
        }

        void clearTxtBox()
        {

            TxtBox_PurchaseReceiptID.Text = "";
            TxtBox_PurchaseNo.Text = "";
            TxtBox_SupplierName.Text = "";
            TxtBox_BatchNo.Text = "";
            TxtBox_MaterialCode.Text = "";
            TxtBox_MaterialName.Text = "";
            TxtBox_MaterialSpecifications.Text = "";
            ip_ProductQuantity.Text = "";
            ip_ProductQuantity1.Text = "";
            comb_state.SelectedIndex = 0;
            comb_FinancialEntry.SelectedIndex = 0;
        }
        private void btni_sava_Click(object sender, EventArgs e)
        {
            this.save();
        }

        bool Message()
        {
            if (!UsersHelp.checkLogin)
            {
                MessageBox.Show("未登录！");
                return true;
            }
            else if (TxtBox_PurchaseReceiptID.Text.Trim() == "")
            {
                MessageBox.Show("序号不能为空!");
                return true;
            }
            else if (comb_FinancialEntry.Text.Trim() == "")
            {
                MessageBox.Show("录入状态不能为空！");
                return true;
            }
            else
            {
                return false;
            }
        }

        FinancialInputERPModel GetFinancialInputERPModel()
        {
            FinancialInputERPModel finerp = new FinancialInputERPModel()
            {
                PurchaseReceiptID=TxtBox_PurchaseReceiptID.Text.Trim(),
                FinancialEntry=comb_FinancialEntry.Text.Trim(),
                FinancialEntryTime=DateTime.Now,
                FinancialEntryName=UsersHelp.Userslist[0].UserName
            };

            return finerp;
        }

        void save()
        {
            if (Message()) return;

            G.Setlb_QueryState("正在保存");
            try
            {
                if (prb.updatePurchaseReceiptFinancialEntryBll(this.GetFinancialInputERPModel(), "updatePurchaseReceiptFinancialEntry"))
                {
                    int i = dataGridViewX1.CurrentRow.Index;
                    dataGridViewX1.DataSource = new List<FinancialInputERPModel>();
                    DataList.RemoveAt(i);
                    dataGridViewX1.DataSource = DataList;
                    G.Setlb_QueryState("完成");
                }
                else
                { G.Setlb_QueryState("保存异常"); }
            }
            catch
            {
                G.Setlb_QueryState("保存异常");
            }
        }

        private void btni_update_Click(object sender, EventArgs e)
        {
            Loead1();
        }

        private void dataGridViewX1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataList.Count > 0)
            {
                InputERP_Message Inerp=new InputERP_Message(DataList[this.dataGridViewX1.CurrentRow.Index]);
                Inerp.ShowDialog();
            }
        }
    }
}
    