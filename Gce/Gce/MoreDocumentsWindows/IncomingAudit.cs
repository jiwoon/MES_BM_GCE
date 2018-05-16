using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gce_Bll;
using Gce_Model;
using Bll;
using System.Globalization;
using Gce_Common;

namespace Gce.MoreDocumentsWindows
{
    public partial class IncomingAudit : Office2007Form
    {
        private Gce G;

        List<IncomingAuditModel> DataList = new List<IncomingAuditModel>();

        PurchaseReceiptBll prb = new PurchaseReceiptBll();

        PWarehouseTable_ReturnGoodsBll pwareBll = new PWarehouseTable_ReturnGoodsBll();

        public IncomingAudit()
        {
            InitializeComponent();
        }

        public IncomingAudit(Gce g)
        {
            InitializeComponent();
            this.G = g;
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
            else if ((!ck_NotQualified.Checked) && (!ck_qualified.Checked) && (!ck_SpecialMining.Checked))
            {
                MessageBox.Show("没有判断；来料是否合格!");
                return true;
            }
            else
            {
                return false;
            }
        }

        void save()
        {
            if (Message()) return;

            G.Setlb_QueryState("正在保存");
            try
            {
                string checkAudit="已审核";
                string checkSpecialMining=ck_SpecialMining.Checked?"特采":"非特采";
                string ReturnGoods = ck_ReturnGoods.Checked ? "已退货" : null;

                
                    if (prb.updatePurchaseReceiptIncomingAuditBll(TxtBox_PurchaseReceiptID.Text.Trim(), checkAudit, checkSpecialMining, UsersHelp.Userslist[0].UserName, TxtBox_note.Text, txt_AttributionResponsibility.Text.Trim(), txt_Presentation8D.Text.Trim(), ck_qualified.Checked, ReturnGoods, "updatePurchaseReceiptIncomingAudit"))
                    {
                        if (ck_ReturnGoods.Checked)
                        {
                            if (pwareBll.insertPWarehouseTable_ReturnGoodsBll(GetPWarehouseTable_ReturnGoods(), "insertPWarehouseTable_ReturnGoods"))
                            { 

                            }
                            else
                            { G.Setlb_QueryState("保存异常"); }
                        }

                        int i = dataGridViewX1.CurrentRow.Index;
                        dataGridViewX1.DataSource = new List<IncomingAuditModel>();
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

        PWarehouseTable_ReturnGoods GetPWarehouseTable_ReturnGoods()
        {
            PWarehouseTable_ReturnGoods pwar = new PWarehouseTable_ReturnGoods()
            {
                PurchaseReceiptID = TxtBox_PurchaseReceiptID.Text.Trim(),
                PurchaseNo = TxtBox_PurchaseNo.Text.Trim(),
                SupplierName = TxtBox_SupplierName.Text.Trim(),
                BatchNo = TxtBox_BatchNo.Text.Trim(),
                MaterialCode = TxtBox_MaterialCode.Text.Trim(),
                MaterialName = TxtBox_MaterialName.Text.Trim(),
                MaterialSpecifications = TxtBox_MaterialSpecifications.Text.Trim(),
                ProductQuantity1 = ip_ProductQuantity.Value,
                note = TxtBox_note.Text,
                UserName = UsersHelp.Userslist[0].UserName
            };
            return pwar;
        }

        private void IncomingAudit_Load(object sender, EventArgs e)
        {
            Loead();
            Loead1();
        }
        void Loead1()
        {
            try
            {
                DataList = prb.selectPurchaseReceiptIncomingAuditBll("selectPurchaseReceiptIncomingAudit");
                dataGridViewX1.DataSource = DataList;
            }
            catch
            {
                MessageBox.Show("通信异常");
            }
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
            newcol7.HeaderText = "数量";
            newcol7.Name = "ProductQuantity1";
            newcol7.DataPropertyName = "ProductQuantity1";
            newcol7.Width = 120;
            newcol7.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol7.Tag = 7;
            this.dataGridViewX1.Columns.Insert(7, newcol7);

            DataGridViewTextBoxColumn newcol8 = new DataGridViewTextBoxColumn();
            newcol8.HeaderText = "合格率";
            newcol8.Name = "QualifiedRate";
            newcol8.DataPropertyName = "QualifiedRate";
            newcol8.Width = 120;
            newcol8.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol8.Tag = 8;
            this.dataGridViewX1.Columns.Insert(8, newcol8);

            DataGridViewTextBoxColumn newcol9 = new DataGridViewTextBoxColumn();
            newcol9.HeaderText = "财务录入ERP状态";
            newcol9.Name = "FinancialEntry";
            newcol9.DataPropertyName = "FinancialEntry";
            newcol9.Width = 120;
            newcol9.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol9.Tag = 9;
            this.dataGridViewX1.Columns.Insert(9, newcol9);

            DataGridViewTextBoxColumn newcol10 = new DataGridViewTextBoxColumn();
            newcol10.HeaderText = "审核状态";
            newcol10.Name = "CheckAudit";
            newcol10.DataPropertyName = "CheckAudit";
            newcol10.Width = 120;
            newcol10.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol10.Tag = 10;
            this.dataGridViewX1.Columns.Insert(10, newcol10);



            DataGridViewTextBoxColumn newcol11 = new DataGridViewTextBoxColumn();
            newcol11.HeaderText = "最近一次更新时间";
            newcol11.Name = "Updatetime1";
            newcol11.DataPropertyName = "Updatetime1";
            newcol11.Width = 120;
            newcol11.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol11.Tag = 11;
            this.dataGridViewX1.Columns.Insert(11, newcol11);

            DataGridViewTextBoxColumn newcol12 = new DataGridViewTextBoxColumn();
            newcol12.HeaderText = "备注";
            newcol12.Name = "note";
            newcol12.DataPropertyName = "note";
            newcol12.Width = 120;
            newcol12.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol12.Tag = 12;
            this.dataGridViewX1.Columns.Insert(12, newcol12);

            DataGridViewTextBoxColumn newcol13 = new DataGridViewTextBoxColumn();
            newcol13.HeaderText = "紧急程度";
            newcol13.Name = "OrderState";
            newcol13.DataPropertyName = "OrderState";
            newcol13.Width = 120;
            newcol13.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol13.Tag = 13;
            newcol13.Visible = false;
            this.dataGridViewX1.Columns.Insert(13, newcol13);

            DataGridViewTextBoxColumn newcol14 = new DataGridViewTextBoxColumn();
            newcol14.HeaderText = "是否合格";
            newcol14.Name = "WhetherQualified";
            newcol14.DataPropertyName = "WhetherQualified";
            newcol14.Width = 120;
            newcol14.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol14.Tag = 14;
            newcol14.Visible = false;
            this.dataGridViewX1.Columns.Insert(14, newcol14);

            DataGridViewTextBoxColumn newcol15 = new DataGridViewTextBoxColumn();
            newcol15.HeaderText = "";
            newcol15.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            newcol15.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewX1.Columns.Insert(15, newcol15);


        }

        private void ck_NotQualified_CheckedChanged(object sender, EventArgs e)
        {
            ck_qualified.Checked = !ck_NotQualified.Checked;
            if (ck_NotQualified.Checked)
            {
                ck_SpecialMining.Enabled = true;
                ck_ReturnGoods.Enabled = true;
            }
            else
            {
                ck_SpecialMining.Checked = false;
                ck_SpecialMining.Enabled = false;
                ck_ReturnGoods.Enabled = false;
                ck_ReturnGoods.Checked = false;
            }
        }

        private void ck_qualified_CheckedChanged(object sender, EventArgs e)
        {
            ck_NotQualified.Checked = !ck_qualified.Checked;
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

        void SetTxtBox(IncomingAuditModel IIM)
        {

            TxtBox_PurchaseReceiptID.Text = IIM.PurchaseReceiptID;
            TxtBox_PurchaseNo.Text = IIM.PurchaseNo;
            TxtBox_SupplierName.Text = IIM.SupplierName;
            TxtBox_BatchNo.Text = IIM.BatchNo;
            TxtBox_MaterialCode.Text = IIM.MaterialCode;
            TxtBox_MaterialName.Text = IIM.MaterialName;
            TxtBox_MaterialSpecifications.Text = IIM.MaterialSpecifications;
            ip_ProductQuantity.Text = IIM.ProductQuantity1.ToString();
            ck_qualified.Checked = IIM.WhetherQualified;
            ck_NotQualified.Checked = !IIM.WhetherQualified;
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
            ck_qualified.Checked = false;
            ck_NotQualified.Checked = false;
        }

        private void btni_update_Click(object sender, EventArgs e)
        {
            Loead1();
        }

        private void ck_SpecialMining_CheckedChanged(object sender, EventArgs e)
        {

            ck_ReturnGoods.Checked = !ck_SpecialMining.Checked;

        }

        private void ck_ReturnGoods_CheckedChanged(object sender, EventArgs e)
        {
            ck_SpecialMining.Checked = !ck_ReturnGoods.Checked;
        }
    }
}
