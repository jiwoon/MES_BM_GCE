using DevComponents.DotNetBar;
using Gce_Model;
using Gce_Bll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gce.Windows;

namespace Gce.pop_upWindows
{
    public partial class ProductionLineConfiguration : Office2007Form
    {

        //类对象
        PWorkScheduleBll pwsb = new PWorkScheduleBll();
        ProductionLinePC_titleBll pc_titleBll = new ProductionLinePC_titleBll();
        ProductionLinePCBll pc_bll = new ProductionLinePCBll();
        ProductionTypeBll ptb = new ProductionTypeBll();

        //集合
        List<PWorkSchedule> listPWorkSchedule = new List<PWorkSchedule>();
        List<ProductionLinePC_title> listProductionLinePC_title = new List<ProductionLinePC_title>();
        Dictionary<string, List<ProductionLinePC>> dicProductionLinePC = new Dictionary<string, List<ProductionLinePC>>();
        List<ProductionType> listpt = new List<ProductionType>();
        List<ProductionLinePC> listPCLine = new List<ProductionLinePC>();

        DataTable dt = new DataTable();

        //insert新建保存状态，插入状态
        //browse浏览状态
        //modify修改状态
        string state = "browse";
        public ProductionLineConfiguration()
        {
            InitializeComponent();
        }

        private void ProductionLineConfiguration_Load(object sender, EventArgs e)
        {
            SetControls();
            BarButtonEnable();
            listpt = ptb.selectProductionTypeBll("selectProductionType");
        }

        private void SetControls()
        {
            listPWorkSchedule = pwsb.selectPWorkScheduleBll("selectPWorkSchedule");
            List<string> strlistPWorkSchedule = new List<string>();
            foreach (PWorkSchedule item in listPWorkSchedule)
            {
                strlistPWorkSchedule.Add(item.CompanyName);
            }
            cb_CompanyName.DataSource = strlistPWorkSchedule;
            cb_CompanyName.Text = "";
            //treeview
            listProductionLinePC_title = pc_titleBll.selectProductionLinePC_titleBll("selectProductionLinePC_title");
            TreeNode tn = new TreeNode();
            tn.Text = "生产线名";
            treeView1.Nodes.Add(tn);

            if (listProductionLinePC_title.Count > 0)
            {
                foreach (ProductionLinePC_title item in listProductionLinePC_title)
                {
                    TreeNode tnChild = new TreeNode();
                    tnChild.Text = item.LineName.Trim();
                    tnChild.Tag = item.CompanyName.Trim();
                    tn.Nodes.Add(tnChild);
                    dicProductionLinePC.Add(item.LineName.Trim(), pc_bll.selectProductionLinePCBll(item.LineName.Trim(), "selectProductionLinePC"));
                }

            }
            
        }

        private void BarButtonEnable()
        {
            if (state == "insert")
            {
                panel1.Enabled = true;
                treeView1.Enabled = false;

                btn_new.Enabled = false;
                btn_save.Enabled = true;
                btn_cancel.Enabled = true;
                btn_Modify.Enabled = false;
                btn_dalete.Enabled = false;
            }
            else if (state == "modify")
            {
                panel1.Enabled = true;
                treeView1.Enabled = false;

                btn_new.Enabled = false;
                btn_save.Enabled = true;
                btn_cancel.Enabled = true;
                btn_Modify.Enabled = false;
                btn_dalete.Enabled = false;
            }
            else
            {
                panel1.Enabled = false;
                treeView1.Enabled = true;

                btn_new.Enabled = true;
                btn_save.Enabled = false;
                btn_cancel.Enabled = false;
                btn_Modify.Enabled = true;
                btn_dalete.Enabled = true;
            }
        }

        private void ControlsClrear()
        {
            txt_LineName.Text = "";
            cb_CompanyName.Text = "";
            dataGridViewX1.Rows.Clear();
            dataGridViewX1.Columns.Clear();
        }
        private void btn_new_Click(object sender, EventArgs e)
        {
            state = "insert";
            ControlsClrear();
            
            BarButtonEnable();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            state = "browse";

            BarButtonEnable();
        }

        private void btn_Modify_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == treeView1.Nodes[0])
            {
                return;
            }
            state = "modify";

