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
using System.Globalization;
using Gce_Common;

namespace Gce.pop_upWindows
{
    public partial class DynamicDetailsform : Office2007Form
    {
        private string windowsText;
        private string Lab1_text;
        private string Lab2_text;
        private List<DynamicDetailsformModel> listddm = new List<DynamicDetailsformModel>();
        private List<ProductionType> listPt = new List<ProductionType>();
        List<string> listSofModel = new List<string>();
        private DataTable dt = new DataTable();
        public DynamicDetailsform(string Windowstext,string lab1_text,string lab2_text,List<DynamicDetailsformModel> list,List<ProductionType> listpt)
        {
            InitializeComponent();

            this.windowsText = Windowstext;
            this.Lab1_text = lab1_text;
            this.Lab2_text = lab2_text;
            this.listddm = list;
            this.listPt = listpt;
        }

        private void DynamicDetailsform_Load(object sender, EventArgs e)
        {
            SetControls();
        }

        private void SetControls()
        {
            this.Text = windowsText;
            this.labelX1.Text = Lab1_text;

            int X = labelX1.Width + labelX1.Location.X;
            labelX2.Location = new Point(X, 12);

            labelX2.Text = Lab2_text;
            int i = -1;
            if (listPt.Count <= 0)
            {
                return;
            }

            foreach (ProductionType item in listPt)
            {
                i++;
                DataGridViewTextBoxColumn newcol = new DataGridViewTextBoxColumn();
                newcol.HeaderText = item.ProductType + "机型";
                newcol.DataPropertyName = item.Command3 + "SofModel";
                newcol.Name = item.Command3 + "SofModel";
                newcol.Tag = item.ProductType;

                dataGridViewX1.Columns.Insert(i, newcol);

                dt.Columns.Add(new DataColumn(newcol.Name, typeof(string)));

                //i++;
                //DataGridViewTextBoxColumn newcol1 = new DataGridViewTextBoxColumn();
                //newcol1.HeaderText = item.ProductType + "订单号";
                //newcol1.DataPropertyName = item.Command3 + "ZhiDan";
                //newcol1.Name = item.Command3 + "ZhiDan";
                //newcol1.Tag = item.ProductType;

                //dataGridViewX1.Columns.Insert(i, newcol1);

                //dt.Columns.Add(new DataColumn(newcol1.Name, typeof(string)));

                i++;
                DataGridViewTextBoxColumn newcol2 = new DataGridViewTextBoxColumn();
                newcol2.HeaderText = item.ProductType + "数量";
                newcol2.DataPropertyName = item.Command3 + "Number";
                newcol2.Name = item.Command3 + "Number";

                newcol2.Tag = item.ProductType;

                dataGridViewX1.Columns.Insert(i,newcol2);

                dt.Columns.Add(new DataColumn(newcol2.Name, typeof(string)));
            }
            i++;
            DataGridViewTextBoxColumn newcol3 = new DataGridViewTextBoxColumn();
            newcol3.HeaderText = "";
            newcol3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewX1.Columns.Insert(i, newcol3);

            foreach (DynamicDetailsformModel ddm in listddm)
            {
                foreach (PeriodTimeTypeModel pttm in ddm.listpttm)
                {
                    if (!listSofModel.Contains(pttm.SoftModel))
                    {
                        listSofModel.Add(pttm.SoftModel);
                    }
                }
            }
            InitializeDynamicDetailsform();
        }
        void InitializeDynamicDetailsform()
        {
            if (listPt.Count <= 0)
            {
                return;
            }
            List<PeriodTimeTypeModel> listper = new List<PeriodTimeTypeModel>();
            for (int i = 0; i < listSofModel.Count; i++)
            {
                DataRow dr = dt.NewRow();
                foreach (ProductionType item in listPt)
                {
                    foreach (DataGridViewTextBoxColumn column in dataGridViewX1.Columns)
                    {
                        if (item.ProductType == Convert.ToString(column.Tag)) 
                        {
                            foreach (DynamicDetailsformModel ddm in listddm)
                            {
                                if (ddm.ProductType == column.Tag.ToString())
                                {
                                    listper = Getlistper(ddm.listpttm, listSofModel[i]);

                                    if (listper.Count > 0)
                                    {
                                        if (column.Name == item.Command3 + "SofModel")
                                        {
                                            dr[column.Name] = listSofModel[i];
                                        }
                                        else if (column.Name == item.Command3 + "Number")
                                        {
                                            dr[column.Name] = listper.Count.ToString();
                                        }
                                        
                                    }
                                }
                            }
                        }
                    }
                }
                dt.Rows.Add(dr);
            }

            dataGridViewX1.DataSource = dt;
        }
        /// <summary>
        /// 获取工位机型数据集合
        /// </summary>
        /// <param name="listpttm"></param>
        /// <returns></returns>
        List<PeriodTimeTypeModel> Getlistper(List<PeriodTimeTypeModel> listpttm1,string SofModel)
        {
            List<PeriodTimeTypeModel> list = new List<PeriodTimeTypeModel>();

            foreach (PeriodTimeTypeModel item in listpttm1)
            {
                if (item.SoftModel == SofModel)
                {
                    list.Add(item);
                }
            }
            return list;
        }

        private void dataGridViewX1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(this.dataGridViewX1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, CultureInfo.CurrentUICulture),
                e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            }
        }

        private void btn_DataOut_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewX1.CurrentRow == null)
            {
                MessageBox.Show("没有可导出的数据");
                return;
            }
            ExcelHelperForCs.ExportToExcel(dataGridViewX1);
            MessageBox.Show("导出完成");
        }
    }
}
