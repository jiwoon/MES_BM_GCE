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
using Bll;
using Gce_Model;
using Model;
using Gce.Windows;

namespace Gce.pop_upWindows
{
    public partial class ParametersCall : Office2007Form
    {
        PCapacityConfigurationBll pcb = new PCapacityConfigurationBll();
        ProductSet_NewBll productSetNewBll = new ProductSet_NewBll();
        ProductSet_New_titleBll psnb = new ProductSet_New_titleBll();
        //数据源集合
        List<ProductSet_New_title> listLoad = new List<ProductSet_New_title>();
        List<ProductSet_New> DataList = new List<ProductSet_New>();
        Dictionary<string, List<ProductSet_New>> dicDataList = new Dictionary<string, List<ProductSet_New>>();
        List<string> listType = new List<string>();
        List<PCapacityConfiguration> listLoadPC = new List<PCapacityConfiguration>();

        string Str = "";

        string state = "browse";
        public ParametersCall()
        {
            InitializeComponent();
        }

        public ParametersCall(string str)
        {
            InitializeComponent();
            this.Str = str;
        }

        void UpdateControls()
        {
            if (state == "browse")
            {
                this.treeView1.Enabled = true;
                this.panelEx1.Enabled = false;

                this.btni_new.Enabled = true;
                this.btni_save.Enabled = false;
                this.btni_cancle.Enabled = false;
                this.btni_modify.Enabled = true;
                this.btni_delete.Enabled = true;
                this.btni_delete.Enabled = true;
                this.btni_lookup.Enabled = true;
            }
            else
            {
                this.treeView1.Enabled = false;
                this.panelEx1.Enabled = true;

                this.btni_new.Enabled = false;
                this.btni_save.Enabled = true;
                this.btni_cancle.Enabled = true;
                this.btni_modify.Enabled = false;
                this.btni_delete.Enabled = false;
                this.btni_delete.Enabled = false;
                this.btni_lookup.Enabled = false;
            }
        }
        private void Loadcbe_ProductClass()
        {
            listLoad.Clear();

            listLoad = psnb.selectProductSet_New_titleBll("selectProductSet_New_title");
            DataList = productSetNewBll.selectProductSet_NewBll("selectProductSet_New");

            List<string> list = new List<string>();

            foreach (ProductSet_New_title item in listLoad)
            {
                list.Add(item.ProductClass);
            }
            cbe_ProductClass.DataSource = list;

            //按照类型名分类数据
            foreach (ProductSet_New_title item in listLoad)
            {
                List<ProductSet_New> list1 = new List<ProductSet_New>();
                foreach (ProductSet_New item1 in DataList)
                {
                    if (item1.ProductClass == item.ProductClass)
                    {
                        list1.Add(item1);
                    }
                }
                dicDataList.Add(item.ProductClass, list1);
            }
        }

        void SetDataGridViewDataS(string str)
        {
            if (str != "")
            {
                if (dicDataList.Keys.Contains(str))
                {
                    dataGridViewX1.DataSource = new List<ProductSet_New>();
                    DataList = dicDataList[str];
                    dataGridViewX1.DataSource = DataList;
                }
            }
            else
            {
                dataGridViewX1.DataSource = new List<ProductSet_New>();
            }
        }
       
        private void ParametersCall_Load(object sender, EventArgs e)
        {
            Loadcbe_ProductClass();
            cbe_ProductClass.Text = "";
            if (Str != "")
            {
                txt_Order.Text = Str;
            }
            this.UpdateControls();

            selectPCapacityConfigurationUI(-1);
        }

        void selectPCapacityConfigurationUI(int Number)
        {
            listLoadPC.Clear();
            treeView1.Nodes.Clear();

            listLoadPC = pcb.selectPCapacityConfigurationBll("selectPCapacityConfiguration");

            TreeNode tn = new TreeNode();
            tn.Text = "订单号";
            this.treeView1.Nodes.Add(tn);
            for (int i = 0; i < listLoadPC.Count; i++)
			{
			    TreeNode tnChild = new TreeNode();
                tnChild.Text = listLoadPC[i].ZhiDan;
                tnChild.Tag = i;
                tn.Nodes.Add(tnChild);
			}
            this.treeView1.Nodes[0].Expand();

            if (Number >= 0)
            {
                if (treeView1.Nodes[0].LastNode != null)
                {
                    this.treeView1.SelectedNode = this.treeView1.Nodes[0].Nodes[Number];
                }
            }
            else
            {
                if (treeView1.Nodes[0].LastNode != null)
                {
                    this.treeView1.SelectedNode = this.treeView1.Nodes[0].LastNode;
                }
            }

        }
        private void cbe_ProductClass_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!(listLoad.Count > 0))
            {
                return;
            }

