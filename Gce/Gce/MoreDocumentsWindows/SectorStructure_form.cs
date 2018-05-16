using DevComponents.DotNetBar;
using Gce_Bll;
using Gce_Common;
using Gce_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gce.MoreDocumentsWindows
{
    public partial class SectorStructure_form : Office2007Form
    {
        Gce G;

        TimeAttendance_DepartmentBll TadBll = new TimeAttendance_DepartmentBll();

        Dictionary<string, TimeAttendance_Department> dicData = new Dictionary<string, TimeAttendance_Department>();
        Dictionary<string, List<TimeAttendance_Department>> dicDataList = new Dictionary<string, List<TimeAttendance_Department>>();

        string state = "browse";

        public SectorStructure_form()
        {
            InitializeComponent();
        }

        public SectorStructure_form(Gce g)
        {
            InitializeComponent();
            this.G = g;
        }

        private void btni_save_Click(object sender, EventArgs e)
        {
            ip_ExceedNumberOfStaff.Value = ip_InTheNumberOfStaff.Value - ip_NumberOfStaff.Value;
            switch (state)
            {
                case "ClearWXJ":
                    if (this.saveInsert())
                    {
                        state = "browse";
                        uodateCotrls();
                    }
                    break;
                case "ClearWTJ":
                    if (this.saveInsert())
                    {
                        state = "browse";
                        uodateCotrls();
                    }
                    break;
                case "modify":

                    if (saveUpdate())
                    {
                        state = "browse";
                        uodateCotrls();
                    }
                    break;
            }
        }


        bool saveInsert()
        {
            if (Message1()) return false;

            G.Setlb_QueryState("正在保存...");

            try
            {
                if (TadBll.insertTimeAttendance_DepartmentBll(this.GetTimeAttendance_Department(), "insertTimeAttendance_Department"))
                {
                    G.Setlb_QueryState("保存完成");
                    this.treeView1.Nodes.Clear();
                    SetTreeeview();
                    return true;
                }
                else
                {
                    G.Setlb_QueryState("保存失败");
                    return false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                G.Setlb_QueryState(ex.Message);
                return false;
            }

        }

        bool saveUpdate()
        {
            if (Message1()) return false;

            G.Setlb_QueryState("正在保存...");

            try
            {
                if (TadBll.updateTimeAttendance_DepartmentDal(this.GetTimeAttendance_Department(), "updateTimeAttendance_Department"))
                {
                    G.Setlb_QueryState("保存完成");
                    this.treeView1.Nodes.Clear();
                    SetTreeeview();
                    return true; ;
                }
                else
                {
                    G.Setlb_QueryState("保存失败");
                    return false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                G.Setlb_QueryState(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 获得编辑数据
        /// </summary>
        /// <returns></returns>
        TimeAttendance_Department GetTimeAttendance_Department()
        {
            TimeAttendance_Department tad = new TimeAttendance_Department()
            {
                DepartmentNo=txt_DepartmentNo.Text.Trim(),
                DepartmentName=txt_DepartmentName.Text.Trim(),
                ParentDepartmentNo=txt_ParentDepartmentNo.Text.Trim(),
                ParentDepartmentName=txt_ParentDepartmentName.Text.Trim(),
                NumberOfStaff=ip_NumberOfStaff.Value,
                InTheNumberOfStaff=ip_InTheNumberOfStaff.Value,
                ExceedNumberOfStaff=ip_ExceedNumberOfStaff.Value,
                note=txt_note.Text
            };

            return tad;
        }

        TimeAttendance_Department GetTimeAttendance_Department1()
        {
            TimeAttendance_Department tad = new TimeAttendance_Department()
            {
                DepartmentNo = treeView1.SelectedNode.Name.Trim()
            };

            return tad;
        }

        bool Message1()
        {
            if (txt_DepartmentNo.Text.Trim() == "")
            {
                MessageBox.Show("部门编号不能为空！");
                return true;
            }
            else if (txt_DepartmentName.Text.Trim() == "")
            {
                MessageBox.Show("部门名称不能为空！");
                return true;
            }
            else return false;
        }

        private void btni_edit_Click(object sender, EventArgs e)
        {
            state = "modify";

            uodateCotrls();
        }

        private void btni_cancle_Click(object sender, EventArgs e)
        {
            state = "browse";

            uodateCotrls();
        }

        private void btni_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode.Nodes.Count > 0)
                {
                    MessageBox.Show("此部门有下级部门，必须先删除下级部门才能删除此部门！");
                    return;
                }
            }
            catch
            { }

            if (Message1()) return;

            if (MessageBox.Show("确定删除此部门吗？", "系统提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }

            G.Setlb_QueryState("正在保存...");

            try
            {
                if (TadBll.deleteTimeAttendance_DepartmentDal(this.GetTimeAttendance_Department1(), "deleteTimeAttendance_Department"))
                {
                    G.Setlb_QueryState("保存完成");
                    this.treeView1.Nodes.Clear();
                    SetTreeeview();
                }
                else
                {
                    G.Setlb_QueryState("保存失败");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                G.Setlb_QueryState(ex.Message);
            }
        }

        private void btni_NewSibling_Click(object sender, EventArgs e)
        {
            state = "ClearWTJ";

            txt_ParentDepartmentNo.Text = treeView1.SelectedNode.Tag.ToString();
            txt_ParentDepartmentName.Text = treeView1.Nodes[treeView1.SelectedNode.Tag.ToString()].Text;
            this.Clear1();
            uodateCotrls();
        }

        private void btni_NewSubordinate_Click(object sender, EventArgs e)
        {
            state = "ClearWXJ";

            txt_ParentDepartmentName.Text = treeView1.SelectedNode.Text;
            txt_ParentDepartmentNo.Text = treeView1.SelectedNode.Name;
            this.Clear1();
            uodateCotrls();
        }

        void Clear1()
        {
            txt_DepartmentNo.Text = "";
            txt_DepartmentName.Text = "";
            ip_ExceedNumberOfStaff.Text = "0";
            ip_InTheNumberOfStaff.Text = "0";
            ip_NumberOfStaff.Text = "0";
            txt_note.Text = "";
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
                btni_edit.Enabled = true;
                btni_NewSibling.Enabled = true;
                btni_NewSubordinate.Enabled = true;

                txt_DepartmentNo.Enabled = true;
                txt_ParentDepartmentNo.Enabled = true;
                txt_ParentDepartmentName.Enabled = true;

                btni_DataInput.Enabled = true;
                btni_DataOut.Enabled = true;
            }
            else if (state == "modify")
            {
                treeView1.Enabled = false;
                panelEx1.Enabled = true;

                btni_save.Enabled = true;
                btni_cancle.Enabled = true;
                btni_delete.Enabled = false;
                btni_edit.Enabled = false;
                btni_NewSibling.Enabled = false;
                btni_NewSubordinate.Enabled = false;

                txt_DepartmentNo.Enabled = false;
                txt_ParentDepartmentNo.Enabled = false;
                txt_ParentDepartmentName.Enabled = false;

                btni_DataInput.Enabled = false;
                btni_DataOut.Enabled = false;
            }
            else
            {
                treeView1.Enabled = false;
                panelEx1.Enabled = true;

                btni_save.Enabled = true;
                btni_cancle.Enabled = true;
                btni_delete.Enabled = false;
                btni_edit.Enabled = false;
                btni_NewSibling.Enabled = false;
                btni_NewSubordinate.Enabled = false;

                txt_DepartmentNo.Enabled = true;
                txt_ParentDepartmentNo.Enabled = false;
                txt_ParentDepartmentName.Enabled = false;

                btni_DataInput.Enabled = false;
                btni_DataOut.Enabled = false;
            }
        }

        private void SectorStructure_form_Load(object sender, EventArgs e)
        {
            uodateCotrls();
            tabControl1.SelectedTab = tabControl1.Tabs[0];
            Loead();
            SetTreeeview();
        }

        void SetTreeeview()
        {
            this.treeView1.Nodes.Clear();
            this.dicData.Clear();
            this.dicDataList.Clear();

            LoadData(treeView1.Nodes, "");

            treeView1.Nodes[0].Expand();
        }

        private void LoadData(TreeNodeCollection treeNodeCollection, string fid)
        {
            try
            {
                List<TimeAttendance_Department> DataList = TadBll.selectTimeAttendance_DepartmentParentDepartmentNoBll(fid, "selectTimeAttendance_DepartmentParentDepartmentNo");
                if (!dicDataList.ContainsKey(fid))
                dicDataList.Add(fid, DataList);

                foreach (TimeAttendance_Department item in DataList)
                {
                    if (!dicData.ContainsKey(item.DepartmentNo))
                        dicData.Add(item.DepartmentNo, item);
                    TreeNode tn = treeNodeCollection.Add(item.DepartmentName);
                    tn.Name = item.DepartmentNo;
                    tn.Tag = item.ParentDepartmentNo;
                    LoadData(tn.Nodes, item.DepartmentNo);
                }
            }
            catch
            {
                MessageBox.Show("加载异常，请检查网络连接情况");
            }
        }

        private void btni_DataInput_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel文件(*.xls;*.xlsx)|*.xls;*.xlsx|所有文件|*.*";
            ofd.ValidateNames = true;
            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;
            G.Setlb_QueryState("正在导入数据...");
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string fileName = ofd.FileName;
                try
                {
                    DataTable dt = ExcelHelperForCs.ImportFromExcel(fileName, "部门结构", 0);

                    foreach (DataRow item in dt.Rows)
                    {
                        TimeAttendance_Department tad = new TimeAttendance_Department()
                        {
                            DepartmentNo = item["组别编号"].ToString(),
                            DepartmentName = item["组别名称"].ToString(),
                            ParentDepartmentNo = item["上级部门编号"].ToString(),
                            ParentDepartmentName = item["上级部门名称"].ToString(),
                            NumberOfStaff = Convert.ToInt32(item["编制人数"]),
                            InTheNumberOfStaff = Convert.ToInt32(item["在编人数"]),
                            ExceedNumberOfStaff = Convert.ToInt32(item["超编人数"]),
                            note = item["备注"].ToString()
                        };
                        try
                        {
                            if (TadBll.insertTimeAttendance_DepartmentBll(tad, "insertTimeAttendance_Department"))
                            {
                                G.Setlb_QueryState("保存完成");
                                this.treeView1.Nodes.Clear();
                            }
                            else
                            {
                                G.Setlb_QueryState("保存失败");
                            }
                        }
                        catch
                        {
                            G.Setlb_QueryState("保存异常，请检查网络连接情况");
                        }
                    }

                    SetTreeeview();
                    G.Setlb_QueryState("导入完成");
                }
                catch (Exception ex)
                {
                    G.Setlb_QueryState("可能导入的Excle文件无法识别");
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void ip_InTheNumberOfStaff_Leave(object sender, EventArgs e)
        {
            ip_ExceedNumberOfStaff.Value = ip_InTheNumberOfStaff.Value - ip_NumberOfStaff.Value;
        }

        private void ip_NumberOfStaff_Leave(object sender, EventArgs e)
        {
            ip_ExceedNumberOfStaff.Value = ip_InTheNumberOfStaff.Value - ip_NumberOfStaff.Value;
        }

        private void btni_DataOut_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewX1.CurrentRow == null)
            {
                MessageBox.Show("没有可导出的数据!");
                return;
            }
            if (ExcelHelperForCs.ExportToExcel(dataGridViewX1) != null)
            {
                MessageBox.Show("导出完成");
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SetTextBox(dicData[treeView1.SelectedNode.Name]);
        }

        void SetTextBox(TimeAttendance_Department data)
        {
            txt_DepartmentNo.Text = data.DepartmentNo;
            txt_DepartmentName.Text = data.DepartmentName;
            txt_ParentDepartmentNo.Text = data.ParentDepartmentNo;
            txt_ParentDepartmentName.Text = data.ParentDepartmentName;
            ip_NumberOfStaff.Value = data.NumberOfStaff;
            ip_InTheNumberOfStaff.Value = data.InTheNumberOfStaff;
            ip_ExceedNumberOfStaff.Value = data.ExceedNumberOfStaff;
            txt_note.Text = data.note;
            List<TimeAttendance_Department> list = new List<TimeAttendance_Department>();
            list.Add(data);
            SetDataGrid(list, data.DepartmentNo);
        }

        void SetDataGrid(List<TimeAttendance_Department> list,string DepartmentNo)
        {
            try
            {
                list.AddRange(dicDataList[DepartmentNo]);

                foreach (TimeAttendance_Department item in dicDataList[DepartmentNo])
                {
                    SetDataGrid(list, item.DepartmentNo);
                }
            }
            catch
            {
                return;
            }
            dataGridViewX1.DataSource = list;
        }

        void Loead()
        {
            DataGridViewTextBoxColumn newcol = new DataGridViewTextBoxColumn();
            newcol.HeaderText = "组别编号";
            newcol.Name = "DepartmentNo";
            newcol.DataPropertyName = "DepartmentNo";
            newcol.Width = 150;
            newcol.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol.Tag = 0;
            this.dataGridViewX1.Columns.Insert(0, newcol);

            DataGridViewTextBoxColumn newcol1 = new DataGridViewTextBoxColumn();
            newcol1.HeaderText = "组别名称";
            newcol1.Name = "DepartmentName";
            newcol1.DataPropertyName = "DepartmentName";
            newcol1.Width = 120;
            newcol1.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol1.Tag = 1;
            this.dataGridViewX1.Columns.Insert(1, newcol1);

            DataGridViewTextBoxColumn newcol2 = new DataGridViewTextBoxColumn();
            newcol2.HeaderText = "上级部门编号";
            newcol2.Name = "ParentDepartmentNo";
            newcol2.DataPropertyName = "ParentDepartmentNo";
            newcol2.Width = 120;
            newcol2.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol2.Tag = 2;
            this.dataGridViewX1.Columns.Insert(2, newcol2);


            DataGridViewTextBoxColumn newcol3 = new DataGridViewTextBoxColumn();
            newcol3.HeaderText = "上级部门名称";
            newcol3.Name = "ParentDepartmentName";
            newcol3.DataPropertyName = "ParentDepartmentName";
            newcol3.Width = 120;
            newcol3.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol3.Tag = 3;
            this.dataGridViewX1.Columns.Insert(3, newcol3);

            DataGridViewTextBoxColumn newcol4 = new DataGridViewTextBoxColumn();
            newcol4.HeaderText = "编制人数";
            newcol4.Name = "NumberOfStaff";
            newcol4.DataPropertyName = "NumberOfStaff";
            newcol4.Width = 120;
            newcol4.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol4.Tag = 4;
            this.dataGridViewX1.Columns.Insert(4, newcol4);

            DataGridViewTextBoxColumn newcol5 = new DataGridViewTextBoxColumn();
            newcol5.HeaderText = "在编人数";
            newcol5.Name = "InTheNumberOfStaff";
            newcol5.DataPropertyName = "InTheNumberOfStaff";
            newcol5.Width = 120;
            newcol5.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol5.Tag = 5;
            this.dataGridViewX1.Columns.Insert(5, newcol5);

            DataGridViewTextBoxColumn newcol6 = new DataGridViewTextBoxColumn();
            newcol6.HeaderText = "超编人数";
            newcol6.Name = "ExceedNumberOfStaff";
            newcol6.DataPropertyName = "ExceedNumberOfStaff";
            newcol6.Width = 120;
            newcol6.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol6.Tag = 6;
            this.dataGridViewX1.Columns.Insert(6, newcol6);

            DataGridViewTextBoxColumn newcol7 = new DataGridViewTextBoxColumn();
            newcol7.HeaderText = "备注";
            newcol7.Name = "note";
            newcol7.DataPropertyName = "note";
            newcol7.Width = 120;
            newcol7.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol7.Tag = 7;
            this.dataGridViewX1.Columns.Insert(7, newcol7);

            DataGridViewTextBoxColumn newcol8 = new DataGridViewTextBoxColumn();
            newcol8.HeaderText = "";
            //newcol8.Name = "ProductQuantity1";
            //newcol8.DataPropertyName = "ProductQuantity1";
            newcol8.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            newcol8.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol8.Tag = 8;
            this.dataGridViewX1.Columns.Insert(8, newcol8);

        }

        private void dataGridViewX1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(this.dataGridViewX1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, CultureInfo.CurrentUICulture),
                e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            }
        }

        private void dataGridViewX1_SelectionChanged(object sender, EventArgs e)
        {
            this.dataGridViewX1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
    }
}
