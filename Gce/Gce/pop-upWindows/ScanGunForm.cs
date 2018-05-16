using DevComponents.DotNetBar;
using Gce.MoreDocumentsWindows;
using Gce.Windows;
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
    public partial class ScanGunForm : Office2007Form
    {

        private ProcurementOrder Procur;

        private IncomingInspection IInspection;

        private PickingOut PickOut;

        private Choose Chooseform;

        public ScanGunForm()
        {
            InitializeComponent();
        }

        public ScanGunForm(IncomingInspection iinsoection)
        {
            InitializeComponent();
            this.IInspection = iinsoection;
        }

        public ScanGunForm(ProcurementOrder procur)
        {
            InitializeComponent();
            this.Procur = procur;
        }

        public ScanGunForm(Choose choose)
        {
            InitializeComponent();
            this.Chooseform = choose;
        }

        public ScanGunForm(PickingOut po)
        {
            InitializeComponent();
            this.PickOut = po;
        }

        private void txt_scan_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (txt_scan.Text.Trim()=="") return;

                //如果是采购入仓单功能进入的扫码
                if (Procur != null)
                {
                    Procur.GetQr(txt_scan.Text.Trim());
                }
                else if (IInspection != null)//如果是来料质检单功能进入的扫码
                {
                    IInspection.GetQr(txt_scan.Text.Trim());
                }
                else if (Chooseform != null)
                {
                    Chooseform.GetQr(txt_scan.Text.Trim());
                }
                else if (PickOut != null)//领料出仓
                {
                    PickOut.GetQr(txt_scan.Text.Trim());
                }
                this.Close();
            }
        }
    }
}
