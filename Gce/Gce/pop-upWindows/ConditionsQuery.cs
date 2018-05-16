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
using Gce.MoreDocumentsWindows;

namespace Gce.Windows
{
    public partial class ConditionsQuery : Office2007Form
    {
        private productionEfficiency form;

        private ProductionSplitTimeRecord formpstr;

        private EmployeeExperience formemployee;

        private AbnormalIput formabnormal;
        private AbnormalIputQury formabnormalQuery;

        //选择类型后返回集合
         List<PWorkSchedule> pwslist2 = new List<PWorkSchedule>();
         List<selectConditionsQueryPStaffResumeModel> queryList2 = new List<selectConditionsQueryPStaffResumeModel>();
         List<selectConditionsQueryPStaffResumeModel2> query2List2 = new List<selectConditionsQueryPStaffResumeModel2>();

        //datagridview列命字段集
        private List<string> strlist = new List<string>();
        //datagridview数据源
        private List<productionOrder>  polist=new List<productionOrder>();
        private List<ProductionSoftModel> psmlist = new List<ProductionSoftModel>();
        private List<PWorkSchedule> pwslist = new List<PWorkSchedule>();
        private List<selectConditionsQueryPStaffResumeModel> queryList = new List<selectConditionsQueryPStaffResumeModel>();
        private List<selectConditionsQueryPStaffResumeModel2> query2List = new List<selectConditionsQueryPStaffResumeModel2>();
        //ComboBox数据源
        private List<string> cbelist = new List<string>();
        //窗体名称window.text
        private string WindowText;

