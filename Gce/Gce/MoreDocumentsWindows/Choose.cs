using DevComponents.DotNetBar;
using Gce.pop_upWindows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gce_Model;
using Bll;
using Gce_Bll;
using System.Globalization;
using Gce_Common;

namespace Gce.MoreDocumentsWindows
{
    public partial class Choose : Office2007Form
    {
        private Gce G;

        PurchaseReceiptBll prb = new PurchaseReceiptBll();

        List<ChooseModel> DataList = new List<ChooseModel>();

        public Choose()
        {
            InitializeComponent();
        }

        public Choose(Gce g)
        {
            InitializeComponent();
            this.G = g;
        }

        /// <summary>
        /// 拿到二维码
        /// </summary>
        /// <param name="str"></param>
        public void GetQr(string str)
        {
            List<string> list = prb.GetQr(str);

            this.SetDgv_IncomingInspection(list);
        }

        private void SetDgv_IncomingInspection(List<string> strlist)
        {
            //try
            //{
            //    DataList = prb.selectPurchaseReceiptChooseDal(strlist[0], "selectPurchaseReceiptChoose");
            //    this.dataGridViewX1.DataSource = DataList;
            //}
            //catch
            //{
            //    MessageBox.Show("查询超时，请检查网络连接情况");
            //}
        }

        private void dataGridViewX1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(this.dataGridViewX1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, CultureInfo.CurrentUICulture),
                e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            }
        }

        private void Choose_Load(object sender, EventArgs e)
        {
            this.Loead();
            this.Loead1();
        }

        void Loead1()
        {
            try
            {
                DataList = prb.selectPurchaseReceiptChooseDal("selectPurchaseReceiptChoose");
                this.dataGridViewX1.DataSource = DataList;
            }
            catch
            {
                MessageBox.Show("查询超时，请检查网络连接情况");
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
            newcol8.HeaderText = "合格率(%)";
            newcol8.Name = "QualifiedRate";
            newcol8.DataPropertyName = "QualifiedRate";
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
            newcol10.HeaderText = "紧急程度";
            newcol10.Name = "OrderState";
            newcol10.DataPropertyName = "OrderState";
            newcol10.Width = 120;
            newcol10.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol10.Tag = 10;
            newcol10.Visible = false;
            this.dataGridViewX1.Columns.Insert(10, newcol10);

            DataGridViewTextBoxColumn newcol11 = new DataGridViewTextBoxColumn();
            newcol11.HeaderText = "备注";
            newcol11.Name = "note";
            newcol11.DataPropertyName = "note";
            newcol11.Width = 120;
            newcol11.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol11.Tag = 11;
            this.dataGridViewX1.Columns.Insert(11, newcol11);

            DataGridViewTextBoxColumn newcol12 = new DataGridViewTextBoxColumn();
            newcol12.HeaderText = "";
            newcol12.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            newcol12.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewX1.Columns.Insert(12, newcol12);
        }

        private void dataGridViewX1_SelectionChanged(object sender, EventArgs e)
        {
            this.dataGridViewX1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (DataList.Count > 0)
            {
                this.SetTxtBox(DataList[dataGridViewX1.CurrentRow.Index]);
            }
        }

        void SetTxtBox(ChooseModel IIM)
        {

            TxtBox_PurchaseReceiptID.Text = IIM.PurchaseReceiptID;
            TxtBox_PurchaseNo.Text = IIM.PurchaseNo;
            TxtBox_SupplierName.Text = IIM.SupplierName;
            TxtBox_BatchNo.Text = IIM.BatchNo;
            TxtBox_MaterialCode.Text = IIM.MaterialCode;
            TxtBox_MaterialName.Text = IIM.MaterialName;
            TxtBox_MaterialSpecifications.Text = IIM.MaterialSpecifications;
            ip_ProductQuantity.Text = IIM.ProductQuantity1.ToString();
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
            else if (ip_ChooseNumber.Text.Trim() == "")
            {
                MessageBox.Show("合格数不能为空!");
                return true;
            }
            else if (ip_NotChooseNumber.Text.Trim() == "")
            {
                MessageBox.Show("不合格数不能为空!");
                return true;
            }
            else if ((ip_ChooseNumber.Value + ip_NotChooseNumber.Value) != ip_ProductQuantity.Value)
            {
                MessageBox.Show("合格数与不合格数的和要等于数量!");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btni_save_Click(object sender, EventArgs e)
        {
            if (Message()) return;

            G.Setlb_QueryState("正在保存");
            try
            {

                if (prb.updatePurchaseReceiptChooseBll(TxtBox_PurchaseReceiptID.Text.Trim(), ip_ChooseNumber.Value, ip_NotChooseNumber.Value, UsersHelp.Userslist[0].UserName,DateTime.Now, "updatePurchaseReceiptChoose"))
                {
                    int i = dataGridViewX1.CurrentRow.Index;
                    dataGridViewX1.DataSource = new List<ChooseModel>();
                    DataList.RemoveAt(i);
                    dataGridViewX1.DataSource = DataList;
                    G.Setlb_QueryState("完成");
                }
                else
                { G.Setlb_QueryState("保存异常"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                G.Setlb_QueryState("保存异常");
            }
        }

        private void btni_update_Click(object sender, EventArgs e)
        {
            Loead1();
        }
    }
}
