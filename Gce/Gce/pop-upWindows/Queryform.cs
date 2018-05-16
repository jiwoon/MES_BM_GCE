using DevComponents.DotNetBar;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gce.pop_upWindows;
using Gce_Model;

namespace Gce.Windows
{
    public partial class Queryform : Office2007Form
    {
        private ParameterSettings f1;
        private ProductionLineConfiguration f2;
        private TypesWorkform f3;
        private ExceptionConfiguration f4;
        private ParametersCall f5;

        //
        private List<ProductSet_New_title> list = new List<ProductSet_New_title>();
        List<string> liststr = new List<string>();
        List<PTypesWork> typesworkList = new List<PTypesWork>();
        List<PEncodingSetting> encodingList = new List<PEncodingSetting>();
        List<PCapacityConfiguration> PCapacityList = new List<PCapacityConfiguration>();

        private string str = "";
        public Queryform(List<ProductSet_New_title> list, ParameterSettings form)
        {
            this.list = list;
            this.f1 = form;
            InitializeComponent();
        }

        public Queryform(List<string> list,string str1, ProductionLineConfiguration form)
        {
            this.f2 = form;
            this.liststr = list;
            this.str = str1;
            InitializeComponent();
        }

        public Queryform(List<PEncodingSetting> list, string str1, ExceptionConfiguration form)
        {
            this.f4 = form;
            this.encodingList = list;
            this.str = str1;
            InitializeComponent();
        }
        public Queryform(List<PTypesWork> list, string str1, TypesWorkform form)
        {
            this.f3 = form;
            this.typesworkList = list;
            this.str = str1;
            InitializeComponent();
        }

        public Queryform(List<PCapacityConfiguration> list, string str1, ParametersCall form)
        {
            this.f5 = form;
            this.PCapacityList = list;
            this.str = str1;
            InitializeComponent();
        }
        private void Queryform_Load(object sender, EventArgs e)
        {
            switch (str)
            {
                case "": setcbe_ProductionClassDataSource(list);
                    break;
                case "生产线名": labelX1.Text = str;
                    cbe_ProductionClass.DataSource = liststr;
                    break;
                case "工种名": labelX1.Text = str;
                    setcbe_ProductionClassDataSource1(typesworkList);
                    break;
                case "异常编码":
                    labelX1.Text = str;
                    setcbe_ProductionClassDataSource1(encodingList);
                    break;
                case "订单号":
                    labelX1.Text = str;
                    setcbe_ProductionClassDataSource1(PCapacityList);
                    break;
            }
            
        }
        private void setcbe_ProductionClassDataSource(List<ProductSet_New_title> list)
        {
            List<string> cbelist = new List<string>();
            foreach (ProductSet_New_title item in list)
            {
                cbelist.Add(item.ProductClass);
            }
            this.cbe_ProductionClass.DataSource = cbelist;
        }
        private void setcbe_ProductionClassDataSource1(List<PTypesWork> list)
        {
            List<string> cbelist = new List<string>();
            foreach (PTypesWork item in list)
            {
                cbelist.Add(item.TypesWork);
            }
            this.cbe_ProductionClass.DataSource = cbelist;
        }
        private void setcbe_ProductionClassDataSource1(List<PEncodingSetting> list)
        {
            List<string> cbelist = new List<string>();
            foreach (PEncodingSetting item in list)
            {
                cbelist.Add(item.BarcodeEncoding);
            }
            this.cbe_ProductionClass.DataSource = cbelist;
        }
        private void setcbe_ProductionClassDataSource1(List<PCapacityConfiguration> list)
        {
            List<string> cbelist = new List<string>();
            foreach (PCapacityConfiguration item in list)
            {
                cbelist.Add(item.ZhiDan);
            }
            this.cbe_ProductionClass.DataSource = cbelist;
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            switch (str)
            {
                case "": if (cbe_ProductionClass.Text != "")
                    {
                        f1.selectdTreeview(cbe_ProductionClass.Text.Trim());
                    }
                    break;
                case "生产线名": 
                    f2.selectedTreeview(cbe_ProductionClass.Text.Trim());
                    break;
                case "工种名": 
                    f3.SelectedTreeviewNode(cbe_ProductionClass.Text.Trim());
                    break;
                case "异常编码":
                    f4.SelectedTreeviewNode(cbe_ProductionClass.Text.Trim());
                    break;
                case "订单号":
                    f5.selectedTreeview(cbe_ProductionClass.Text.Trim());
                    break;
            }

            this.Close();
        }
    }
}
