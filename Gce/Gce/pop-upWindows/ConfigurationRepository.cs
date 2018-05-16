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

namespace Gce.pop_upWindows
{
    public partial class ConfigurationRepository : Office2007Form
    {

        PWarehouseTable_titleBll pwb = new PWarehouseTable_titleBll();

        string state = "browse";
        public ConfigurationRepository()
        {
            InitializeComponent();
        }

        private void ConfigurationRepository_Load(object sender, EventArgs e)
        {
            SetTreeeview();
            uodateCotrls();
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

        private void btni_clearW_Click(object sender, EventArgs e)
        {
            state = "clearW";
            txt_Name.Text = "";
            uodateCotrls();
        }

        bool Message()
        {
            if (txt_Name.Text.Trim() == "")
            {
                MessageBox.Show("名称不能为空！");
                return true;
            }
            else return false;
        }

        PWarehouseTable_title GetPWarehouseTable_title(string Fid)
        {
            PWarehouseTable_title pwtable = new PWarehouseTable_title()
            {
                ID=Guid.NewGuid().ToString(),
                WarehouseName=txt_Name.Text.Trim(),
                FID=Fid
            };

            return pwtable;
        }
        /// <summary>
        /// 创建仓库
        /// </summary>
        void ClearW()
        {

            if (Message()) return;
            try
            {
                if (pwb.insertPWarehouseTable_titleBll(this.GetPWarehouseTable_title("0"), "insertPWarehouseTable_title"))
                {
                    MessageBox.Show("保存完成");
                    this.treeView1.Nodes.Clear();
                    LoadData(treeView1.Nodes, "0");
                }
                else
                {
                    MessageBox.Show("保存失败");
                }
            }
            catch
            {
                MessageBox.Show("保存异常，请检查网络连接情况");
            }

        }
        /// <summary>
        /// 创建同级
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItem2_Click(object sender, EventArgs e)
        {
            state = "ClearWTJ";
            txt_Name.Text = "";
            uodateCotrls();
        }
        /// <summary>
        /// 下级
        /// </summary>
        void ClearWXJ()
        {
            string Fid = "0";
            if (treeView1.Nodes.Count > 0)
            {
                Fid = treeView1.SelectedNode.Name.Trim();
            }

            if (Message()) return;
            try
            {
                if (pwb.insertPWarehouseTable_titleBll(this.GetPWarehouseTable_title(Fid), "insertPWarehouseTable_title"))
                {
                    MessageBox.Show("保存完成");
                    this.treeView1.Nodes.Clear();
                    LoadData(treeView1.Nodes, "0");
                }
                else
                {
                    MessageBox.Show("保存失败");
                }
            }
            catch
            {
                MessageBox.Show("保存异常，请检查网络连接情况");
            }

        }
        /// <summary>
        /// 创建下级
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItem3_Click(object sender, EventArgs e)
        {
            state = "ClearWXJ";
            txt_Name.Text = "";
            uodateCotrls();
        }

        void ClearWTJ()
        {
            string Fid = "0";
            if (treeView1.Nodes.Count > 0)
            {
                Fid = treeView1.SelectedNode.Tag.ToString();
            }

            if (Message()) return;
            try
            {
                if (pwb.insertPWarehouseTable_titleBll(this.GetPWarehouseTable_title(Fid), "insertPWarehouseTable_title"))
                {
                    MessageBox.Show("保存完成");
                    this.treeView1.Nodes.Clear();
                    LoadData(treeView1.Nodes, "0");
                }
                else
                {
                    MessageBox.Show("保存失败");
                }
            }
            catch
            {
                MessageBox.Show("保存异常，请检查网络连接情况");
            }

        }

        private void btni_save_Click(object sender, EventArgs e)
        {
            switch (state)
            {
                case "ClearWXJ":
                    this.ClearWXJ();
                    state = "browse";
                    uodateCotrls();
                    break;
                case "ClearWTJ":
                    this.ClearWTJ();
                    state = "browse";
                    uodateCotrls();
                    break;
                case "clearW":
                    this.ClearW();
                    state = "browse";
                    uodateCotrls();
                    break;
                case "modify":
                    modify1();
                    state = "browse";
                    uodateCotrls();
                    break;
            }
        }

        void uodateCotrls()
        {
            if (state == "browse")
            {
                treeView1.Enabled = true;
                panelEx1.Enabled = false;

                btni_save.Enabled = false;
                btni_cancle.Enabled = false;
                btni_delete.Enabled = true;
                btni_modify.Enabled = true;
                buttonItem2.Enabled = true;
                buttonItem3.Enabled = true;
                btni_clearW.Enabled = true;
            }
            else
            {
                treeView1.Enabled = false;
                panelEx1.Enabled = true;

                btni_save.Enabled = true;
                btni_cancle.Enabled = true;
                btni_delete.Enabled = false;
                btni_modify.Enabled = false;
                buttonItem2.Enabled = false;
                buttonItem3.Enabled = false;
                btni_clearW.Enabled = false;
            }
        }

        private void btni_modify_Click(object sender, EventArgs e)
        {
            state = "modify";

            uodateCotrls();
        }

        private void btni_cancle_Click(object sender, EventArgs e)
        {
            state = "browse";
            uodateCotrls();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                txt_Name.Text = e.Node.Text;
            }
            catch
            { 
                txt_Name.Text = "";            
            }
        }

        void modify1()
        {

            if (Message()) return;
            try
            {
                if (pwb.updatePWarehouseTable_titleBll(treeView1.SelectedNode.Name, txt_Name.Text.Trim(), "updatePWarehouseTable_title"))
                {
                    MessageBox.Show("保存完成");
                    this.treeView1.Nodes.Clear();
                    LoadData(treeView1.Nodes, "0");
                }
                else
                {
                    MessageBox.Show("保存失败");
                }
            }
            catch
            {
                MessageBox.Show("保存异常，请检查网络连接情况");
            }
        }

        private void btni_delete_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Nodes.Count > 0)
            {
                MessageBox.Show("该节点存在下级子节点，请删除子节点后再进行删除该节点");
                return;
            }

            if (MessageBox.Show("确定删除该节点？", "系统提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    if (pwb.deletePWarehouseTable_titleBll(treeView1.SelectedNode.Name, "deletePWarehouseTable_title"))
                    {
                        MessageBox.Show("保存完成");
                        this.treeView1.Nodes.Clear();
                        LoadData(treeView1.Nodes, "0");
                    }
                    else
                    {
                        MessageBox.Show("保存失败");
                    }
                }
                catch
                {
                    MessageBox.Show("保存异常，请检查网络连接情况");
                }
            }
        }
    }
}
