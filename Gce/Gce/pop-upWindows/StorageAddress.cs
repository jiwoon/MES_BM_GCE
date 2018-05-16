using DevComponents.DotNetBar;
using Gce.MoreDocumentsWindows;
using Gce_Bll;
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
    public partial class StorageAddress : Office2007Form
    {
        private IncomingWarehousing IncomingWar;

        PWarehouseTable_titleBll pwb = new PWarehouseTable_titleBll();
        public StorageAddress()
        {
            InitializeComponent();
        }

        public StorageAddress(IncomingWarehousing Incoming)
        {
            InitializeComponent();
            this.IncomingWar = Incoming;
        }

        private void StorageAddress_Load(object sender, EventArgs e)
        {
            SetTreeeview();
        }

        void SetTreeeview()
        {
            this.treeView1.Nodes.Clear();

            LoadData(treeView1.Nodes, "0");
        }

        private void LoadData(TreeNodeCollection treeNodeCollection, string fid)
        {
            try
            {
                List<PWarehouseTable_title> DataList = pwb.selectPWarehouseTable_titleBll(fid, "selectPWarehouseTable_title");

                foreach (PWarehouseTable_title item in DataList)
                {
                    TreeNode tn = treeNodeCollection.Add(item.WarehouseName);
                    tn.Name = item.ID;
                    tn.Tag = item.FID;
                    LoadData(tn.Nodes, item.ID);
                }
            }
            catch
            {
                MessageBox.Show("加载异常，请检查网络连接情况");                
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.Nodes.Count > 0)
            {
                List<string> StrListNumber = new List<string>();

                StrListNumber = GetNumber(StrListNumber, e.Node.Parent);//获取所有父节点text递归方法

                SetTxtBox(StrListNumber, e.Node.Text.Trim());
            }
        }

        private List<string> GetNumber(List<string> StrListNumber, TreeNode treeNode)
        {
            if (treeNode != null)
            {
                StrListNumber.Insert(0,treeNode.Text.Trim());
                GetNumber(StrListNumber, treeNode.Parent);
            }

            return StrListNumber;
        }

        void SetTxtBox(List<string> StrListNumber,string nodetxt)
        {            
            StringBuilder str = new StringBuilder();
            StrListNumber.Add(nodetxt);
            if(StrListNumber.Count>0)
            {
                str.Append(string.Join("--", StrListNumber));
            }
            txt_rasaul.Text = str.ToString();
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Nodes.Count > 0)
            {
                MessageBox.Show("该节点存在下级子节点，请选择最下级节点点击完成");
                return;
            }

            IncomingWar.GetTxtbox(txt_rasaul.Text.Trim());
            this.Close();
        }

    }
}
