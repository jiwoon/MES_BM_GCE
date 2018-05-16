using DevComponents.DotNetBar;
using Gce_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gce.pop_upWindows
{
    public partial class ClassificationDisplay : Office2007Form
    {

        //数据源集合
        List<PAbnormalInput> DataList = new List<PAbnormalInput>();
        Dictionary<string, List<PAbnormalInput>> DataDic = new Dictionary<string, List<PAbnormalInput>>();


        public ClassificationDisplay()
        {
            InitializeComponent();
        }

        public ClassificationDisplay(List<PAbnormalInput> dataList)
        {
            InitializeComponent();
            this.DataList = dataList;
        }

        private void ClassificationDisplay_Load(object sender, EventArgs e)
        {
            this.SetDataGridView();
            this.SetTreeView();
        }

        void SetTreeView()
        {
            if (DataList.Count > 0)
            {
                List<string> strList = new List<string>();
                foreach (PAbnormalInput item in DataList)
                {
                    if (!strList.Contains(item.ExceptionTypes))
                    {
                        strList.Add(item.ExceptionTypes);
                    }
                }
                TreeNode tn = new TreeNode();
                tn.Text = "统计";
                treeView1.Nodes.Add(tn);

                for (int i = 0; i < strList.Count; i++)
                {
                    TreeNode tnChild = new TreeNode();
                    tnChild.Text = strList[i].Trim();
                    tnChild.Tag = i;
                    tn.Nodes.Add(tnChild);

                    List<PAbnormalInput> list = new List<PAbnormalInput>();
                    foreach (PAbnormalInput item in DataList)
                    {
                        if (item.ExceptionTypes == strList[i])
                        {
                            list.Add(item);
                        }
                    }
                    DataDic.Add(strList[i], list);
                }

                if (treeView1.Nodes[0].LastNode != null)
                {
                    this.treeView1.Nodes[0].Expand();
                    this.treeView1.SelectedNode = this.treeView1.Nodes[0].LastNode;
                }
            }
        }

        void SetDataGridView()
        {
            DataGridViewTextBoxColumn newcol = new DataGridViewTextBoxColumn();
            newcol.HeaderText = "订单号";
            newcol.Name = "ZhiDan";
            newcol.DataPropertyName = "ZhiDan";

            this.dataGridViewX1.Columns.Insert(0, newcol);

            DataGridViewTextBoxColumn newcol1 = new DataGridViewTextBoxColumn();
            newcol1.HeaderText = "录入人员";
            newcol1.Name = "SchoolPersonnel";
            newcol1.DataPropertyName = "SchoolPersonnel";

            this.dataGridViewX1.Columns.Insert(1, newcol1);

            DataGridViewTextBoxColumn newcol2 = new DataGridViewTextBoxColumn();
            newcol2.HeaderText = "公司名称";
            newcol2.Name = "CompanyName";
            newcol2.DataPropertyName = "CompanyName";

            this.dataGridViewX1.Columns.Insert(2, newcol2);

            DataGridViewTextBoxColumn newcol3 = new DataGridViewTextBoxColumn();
            newcol3.HeaderText = "产线名称";
            newcol3.Name = "LineOf";
            newcol3.DataPropertyName = "LineOf";

            this.dataGridViewX1.Columns.Insert(3, newcol3);

            DataGridViewTextBoxColumn newcol4 = new DataGridViewTextBoxColumn();
            newcol4.HeaderText = "工站";
            newcol4.Name = "WorkStation";
            newcol4.DataPropertyName = "WorkStation";

            this.dataGridViewX1.Columns.Insert(4, newcol4);

            DataGridViewTextBoxColumn newcol5 = new DataGridViewTextBoxColumn();
            newcol5.HeaderText = "异常类型";
            newcol5.Name = "ExceptionTypes";
            newcol5.DataPropertyName = "ExceptionTypes";

            this.dataGridViewX1.Columns.Insert(5, newcol5);

            DataGridViewTextBoxColumn newcol6 = new DataGridViewTextBoxColumn();
            newcol6.HeaderText = "问题描述";
            newcol6.Name = "ProblemDescription";
            newcol6.DataPropertyName = "ProblemDescription";

            this.dataGridViewX1.Columns.Insert(6, newcol6);

            DataGridViewTextBoxColumn newcol7 = new DataGridViewTextBoxColumn();
            newcol7.HeaderText = "备注";
            newcol7.Name = "Node1";
            newcol7.DataPropertyName = "Node1";
            newcol7.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            this.dataGridViewX1.Columns.Insert(7, newcol7);

            DataGridViewTextBoxColumn newcol8 = new DataGridViewTextBoxColumn();
            newcol8.HeaderText = "";
            newcol8.Name = "ID";
            newcol8.DataPropertyName = "ID";
            newcol8.Visible = false;

            this.dataGridViewX1.Columns.Insert(8, newcol8);


        }
        //datagridview行号
        private void dataGridViewX1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(this.dataGridViewX1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, CultureInfo.CurrentUICulture),
                e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != this.treeView1.Nodes[0])
            {
                SetDataGridView(DataDic[e.Node.Text.Trim()]);
            }
        }

        void SetDataGridView(List<PAbnormalInput> list)
        {
            dataGridViewX1.DataSource = new List<PAbnormalInput>();
            if(list.Count>0)
            {
                dataGridViewX1.DataSource = list;
            }
        }
    }
}
    