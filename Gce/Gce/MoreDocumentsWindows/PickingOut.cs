using Bll;
using DevComponents.DotNetBar;
using Gce.pop_upWindows;
using Gce_Bll;
using Gce_Common;
using Gce_Model;
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
    public partial class PickingOut : Office2007Form
    {

        private Gce G;

        PurchaseReceiptBll prb = new PurchaseReceiptBll();

        PWarehouseTable_PickingOutBll pwareBll = new PWarehouseTable_PickingOutBll();

        List<PWarehouseTable_PickingOut> DataList = new List<PWarehouseTable_PickingOut>();

        private int number = 0;

        public PickingOut()
        {
            InitializeComponent();
        } 

        public PickingOut(Gce g)
        {
            InitializeComponent();
            this.G = g;
        }

        private void btni_scan_Click(object sender, EventArgs e)
        {
            ScanForm Sf = new ScanForm(this);
            Sf.ShowDialog();
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

        private void SetDgv_IncomingInspection(List<string> list)
        {
            if (list.Count < 5)
            {
                return;
            }

            TxtBox_PurchaseReceiptID.Text = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            TxtBox_PurchaseNo.Text = list[0];
            TxtBox_SupplierName.Text = list[1];
            TxtBox_BatchNo.Text = list[2];
            TxtBox_MaterialCode.Text = list[3];
            TxtBox_MaterialName.Text = list[4];
            TxtBox_MaterialSpecifications.Text = list[5];
            number = pwareBll.PWarehouseTable_DetailedPWarehouseTable_PickingOutSUMBll(TxtBox_MaterialName.Text.Trim(), "PWarehouseTable_DetailedPWarehouseTable_PickingOutSUM");
            txt_Number.Text = number.ToString();
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

            DataGridViewTextBoxColumn newcol13 = new DataGridViewTextBoxColumn();
            newcol13.HeaderText = "储存地址";
            newcol13.Name = "StorageAddress";
            newcol13.DataPropertyName = "StorageAddress";
            newcol13.Width = 120;
            newcol13.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol13.Tag = 13;
            newcol13.Visible = false;
            this.dataGridViewX1.Columns.Insert(10, newcol13);

            DataGridViewTextBoxColumn newcol12 = new DataGridViewTextBoxColumn();
            newcol12.HeaderText = "";
            newcol12.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            newcol12.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewX1.Columns.Insert(11, newcol12);


        }

        private void PickingOut_Load(object sender, EventArgs e)
        {
            Loead();
        }

        private void btni_ScanGun_Click(object sender, EventArgs e)
        {
            ScanGunForm scangun = new ScanGunForm(this);
            scangun.ShowDialog();
        }

        private void btni_PeckingOut_Click(object sender, EventArgs e)
        {
            PeckingOut();
        }

        bool Message()
        {
            if (TxtBox_PurchaseReceiptID.Text == "")
            {
                MessageBox.Show("序列号不能为空！");
                return true;
            }
            else if (TxtBox_SupplierName.Text == "")
            {
                MessageBox.Show("供应商不能为空!");
                return true;
            }
            else if (TxtBox_PurchaseNo.Text == "")
            {
                MessageBox.Show("采购订单号不能为空！");
                return true;
            }
            else if (TxtBox_MaterialCode.Text == "")
            {
                MessageBox.Show("物料编码不能为空！");
                return true;
            }
            else if (TxtBox_MaterialName.Text == "")
            {
                MessageBox.Show("物料名称不能为空！");
                return true;
            }
            else if (TxtBox_MaterialSpecifications.Text == "")
            {
                MessageBox.Show("物料规格不能为空！");
                return true;
            }
            else if (TxtBox_BatchNo.Text == "")
            {
                MessageBox.Show("供应商生产批次号不能为空!");
                return true;
            }
            else if (ip_ProductQuantity.Text == "")
            {
                MessageBox.Show("数量不能为空！");
                return true;
            }
            else if (!UsersHelp.checkLogin)
            {
                MessageBox.Show("未登录！");
                return true;
            }
            else
            {
                return false;
            }
        }

        PWarehouseTable_PickingOut GetPWarehouseTable_PickingOut()
        {
            PWarehouseTable_PickingOut pw = new PWarehouseTable_PickingOut();
            pw.PurchaseReceiptID = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            pw.PurchaseNo = TxtBox_PurchaseNo.Text.Trim();
            pw.SupplierName = TxtBox_SupplierName.Text.Trim();
            pw.BatchNo = TxtBox_BatchNo.Text.Trim();
            pw.MaterialCode = TxtBox_MaterialCode.Text.Trim();
            pw.MaterialName = TxtBox_MaterialName.Text.Trim();
            pw.MaterialSpecifications = TxtBox_MaterialSpecifications.Text.Trim();
            pw.ProductQuantity = ip_ProductQuantity.Value;
            pw.note = TxtBox_note.Text.Trim();
            pw.StorageAddress = "";
            pw.UserName = UsersHelp.Userslist[0].UserName;

            return pw;
        }

        void PeckingOut()
        {
            if (Message()) return;           

            if (number < ip_ProductQuantity.Value)
            {
                int i =  ip_ProductQuantity.Value - number;

                MessageBox.Show("物料不足，\r\n" + "欠料：" + i.ToString(), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            G.Setlb_QueryState("正在保存...");
            try
            {
                if (pwareBll.insertPWarehouseTable_PickingOutBll(GetPWarehouseTable_PickingOut(), "insertPWarehouseTable_PickingOut"))
                {
                    G.Setlb_QueryState("完成");
                    dataGridViewX1.DataSource = new List<PWarehouseTable_PickingOut>();
                    DataList.Add(GetPWarehouseTable_PickingOut());
                    dataGridViewX1.DataSource = DataList;
                    number = pwareBll.PWarehouseTable_DetailedPWarehouseTable_PickingOutSUMBll(TxtBox_MaterialName.Text.Trim(), "PWarehouseTable_DetailedPWarehouseTable_PickingOutSUM");
                    txt_Number.Text = number.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
    