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
using Model;
using Bll;
using Gce_Model;
using Gce_Bll;

namespace Gce.Windows
{
    public partial class ParameterSettings : Office2007Form
    {
        //第一次查询ProductSet数据表时接受数据的集合
        List<string> listType = new List<string>();
        //List<ProductionType> listpt = new List<ProductionType>();
        List<ProductSet_New_title> listLoad1 = new List<ProductSet_New_title>();
        List<ProductSet_New> DataList = new List<ProductSet_New>();

        Dictionary<string, List<ProductSet_New>> dicDataList = new Dictionary<string, List<ProductSet_New>>();

        ProductionTypeBll ptd = new ProductionTypeBll();
        ProductionTypeBll ptb = new ProductionTypeBll();
        ProductSet_New_titleBll psnb = new ProductSet_New_titleBll();
        ProductSet_NewBll productSetNewBll = new ProductSet_NewBll();
        
        //记录当前按钮状态
        string strState = "browse";

        //修改节点的名字
        int UpdateNodeName = -1;
        //是否继续保存
        bool flag = false;

        //选中行数索引
        int DGVindex;
        public ParameterSettings()
        {
            InitializeComponent();
        }

        private void ProductSet_Load(object sender, EventArgs e)
        {
            //加载TreeView
            SelectProductSetUI(-1);
            //初始化新建、保存、取消、修改、删除等按钮的enabled状态
            ControlChage();
        }
        private void LoadDatagridview()
        {
            dicDataList.Clear();
            listType.Clear();

            listType = ptd.selectProductTypeBll("selectProductType");
            List<ProductSet_New> datalist1 = new List<ProductSet_New>();
            datalist1 = productSetNewBll.selectProductSet_NewBll("selectProductSet_New");
            //按照类型名分类数据
            foreach (ProductSet_New_title item in listLoad1)
            {
                List<ProductSet_New> list = new List<ProductSet_New>();
                foreach (ProductSet_New item1 in datalist1)
                {
                    if (item1.ProductClass == item.ProductClass)
                    {
                        list.Add(item1);
                    }
                }
                dicDataList.Add(item.ProductClass, list);
            }

            comb_ProductionClass.DataSource = listType;
            
        }
        /// <summary>
        /// 查询productset表，并加载TreeView
        /// </summary>
        private void SelectProductSetUI(int nodeNumBer)
        {
            listLoad1.Clear();
            tv_ProductClass.Nodes.Clear();

            listLoad1 = psnb.selectProductSet_New_titleBll("selectProductSet_New_title");

            //加载Datagridview
            LoadDatagridview();

            TreeNode tn = new TreeNode();
            tn.Text="产品产能类型";
            tv_ProductClass.Nodes.Add(tn);
            for (int i = 0; i < listLoad1.Count; i++)
            {
                TreeNode tnChild = new TreeNode();
                tnChild.Text = listLoad1[i].ProductClass;
                tnChild.Tag = i;
                tn.Nodes.Add(tnChild);
            }
            this.tv_ProductClass.Nodes[0].Expand();
            if (nodeNumBer >= 0)
            {
                if (tv_ProductClass.Nodes[0].LastNode != null)
                {
                    this.tv_ProductClass.SelectedNode = this.tv_ProductClass.Nodes[0].Nodes[nodeNumBer];
                }
            }
            else
            {
                if (tv_ProductClass.Nodes[0].LastNode != null)
                {
                    this.tv_ProductClass.SelectedNode = this.tv_ProductClass.Nodes[0].LastNode;
                }
            }
        }
        /// <summary>
        /// 给控件赋值
        /// </summary>
        private void LoadTreeview(string str,List<ProductSet_New> list)
        {
            if (str != "")
            {
                this.txtB_ProductClass.Text = str;
                dataGridViewX1.DataSource = new List<ProductSet_New>();
                DataList = dicDataList[str];
                if (list.Count > 0)
                { 
                    DataList.AddRange(list);
                }
                dataGridViewX1.DataSource = DataList;
            }
        }
        private void Insert_Click(object sender, EventArgs e)
        {
            this.dataGridViewX1.DataSource = new List<ProductSet_New>();
            DataList = new List<ProductSet_New>();
            this.panelEx1.Enabled = true;
            strState = "insert";
            ControlChage();
        }
        private bool checkControl()
        {
             if (this.txtB_ProductClass.Text == "")
            {
                MessageBox.Show("产品类型不能为空！");
                return false;
            }
            else
            {
                return true;
            }

        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (strState == "insert")
            {
                UpdateNodeName = -1;
                if (checkControl())
                {
                    List<ProductSet_New> list = new List<ProductSet_New>();
                    list.Add(new ProductSet_New()
                    {
                        ProductClass=txtB_ProductClass.Text.Trim(),
                        Stations=comb_ProductionClass.Text.Trim(),
                        EfficiencyQuantity=intput_MinimumCapacity.Text.Trim(),
                        TheNumberOf=input_TheNumberOf.Text.Trim()
                    });

                    if (psnb.checkProductSet_New_titleBll(this.txtB_ProductClass.Text.Trim(), "checkProductSet_New_title"))
                    {
                        if (flag)
                        {
                            if (!productSetNewBll.checkProductSet_NewBll(txtB_ProductClass.Text.Trim(), comb_ProductionClass.Text.Trim(), "checkProductSet_New"))
                            {
                                if (productSetNewBll.insertProductSet_NewBll(list, "insertProductSet_New"))
                                {
                                    MessageBox.Show("保存成功!");
                                    this.dataGridViewX1.DataSource = new List<ProductSet_New>();
                                    DataList.Add(list[0]);
                                    this.dataGridViewX1.DataSource = DataList;
                                }
                                else
                                {
                                    MessageBox.Show("该生产类型已存在或数据库访问异常,保存失败！");
                                }
                            }
                            else
                            {
                                MessageBox.Show("生产类型已存在！");
                            }
                        }
                        else
                        {
                            if (MessageBox.Show("该产能类型已经存在，继续保存会为该产能类型添加一个生产类型的产能记录，是否继续？", "系统提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            {
                                flag = true;
                                if (!productSetNewBll.checkProductSet_NewBll(txtB_ProductClass.Text.Trim(), comb_ProductionClass.Text.Trim(), "checkProductSet_New"))
                                {
                                    if (productSetNewBll.insertProductSet_NewBll(list, "insertProductSet_New"))
                                    {
                                        MessageBox.Show("保存成功!");
                                        this.dataGridViewX1.DataSource = new List<ProductSet_New>();
                                        DataList.Add(list[0]);
                                        this.dataGridViewX1.DataSource = DataList;
                                    }
                                    else
                                    {
                                        MessageBox.Show("该生产类型已存在或数据库访问异常,保存失败！");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("生产类型已存在！");
                                }
                            }
                            else
                            {
                                return;
                            }
                        }

                    }
                    else
                    {
                        if (!psnb.insertProductSet_New_titleBll(txtB_ProductClass.Text.Trim(), "insertProductSet_New_title"))                       
                        {
                            MessageBox.Show("保存失败,产品类型已存在或数据库访问异常!");
                        }
                        if (!productSetNewBll.checkProductSet_NewBll(txtB_ProductClass.Text.Trim(), comb_ProductionClass.Text.Trim(), "checkProductSet_New"))
                        {
                            if (productSetNewBll.insertProductSet_NewBll(list, "insertProductSet_New"))
                            {
                                MessageBox.Show("保存成功!");
                                this.dataGridViewX1.DataSource = new List<ProductSet_New>();
                                DataList.Add(list[0]);
                                this.dataGridViewX1.DataSource = DataList;

                            }
                            else
                            {
                                MessageBox.Show("该生产类型已存在或数据库访问异常,保存失败！");
                            }
                        }
                        else
                        {
                            MessageBox.Show("生产类型已存在！");
                        }

                    }
                    
                }
            }
            else if (strState == "modify")
            {
                if (checkControl())
                {
                    if (psnb.checkProductSet_New_titleBll(this.txtB_ProductClass.Text.Trim(), "checkProductSet_New_title"))
                    {
                        List<ProductSet_New> list = new List<ProductSet_New>();
                        list.Add(new ProductSet_New()
                        {
                            ProductClass = txtB_ProductClass.Text.Trim(),
                            Stations = comb_ProductionClass.Text.Trim(),
                            EfficiencyQuantity = intput_MinimumCapacity.Text.Trim(),
                            TheNumberOf = input_TheNumberOf.Text.Trim()
                        });
                        if (productSetNewBll.checkProductSet_NewBll(txtB_ProductClass.Text.Trim(), comb_ProductionClass.Text.Trim(), "checkProductSet_New"))
                        {
                            if (productSetNewBll.updateProductSet_NewBll(list, "updateProductSet_New"))
                            {
                                MessageBox.Show("保存成功!");
                                UpdateNodeName = tv_ProductClass.SelectedNode.Index;
                                this.dataGridViewX1.DataSource = new List<ProductSet_New>();
                                DataList[DGVindex] = list[0];
                                this.dataGridViewX1.DataSource = DataList;
                            }
                            else
                            {
                                MessageBox.Show("保存失败,产品类型已存在或数据访问出错!");
                            }
                        }
                        else
                        {
                            if (flag)
                            {
                                if (productSetNewBll.insertProductSet_NewBll(list, "insertProductSet_New"))
                                {
                                    MessageBox.Show("保存成功!");
                                    LoadTreeview(txtB_ProductClass.Text.Trim(), list);
                                }
                                else
                                {
                                    MessageBox.Show("该生产类型已存在或数据库访问异常,保存失败！");
                                }
                            }
                            else
                            {
                                if (MessageBox.Show("该产能类型不存在，继续保存会为该产能类型添加一个生产类型的产能记录，是否继续？", "系统提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                                {
                                    flag = true;
                                    if (productSetNewBll.insertProductSet_NewBll(list, "insertProductSet_New"))
                                    {
                                        MessageBox.Show("保存成功!");
                                        LoadTreeview(txtB_ProductClass.Text.Trim(), list);
                                    }
                                    else
                                    {
                                        MessageBox.Show("该生产类型已存在或数据库访问异常,保存失败！");
                                    }
                                }
                                else
                                {
                                    return;
                                }
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("该类型不存在或已被删除！");
                    }
                }

            }
        }

        private void tv_ProductClass_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != tv_ProductClass.Nodes[0])
            {
                LoadTreeview(e.Node.Text,new List<ProductSet_New>());
            }
            else
            {
                LoadTreeview("",new List<ProductSet_New>());
            }
        }
        /// <summary>
        /// 不同状态按钮的enabled相应改变
        /// </summary>
        private void ControlChage()
        {
            if (strState == "insert")
            {
                this.Insert.Enabled = false;
                this.Save.Enabled = true;
                this.Cancel.Enabled = true;
                this.Modify.Enabled = false;
                this.Delete.Enabled = false;
                this.tv_ProductClass.Enabled = false;
                this.panelEx1.Enabled = true;
                this.Query.Enabled = false;
                this.txtB_ProductClass.Enabled = true;
                this.btni_complete.Enabled = true;

                dataGridViewX1.DataSource = new List<ProductSet_New>();
                this.txtB_ProductClass.Text = "";
                this.comb_ProductionClass.Text = "";
                this.intput_MinimumCapacity.Text = "0";
                this.input_TheNumberOf.Text = "0";


            }
            else if (strState == "modify")
            {
                this.Insert.Enabled = false;
                this.Save.Enabled = true;
                this.Cancel.Enabled = true;
                this.Modify.Enabled = false;
                this.Delete.Enabled = true;
                this.tv_ProductClass.Enabled = false;
                this.panelEx1.Enabled = true;
                this.Query.Enabled = false;
                this.txtB_ProductClass.Enabled = false;
                this.btni_complete.Enabled = true;

            }
            else 
            {
                this.Insert.Enabled = true;
                this.Save.Enabled = false;
                this.Cancel.Enabled = false;
                this.Modify.Enabled = true;
                this.Delete.Enabled = true;
                this.tv_ProductClass.Enabled = true;
                this.panelEx1.Enabled = false;
                this.Query.Enabled = true;
                this.btni_complete.Enabled = false;

                this.comb_ProductionClass.Text = "";
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            strState = "browse";
            ControlChage();
            flag = false;
        }

        private void Modify_Click(object sender, EventArgs e)
        {
            strState = "modify";
            ControlChage();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (strState == "browse")
            {
                if (tv_ProductClass.SelectedNode != tv_ProductClass.Nodes[0])
                {
                    if (DialogResult.OK == MessageBox.Show(this, "是否删除这条数据", "系统提示", MessageBoxButtons.OKCancel))
                    {
                        if (!psnb.deleteProductSet_New_titleBll(this.tv_ProductClass.SelectedNode.Text.Trim(), "deleteProductSet_New_title"))
                        {
                            MessageBox.Show("产能类型删除失败！");
                            return;
                        }
                        if (!productSetNewBll.deleteProductSet_NewBll(txtB_ProductClass.Text.Trim(), "deleteProductSet_New"))
                        {
                            MessageBox.Show("生产类型删除失败！");
                            return;
                        }
                        MessageBox.Show("删除成功！");
                        this.SelectProductSetUI(-1);
                    }
                }
            }
            else
            {
                if (dataGridViewX1.Rows.Count > 0)
                {
                    if (DialogResult.OK == MessageBox.Show(this, "是否删除这条数据", "系统提示", MessageBoxButtons.OKCancel))
                    {
                        if (!productSetNewBll.deleteProductSet_NewStationsBll(txtB_ProductClass.Text.Trim(), comb_ProductionClass.Text.Trim(), "deleteProductSet_NewStations"))
                        {
                            MessageBox.Show("生产类型删除失败！");
                            return;
                        }
                        MessageBox.Show("删除成功！");
                        this.SelectProductSetUI(this.tv_ProductClass.SelectedNode.Index);
                    }
                }
                
            }
        }

        private void Query_Click(object sender, EventArgs e)
        {
            Queryform qf = new Queryform(listLoad1, this);
            qf.ShowDialog();
        }
        public void selectdTreeview(string productionclass)
        {
            foreach (TreeNode item in tv_ProductClass.Nodes[0].Nodes)
            {
                if (item.Text == productionclass)
                {
                    this.tv_ProductClass.SelectedNode = item;
                }
            }
        }

        private void dataGridViewX1_SelectionChanged(object sender, EventArgs e)
        {
            this.dataGridViewX1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (dataGridViewX1.Rows.Count > 0)
            {
                this.UpdateControls(DataList[this.dataGridViewX1.CurrentRow.Index]);//根据行数索引在公共变量集合数据源中获得当前选中的数据
                DGVindex = this.dataGridViewX1.CurrentRow.Index;
            }
        }
        //刷新输入控件
        void UpdateControls(ProductSet_New psn)
        {
            comb_ProductionClass.Text = psn.Stations;
            intput_MinimumCapacity.Text = psn.EfficiencyQuantity;
            input_TheNumberOf.Text = psn.TheNumberOf;
        }

        private void btni_complete_Click(object sender, EventArgs e)
        {
            tv_ProductClass.Nodes.Clear();
            SelectProductSetUI(UpdateNodeName);
            tv_ProductClass.Nodes[0].Expand();
            strState = "browse";
            ControlChage();
            flag = false;
        }
    }
}
