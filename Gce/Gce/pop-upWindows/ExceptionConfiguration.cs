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
using Gce.Windows;

namespace Gce.pop_upWindows
{
    public partial class ExceptionConfiguration : Office2007Form
    {
        //类对象
        PExceptionTypesBll ptb = new PExceptionTypesBll();
        PEncodingSettingBll pesb = new PEncodingSettingBll();

        //数据源集合
        List<string> combList=new List<string>();
        List<PEncodingSetting> TreeList = new List<PEncodingSetting>();

        //存储状态
        string state = "browse";
        public ExceptionConfiguration()
        {
            InitializeComponent();
            UpdateBtni();
        }

        private void btni_new_Click(object sender, EventArgs e)
        {
            state = "insert";

            UpdateBtni();
        }

        private void btni_save_Click(object sender, EventArgs e)
        {
            if (state == "insert")
            {
                if (!pesb.checkedPEncodingSettingBll(txt_BarcodeEncoding.Text.Trim(), "checkedPEncodingSetting"))
                {
                    List<PEncodingSetting> list = new List<PEncodingSetting>();
                    list.Add(new PEncodingSetting()
                    {
                        BarcodeEncoding=txt_BarcodeEncoding.Text.Trim(),
                        ProblemDescription=txt_ProblemDescription.Text.Trim(),
                        ES_ExceptionTypes=comb_ExceptionTypes.Text.Trim()
                    });

                    if (pesb.insertPEncodingSettingBll(list, "insertPEncodingSetting"))
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
                else
                {
                    MessageBox.Show("编码已存在！");
                    return;
                }
            }
            else if (state == "modify")
            {
                if (pesb.checkedPEncodingSettingBll(txt_BarcodeEncoding.Text.Trim(), "checkedPEncodingSetting"))
                {
                    List<PEncodingSetting> list = new List<PEncodingSetting>();
                    list.Add(new PEncodingSetting()
                    {
                        BarcodeEncoding = txt_BarcodeEncoding.Text.Trim(),
                        ProblemDescription = txt_ProblemDescription.Text.Trim(),
                        ES_ExceptionTypes = comb_ExceptionTypes.Text.Trim()
                    });

                    if (pesb.insertPEncodingSettingBll(list, "updatePEncodingSetting"))
                    {
                        MessageBox.Show("保存成功");
                        this.SetTreeView(treeView1.SelectedNode.Index);
                        this.state = "browse";
                        this.UpdateBtni();
                    }
                    else
                    {
                        MessageBox.Show("保存失败");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("编码不存在！");
                    return;
                }
            }
        }

        private void btni_cancle_Click(object sender, EventArgs e)
        {
            state = "browse";

            UpdateBtni();
        }

        private void btni_modify_Click(object sender, EventArgs e)
        {
            state = "modify";

            UpdateBtni();
        }
        /// <summary>
        /// 更新按钮控件
        /// </summary>
        void UpdateBtni()
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

        private void btni_createType_Click(object sender, EventArgs e)
        {
            Create_ExceptionTypes cet = new Create_ExceptionTypes(this);
            cet.ShowDialog();
        }
        /// <summary>
        /// 添加异常类型并重新赋值控件
        /// </summary>
        /// <param name="str"></param>
        public void SetcombList(string str)
        {
            combList.Add(str);

            comb_ExceptionTypes.DataSource = new List<string>();

            comb_ExceptionTypes.DataSource = combList;
        }

        private void ExceptionConfiguration_Load(object sender, EventArgs e)
        {
            InitializationCombox();
            SetTreeView(-1);
        }
        /// <summary>
        /// 初始化comb_ExceptionTypes
        /// </summary>
        void InitializationCombox()
        {
            combList = ptb.selectPExceptionTypesBll("selectPExceptionTypes");

            comb_ExceptionTypes.DataSource = combList;
        }

        void SetTreeView(int number)
        {
            TreeList.Clear();
            treeView1.Nodes.Clear();

            TreeList = pesb.selectPEncodingSettingBll("selectPEncodingSetting");

            TreeNode tn = new TreeNode();
            tn.Text = "异常编码";
            treeView1.Nodes.Add(tn);
            for (int i = 0; i < TreeList.Count; i++)
            {
                TreeNode tnChild = new TreeNode();
                tnChild.Text = TreeList[i].BarcodeEncoding;
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

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.SetControls(TreeList[Convert.ToInt32(e.Node.Tag)]);
        }

        void SetControls(PEncodingSetting list)
        {
            txt_BarcodeEncoding.Text = list.BarcodeEncoding;
            txt_ProblemDescription.Text = list.ProblemDescription;
            comb_ExceptionTypes.Text = list.ES_ExceptionTypes;
        }

        private void btni_delete_Click(object sender, EventArgs e)
        {
            if(treeView1.SelectedNode==treeView1.Nodes[0])
            {
                return;
            }
            if (pesb.deletePEncodingSettingBll(treeView1.SelectedNode.Text.Trim(), "deletePEncodingSetting"))
            {
                MessageBox.Show("删除成功");
                this.SetTreeView(-1);
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        }

        private void btni_lookup_Click(object sender, EventArgs e)
        {
            Queryform qf = new Queryform(TreeList, "异常编码", this);
            qf.ShowDialog();
        }
        public void SelectedTreeviewNode(string Nodename)
        {
            foreach (TreeNode item in treeView1.Nodes[0].Nodes)
            {
                if (item.Text == Nodename)
                {
                    this.treeView1.SelectedNode = item;
                }
            }
        }
    }
}
