using Bll;
using DevComponents.DotNetBar;
using Gce.pop_upWindows;
using Gce_Bll;
using Gce_Common;
using Gce_Model;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gce.Windows
{
    public partial class IncomingInspection : Office2007Form
    {
        PurchaseReceiptBll prb = new PurchaseReceiptBll();
        ClassType_tableBll ctBll = new ClassType_tableBll();

        private Gce G;

        List<IncomingInspectionModel> DataList = new List<IncomingInspectionModel>();
        public IncomingInspection()
        {
            InitializeComponent();
        }

        public IncomingInspection(Gce g)
        {
            InitializeComponent();
            this.G = g;
        }

        private void IncomingInspection_Load(object sender, EventArgs e)
        {
            this.Loead();
        }

        void Loead()
        {
            DataList = prb.selectPurchaseNoPurchaseReceiptBll("selectPurchaseNoPurchaseReceipt");
            Dgv_IncomingInspection.DataSource = DataList;

            List<string> TreeList = ctBll.selectClassType_tableDal("selectClassType_table");
            combo_ClassType.DataSource = TreeList;
        }
        private void SetDgv_IncomingInspection(List<string> strlist)
        {

        }

        private void Dgv_IncomingInspection_SelectionChanged(object sender, EventArgs e)
        {
            this.Dgv_IncomingInspection.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (DataList.Count > 0)
            {
                this.SetTxtBox(DataList[Dgv_IncomingInspection.CurrentRow.Index]);
            }
        }

        private void Dgv_IncomingInspection_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(this.Dgv_IncomingInspection.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, CultureInfo.CurrentUICulture),
                e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            }
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
        /// <summary>
        /// 给输入框控件赋值
        /// </summary>
        /// <param name="IIM"></param>
        void SetTxtBox(IncomingInspectionModel IIM)
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
            input_QualifiedRate.Value = (int)IIM.QualifiedRate;
        }

        IncomingInspectionModel GetIncoming()
        {
           return new IncomingInspectionModel()
            {
                PurchaseReceiptID=TxtBox_PurchaseReceiptID.Text.Trim(),
                CheckQualified="已检测",
                CheckQualifiedUserName = UsersHelp.Userslist[0].UserName,
                QualifiedTime1 = DateTime.Now,
                QualifiedTime2=DateTime.Now,
                CheckNumber=input_CheckNumber.Value,
                classType=combo_ClassType.Text,
                ProblemDescription=txt_wentimiaoshu.Text,
                QualifiedRate= (double)input_QualifiedRate.Value
            };
        }

        private void btni_sava_Click(object sender, EventArgs e)
        {
            this.sava();
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
            else if (comb_state.Text == "")
            {
                MessageBox.Show("订单状态不能为空!");
                return true;
            }
            else if (input_QualifiedRate.Text == "")
            {
                MessageBox.Show("合格率不能为空!");
                return true; 
            }
            else if (input_CheckNumber.Value == 0 || input_CheckNumber.Text == "")
            {
                MessageBox.Show("必须输入检查数量!");
                return true; 
            }
            else if ((!ck_NotQualified.Checked) && (!ck_qualified.Checked))
            {
                MessageBox.Show("没有判断；来料是否合格!");
                return true;
            }
            else
            {
                return false;
            }
        }

        void sava()
        {
            if (Message1()) return;

            G.Setlb_QueryState("正在保存");
            try
            {
                if (prb.updatePurchaseReceiptQualifiedBll(GetIncoming(),ck_qualified.Checked, "updatePurchaseReceiptQualified"))
                {
                    int i = Dgv_IncomingInspection.CurrentRow.Index;
                    Dgv_IncomingInspection.DataSource = new List<IncomingInspectionModel>();
                    DataList.RemoveAt(i);
                    Dgv_IncomingInspection.DataSource = DataList;
                    G.Setlb_QueryState("完成");
                }
                else
                {
                    G.Setlb_QueryState("保存失败");
                }
            }
            catch(Exception ex)
            {
                G.Setlb_QueryState(ex.Message);
            }
        }

        private void btni_update_Click(object sender, EventArgs e)
        {
            Loead();
        }

        private void ck_qualified_CheckedChanged(object sender, EventArgs e)
        {
            ck_NotQualified.Checked = !ck_qualified.Checked;
        }

        private void ck_NotQualified_CheckedChanged(object sender, EventArgs e)
        {
            ck_qualified.Checked = !ck_NotQualified.Checked;
        }

        private void btni_ClassType_Click(object sender, EventArgs e)
        {
            ClassType ct = new ClassType(this);
            ct.ShowDialog();
        }

        public void SetctBll(List<string> list)
        {
            combo_ClassType.DataSource = list;
        }
    }
}
