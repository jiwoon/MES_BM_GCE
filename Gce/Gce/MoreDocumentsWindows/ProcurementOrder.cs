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
using Bll;
using Model;
using Gce.pop_upWindows;
using Gce_Common;
using System.Globalization;

namespace Gce.Windows
{
    public partial class ProcurementOrder : Office2007Form
    {
        private Gce G;

        PurchaseReceiptBll prb = new PurchaseReceiptBll();

        private List<PurchaseReceipt> DataList = new List<PurchaseReceipt>();

        bool clear1 = false;
        public ProcurementOrder()
        {
            InitializeComponent();
        }

        public ProcurementOrder(Gce gce)
        {
            InitializeComponent();
            this.G = gce;
        }
        private void LeviteOrder_Load(object sender, EventArgs e)
        {

        }

        private void setDgv_ProcurementOrder()
        { 

        }

        private void Dgv_ProcurementOrder_SelectionChanged(object sender, EventArgs e)
        {
            this.Dgv_ProcurementOrder.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (DataList.Count > 0 && !clear1)
            {
                try
                {
                    if (!(Dgv_ProcurementOrder.CurrentRow.Index > DataList.Count))
                    {
                        this.SelectDgv(DataList[Dgv_ProcurementOrder.CurrentRow.Index]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            clear1 = false;
        }

        private void btni_ScanQRCode_Click(object sender, EventArgs e)
        {
            ScanForm sf = new ScanForm(this);
            sf.ShowDialog();
        }

        void Load1()
        {
            Dgv_ProcurementOrder.DataSource = DataList;
        }

        public void GetQr(string strQr)
        {
            try
            {

                List<string> list = new List<string>();
                string str1;
                while (strQr.Length != 0)
                {
                    int i = strQr.IndexOf("：");
                    int j = strQr.IndexOf("@");
                    if (i == -1)
                    {
                        i = strQr.IndexOf(":");
                    }
                    if (j != -1)
                    {
                        str1 = strQr.Substring(i + 1, j - i - 1);
                        strQr = strQr.Remove(0, j + 1);
                    }
                    else
                    {
                        str1 = strQr.Substring(i + 1, strQr.Length - i - 1);
                        strQr = strQr.Remove(0, strQr.Length);
                    }

                    list.Add(str1);
                }
                this.SetTextBox(list);
            }
            catch
            {
                MessageBox.Show("条码信息格式出错");
            }
        }
        /// <summary>
        /// 赋值输入框控件
        /// </summary>
        /// <param name="list"></param>
        void SetTextBox(List<string> list)
        {
            if (list.Count <= 0)
            {
                return;
            }
            ip_ProductQuantity1.Text = "";
            TxtBox_note.Text = "";

            TxtBox_PurchaseReceiptID.Text = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            TxtBox_PurchaseNo.Text = list[0];
            TxtBox_SupplierName.Text = list[1];
            TxtBox_BatchNo.Text = list[2];
            TxtBox_MaterialCode.Text = list[3];
            TxtBox_MaterialName.Text = list[4];
            TxtBox_MaterialSpecifications.Text = list[5];
            ip_ProductQuantity.Text = list[6];
            ip_ProductQuantity1.Text = list[6];

            comb_state.SelectedIndex = 0;

            dti_Updatetime.Value = DateTime.Now;
        }


        private void btni_Save_Click(object sender, EventArgs e)
        {
            this.SaveData();
        }

        void SaveData()
        {
            if (this.Message1())
            {
                return;
            }
            G.Setlb_QueryState("正在保存");
            try
            {
                if (prb.insertPurchaseReceiptBll(this.GetList(), "insertPurchaseReceipt"))
                {
                    this.SetDGV(this.GetList());
                    G.Setlb_QueryState("完成");
                }
            }
            catch
            {
                try
                {
                    if (prb.updatePurchaseReceiptBll(this.GetList(), "updatePurchaseReceipt"))
                    {
                        this.UpdateDVG(this.GetList(), Dgv_ProcurementOrder.CurrentRow.Index);
                        G.Setlb_QueryState("完成");
                    }
                    else
                    {
                        G.Setlb_QueryState("保存失败");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    G.Setlb_QueryState("保存异常");   
                }
            }
        }

        bool Message1()
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
            else if (ip_ProductQuantity1.Text == "")
            {
                MessageBox.Show("确定数量不能不为空!");
                return true;
            }
            else if (dti_Updatetime.Text == "")
            {
                MessageBox.Show("扫码时间不能为空!");
                return true;
            }
            else if (comb_state.Text == "")
            {
                MessageBox.Show("订单状态不能为空!");
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 获取输入框值的实体类集合
        /// </summary>
        /// <returns></returns>
        List<PurchaseReceipt> GetList()
        {
            List<PurchaseReceipt> list = new List<PurchaseReceipt>();
            list.Add(new PurchaseReceipt()
                {
                    PurchaseReceiptID=TxtBox_PurchaseReceiptID.Text.Trim(),
                    PurchaseNo=TxtBox_PurchaseNo.Text.Trim(),
                    SupplierName=TxtBox_SupplierName.Text.Trim(),
                    BatchNo=TxtBox_BatchNo.Text.Trim(),
                    MaterialCode=TxtBox_MaterialCode.Text.Trim(),
                    MaterialName=TxtBox_MaterialName.Text.Trim(),
                    MaterialSpecifications=TxtBox_MaterialSpecifications.Text.Trim(),
                    ProductQuantity=ip_ProductQuantity.Value,
                    ProductQuantity1=ip_ProductQuantity1.Value,
                    CheckAudit="未审核",
                    CheckQualified="未检测",
                    CheckSpecialMining="未检测",
                    note=TxtBox_note.Text,
                    ScanningTime=dti_Updatetime.Value,
                    Updatetime=DateTime.Now,
                    UserName = UsersHelp.Userslist[0].UserName,
                    OrderState=comb_state.SelectedIndex
                });

            return list;
        }

        void SetDGV(List<PurchaseReceipt> list)
        {
            Dgv_ProcurementOrder.DataSource = new List<PurchaseReceipt>();
            DataList.AddRange(list);
            Dgv_ProcurementOrder.DataSource = DataList;

            Dgv_ProcurementOrder.CurrentCell = Dgv_ProcurementOrder.Rows[Dgv_ProcurementOrder.Rows.Count - 1].Cells[0];
        }

        void UpdateDVG(List<PurchaseReceipt> list,int i)
        {
            Dgv_ProcurementOrder.DataSource = new List<PurchaseReceipt>();
            DataList[i] = list[0];
            Dgv_ProcurementOrder.DataSource = DataList;

            Dgv_ProcurementOrder.CurrentCell = Dgv_ProcurementOrder.Rows[i].Cells[0];
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="list"></param>
        /// <param name="i"></param>
        void DeleteDVG(int i)
        {
            Dgv_ProcurementOrder.DataSource = new List<PurchaseReceipt>();
            DataList.RemoveAt(i);
            Dgv_ProcurementOrder.DataSource = DataList;
        }

        private void ProcurementOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            G.lb_QueryStateVisible();
        }
        /// <summary>
        /// 行数的写入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_ProcurementOrder_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(this.Dgv_ProcurementOrder.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, CultureInfo.CurrentUICulture),
                e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            }
        }
        /// <summary>
        /// 选择DataGridView时赋值输入控件
        /// </summary>
        /// <param name="pur"></param>
        void SelectDgv(PurchaseReceipt pur)
        {
            ip_ProductQuantity1.Value = pur.ProductQuantity1;
            TxtBox_note.Text = pur.note;

            TxtBox_PurchaseReceiptID.Text = pur.PurchaseReceiptID;
            TxtBox_PurchaseNo.Text = pur.PurchaseNo;
            TxtBox_SupplierName.Text = pur.SupplierName;
            TxtBox_BatchNo.Text = pur.BatchNo;
            TxtBox_MaterialCode.Text = pur.MaterialCode;
            TxtBox_MaterialName.Text = pur.MaterialName;
            TxtBox_MaterialSpecifications.Text = pur.MaterialSpecifications;
            ip_ProductQuantity.Value = pur.ProductQuantity;

            dti_Updatetime.Value = pur.Updatetime;
        }
        //清空输入控件
        private void btni_Clear_Click(object sender, EventArgs e)
        {
            this.clear1 = true;
            this.ClearTxt();
        }
        /// <summary>
        /// 情况输入控件
        /// </summary>
        void ClearTxt()
        {
            ip_ProductQuantity1.Text = "";
            TxtBox_note.Text = "";

            TxtBox_PurchaseReceiptID.Text = "";
            TxtBox_PurchaseNo.Text = "";
            TxtBox_SupplierName.Text = "";
            TxtBox_BatchNo.Text = "";
            TxtBox_MaterialCode.Text = "";
            TxtBox_MaterialName.Text = "";
            TxtBox_MaterialSpecifications.Text = "";
            ip_ProductQuantity.Text = "";

            dti_Updatetime.Text = "";
        }

        private void btni_delete_Click(object sender, EventArgs e)
        {
            this.DeletePu();
        }
        /// <summary>
        /// 删除事件
        /// </summary>
        void DeletePu()
        {
            try
            {
                if (DataList.Count > 0)
                {
                    if (MessageBox.Show("确定删除？", "系统提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        G.Setlb_QueryState("正在删除");
                        if (prb.deletePurchaseReceiptBll(DataList[Dgv_ProcurementOrder.CurrentRow.Index].PurchaseReceiptID, "deletePurchaseReceipt"))
                        {
                            this.DeleteDVG(Dgv_ProcurementOrder.CurrentRow.Index);
                            G.Setlb_QueryState("完成");
                        }
                    }
                }
            }
            catch
            {
                G.Setlb_QueryState("删除异常");
            }
        }

        private void btni_scan_Click(object sender, EventArgs e)
        {
            this.clear1 = true;
            this.ClearTxt();

            this.TxtBox_PurchaseReceiptID.Text = DateTime.Now.ToString("yyyyMMddHHmmssfff"); 
        }

        private void btni_ScanGun_Click(object sender, EventArgs e)
        {
            ScanGunForm scangun = new ScanGunForm(this);
            scangun.ShowDialog();
        }
    }
}
