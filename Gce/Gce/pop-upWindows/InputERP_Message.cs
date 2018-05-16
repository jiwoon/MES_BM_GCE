using DevComponents.DotNetBar;
using Gce_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gce.pop_upWindows
{
    public partial class InputERP_Message : Office2007Form
    {
        FinancialInputERPModel FinERP;

        public InputERP_Message()
        {
            InitializeComponent();
        }

        public InputERP_Message(FinancialInputERPModel finERP)
        {
            InitializeComponent();

            this.FinERP = finERP;
        }

        private void InputERP_Message_Load(object sender, EventArgs e)
        {
            this.textBoxX1.AppendText("时间序号：" + FinERP.PurchaseReceiptID + "\r\n");
            this.textBoxX1.AppendText("采购订单号：" + FinERP.PurchaseNo + "\r\n");
            this.textBoxX1.AppendText("供应商名：" + FinERP.SupplierName + "\r\n");
            this.textBoxX1.AppendText("物料批次号：" + FinERP.BatchNo + "\r\n");
            this.textBoxX1.AppendText("物料编码：" + FinERP.MaterialCode + "\r\n");
            this.textBoxX1.AppendText("物料名称：" + FinERP.MaterialName + "\r\n");
            this.textBoxX1.AppendText("物料规格：" + FinERP.MaterialSpecifications + "\r\n");
            this.textBoxX1.AppendText("二维码标记数量：" + FinERP.ProductQuantity.ToString() + "\r\n");
            this.textBoxX1.AppendText("确定数量：" + FinERP.ProductQuantity1.ToString() + "\r\n");
            this.textBoxX1.AppendText("更新时间：" + FinERP.Updatetime1.ToString() + "\r\n");
            this.textBoxX1.AppendText("备注：" + FinERP.note + "\r\n");

        }


    }
}
