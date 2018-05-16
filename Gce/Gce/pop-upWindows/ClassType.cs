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
using Gce.Windows;

namespace Gce.pop_upWindows
{
    public partial class ClassType : Office2007Form
    {
        ClassType_tableBll ctBll = new ClassType_tableBll();

        IncomingInspection Iintion;
        List<string> TreeList = new List<string>();

        string state = "browse";
        public ClassType()
        {
            InitializeComponent();
        }

        public ClassType(IncomingInspection iintion)
        {
            InitializeComponent();
            this.Iintion = iintion;
        }

        private void ClassType_Load(object sender, EventArgs e)
        {
            SetTreeView(-1);
        }

        void SetTreeView(int number)
        {
            treeView1.Nodes.Clear();
            TreeList.Clear();

            TreeList = ctBll.selectClassType_tableDal("selectClassType_table");

            TreeNode tn = new TreeNode();
            tn.Text = "异常类别";
            treeView1.Nodes.Add(tn);
            for (int i = 0; i < TreeList.Count; i++)
            {
                TreeNode tnChild = new TreeNode();
                tnChild.Text = TreeList[i];
                tnChild.Tag = i;
                tn.Nodes.Add(tnChild);
            }
            if (number >= 0)
            {
                if (treeView1.Nodes[0].LastNode != null)
                {
                    treeView1.Nodes[0].Expand();
                    treeView1.SelectedNode = treeView1.Nodes[0].Nodes[number];
                }

            }
            else
            {
                if (treeView1.Nodes[0].LastNode != null)
                {
                    treeView1.Nodes[0].Expand();
                    treeView1.SelectedNode = treeView1.Nodes[0].LastNode;
                }
            }
        }
        void UpdateBtni()
        {
            if (state == "browse")
            {
                btni_new.Enabled = true;
                btni_save.Enabled = false;
                btni_cancle.Enabled = false;
                btni_delete.Enabled = true;
                btni_lookup.Enabled = true;

                treeView1.Enabled = true;
                panelEx1.Enabled = false;
            }
            else
            {
                btni_new.Enabled = false;
                btni_save.Enabled = true;
                btni_cancle.Enabled = true;
                btni_delete.Enabled = false;
                btni_lookup.Enabled = false;

                treeView1.Enabled = false;
                panelEx1.Enabled = true;
            }
        }

        private void btni_new_Click(object sender, EventArgs e)
        {
            state = "insert";

            UpdateBtni();
        }

        private void btni_cancle_Click(object sender, EventArgs e)
        {
            state = "browse";

            UpdateBtni();
        }

        private void btni_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (ctBll.insertClassType_tableBll(txt_classType.Text.Trim(), "insertClassType_table"))
                {
                    MessageBox.Show("保存成功");
                    this.SetTreeView(-1);
                    this.state = "browse";
                    this.UpdateBtni();
                }
                else
                {
                    MessageBox.Show("保存失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClassType_FormClosed(object sender, FormClosedEventArgs e)
        {
            Iintion.SetctBll(TreeList);
        }

        private void btni_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (ctBll.insertClassType_tableBll(txt_classType.Text.Trim(), "deleteClassType_table"))
                {
                    MessageBox.Show("删除成功");
                    this.SetTreeView(-1);
                    this.state = "browse";
                    this.UpdateBtni();
                }
                else
                {
                    MessageBox.Show("删除失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btni_lookup_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == treeView1.Nodes[0])
            {
                txt_classType.Text = "";
                return;
            }
            txt_classType.Text = e.Node.Text.Trim();
        }
    }
}