        ConditionQueryBll cqb = new ConditionQueryBll();
        public ConditionsQuery()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 订单号查询
        /// </summary>
        /// <param name="WindowsName">窗体名字</param>
        /// <param name="DataTableColumn">表列名</param>
        /// <param name="DataCollection">数据源集合</param>
        /// <param name="f">上级窗体类型</param>
        public ConditionsQuery(string WindowsName, List<string> DataTableColumn, List<productionOrder> DataCollection, productionEfficiency f)
        {
            InitializeComponent();
            this.WindowText = WindowsName;
            this.strlist = DataTableColumn;
            this.polist = DataCollection;
            this.form = f;
        }
        //
        public ConditionsQuery(string WindowsName, List<string> DataTableColumn, List<productionOrder> DataCollection, AbnormalIput f)
        {
            InitializeComponent();
            this.WindowText = WindowsName;
            this.strlist = DataTableColumn;
            this.polist = DataCollection;
            this.formabnormal = f;
        }
        //异常查询界面
        public ConditionsQuery(string WindowsName, List<string> DataTableColumn, List<productionOrder> DataCollection, AbnormalIputQury f)
        {
            InitializeComponent();
            this.WindowText = WindowsName;
            this.strlist = DataTableColumn;
            this.polist = DataCollection;
            this.formabnormalQuery = f;
        }
        /// <summary>
        /// 机型查询
        /// </summary>
        /// <param name="WindowsName">窗体名字</param>
        /// <param name="DataTableColumn">表列名</param>
        /// <param name="DataCollection">数据源集合</param>
        /// <param name="f">上级窗体类型</param>
        public ConditionsQuery(string WindowsName, List<string> DataTableColumn, List<ProductionSoftModel> DataCollection, productionEfficiency f)
        {
            InitializeComponent();
            this.WindowText = WindowsName;
            this.strlist = DataTableColumn;
            this.psmlist = DataCollection;
            this.form = f;
        }
        /// <summary>
        /// 公司上下班时间类型查询
        /// </summary>
        /// <param name="WindowsName"></param>
        /// <param name="DataTableColumn"></param>
        /// <param name="DataCollection"></param>
        /// <param name="f"></param>
        public ConditionsQuery(string WindowsName, List<string> DataTableColumn, List<PWorkSchedule> DataCollection,ProductionSplitTimeRecord f)
        {
            InitializeComponent();
            this.WindowText = WindowsName;
            this.strlist = DataTableColumn;
            this.pwslist = DataCollection;
            this.formpstr = f;
        }
        public ConditionsQuery(string WindowsName, List<string> DataTableColumn, List<PWorkSchedule> DataCollection, productionEfficiency f)
        {
            InitializeComponent();
            this.WindowText = WindowsName;
            this.strlist = DataTableColumn;
            this.pwslist = DataCollection;
            this.form = f;
        }
        /// <summary>
        /// 员工履历表，姓名工号查询 
        /// </summary>
        /// <param name="WindowsName"></param>
        /// <param name="DataTableColumn"></param>
        /// <param name="QueryList"></param>
        /// <param name="f"></param>
        public ConditionsQuery(string WindowsName, List<string> DataTableColumn, List<selectConditionsQueryPStaffResumeModel> QueryList,EmployeeExperience f)
        {
            InitializeComponent();
            this.WindowText = WindowsName;
            this.strlist = DataTableColumn;
            this.queryList = QueryList;
            this.formemployee = f;
            
        }
        /// <summary>
        /// 异常录入，姓名、公司名称查询 
        /// </summary>
        /// <param name="WindowsName"></param>
        /// <param name="DataTableColumn"></param>
        /// <param name="QueryList"></param>
        /// <param name="f"></param>
        public ConditionsQuery(string WindowsName, List<string> DataTableColumn, List<selectConditionsQueryPStaffResumeModel2> QueryList, AbnormalIput f)
        {
            InitializeComponent();
            this.WindowText = WindowsName;
            this.strlist = DataTableColumn;
            this.query2List = QueryList;
            this.formabnormal = f;

        }
        public ConditionsQuery(string WindowsName, List<string> DataTableColumn, List<selectConditionsQueryPStaffResumeModel2> QueryList, AbnormalIputQury f)
        {
            InitializeComponent();
            this.WindowText = WindowsName;
            this.strlist = DataTableColumn;
            this.query2List = QueryList;
            this.formabnormalQuery = f;

        }
        //订单号查询
        private void LoadproductionOrder()
        {
            this.Text = this.WindowText;
            labelX1.Text = strlist[0];
            int X = Convert.ToInt32(this.labelX1.Width + this.labelX1.Location.X);
            Cbe_Condiyions.Location = new Point(X, 17);
            for (int i = 0; i < strlist.Count; i++)
            {
                DataGridViewTextBoxColumn newcol = new DataGridViewTextBoxColumn();
                newcol.HeaderText = strlist[i];
                newcol.Name = "Order";
                newcol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                newcol.DataPropertyName = "Order";
                newcol.Tag = i;
                dataGridViewX1.Columns.Insert(i, newcol);
            }
            this.dataGridViewX1.DataSource = polist;
            foreach (productionOrder item in polist)
            {
                cbelist.Add(item.Order);
            }
            this.Cbe_Condiyions.DataSource = cbelist;
        }
        private void LoadProductionSoftModel()
        {
            this.Text = this.WindowText;
            labelX1.Text = strlist[0];
            int X = Convert.ToInt32(this.labelX1.Width + this.labelX1.Location.X);
            Cbe_Condiyions.Location = new Point(X, 17);

            for (int i = 0; i < strlist.Count; i++)
            {
                DataGridViewTextBoxColumn newcol = new DataGridViewTextBoxColumn();
                newcol.HeaderText = strlist[i];
                newcol.Name = "SoftModel";
                newcol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                newcol.DataPropertyName = "SoftModel";
                newcol.Tag = i;
                dataGridViewX1.Columns.Insert(i, newcol);
            }
            this.dataGridViewX1.DataSource = psmlist;
            foreach (ProductionSoftModel item in psmlist)
            {
                cbelist.Add(item.SoftModel);
            }
            this.Cbe_Condiyions.DataSource = cbelist;
        }
        //公司上下班时间类型查询
        private void LoadProductionCompanyName()
        {
            this.Text = this.WindowText;
            labelX1.Text = strlist[0];
            int X = Convert.ToInt32(this.labelX1.Width + this.labelX1.Location.X);
            Cbe_Condiyions.Location = new Point(X, 17);

            for (int i = 0; i < strlist.Count; i++)
            {
                DataGridViewTextBoxColumn newcol = new DataGridViewTextBoxColumn();
                newcol.HeaderText = strlist[i];  
                switch (i)
                {
                    case 0: newcol.Name = "CompanyName"; newcol.DataPropertyName = "CompanyName";
                        newcol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        break;
                    case 1: newcol.Name = "MorningOnWorkTime"; newcol.DataPropertyName = "MorningOnWorkTime";
                        newcol.Visible = false;
                        break;
                    case 2: newcol.Name = "MorningUnderWorkTime"; newcol.DataPropertyName = "MorningUnderWorkTime";
                        newcol.Visible = false;
                        break;
                    case 3: newcol.Name = "AfternoonOnWorkTime"; newcol.DataPropertyName = "AfternoonOnWorkTime";
                        newcol.Visible = false;
                        break;
                    case 4: newcol.Name = "AfternoonUnderWorkTime"; newcol.DataPropertyName = "AfternoonUnderWorkTime";
                        newcol.Visible = false;
                        break;
                    case 5: newcol.Name = "NightOnWorkTime"; newcol.DataPropertyName = "NightOnWorkTime";
                        newcol.Visible = false;
                        break;
                    case 6: newcol.Name = "Flag"; newcol.DataPropertyName = "Flag"; 
                        newcol.Visible = false;
                        break;
                }
                newcol.Tag = i;
                dataGridViewX1.Columns.Insert(i, newcol);
            }
            this.dataGridViewX1.DataSource = pwslist;
            foreach (PWorkSchedule item in pwslist)
            {
                cbelist.Add(item.CompanyName);
            }
            this.Cbe_Condiyions.DataSource = cbelist;
        }
        /// <summary>
        /// 员工履历表姓名工号查询
        /// </summary>
        private void LoadProductionEmployee()
        {
            this.Text = this.WindowText;
            labelX1.Text = strlist[0];
            int X = Convert.ToInt32(this.labelX1.Width + this.labelX1.Location.X);
            Cbe_Condiyions.Location = new Point(X, 17);

            for (int i = 0; i < strlist.Count; i++)
            {
                DataGridViewTextBoxColumn newcol = new DataGridViewTextBoxColumn();
                newcol.HeaderText = strlist[i];
                switch (i)
                {
                    case 0: newcol.Name = "Name"; newcol.DataPropertyName = "Name";
                        break;
                    case 1: newcol.Name = "WorkNumber"; newcol.DataPropertyName = "WorkNumber";
                        newcol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        break;
                }
                newcol.Tag = i;
                dataGridViewX1.Columns.Insert(i, newcol);
            }
            this.dataGridViewX1.DataSource = queryList;

            foreach (selectConditionsQueryPStaffResumeModel item in queryList)
            {
                cbelist.Add(item.Name);
            }
            this.Cbe_Condiyions.DataSource = cbelist;
        }
        /// <summary>
        /// 异常录入--员工履历表姓名工号查询
        /// </summary>
        private void LoadProductionAbnormal()
        {
            this.Text = this.WindowText;
            labelX1.Text = strlist[0];
            int X = Convert.ToInt32(this.labelX1.Width + this.labelX1.Location.X);
            Cbe_Condiyions.Location = new Point(X, 17);

            for (int i = 0; i < strlist.Count; i++)
            {
                DataGridViewTextBoxColumn newcol = new DataGridViewTextBoxColumn();
                newcol.HeaderText = strlist[i];
                switch (i)
                {
                    case 0: newcol.Name = "Name"; newcol.DataPropertyName = "Name";
                        break;
                    case 1: newcol.Name = "WorkNumber"; newcol.DataPropertyName = "WorkNumber";
                        break;
                    case 2: newcol.Name = "CompanyName"; newcol.DataPropertyName = "CompanyName";
                        newcol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        break;                        
                }
                newcol.Tag = i;
                dataGridViewX1.Columns.Insert(i, newcol);
            }
            this.dataGridViewX1.DataSource = query2List;

            foreach (selectConditionsQueryPStaffResumeModel2 item in query2List)
            {
                cbelist.Add(item.Name);
            }
            this.Cbe_Condiyions.DataSource = cbelist;
        }
        private void ConditionsQuery_Load(object sender, EventArgs e)
        {
            switch (WindowText)
            {
                case "订单号查询": LoadproductionOrder();
                    break;
                case "机型查询": LoadProductionSoftModel();
                    break;
                case "公司上下班时间类型查询": LoadProductionCompanyName();
                    break;
                case "姓名工号查询": LoadProductionEmployee();
                    break;
                case "录入人员姓名与所属公司": LoadProductionAbnormal();
                    break;
            }
            
        }

