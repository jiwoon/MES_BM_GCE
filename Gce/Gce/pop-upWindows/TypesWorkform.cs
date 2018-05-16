using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gce_Model;
using Gce_Bll;
using Gce.Windows;

namespace Gce.pop_upWindows
{
    public partial class TypesWorkform : Office2007Form
    {
        //类对象
        PTypesWorkBll ptwb = new PTypesWorkBll();

        //数据集合
        List<PTypesWork> TreeList = new List<PTypesWork>();

        //状态
        string state = "browse";

        public TypesWorkform()
        {
            InitializeComponent();
        }

        private void TypesWorkform_Load(object sender, EventArgs e)
        {
            SetTreeView(-1);//加载TreeView

            SetControlsBtn();
        }

        void SetControlsBtn()
        {
            if (state == "browse")
            {
                btni_new.Enabled = true;
                btni_save.Enabled = false;
                btni_cancle.Enabled = false;
                btni_modify.Enabled = true;
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
                btni_modify.Enabled = false;
                btni_delete.Enabled = false;
                btni_lookup.Enabled = false;

                treeView1.Enabled = false;
                panelEx1.Enabled = true;
            }

        }


        void SetTreeView(int number)
        {
            TreeList.Clear();
            treeView1.Nodes.Clear();

            TreeList = ptwb.selectPTypesWorkDal("selectPTypesWork");

            TreeNode tn = new TreeNode();
            tn.Text = "工作种类";
            treeView1.Nodes.Add(tn);
            for (int i = 0; i < TreeList.Count; i++)
            {
                TreeNode tnChild = new TreeNode();
                tnChild.Text = TreeList[i].TypesWork;
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

        private void btni_new_Click(object sender, EventArgs e)
        {
            state = "insert";

            SetControlsBtn();
        }

        private void btni_save_Click(object sender, EventArgs e)
        {
            if (state == "insert")
            {
                if (!ptwb.checkedPTypesWorkBll(txt_typeswork.Text.Trim(), "checkedPTypesWork"))
                {
                    List<PTypesWork> list = new List<PTypesWork>();
                    list.Add(new PTypesWork()
                    {
                        TypesWork=txt_typeswork.Text.Trim()
                    });
                    if (ptwb.insertPTypesWorkBll(list, "insertPTypesWork"))
                    {
                        MessageBox.Show("保存成功！");
                        state = "browse";
                        SetControlsBtn();
                        SetTreeView(-1);
                    }
                    else
                    {
                        MessageBox.Show("保存失败!");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("此工作种类已存在！");
                    return;
                }
            }
            else if (state == "modify")
            {
                if (ptwb.checkedPTypesWorkBll(treeView1.SelectedNode.Text.Trim(), "checkedPTypesWork"))
                {
                    List<PTypesWork> list1 = new List<PTypesWork>();
                    list1.Add(new PTypesWork()
                    {
                        TypesWork = txt_typeswork.Text.Trim()
                    });
                    if (ptwb.updatePTypesWorkBll(treeView1.SelectedNode.Text.Trim(), list1, "updatePTypesWork"))
                    {
                        MessageBox.Show("保存成功!");
                        state = "browse";
                        SetControlsBtn();
                        SetTreeView(Convert.ToInt32(treeView1.SelectedNode.Tag));
                    }
                }
                else
                {
                    MessageBox.Show("该工种不存在!");
                    return;
                }

            }
        }

        private void btni_cancle_Click(object sender, EventArgs e)
        {
            state = "browse";

            SetControlsBtn();
        }

        private void btni_modify_Click(object sender, EventArgs e)
        {
            state = "modify";

            SetControlsBtn();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != treeView1.Nodes[0])
            {
                UpdateControls(Convert.ToInt32(e.Node.Tag));
            }
            else
            {
                UpdateControls(-1);
            }
        }

        void UpdateControls(int i)
        {
            if (i >= 0)
            {
                txt_typeswork.Text = TreeList[i].TypesWork;
            }
            else
            {
                txt_typeswork.Text = "";
            }
        }

        private void btni_delete_Click(object sender, EventArgs e)
        {
            List<PTypesWork> list=new List<PTypesWork>();
            list.Add(new PTypesWork(){
                TypesWork=txt_typeswork.Text.Trim()
            });
            if (ptwb.insertPTypesWorkBll(list, "deletePTypesWork"))
            {
                MessageBox.Show("删除成功！");
                SetTreeView(-1);
            }
            else
            {
                MessageBox.Show("删除失败！");
                SetTreeView(-1);
            }
        }

        private void btni_lookup_Click(object sender, EventArgs e)
        {
            Queryform qf = new Queryform(TreeList,"工种名", this);
            qf.ShowDialog();
        }

        public void SelectedTreeviewNode(string nodesName)
        {
            foreach (TreeNode item in treeView1.Nodes[0].Nodes)
            {
                if (item.Text == nodesName)
                {
                    this.treeView1.SelectedNode = item;
                }
            }
        }
    }
}