            BarButtonEnable();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != this.treeView1.Nodes[0])
            {                 
                dicProductionLinePC.TryGetValue(e.Node.Text.Trim(), out listPCLine);
                SetDataGridView(listPCLine, e.Node.Text.Trim(),e.Node.Tag.ToString().Trim());
            }
        }

        private void SetDataGridView(List<ProductionLinePC> list,string nodeTexe,string nodeTag)
        {
            if (list.Count > 0)
            {
                txt_LineName.Text = list[0].LineName;
                cb_CompanyName.Text = list[0].CompanyName;
                SetCoulmns(cb_CompanyName.Text);

                foreach (DataGridViewTextBoxColumn Coulumn in dataGridViewX1.Columns)
                {
                    int i = 0;
                    foreach (ProductionLinePC item in list)
                    {
                        if (item.ProductType.Trim() == Coulumn.HeaderText.Trim())
                        {
                            if (dataGridViewX1.Rows.Count > i + 1)
                            {
                                dataGridViewX1.Rows[i].Cells[Coulumn.Index].Value = item.Pcname;
                                dt.Rows[i][Coulumn.Name] = item.Pcname;
                            }
                            else
                            {
                                DataGridViewRow dr = new DataGridViewRow();
                                dr.CreateCells(dataGridViewX1);
                                dr.Cells[Coulumn.Index].Value = item.Pcname;
                                dataGridViewX1.Rows.Insert(i, dr);

                                DataRow datatableRow = dt.NewRow();
                                datatableRow[Coulumn.Name] = item.Pcname;
                                dt.Rows.InsertAt(datatableRow, i);

                            }
                            i++;
                        }
                    }
                }

            }
            else
            {
                txt_LineName.Text = nodeTexe;
                cb_CompanyName.Text = nodeTag;
                SetCoulmns(cb_CompanyName.Text);
            }
        }

        private void SetCoulmns(string cb_CompanyName)
        {
            dataGridViewX1.Rows.Clear();
            dataGridViewX1.Columns.Clear();
            dt.Columns.Clear();
            dt.Rows.Clear();

            int i = 0;
            foreach (ProductionType item in listpt)
            {
                if (item.OnWorkTimeType.Trim() == cb_CompanyName.Trim())
                {
                    DataGridViewTextBoxColumn newcol1 = new DataGridViewTextBoxColumn();
                    newcol1.HeaderText = item.ProductType;
                    newcol1.Name = item.Command3.ToString().Trim();
                    newcol1.SortMode = DataGridViewColumnSortMode.NotSortable;
                    this.dataGridViewX1.Columns.Insert(i, newcol1);

                    dt.Columns.Add(new DataColumn(newcol1.Name, typeof(string)));
                    i++;
                }

            }
        }

        private void cb_CompanyName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (dataGridViewX1.Rows.Count > 0 && dataGridViewX1.Columns.Count > 0)
            {
                dataGridViewX1.Rows.Clear();
                dataGridViewX1.Columns.Clear();
            }

            SetCoulmns(cb_CompanyName.SelectedItem.ToString());
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            this.dataGridViewX1.EndEdit();
            if (state == "insert")
            {
                MessageB();
                List<ProductionLinePC_title> listpc = new List<ProductionLinePC_title>();
                listpc.Add(new ProductionLinePC_title()
                {
                    LineName=txt_LineName.Text.Trim(),
                    CompanyName=cb_CompanyName.Text.Trim()
                });
                if (pc_titleBll.CheckProductionLinePC_titleBll(listpc[0].LineName, "CheckProductionLinePC_title") <= 0)
                {
                    pc_titleBll.insertProductionLinePC_titleBll(listpc, "insertProductionLinePC_title", "");
                }                
                List<ProductionLinePC> list = new List<ProductionLinePC>();
                List<string> liststr = new List<string>();
                //遍历datagridview的行和列
                foreach (DataGridViewTextBoxColumn column in dataGridViewX1.Columns)
                {
                    foreach (DataGridViewRow row in dataGridViewX1.Rows)
                    {
                        //如果没有计算机名则不插入数据
                        if (dataGridViewX1.Rows[row.Index].Cells[column.Index].Value != null)
                        {
                            list.Clear();
                            list.Add(new ProductionLinePC()
                            {
                                Pcname = dataGridViewX1.Rows[row.Index].Cells[column.Index].Value.ToString(),
                                ProductType = column.HeaderText.Trim(),
                                LineName = txt_LineName.Text.Trim(),
                                CompanyName=cb_CompanyName.Text.Trim()
                            });
                            if (!pc_bll.selectCountProductionLinePCBll(list, "selectCountProductionLinePC"))
                            {
                                if (!pc_bll.insertProductionLinePCBll(list, "insertProductionLinePC"))
                                {
                                    liststr.Add(list[0].Pcname);
                                }
                            }

                            if (liststr.Count > 0)
                            {
                                string str=null;
                                for (int i = 0; i < liststr.Count; i++)
                                {
                                    str += liststr[i]+"\r\n";
                                }
                                str += "以上计算机或已在同线同工位类型中重复！";
                                MessageBox.Show(str);                               
                            }

                        }
                    }

                }
                MessageBox.Show("保存完成！");
                ControlsClrear();
                refreshTreeView();
                state = "browse";
                BarButtonEnable();
            }
            else if (state == "modify")
            {
                MessageB();
                List<ProductionLinePC_title> listpc = new List<ProductionLinePC_title>();
                listpc.Add(new ProductionLinePC_title()
                {
                    LineName = treeView1.SelectedNode.Text.Trim(),
                    CompanyName = cb_CompanyName.Text.Trim()
                });
                if (pc_titleBll.CheckProductionLinePC_titleBll(listpc[0].LineName, "CheckProductionLinePC_title") > 0)
                {
                    pc_titleBll.insertProductionLinePC_titleBll(listpc, "updateProductionLinePC_title", txt_LineName.Text.Trim());
                }  
                
                List<ProductionLinePC> list = new List<ProductionLinePC>();
                List<string> liststr = new List<string>();
                //遍历datagridview的行和列
                foreach (DataGridViewTextBoxColumn column in dataGridViewX1.Columns)
                {
                    foreach (DataGridViewRow row in dataGridViewX1.Rows)
                    {
                            list.Clear();
                            if (dataGridViewX1.Rows[row.Index].Cells[column.Index].Value == null)
                            {
                                list.Add(new ProductionLinePC()
                                {
                                    Pcname = "",
                                    ProductType = column.HeaderText.Trim(),
                                    LineName = txt_LineName.Text.Trim(),
                                    CompanyName = cb_CompanyName.Text.Trim()
                                });
                            }
                            else
                            {
                                list.Add(new ProductionLinePC()
                                {
                                    Pcname = dataGridViewX1.Rows[row.Index].Cells[column.Index].Value.ToString(),
                                    ProductType = column.HeaderText.Trim(),
                                    LineName = txt_LineName.Text.Trim(),
                                    CompanyName = cb_CompanyName.Text.Trim()
                                });
                            }

                        if (insertProductionLinePC(row.Index,column.Index))
                        {
                            if (!pc_bll.selectCountProductionLinePCBll(list, "selectCountProductionLinePC"))
                            {
                                if (!pc_bll.insertProductionLinePCBll(list, "insertProductionLinePC"))
                                {
                                    liststr.Add(list[0].Pcname);
                                }

                                if (liststr.Count > 0)
                                {
                                    string str = null;
                                    for (int i = 0; i < liststr.Count; i++)
                                    {
                                        str += liststr[i] + "\r\n";
                                    }
                                    str += "以上计算机或已在同线同工位类型中重复！";
                                    MessageBox.Show(str);
                                }
                            }
                        }
                        else if (UpdateProductionLinePC(row.Index,column.Index))
                        {
                            if (dt.Rows[row.Index][column.Index].ToString() != dataGridViewX1.Rows[row.Index].Cells[column.Index].Value.ToString())
                            {
                                if (!pc_bll.UpdateProductionLinePCBll(dt.Rows[row.Index][column.Index].ToString(), list, "UpdateProductionLinePC"))
                                {
                                    liststr.Add(list[0].Pcname);
                                }

                                if (liststr.Count > 0)
                                {
                                    string str = null;
                                    for (int i = 0; i < liststr.Count; i++)
                                    {
                                        str += liststr[i] + "\r\n";
                                    }
                                    str += "以上计算机或已在同线同工位类型中重复！";
                                    MessageBox.Show(str);
                                }
                            }
                        }
                        else if (deleteProductionLinePC(row.Index,column.Index))
                        {
                            List<ProductionLinePC> list1 = new List<ProductionLinePC>();
                            list1.Add(new ProductionLinePC()
                            {
                                Pcname = dt.Rows[row.Index][column.Index].ToString(),
                                ProductType = column.HeaderText.Trim(),
                                LineName = txt_LineName.Text.Trim(),
                                CompanyName = cb_CompanyName.Text.Trim()
                            });
                            if (pc_bll.selectCountProductionLinePCBll(list1, "selectCountProductionLinePC"))
                            {
                                if (!pc_bll.insertProductionLinePCBll(list1, "deleteProductionLinePC"))
                                {
                                    liststr.Add(list[0].Pcname);
                                }

                                if (liststr.Count > 0)
                                {
                                    string str = null;
                                    for (int i = 0; i < liststr.Count; i++)
                                    {
                                        str += liststr[i] + "\r\n";
                                    }
                                    str += "以上计算机或不存在！";
                                    MessageBox.Show(str);
                                }
                            }
                        }
                        }
                    }                
                MessageBox.Show("保存完成！");
                ControlsClrear();
                refreshTreeView();
                state = "browse";
                BarButtonEnable();
            }
        }
        private void MessageB()
        {
            if (txt_LineName.Text == "")
            {
                MessageBox.Show("生产线名不能为空");
                return;
            }
            if (cb_CompanyName.Text == "")
            {
                MessageBox.Show("公司上班类型不能为空");
                return;
            }
            if (dataGridViewX1.Columns.Count <= 0)
            {
                MessageBox.Show("至少需要一个工位");
                return;
            }
            if (dataGridViewX1.Rows.Count <= 0)
            {
                MessageBox.Show("没有输入任何计算机名称");
                return;
            }
        }

        private void refreshTreeView()
        {
            treeView1.Nodes.Clear();
            dicProductionLinePC.Clear();

            listProductionLinePC_title = pc_titleBll.selectProductionLinePC_titleBll("selectProductionLinePC_title");
            TreeNode tn = new TreeNode();
            tn.Text = "生产线名";
            treeView1.Nodes.Add(tn);

            if (listProductionLinePC_title.Count > 0)
            {
                foreach (ProductionLinePC_title item in listProductionLinePC_title)
                {
                    TreeNode tnChild = new TreeNode();
                    tnChild.Text = item.LineName.Trim();
                    tnChild.Tag = item.CompanyName.Trim();
                    tn.Nodes.Add(tnChild);
                    dicProductionLinePC.Add(item.LineName.Trim(), pc_bll.selectProductionLinePCBll(item.LineName.Trim(), "selectProductionLinePC"));
                }

            }
        }

        private void btn_dalete_Click(object sender, EventArgs e)
        {
            if (this.treeView1.SelectedNode == treeView1.Nodes[0])
            {
                return;
            }
            if (MessageBox.Show("确定删除此条数据吗？", "系统提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                List<ProductionLinePC_title> listpc = new List<ProductionLinePC_title>();
                listpc.Add(new ProductionLinePC_title()
                {
                    LineName = treeView1.SelectedNode.Text.Trim(),
                    CompanyName = cb_CompanyName.Text.Trim()
                });
                pc_titleBll.insertProductionLinePC_titleBll(listpc, "deleteProductionLinePC_title", "");
                List<ProductionLinePC> list = new List<ProductionLinePC>();
                List<string> liststr = new List<string>();
                //遍历datagridview的行和列
                foreach (DataGridViewTextBoxColumn column in dataGridViewX1.Columns)
                {
                    foreach (DataGridViewRow row in dataGridViewX1.Rows)
                    {
                        //如果没有计算机名则不更新数据数据
                        if (dataGridViewX1.Rows[row.Index].Cells[column.Index].Value != null)
                        {
                            list.Clear();
                            list.Add(new ProductionLinePC()
                            {
                                Pcname = dataGridViewX1.Rows[row.Index].Cells[column.Index].Value.ToString(),
                                ProductType = column.HeaderText.Trim(),
                                LineName = txt_LineName.Text.Trim(),
                                CompanyName = cb_CompanyName.Text.Trim()
                            });
                            if (pc_bll.selectCountProductionLinePCBll(list, "selectCountProductionLinePC"))
                            {
                                if (!pc_bll.insertProductionLinePCBll(list, "deleteProductionLinePC"))
                                {
                                    liststr.Add(list[0].Pcname);
                                }

                                if (liststr.Count > 0)
                                {
                                    string str = null;
                                    for (int i = 0; i < liststr.Count; i++)
                                    {
                                        str += liststr[i] + "\r\n";
                                    }
                                    str += "以上计算机或不存在！";
                                    MessageBox.Show(str);
                                }
                            }

                        }
                    }

                }
                MessageBox.Show("完成！");
                ControlsClrear();
                refreshTreeView();
                state = "browse";
                BarButtonEnable();
            }
        }

        private void btn_Query_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            foreach (TreeNode item in this.treeView1.Nodes[0].Nodes)
            {
                list.Add(item.Text);
            }

            Queryform qf = new Queryform(list,this.treeView1.Nodes[0].Text.Trim(),this);
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
        bool insertProductionLinePC(int Rowindex,int Colunmindex)
        {
            try
            {
                if (dataGridViewX1.Rows[Rowindex].Cells[Colunmindex].Value != null && dt.Rows[Rowindex][Colunmindex].ToString() == "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                if (dataGridViewX1.Rows[Rowindex].Cells[Colunmindex].Value != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
        }
        bool UpdateProductionLinePC(int Rowindex, int Colunmindex)
        {
            try
            {                  
                if (dt.Rows[Rowindex][Colunmindex].ToString()!= "" && dataGridViewX1.Rows[Rowindex].Cells[Colunmindex].Value != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                if (dataGridViewX1.Rows[Rowindex].Cells[Colunmindex].Value != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        bool deleteProductionLinePC(int Rowindex, int Colunmindex)
        {
         try{
                if (dt.Rows[Rowindex][Colunmindex].ToString() != "" && dataGridViewX1.Rows[Rowindex].Cells[Colunmindex].Value == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