        private void dataGridViewX1_SelectionChanged(object sender, EventArgs e)
        {
            this.dataGridViewX1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }
        /// <summary>
        /// 点击选择一行时，获得该行的列的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (WindowText)
                {
                    case "订单号查询":
                        if (form != null)
                        {
                            form.setTxt_Order(dataGridViewX1["Order", e.RowIndex].Value.ToString());
                        }
                        else if (formabnormal != null)
                        {
                            formabnormal.setTxt_Order(dataGridViewX1["Order", e.RowIndex].Value.ToString());
                        }
                        else if (formabnormalQuery != null)
                        {
                            formabnormalQuery.setTxt_Order(dataGridViewX1["Order", e.RowIndex].Value.ToString());
                        }
                        this.Close();
                        break;
                    case "机型查询":
                        form.setTxt_SoftModel(dataGridViewX1["SoftModel", e.RowIndex].Value.ToString());
                        this.Close();
                        break;
                    case "公司上下班时间类型查询":
                        pwslist2.Add(new PWorkSchedule(){
                            CompanyName = dataGridViewX1["CompanyName", e.RowIndex].Value.ToString(),
                            MorningOnWorkTime = dataGridViewX1["MorningOnWorkTime", e.RowIndex].Value.ToString(),
                            MorningUnderWorkTime = dataGridViewX1["MorningUnderWorkTime", e.RowIndex].Value.ToString(),
                            AfternoonOnWorkTime = dataGridViewX1["AfternoonOnWorkTime", e.RowIndex].Value.ToString(),
                            AfternoonUnderWorkTime = dataGridViewX1["AfternoonUnderWorkTime", e.RowIndex].Value.ToString(),
                            NightOnWorkTime = dataGridViewX1["NightOnWorkTime", e.RowIndex].Value.ToString(),
                            Flag = Convert.ToBoolean(dataGridViewX1["Flag",e.RowIndex].Value)
                        });
                        if (formpstr != null)
                        {
                            formpstr.SetTextbox_CompanyName(dataGridViewX1["CompanyName", e.RowIndex].Value.ToString(), pwslist2);
                        }
                        else
                        {
                            form.SetTextbox_CompanyName(dataGridViewX1["CompanyName", e.RowIndex].Value.ToString(), pwslist2);
                        }
                        this.Close();
                        break;
                    case "姓名工号查询":
                        queryList2.Add(new selectConditionsQueryPStaffResumeModel()
                        {
                            Name = dataGridViewX1["Name", e.RowIndex].Value.ToString(),
                            WorkNumber = dataGridViewX1["WorkNumber", e.RowIndex].Value.ToString()
                        });
                        formemployee.SetNameAndWorkNumber(queryList2);
                        this.Close();
                        break;
                    case "录入人员姓名与所属公司":
                       query2List2.Add(new selectConditionsQueryPStaffResumeModel2()
                       {
                           Name = dataGridViewX1["Name", e.RowIndex].Value.ToString(),
                           CompanyName = dataGridViewX1["CompanyName", e.RowIndex].Value.ToString()
                       });
                       if (formabnormal != null)
                       {
                           formabnormal.SetNameAndCompanyName(query2List2);
                       }
                       else
                       {
                           formabnormalQuery.SetNameAndCompanyName(query2List2);
                       }
                       this.Close();
                        break;
                }
            }
            catch 
            { }

        }
        /// <summary>
        /// 过滤功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cbe_Condiyions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                switch(WindowText)
                {
                    case "订单号查询":
                    if (Cbe_Condiyions.Text != "")
                    {
                        List<productionOrder> list1 = new List<productionOrder>();
                        foreach (productionOrder item in polist)
                        {
                            if (item.Order == Cbe_Condiyions.Text)
                            {
                                list1.Add(item);
                                dataGridViewX1.DataSource = list1;
                                break;
                            }
                        }
                    }
                    else
                    {
                        dataGridViewX1.DataSource = polist;
                    }
                    break;
                    case "机型查询":
                    if (Cbe_Condiyions.Text != "")
                    {
                        List<ProductionSoftModel> list1 = new List<ProductionSoftModel>();
                        foreach (ProductionSoftModel item in psmlist)
                        {
                            if (item.SoftModel == Cbe_Condiyions.Text)
                            {
                                list1.Add(item);
                                dataGridViewX1.DataSource = list1;
                                break;
                            }
                        }
                    }
                    else
                    {
                        dataGridViewX1.DataSource = psmlist;
                    }
                    break;
                    case "公司上下班时间类型查询":
                    if (Cbe_Condiyions.Text != "")
                    {
                        List<PWorkSchedule> list1 = new List<PWorkSchedule>();
                        foreach (PWorkSchedule item in pwslist)
                        {
                            if (item.CompanyName == Cbe_Condiyions.Text)
                            {
                                list1.Add(item);
                                dataGridViewX1.DataSource = list1;
                                break;
                            }
                        }
                    }
                    else
                    {
                        dataGridViewX1.DataSource = pwslist;
                    }
                    break;
                    case "姓名工号查询":
                    if (Cbe_Condiyions.Text != "")
                    {
                        List<selectConditionsQueryPStaffResumeModel> list1 = new List<selectConditionsQueryPStaffResumeModel>();
                        foreach (selectConditionsQueryPStaffResumeModel item in queryList)
                        {
                            if (item.Name == Cbe_Condiyions.Text || item.WorkNumber == Cbe_Condiyions.Text)
                            {
                                list1.Add(item);
                                dataGridViewX1.DataSource = list1;
                                break;
                            }
                        }
                    }
                    else
                    {
                        dataGridViewX1.DataSource = queryList;
                    }
                    break;
                    case "录入人员姓名与所属公司":
                    if (Cbe_Condiyions.Text != "")
                    {
                        List<selectConditionsQueryPStaffResumeModel2> list1 = new List<selectConditionsQueryPStaffResumeModel2>();
                        foreach (selectConditionsQueryPStaffResumeModel2 item in query2List)
                        {
                            if (item.Name == Cbe_Condiyions.Text || item.CompanyName == Cbe_Condiyions.Text)
                            {
                                list1.Add(item);
                                dataGridViewX1.DataSource = list1;
                                break;
                            }
                        }
                    }
                    else
                    {
                        dataGridViewX1.DataSource = query2List;
                    }
                    break;
                 }
            }
        }
        //待优化
        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (WindowText == "姓名工号查询")
            //{
            //    cbelist.Clear();

            //    if (dataGridViewX1.Rows.Count > 0)
            //    {
            //        labelX1.Text = this.dataGridViewX1.Columns[dataGridViewX1.CurrentCell.ColumnIndex].HeaderText;
            //        int X = Convert.ToInt32(this.labelX1.Width + this.labelX1.Location.X);
            //        Cbe_Condiyions.Location = new Point(X, 17);

            //        switch (labelX1.Text)
            //        { 
            //            case "姓名":
            //                foreach (selectConditionsQueryPStaffResumeModel item in queryList)
            //                {
            //                    cbelist.Add(item.Name);
            //                }
            //                break;
            //            case "工号":
            //                foreach (selectConditionsQueryPStaffResumeModel item in queryList)
            //                {
            //                    cbelist.Add(item.WorkNumber);
            //                }
            //                break;
            //        }

            //        //Cbe_Condiyions.DataSource = cbelist;
            //    }
            //}
        }
    }
}