            this.SetDataGridViewDataS(cbe_ProductClass.SelectedItem.ToString());
        }

        private void cbe_ProductClass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (!(listLoad.Count > 0))
                    {
                        return;
                    }
                    this.SetDataGridViewDataS(cbe_ProductClass.SelectedItem.ToString());
                }
                catch { }
            }
        }

        void Message1()
        {
            if (txt_Order.Text.Trim() == "")
            {
                MessageBox.Show("订单号不能为空!");
                return;
            }
            else if (cbe_ProductClass.Text.Trim() == "")
            {
                MessageBox.Show("产能类型不能为空！");
                return;
            }
        }
        private void btni_new_Click(object sender, EventArgs e)
        {
            state = "insert";

            dataGridViewX1.DataSource = new List<ProductSet_New>();
            txt_Order.Text = "";
            cbe_ProductClass.Text = "";
            UpdateControls();
        }

        private void btni_save_Click(object sender, EventArgs e)
        {
            this.save1();
        }

        void save1()
        {
            this.Message1();
            List<PCapacityConfiguration> listpcb = new List<PCapacityConfiguration>();
            listpcb.Add(new PCapacityConfiguration()
            {
                ZhiDan = txt_Order.Text.Trim(),
                ProductClass = cbe_ProductClass.Text.Trim()
            });

            try
            {
                if (state == "insert")
                {
                    //判断是否已配置标准产能
                    if (!pcb.selectPCapacityConfigurationNumberBll(txt_Order.Text.Trim(), "selectPCapacityConfigurationNumber"))
                    {
                        if (pcb.InsertPCapacityConfigurationBll(listpcb, "InsertPCapacityConfiguration") > 0)
                        {
                            MessageBox.Show("保存成功");
                            selectPCapacityConfigurationUI(-1);
                            state = "browse";
                            UpdateControls();
                        }
                        else
                        {
                            MessageBox.Show("保存失败");
                        }
                    }
                    else//如果已配置
                    {
                        MessageBox.Show("该配置已存在!");
                    }
                }
                else if (state == "modify")
                {
                    if (pcb.InsertPCapacityConfigurationBll(listpcb, "UpdatePCapacityConfiguration") > 0)
                    {
                        MessageBox.Show("保存成功");
                        selectPCapacityConfigurationUI(this.treeView1.SelectedNode.Index);
                        state = "browse";
                        UpdateControls();
                    }
                    else
                    {
                        MessageBox.Show("保存失败");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + "配置可能已经存在！");
            }
        }
        private void btni_cancle_Click(object sender, EventArgs e)
        {
            state = "browse";

            UpdateControls();
        }

        private void btni_modify_Click(object sender, EventArgs e)
        {
            state = "modify";

            UpdateControls();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != this.treeView1.Nodes[0])
            {
                this.SelectChangeSetControls(listLoadPC[Convert.ToInt32(e.Node.Tag)]);
            }
        }

        void SelectChangeSetControls(PCapacityConfiguration list)
        {
            txt_Order.Text = list.ZhiDan;
            cbe_ProductClass.Text = list.ProductClass;

            SetDataGridViewDataS(list.ProductClass);
        }

        private void btni_delete_Click(object sender, EventArgs e)
        {
            this.delete1();
        }

        void delete1()
        {
            if (txt_Order.Text.Trim() == "")
            {
                MessageBox.Show("订单号不能为空！");
                return;
            }
            try
            {
                if (pcb.deletePCapacityConfigurationBll(txt_Order.Text.Trim(), "deletePCapacityConfiguration"))
                {
                    MessageBox.Show("删除成功");
                    selectPCapacityConfigurationUI(-1);
                    state = "browse";
                    UpdateControls();
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btni_lookup_Click(object sender, EventArgs e)
        {
            Queryform qf = new Queryform(listLoadPC,"订单号", this);
            qf.ShowDialog();
        }

        public void selectedTreeview(string nodesName)
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
