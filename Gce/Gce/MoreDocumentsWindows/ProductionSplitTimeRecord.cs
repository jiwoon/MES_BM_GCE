using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gce.pop_upWindows;
using Gce_Model;
using Gce_Bll;
using Gce.Windows;
using Bll;
using Model;
using Gce.Class;
using System.Threading;
using System.Globalization;
using Gce_Common;


namespace Gce.MoreDocumentsWindows
{
    public partial class ProductionSplitTimeRecord : Office2007Form
    {
        Gce gce;
        //线程
        Thread th;

        //线程安全上下文
        SynchronizationContext m_SyncContext = null;

        //类对象
        PWorkScheduleBll pwsb = new PWorkScheduleBll();
        ProductionTypeBll ptb = new ProductionTypeBll();
        ProductPerformanceBll ppb = new ProductPerformanceBll();
        LTestLogMessageBll ltlmb = new LTestLogMessageBll();
        ProductionLinePC_titleBll productionLinePC_titleBll = new ProductionLinePC_titleBll();
        ProductionSplitTimeRecordBll pstrb = new ProductionSplitTimeRecordBll();
        ProductionLinePCBll pc_bll = new ProductionLinePCBll();

        //集合
        List<PWorkSchedule> listPWorkSchedule = new List<PWorkSchedule>();
        List<ProductionType> listpt = new List<ProductionType>();
        List<ProductionType> listpt2 = new List<ProductionType>();
        List<DynamicDetailsformModel> listddm = new List<DynamicDetailsformModel>();
        Dictionary<string, List<PeriodTimeTypeModel>> dicTypeModel = new Dictionary<string, List<PeriodTimeTypeModel>>();
        Dictionary<string, List<BadMachineFrmModel>> dicMessage = new Dictionary<string, List<BadMachineFrmModel>>();

        //声明柱形图数据源集合
        List<string> listX = new List<string>();
        Dictionary<string, List<int>> dicY = new Dictionary<string, List<int>>();
        //List<int> listY = new List<int>();

        DataTable dt = new DataTable();


        //
        string state = "browse";
        List<int> listNumber = new List<int>();

        System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        public ProductionSplitTimeRecord(Gce g)
        {
            InitializeComponent();
            this.gce = g;
            m_SyncContext = SynchronizationContext.Current;//获取主线程同步的上下文
        }

        private void ProductionSplitTimeRecord_Load(object sender, EventArgs e)
        {
            setDateTime();
            listpt = ptb.selectProductionTypeBll("selectProductionType");            
        }
        //为控件赋初始值
        public void setDateTime()
        {
            DateTime dt = DateTime.Now;
            DateTime beginTime = new DateTime(dt.Year, dt.Month, dt.Day);
            dti_begin.Value = beginTime;
            dti_end.Value = beginTime;
            comb_unit.SelectedIndex = 0;
            comb_LineName.Text = "所有产线";
            listPWorkSchedule = pwsb.selectPWorkScheduleBll("Top1_PWorkSchedule");
            txt_OnWorkClass.Text = listPWorkSchedule[0].CompanyName;
            cb_night.Checked = listPWorkSchedule[0].Flag;
        }

        private void btn_configuration_Click(object sender, EventArgs e)
        {
            if (!(UsersHelp.systemAdimin || UsersHelp.Dayparting_Commuting_time_allocation))
            {
                MessageBox.Show("抱歉，您没有使用该功能的权限");
                return;
            }
            
            WorkScheduleForm wsf = new WorkScheduleForm();  
            wsf.ShowDialog();
        }

        private void txt_OnWorkClass_ButtonCustomClick(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            list.Add("公司上下班时间类型");
            list.Add("1");
            list.Add("2");
            list.Add("3");
            list.Add("4");
            list.Add("5");
            list.Add("6");

            listPWorkSchedule = pwsb.selectPWorkScheduleBll("selectPWorkSchedule");

            ConditionsQuery cq = new ConditionsQuery("公司上下班时间类型查询",list,listPWorkSchedule,this);
            cq.ShowDialog();
        }

        public void SetTextbox_CompanyName(string CompanyName,List<PWorkSchedule> list)
        {
            txt_OnWorkClass.Text = CompanyName;
            cb_night.Checked = list[0].Flag;
            listPWorkSchedule = list;
        }

        private void SetState()
        {
            if (comb_unit.Text == "小时")
            {
                state = "Hours";
            }
            else if (comb_unit.Text == "日")
            {
                state = "Days";
            }
            else if (comb_unit.Text == "月")
            {
                state = "Month";
            }
            else if (comb_unit.Text == "年")
            {
                state = "Year";
            }
        }

        private void btn_Query_Click(object sender, EventArgs e)
        {
            this.QuertClick1();
        }

        void QuertClick1()
        {
            if (txt_OnWorkClass.Text == "")
            {
                MessageBox.Show("公司上班类型不能为空！");
                return;
            }
            listpt2.Clear();
            dicMessage.Clear();
            dicTypeModel.Clear();
            dt.Columns.Clear();
            dt.Rows.Clear();
            listX.Clear();
            dicY.Clear();
            listddm.Clear();
            this.contextMenuStrip1.Items.Clear();

            SetState();

            foreach (ProductionType item in listpt)
            {
                if (cb_night.Checked)
                {
                    if (item.OnWorkTimeTypeNight.Trim() == txt_OnWorkClass.Text.Trim())
                    {
                        listpt2.Add(item);
                    }
                }
                else
                {
                    if (item.OnWorkTimeType.Trim() == txt_OnWorkClass.Text.Trim())
                    {
                        listpt2.Add(item);
                    }
                }
            }
            ToolStripMenuItem[] MenuItem = new ToolStripMenuItem[listpt2.Count + 2];
            for (int i = 0; i < listpt2.Count; i++)
            {
                MenuItem[i] = new ToolStripMenuItem(listpt2[i].ProductType + "柱形图详情", null, new EventHandler(PopMenuItemClick), listpt2[i].Command3);
            }

            MenuItem[listpt2.Count] = new ToolStripMenuItem("时段内所工作机型查看", null, new EventHandler(PopMenuItemClick1), "TimeEtails");

            MenuItem[listpt2.Count + 1] = new ToolStripMenuItem("按时间段查询生产效能", null, new EventHandler(PopMenuItemClick2), "Jump_productionEfficiency");

            this.contextMenuStrip1.Items.AddRange(MenuItem);

            this.SetDataGridVie(listpt2);
            gce.Setlb_QueryState("正在查询...");

            RowMergeView rowMergeView = this.rowMergeView1;
            int Number = Convert.ToInt32(ip_Interval_number.Text);
            string unit = comb_unit.Text.Trim();
            string LineName = comb_LineName.Text.Trim();
            DateTime beginTime = new DateTime(dti_begin.Value.Year, dti_begin.Value.Month, dti_begin.Value.Day, 0, 0, 0);
            DateTime endTime = new DateTime(dti_end.Value.Year, dti_end.Value.Month, dti_end.Value.Day, 23, 59, 59);
            bool flag = cb_night.Checked;

            if (th != null)
            {
                th.Abort();
            }

            try
            {
                th = new Thread(delegate()
                {
                    FunctionCalculation(rowMergeView, dt, listpt2, Number, unit, LineName, listPWorkSchedule, beginTime, endTime, flag);
                });
                th.IsBackground = true;
                th.Start();
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            };
        }
        
        private void SetDataGridVie(List<ProductionType> list)
        {
            dt.Columns.Clear();
            dt.Rows.Clear();
            this.rowMergeView1.Columns.Clear();
            List<string> liststr = new List<string>();
            DataGridViewTextBoxColumn newcol = new DataGridViewTextBoxColumn();
            newcol.HeaderText = "时段";
            newcol.Name = "PeriodTime";
            newcol.DataPropertyName = "PeriodTime";
            newcol.Width = 180;
            newcol.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol.Tag = 0;
            this.rowMergeView1.Columns.Insert(0, newcol);

            dt.Columns.Add(new DataColumn("PeriodTime", typeof(string)));
                
            int i=0;
            foreach (ProductionType item in list)
            {
                liststr.Clear();
                if (item.Command3 != "")
                {
                    i++;
                    DataGridViewTextBoxColumn newcol1 = new DataGridViewTextBoxColumn();
                    newcol1.HeaderText = "数量";
                    newcol1.Name = item.Command3.ToString().Trim();
                    newcol1.DataPropertyName = item.Command3.ToString().Trim();
                    newcol1.Tag = item.ProductType;
                    newcol1.SortMode = DataGridViewColumnSortMode.NotSortable;
                    this.rowMergeView1.Columns.Insert(i, newcol1);
                    liststr.Add(newcol1.Name);
                    dt.Columns.Add(new DataColumn(newcol1.Name, typeof(string)));
                }
                if (item.Command2 != "")
                {
                    i++;
                    DataGridViewTextBoxColumn newcol1 = new DataGridViewTextBoxColumn();
                    newcol1.HeaderText = "异常记录";
                    newcol1.Name = item.Command2.ToString().Trim();
                    newcol1.DataPropertyName = item.Command2.ToString().Trim();
                    newcol1.SortMode = DataGridViewColumnSortMode.NotSortable;
                    this.rowMergeView1.Columns.Insert(i, newcol1);
                    liststr.Add(newcol1.Name);
                    dt.Columns.Add(new DataColumn(newcol1.Name, typeof(string)));
                }
                    i++;
                    DataGridViewTextBoxColumn newcol3 = new DataGridViewTextBoxColumn();
                    newcol3.HeaderText = "有效工作时长(小时)";
                    newcol3.Name = item.Command3.ToString().Trim() + "F";
                    newcol3.DataPropertyName = item.Command3.ToString().Trim() + "F";
                    newcol3.SortMode = DataGridViewColumnSortMode.NotSortable;
                    newcol3.Width = 130;
                    this.rowMergeView1.Columns.Insert(i, newcol3);
                    liststr.Add(newcol3.Name);
                    dt.Columns.Add(new DataColumn(newcol3.Name, typeof(string)));

                    i++;
                    DataGridViewTextBoxColumn newcol2 = new DataGridViewTextBoxColumn();
                    newcol2.HeaderText = "有效工作时段";
                    newcol2.Name = item.Command3.ToString().Trim() + "T";
                    newcol2.DataPropertyName = item.Command3.ToString().Trim() + "T";
                    newcol2.SortMode = DataGridViewColumnSortMode.NotSortable;
                    newcol2.Width = 180;
                    this.rowMergeView1.Columns.Insert(i, newcol2);
                    liststr.Add(newcol2.Name);
                    dt.Columns.Add(new DataColumn(newcol2.Name, typeof(string)));

                    this.rowMergeView1.ColumnHeadersHeight = 40;
                    //if (j / 2 == 0 && j != 0)
                    //{
                    //    this.rowMergeView1.MergeColumnHeaderBackColor = Color.GreenYellow;
                    //}
                    //else
                    //{
                    this.rowMergeView1.MergeColumnHeaderBackColor = Color.Yellow;
                    //}
                    this.rowMergeView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                    this.rowMergeView1.MergeColumnNames.Add(item.ProductType+i.ToString());
                    this.rowMergeView1.AddSpanHeader(this.rowMergeView1.Columns[item.Command3.ToString().Trim()].Index, liststr.Count, item.ProductType);
            }
        }
        /// <summary>
        /// 查询各个工位的失败数
        /// </summary>
        /// <param name="strorder"></param>
        /// <param name="strSoftModel"></param>
        /// <param name="sqlcommand"></param>
        /// <param name="datetimebegin"></param>
        /// <param name="datetimeend"></param>
        private void selectMessageUI(string productType,string sqlcommand, DateTime BeginTime, DateTime EndTime)
        {
            if (sqlcommand != "")
            {
                //传入SQL命令
                dicMessage.Add(productType, ltlmb.selectMessageBll("", BeginTime, EndTime, sqlcommand));
            }
        }

        private void SetDataSourceList(string productType,string SQLCommand,DateTime beginTime,DateTime endTime,bool flag)
        {
            if (SQLCommand != "")
            {
                dicTypeModel.Add(productType, pstrb.selectPeriodTimeTypeModelBll(SQLCommand, beginTime, endTime,flag));
            }
        }

        private void Refresh(object o)
        {
            gce.Setlb_QueryState("完成");
        }

        private void FunctionCalculation(RowMergeView rowmergeview,DataTable dt1,List<ProductionType> list,int Number,string Unit,string LineName,List<PWorkSchedule> listPwork,DateTime beginTime,DateTime endTime,bool flag)
        {
            try
            {
                if (LineName == "所有产线")
                {
                    foreach (ProductionType item in list)
                    {
                        SetDataSourceList(item.Command3, item.Command3, beginTime, endTime.AddDays(1D), false);
                        selectMessageUI(item.Command2, item.Command2, beginTime, endTime.AddDays(1D));
                    }
                    switch (Unit)
                    {
                        case "小时":
                            while (beginTime <= endTime)
                            {
                                HoursAlgorithm(rowmergeview, dt1, Number, beginTime, listPwork, new List<string>(), flag);
                                DataRow dr = dt1.NewRow();
                                dt1.Rows.Add(dr);

                                beginTime = beginTime.AddDays(1);
                            }
                            m_SyncContext.Post(SetDgv, dt1);
                            break;
                        case "日":
                            while (beginTime <= endTime)
                            {
                                DaysAlgorithm(rowmergeview, dt1, Number, beginTime, new List<string>());
                                beginTime = beginTime.AddDays(Number);
                            }
                            DataRow drDay = dt1.NewRow();
                            dt1.Rows.Add(drDay);
                            m_SyncContext.Post(SetDgv, dt1);
                            break;
                        case "月":
                            if (beginTime.AddMonths(Number).AddDays(-1) > endTime)
                            {
                                MessageBox.Show("您选择的时间段不足当前间隔或单位数。请重新选择");
                                m_SyncContext.Post(Refresh, true);
                                return;
                            }
                            else
                            {
                                while (beginTime <= endTime)
                                {
                                    DateTime datetime = new DateTime(beginTime.Year, beginTime.Month, beginTime.Day, 23, 59, 59);
                                    MonthsAlgorithm(rowmergeview, dt1, Number, beginTime, datetime.AddMonths(1).AddDays(-1), new List<string>());
                                    beginTime = beginTime.AddMonths(Number);
                                }
                                DataRow drMonth = dt1.NewRow();
                                dt1.Rows.Add(drMonth);
                                m_SyncContext.Post(SetDgv, dt1);
                            }

                            break;
                        case "年":
                            if (beginTime.AddYears(Number).AddDays(-1) > endTime)
                            {
                                MessageBox.Show("您选择的时间段不足当前间隔或单位数。请重新选择");
                                m_SyncContext.Post(Refresh, true);
                                return;
                            }
                            else
                            {
                                while (beginTime <= endTime)
                                {
                                    DateTime datetime = new DateTime(beginTime.Year, beginTime.Month, beginTime.Day, 23, 59, 59);
                                    MonthsAlgorithm(rowmergeview, dt1, Number, beginTime, datetime.AddMonths(1).AddDays(-1), new List<string>());
                                    beginTime = beginTime.AddYears(Number);
                                }
                                DataRow drYears = dt1.NewRow();
                                dt1.Rows.Add(drYears);
                                m_SyncContext.Post(SetDgv, dt1);
                            }
                            break;
                    }
                }
                else
                {
                    foreach (ProductionType item in list)
                    {
                        SetDataSourceList(item.Command3, item.Command3, beginTime, endTime, true);
                        selectMessageUI(item.Command2, item.Command2, beginTime, endTime);
                    }

                    List<ProductionLinePC> listPC = new List<ProductionLinePC>();
                    listPC = pc_bll.selectProductionLinePCBll(LineName, "selectProductionLinePC");
                    List<string> strlistPC = new List<string>();
                    foreach (ProductionLinePC item in listPC)
                    {
                        strlistPC.Add(item.Pcname);
                    }
                    switch (Unit)
                    {
                        case "小时":
                            while (beginTime <= endTime)
                            {
                                HoursAlgorithm(rowmergeview, dt1, Number, beginTime, listPwork, strlistPC, flag);
                                DataRow dr = dt1.NewRow();
                                dt1.Rows.Add(dr);

                                beginTime = beginTime.AddDays(1);
                            }
                            m_SyncContext.Post(SetDgv, dt1);
                            break;
                        case "日":
                            while (beginTime <= endTime)
                            {
                                DaysAlgorithm(rowmergeview, dt1, Number, beginTime, strlistPC);
                                beginTime = beginTime.AddDays(Number);
                            }
                            m_SyncContext.Post(SetDgv, dt1);
                            break;
                        case "月":
                            if (beginTime.AddMonths(Number).AddDays(-1) > endTime)
                            {
                                MessageBox.Show("您选择的时间段不足当前间隔或单位数。请重新选择");
                                gce.Setlb_QueryState("完成");
                                return;
                            }
                            else
                            {
                                while (beginTime <= endTime)
                                {
                                    DateTime datetime = new DateTime(beginTime.Year, beginTime.Month, beginTime.Day, 23, 59, 59);
                                    MonthsAlgorithm(rowmergeview, dt1, Number, beginTime, datetime.AddMonths(1).AddDays(-1), strlistPC);
                                    beginTime = beginTime.AddMonths(Number);
                                }
                                DataRow drMonth = dt1.NewRow();
                                dt1.Rows.Add(drMonth);
                                m_SyncContext.Post(SetDgv, dt1);
                            }
                            break;
                        case "年":
                            if (beginTime.AddYears(Number).AddDays(-1) > endTime)
                            {
                                MessageBox.Show("您选择的时间段不足当前间隔或单位数。请重新选择");
                                gce.Setlb_QueryState("完成");
                                return;
                            }
                            else
                            {
                                while (beginTime <= endTime)
                                {
                                    DateTime datetime = new DateTime(beginTime.Year, beginTime.Month, beginTime.Day, 23, 59, 59);
                                    MonthsAlgorithm(rowmergeview, dt1, Number, beginTime, datetime.AddMonths(1).AddDays(-1), strlistPC);
                                    beginTime = beginTime.AddYears(Number);
                                }
                                DataRow drYears = dt1.NewRow();
                                dt1.Rows.Add(drYears);
                                m_SyncContext.Post(SetDgv, dt1);
                            }
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_ProductionLine_Click(object sender, EventArgs e)
        {
            if (!(UsersHelp.systemAdimin || UsersHelp.Dayparting_Production_PC_configuration))
            {
                MessageBox.Show("抱歉，您没有使用该功能的权限");
                return;
            }
            
            ProductionLineConfiguration pconfig = new ProductionLineConfiguration();
            pconfig.ShowDialog();
        }

        private void comboBoxEx1_DropDown(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            list = productionLinePC_titleBll.selectProductionLinePC_titleLineNameBll(txt_OnWorkClass.Text.Trim(), "selectProductionLinePC_titleLineName");

            list.Insert(0, "所有产线");
            comb_LineName.DataSource = list;
            
        }

        private void comb_unit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comb_unit.SelectedItem.ToString() == "小时")
            {
                cb_night.Visible = true;
            }
            else
            {
                cb_night.Visible = false;
            }
            if (comb_unit.SelectedItem.ToString() == "月")
            {
                if (dti_begin.Value.AddMonths(1) > dti_end.Value)
                {
                    DateTime dt = new DateTime();
                    DateTime dt1 = new DateTime();
                    DateTime dtb;
                    DateTime dte;
                    dt = dti_begin.Value;
                    dt1 = dti_end.Value;
                    dtb = new DateTime(dt.Year, dt.Month, 1);
                    dte = dt1.AddDays(1 - dt1.Day).AddMonths(1).AddDays(-1);
                    dti_begin.Value = dtb;
                    dti_end.Value = dte;
                }
            }
            else if (comb_unit.SelectedItem.ToString() == "年")
            {

                if (dti_begin.Value.AddYears(1) > dti_end.Value)
                {
                    DateTime dt = new DateTime();
                    DateTime dt1 = new DateTime();
                    DateTime dtb;
                    DateTime dte;
                    dt = dti_begin.Value;
                    dt1 = dti_end.Value;
                    dtb = new DateTime(dt.Year, 1, 1);
                    dte = new DateTime(dt1.Year, 12, 31);
                    dti_begin.Value = dtb;
                    dti_end.Value = dte;
                }
            }
        }
        /// <summary>
        /// 单位为日时
        /// </summary>
        /// <param name="rowmergeview"></param>
        /// <param name="dt1"></param>
        /// <param name="Number"></param>
        /// <param name="dataTime"></param>
        /// <param name="strlistPC"></param>
        private void DaysAlgorithm(RowMergeView rowmergeview,DataTable dt1,int Number,DateTime dataTime,List<string> strlistPC)
        {
            DataRow dr = dt1.NewRow();
            DateTime startTime = new DateTime(dataTime.Year, dataTime.Month, dataTime.Day, 0, 0, 0);
            DateTime endTime = new DateTime(dataTime.Year, dataTime.Month, dataTime.Day, 23, 59, 59);
            List<PeriodTimeTypeModel> listPer = new List<PeriodTimeTypeModel>();
            List<BadMachineFrmModel> listBad = new List<BadMachineFrmModel>();

            foreach (DataGridViewTextBoxColumn column in rowmergeview.Columns)
            {
                switch (column.HeaderText)
                {
                    case "时段":
                        dr[column.Name] = dataTime.ToString("yyyy-MM-dd");
                        m_SyncContext.Post(SetlistX, dataTime.ToString("yyyy-MM-dd"));
                        break;
                    case "数量":
                        List<PeriodTimeTypeModel> listPer1 = new List<PeriodTimeTypeModel>();
                        dicTypeModel.TryGetValue(column.Name, out listPer1);
                        listPer = GetNumber(listPer1, strlistPC, startTime, endTime);
                        dr[column.Name] = Convert.ToString(listPer.Count);
                        //柱形图详情数据收集
                        Dictionary<string, int> dic = new Dictionary<string, int>();
                        dic.Add(column.Name, listPer.Count);
                        m_SyncContext.Post(SetlistY, dic);
                        //机型详情查询收集收集
                        List<DynamicDetailsformModel> listddf = new List<DynamicDetailsformModel>();
                        listddf.Add(new DynamicDetailsformModel()
                        {
                            PeriodTime = dataTime.ToString("yyyy-MM-dd"),
                            listpttm = listPer,
                            ProductType = column.Tag.ToString()
                        });
                        m_SyncContext.Post(SetdicRightMenu, listddf);
                        break;
                    case "异常记录":
                        List<BadMachineFrmModel> listBad1 = new List<BadMachineFrmModel>();
                        dicMessage.TryGetValue(column.Name, out listBad1);
                        listBad = GetBadMachineNumber(listBad1,strlistPC, startTime, endTime);
                        dr[column.Name] = Convert.ToString(listBad.Count);
                        break;
                    case "有效工作时段":
                        //List<PeriodTimeTypeModel> listPer2 = new List<PeriodTimeTypeModel>();
                        //string colunmName = column.Name.Substring(0, column.Name.Length - 1);
                        //dicTypeModel.TryGetValue(colunmName, out listPer2);

                        //listPer = GetNumber(listPer2, strlistPC, startTime, endTime);
                        if (listPer.Count > 0)
                        {
                            dr[column.Name] = listPer[0].TestTime.ToString("HH:mm:ss") + "～" + listPer[listPer.Count - 1].TestTime.ToString("HH:mm:ss");
                        }
                        else
                        {
                            dr[column.Name] = "";
                        }
                        break;
                    case "有效工作时长(小时)":
                        List<PeriodTimeTypeModel> listPer3 = new List<PeriodTimeTypeModel>();
                        string colunmName1 = column.Name.Substring(0, column.Name.Length - 1);
                        dicTypeModel.TryGetValue(colunmName1, out listPer3);

                        if (listPer.Count > 0)
                        {
                            dr[column.Name] = GetEffectiveTime(GetNumber(listPer3, strlistPC, dataTime, endTime));//GetsumHours(listPer[0].TestTime, listPer[listPer.Count - 1].TestTime).ToString("f2");
                        }
                        else
                        {
                            dr[column.Name] = "0";
                        }
                        break;
                }
            }
            dt1.Rows.Add(dr);

        }

        private void MonthsAlgorithm(RowMergeView rowmergeview, DataTable dt1, int Number, DateTime dataTime, DateTime endTime, List<string> strlistPC)
        {
            DataRow dr = dt1.NewRow();
            List<PeriodTimeTypeModel> listPer = new List<PeriodTimeTypeModel>();
            List<BadMachineFrmModel> listBad = new List<BadMachineFrmModel>();

            foreach (DataGridViewTextBoxColumn column in rowmergeview.Columns)
            {
                switch (column.HeaderText)
                {
                    case "时段":
                        dr[column.Name] = dataTime.ToString("yyyy-MM-dd") + "～" + endTime.ToString("yyyy-MM-dd");
                        m_SyncContext.Post(SetlistX, dataTime.ToString("yyyy-MM-dd") + "～" + endTime.ToString("yyyy-MM-dd"));
                        break;
                    case "数量":
                        List<PeriodTimeTypeModel> listPer1 = new List<PeriodTimeTypeModel>();
                        dicTypeModel.TryGetValue(column.Name, out listPer1);
                        listPer = GetNumber(listPer1, strlistPC, dataTime, endTime);
                        dr[column.Name] = Convert.ToString(listPer.Count);
                        //柱形图详情数据收集
                        Dictionary<string, int> dic = new Dictionary<string, int>();
                        dic.Add(column.Name, listPer.Count);
                        m_SyncContext.Post(SetlistY, dic);
                        //机型详情查询收集收集
                        List<DynamicDetailsformModel> listddf = new List<DynamicDetailsformModel>();
                        listddf.Add(new DynamicDetailsformModel()
                        {
                            PeriodTime = dataTime.ToString("yyyy-MM-dd") + "～" + endTime.ToString("yyyy-MM-dd"),
                            listpttm = listPer,
                            ProductType = column.Tag.ToString()
                        });
                        m_SyncContext.Post(SetdicRightMenu, listddf);
                        break;
                    case "异常记录":
                        List<BadMachineFrmModel> listBad1 = new List<BadMachineFrmModel>();
                        dicMessage.TryGetValue(column.Name, out listBad1);
                        listBad = GetBadMachineNumber(listBad1,strlistPC, dataTime,  endTime);
                        dr[column.Name] = Convert.ToString(listBad.Count);
                        break;
                    case "有效工作时段":
                        //List<PeriodTimeTypeModel> listPer2 = new List<PeriodTimeTypeModel>();
                        //string colunmName = column.Name.Substring(0, column.Name.Length - 1);
                        //dicTypeModel.TryGetValue(colunmName, out listPer2);

                        //listPer = GetNumber(listPer2, strlistPC, dataTime,  endTime);
                        if (listPer.Count > 0)
                        {
                            dr[column.Name] = listPer[0].TestTime.ToString("HH:mm:ss") + "～" + listPer[listPer.Count - 1].TestTime.ToString("HH:mm:ss");
                        }
                        else
                        {
                            dr[column.Name] = "";
                        }
                        break;
                    case "有效工作时长(小时)":
                        List<PeriodTimeTypeModel> listPer3 = new List<PeriodTimeTypeModel>();
                        string colunmName1 = column.Name.Substring(0, column.Name.Length - 1);
                        dicTypeModel.TryGetValue(colunmName1, out listPer3);

                        //listPer = GetNumber(listPer3, strlistPC, dataTime, endTime);
                        if (listPer.Count > 0)
                        {
                            dr[column.Name] = GetEffectiveTime(GetNumber(listPer3, strlistPC, dataTime, endTime));//GetsumHours(listPer[0].TestTime, listPer[listPer.Count - 1].TestTime).ToString("f2");
                        }
                        else
                        {
                            dr[column.Name] = "0";
                        }
                        break;
                }
            }
            dt1.Rows.Add(dr);
        }

        private void HoursAlgorithm(RowMergeView rowmergeview,DataTable dt1, int Number, DateTime dataTime,List<PWorkSchedule> listPwork,List<string> strlistPC,bool flag)
        {
            List<StartingTimeModel> list = new List<StartingTimeModel>();
            list = GetStartingTime(Number, dataTime, listPwork,flag);
            List<PeriodTimeTypeModel> listPer = new List<PeriodTimeTypeModel>();
            List<BadMachineFrmModel> listBad = new List<BadMachineFrmModel>();
            foreach (StartingTimeModel item in list)
            {
                DataRow dr = dt1.NewRow();//new DataRow();
                foreach (DataGridViewTextBoxColumn column in rowmergeview.Columns)
                {
                    switch (column.HeaderText)
                    {
                        case "时段":
                            dr[column.Name] = item.startTime.ToString("yyyy-MM-dd HH:mm:ss") + "～" + item.endTime.ToString("HH:mm:ss");
                            m_SyncContext.Post(SetlistX, item.startTime.ToString("yyyy-MM-dd HH:mm:ss") + "～" + item.endTime.ToString("HH:mm:ss"));
                            break;
                        case "数量":
                            List<PeriodTimeTypeModel> listPer1=new List<PeriodTimeTypeModel>();
                            dicTypeModel.TryGetValue(column.Name, out listPer1);
                            listPer=GetNumber(listPer1,strlistPC, item.startTime, item.endTime);
                            dr[column.Name] = Convert.ToString(listPer.Count);
                            //柱形图详情数据收集
                            Dictionary<string, int> dic = new Dictionary<string, int>();
                            dic.Add(column.Name, listPer.Count);
                            m_SyncContext.Post(SetlistY, dic);
                            //机型详情查询收集收集
                            List<DynamicDetailsformModel> listddf = new List<DynamicDetailsformModel>();
                            listddf.Add(new DynamicDetailsformModel()
                            {
                                PeriodTime=item.startTime.ToString("yyyy-MM-dd HH:mm:ss") + "～" + item.endTime.ToString("HH:mm:ss"),
                                listpttm=listPer,
                                ProductType=column.Tag.ToString()
                            });
                            m_SyncContext.Post(SetdicRightMenu, listddf);
                            break;
                        case "异常记录":
                            List<BadMachineFrmModel> listBad1 = new List<BadMachineFrmModel>();
                            dicMessage.TryGetValue(column.Name, out listBad1);
                            listBad = GetBadMachineNumber(listBad1,strlistPC, item.startTime, item.endTime);
                            dr[column.Name] =Convert.ToString(listBad.Count);
                            break;
                        case "有效工作时段":
                            // List<PeriodTimeTypeModel> listPer2=new List<PeriodTimeTypeModel>();
                            // string colunmName = column.Name.Substring(0, column.Name.Length - 1);
                            //dicTypeModel.TryGetValue(colunmName, out listPer2);
                            
                            //listPer = GetNumber(listPer2,strlistPC, item.startTime, item.endTime);
                            if(listPer.Count>0)
                            {
                                dr[column.Name] = listPer[0].TestTime.ToString("HH:mm:ss") + "～" + listPer[listPer.Count - 1].TestTime.ToString("HH:mm:ss");
                            }
                            else
                            {
                                dr[column.Name] = "";
                            }
                            break;
                        case "有效工作时长(小时)":
                            List<PeriodTimeTypeModel> listPer3 = new List<PeriodTimeTypeModel>();
                            string colunmName1 = column.Name.Substring(0, column.Name.Length - 1);
                            dicTypeModel.TryGetValue(colunmName1, out listPer3);

                            if (listPer.Count > 0)
                            {
                                dr[column.Name] = GetEffectiveTime(GetNumber(listPer3, strlistPC, item.startTime, item.endTime));//GetsumHours(listPer[0].TestTime, listPer[listPer.Count - 1].TestTime).ToString("f2");
                            }
                            else
                            {
                                dr[column.Name] = "0";
                            }
                            break;
                    }
                }
                dt1.Rows.Add(dr);
            }
  
        }
        /// <summary>
        /// 获取时段集合
        /// </summary>
        /// <param name="Number"></param>
        /// <param name="dataTime"></param>
        /// <param name="ListPwork"></param>
        /// <returns></returns>
        private List<StartingTimeModel> GetStartingTime(int Number,DateTime dataTime,List<PWorkSchedule> ListPwork,bool flag)
        {
            List<StartingTimeModel> list=new List<StartingTimeModel>();
            DateTime nighTime=new DateTime(dataTime.Year,dataTime.Month,dataTime.Day, 23, 59,59);


            list.AddRange(GetListelement(Number, dataTime, Convert.ToDateTime(ListPwork[0].MorningOnWorkTime), Convert.ToDateTime(ListPwork[0].MorningUnderWorkTime), Convert.ToDateTime(ListPwork[0].MorningOnWorkTime)));

            list.AddRange(GetOnUpWork(dataTime, Convert.ToDateTime(ListPwork[0].MorningUnderWorkTime), Convert.ToDateTime(ListPwork[0].AfternoonOnWorkTime), Convert.ToDateTime(ListPwork[0].MorningOnWorkTime)));
            
            list.AddRange(GetListelement(Number, dataTime, Convert.ToDateTime(ListPwork[0].AfternoonOnWorkTime), Convert.ToDateTime(ListPwork[0].AfternoonUnderWorkTime),Convert.ToDateTime(ListPwork[0].MorningOnWorkTime)));

            list.AddRange(GetOnUpWork(dataTime, Convert.ToDateTime(ListPwork[0].AfternoonUnderWorkTime), Convert.ToDateTime(ListPwork[0].NightOnWorkTime), Convert.ToDateTime(ListPwork[0].MorningOnWorkTime)));
            if (!flag)
            {
                list.AddRange(GetListelement(Number, dataTime, Convert.ToDateTime(ListPwork[0].NightOnWorkTime), nighTime, Convert.ToDateTime(ListPwork[0].MorningOnWorkTime)));
            }
            //list.Add(new StartingTimeModel()
            //{
            //    startTime = nighTime,
            //});
            return list;
        }
        /// <summary>
        /// 截取时段
        /// </summary>
        /// <param name="Number"></param>
        /// <param name="dataTime"></param>
        /// <param name="OnWorkTime"></param>
        /// <param name="UnderWorkTime"></param>
        /// <returns></returns>
        private List<StartingTimeModel> GetListelement(int Number, DateTime dataTime, DateTime OnWorkTime,DateTime UnderWorkTime,DateTime firstTimeWork)
        {
            DateTime startTime;
            DateTime endTime;
            DateTime MoreTime;
            List<StartingTimeModel> list = new List<StartingTimeModel>();
            if (OnWorkTime < firstTimeWork)//如果小于第一次上班时间，则判断为下一天的上班时间
            {
                DateTime dataTime1 = dataTime.AddDays(1D);
                startTime = new DateTime(dataTime1.Year, dataTime1.Month, dataTime1.Day, OnWorkTime.Hour, OnWorkTime.Minute, 00);
            }
            else
            {
                startTime = new DateTime(dataTime.Year, dataTime.Month, dataTime.Day, OnWorkTime.Hour, OnWorkTime.Minute, 00);
            }
            if (UnderWorkTime < firstTimeWork)//如果小于第一次上班时间，则判断为下一天的上班时间
            {
                DateTime dataTime1 = dataTime.AddDays(1D);
                MoreTime = new DateTime(dataTime1.Year, dataTime1.Month, dataTime1.Day, UnderWorkTime.Hour, UnderWorkTime.Minute, 00);
            }
            else
            {
                MoreTime = new DateTime(dataTime.Year, dataTime.Month, dataTime.Day, UnderWorkTime.Hour, UnderWorkTime.Minute, 00);
            }

            while (startTime <= MoreTime)
            {
                if (startTime.AddHours(Convert.ToDouble(Number)) > MoreTime)
                {
                    endTime = MoreTime;
                }
                else
                {
                    endTime = startTime.AddHours(Convert.ToDouble(Number));
                }
                list.Add(new StartingTimeModel()
                {
                    startTime = startTime,
                    endTime = endTime
                });
                startTime = startTime.AddHours(Convert.ToDouble(Number));
            }

            return list;
        }
        /// <summary>
        /// 获取下班时间
        /// </summary>
        /// <param name="dataTime"></param>
        /// <param name="OnWorkTime"></param>
        /// <param name="UnderWorkTime"></param>
        /// <returns></returns>
        private List<StartingTimeModel> GetOnUpWork(DateTime dataTime, DateTime OnWorkTime, DateTime UnderWorkTime, DateTime firstTimeWork)
        {
            DateTime startTime;
            DateTime endTime;
            List<StartingTimeModel> list = new List<StartingTimeModel>();
            if (OnWorkTime < firstTimeWork)//如果小于第一次上班时间，则判断为下一天的上班时间
            {
                DateTime dataTime1 = dataTime.AddDays(1D);
                startTime = new DateTime(dataTime1.Year, dataTime1.Month, dataTime1.Day, OnWorkTime.Hour, OnWorkTime.Minute, 00);
            }
            else
            {
                startTime = new DateTime(dataTime.Year, dataTime.Month, dataTime.Day, OnWorkTime.Hour, OnWorkTime.Minute, 00);
            }
            if (UnderWorkTime < firstTimeWork)//如果小于第一次上班时间，则判断为下一天的上班时间
            {
                DateTime dataTime1 = dataTime.AddDays(1D);
                endTime = new DateTime(dataTime1.Year, dataTime1.Month, dataTime1.Day, UnderWorkTime.Hour, UnderWorkTime.Minute, 00);
            }
            else
            {
                endTime = new DateTime(dataTime.Year, dataTime.Month, dataTime.Day, UnderWorkTime.Hour, UnderWorkTime.Minute, 00);
            }
           
            list.Add(new StartingTimeModel()
            {
                startTime=startTime,
                endTime=endTime
            });

            return list;
        }

        private List<PeriodTimeTypeModel> GetNumber(List<PeriodTimeTypeModel> datalist,List<string> strlistPC,DateTime beginTime,DateTime endTime)
        {
            List<PeriodTimeTypeModel> list = new List<PeriodTimeTypeModel>();
            if (endTime < beginTime)
            {
                endTime = new DateTime(beginTime.Year, beginTime.Month, beginTime.Day, 23, 59, 59);
            }
            if (strlistPC.Count > 0)
            {
                foreach (PeriodTimeTypeModel item in datalist)
                {
                    if (item.TestTime >= beginTime && item.TestTime <= endTime && strlistPC.Exists(o => o == item.Computer))
                    {
                        list.Add(item);
                    }
                }
                return list;
            }
            else
            {
                foreach (PeriodTimeTypeModel item in datalist)
                {
                    if (item.TestTime >= beginTime && item.TestTime <= endTime)
                    {
                        list.Add(item);
                    }
                }
                return list;
            }
        }

        private List<BadMachineFrmModel> GetBadMachineNumber(List<BadMachineFrmModel> datalist,List<string> strlistPC , DateTime beginTime, DateTime endTime)
        {
            List<BadMachineFrmModel> list = new List<BadMachineFrmModel>();
            if (strlistPC.Count > 0)
            {
                foreach (BadMachineFrmModel item in datalist)
                {
                    if (item.TestTime >= beginTime && item.TestTime <= endTime && strlistPC.Exists(o => o == item.Computer))
                    {
                        list.Add(item);
                    }
                }
                return list;
            }
            else
            {
                foreach (BadMachineFrmModel item in datalist)
                {
                    if (item.TestTime >= beginTime && item.TestTime <= endTime)
                    {
                        list.Add(item);
                    }
                }
                return list;
            }


        }
        /// <summary>
        /// 获取小时
        /// </summary>
        /// <param name="starTime">时间段开始时间</param>
        /// <param name="endTime">时间段结束</param>
        /// <returns>double</returns>
        private double GetsumHours(DateTime starTime, DateTime endTime)
        {
            TimeSpan ts = endTime - starTime;
            return ts.TotalHours;
        }

        private void ProductionSplitTimeRecord_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (th != null)
            {
                th.Abort();
            }
        }

        private void SetDgv(object dt1)
        {
            DataTable dt2 = dt1 as DataTable;
            DataRow dr = dt2.NewRow();
            foreach (DataGridViewTextBoxColumn column in rowMergeView1.Columns)
            {
                switch (column.HeaderText)
                { 
                    case "时段":
                        dr[column.Name] = "合计";
                        break;
                    case "数量":
                        dr[column.Name] = Getsum(dt2,column.Name).ToString();
                        break;
                    case "异常记录":
                        dr[column.Name] = Getsum(dt2, column.Name).ToString();
                        break;
                    case "有效工作时长(小时)":
                        dr[column.Name] = Getsum(dt2, column.Name).ToString();
                        break;
                }
            }
            dt2.Rows.Add(dr);

            this.rowMergeView1.DataSource = dt2;
            this.rowMergeView1.Refresh();//刷新控件
            gce.Setlb_QueryState("完成");
        }

        private double Getsum(DataTable dt1,string column)
        {
            double sum = 0;
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                if (dt1.Rows[i][column].ToString() != ""||dt1.Rows[i][column] != DBNull.Value)
                {
                   sum += Convert.ToDouble(dt1.Rows[i][column]);
                }
            }


            return sum;
        }

        private void ProductionSplitTimeRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            gce.lb_QueryStateVisible();
        }

        private void rowMergeView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(this.rowMergeView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, CultureInfo.CurrentUICulture),
                e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            }
        }
        private void SetlistX(object o)
        {
            if (o == null || o == DBNull.Value)
            {
                return;
            }
            else
            {
                string str = o as string;
                listX.Add(str);
            }

        }
        private void SetlistY(object o)
        {
            if (o == null || o == DBNull.Value)
            {
                return;
            }
            else
            {
                Dictionary<string, int> dic = o as Dictionary<string, int>;                
                List<int> list = new List<int>();
                string str = "";

                foreach (string key in dic.Keys)
                {
                   //int i = dic[key];
                   list.Add(dic[key]);
                   str = key;
                }
                if (dicY.ContainsKey(str))
                {
                    dicY[str].AddRange(list);
                }
                else
                {
                    dicY.Add(str, list);
                }
            }

        }
        /// <summary>
        /// 为右键菜单查看时间段内做的机型的数据源收集
        /// </summary>
        /// <param name="o"></param>
        private void SetdicRightMenu(object o)
        {
            if (o == null || o == DBNull.Value)
            {
                return;
            }
            else
            {
                List<DynamicDetailsformModel> listD = o as List<DynamicDetailsformModel>;

                listddm.AddRange(listD);
            }

        }
        private void PopMenuItemClick1(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            List<DynamicDetailsformModel> list = new List<DynamicDetailsformModel>();


            foreach (DynamicDetailsformModel model in listddm)
            {
                if (model.PeriodTime == rowMergeView1.CurrentRow.Cells["PeriodTime"].Value.ToString())
                {
                    list.Add(model);
                }
            }
            if (list.Count > 0)
            {
                DynamicDetailsform ddf = new DynamicDetailsform("时段内所工作机型查看", "时段：", list[0].PeriodTime, list, listpt2);
                ddf.ShowDialog();
            }

        }

        private void PopMenuItemClick2(object sender, EventArgs e)
        {            
            DateTime BeginTime;           
            DateTime EndTime;
            string str = this.rowMergeView1.Rows[this.rowMergeView1.CurrentRow.Index].Cells["PeriodTime"].Value.ToString();
            switch(state)
            {
                case "Hours":                    
                    BeginTime = GetBeginTimeHours(str, DateTime.Now, true);
                    EndTime = GetBeginTimeHours(str, BeginTime, false);
                    productionEfficiency pe = new productionEfficiency(gce);
                    pe.JumpSetDatetime(BeginTime, EndTime);
                    pe.ShowDialog();
                    //gce.Jump_productionEfficiency(BeginTime, EndTime);
                    break;
                case "Days":
                    BeginTime = GetBeginTimeDays(str, true);
                    EndTime = GetBeginTimeDays(str, false);
                    productionEfficiency pe1 = new productionEfficiency(gce);
                    pe1.JumpSetDatetime(BeginTime, EndTime);
                    pe1.ShowDialog();
                   // gce.Jump_productionEfficiency(BeginTime, EndTime);
                    break;
                case "Month":
                    BeginTime = GetBeginTimeMonth(str, true);
                    EndTime = GetBeginTimeMonth(str, false);
                    productionEfficiency pe2 = new productionEfficiency(gce);
                    pe2.JumpSetDatetime(BeginTime, EndTime);
                    pe2.ShowDialog();
                   // gce.Jump_productionEfficiency(BeginTime, EndTime);
                    break;
            }
        }
        DateTime GetBeginTimeHours(string str,DateTime begintime,bool bl)
        {
            int i = str.IndexOf("～");
            if (bl)
            {
                string datetime = str.Substring(0, i);

                return Convert.ToDateTime(datetime);
            }
            else
            {
                string endtime = begintime.ToString("yyyy-MM-dd ");
                endtime += str.Substring(i + 1, str.Length - i - 1);
                return Convert.ToDateTime(endtime);
            }
        }
        DateTime GetBeginTimeMonth(string str, bool bl)
        {
            int i = str.IndexOf("～");
            if (bl)
            {
                string datetime = str.Substring(0, i);
                DateTime datetime1 = new DateTime(Convert.ToDateTime(datetime).Year, Convert.ToDateTime(datetime).Month, Convert.ToDateTime(datetime).Day,00,00,00);
                return datetime1;
            }
            else
            {
                string datetime = str.Substring(i + 1, str.Length - i - 1);
                DateTime datetime2 = new DateTime(Convert.ToDateTime(datetime).Year, Convert.ToDateTime(datetime).Month, Convert.ToDateTime(datetime).Day, 23, 59, 59);
                return datetime2;
            }
        }
        DateTime GetBeginTimeDays(string str, bool bl)
        {
            DateTime datetime;
            if (bl)
            {
                datetime = Convert.ToDateTime(str);
                DateTime returnTime=new DateTime(datetime.Year,datetime.Month,datetime.Day,00,00,00);
                return returnTime;
            }
            else
            {
                datetime = Convert.ToDateTime(str);
                DateTime returnTime = new DateTime(datetime.Year, datetime.Month, datetime.Day, 23, 59, 59);
                return returnTime;
            }
        }
        private void PopMenuItemClick(object sender,EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            switch (state)
            {
                case "Hours":
                    if (dicY.ContainsKey(item.Name))
                    {
                        CapacityDetails cdHours = new CapacityDetails(item.Text.Trim() + "按小时", listX, dicY[item.Name]);
                        cdHours.ShowDialog();
                    }
                    break;
                case "Days":
                    if (dicY.ContainsKey(item.Name))
                    {
                        CapacityDetails cdDays = new CapacityDetails(item.Text.Trim() + "按日", listX, dicY[item.Name]);
                        cdDays.ShowDialog();
                    }
                    break;
                case "Month":
                    if (dicY.ContainsKey(item.Name))
                    {
                        CapacityDetails cdMonth = new CapacityDetails(item.Text.Trim() + "按月", listX, dicY[item.Name]);
                        cdMonth.ShowDialog();
                    }
                    break;
                case "Year":
                    if (dicY.ContainsKey(item.Name))
                    {
                        CapacityDetails cdYear = new CapacityDetails(item.Text.Trim() + "按年", listX, dicY[item.Name]);
                        cdYear.ShowDialog();
                    }
                    break;
            }
        }

        private string GetEffectiveTime(List<PeriodTimeTypeModel> list)
        {
            if (list.Count > 0)
            {
                DateTime startTime = list[0].TestTime;//开始计算时间
                DateTime endTime = list[0].TestTime;//上一条数据时间
                DateTime overTime = list[0].TestTime.AddHours(1);//时间段结束时间
                DateTime listLastTime = list[list.Count - 1].TestTime;//集合最后一条数据时间
                double sumTime = 0;

                foreach (PeriodTimeTypeModel item in list)
                {
                    if (item.TestTime > endTime.AddMinutes(15D))
                    {
                        sumTime += GetsumHours(startTime, endTime);
                        startTime = item.TestTime;
                        overTime = startTime.AddHours(1);
                    }
                    else
                    {
                        if (item.TestTime > overTime || item.TestTime == listLastTime)
                        {
                            sumTime += GetsumHours(startTime, endTime);
                            startTime = item.TestTime;
                            overTime = startTime.AddHours(1);
                        }
                    }
                    endTime = item.TestTime;
                }
                return sumTime.ToString("f2");
            }
            else
            {
                return "0";
            }

        }

        private void rowMergeView1_SelectionChanged(object sender, EventArgs e)
        {
            this.rowMergeView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (contextMenuStrip1.Items.Count > 0)
            {
                foreach (ToolStripItem item in contextMenuStrip1.Items)
                {
                    if (item is ToolStripMenuItem && (item.Name == "TimeEtails" || item.Name == "Jump_productionEfficiency"))
                    {
                        SetToolStripMenuItemEnable((ToolStripMenuItem)item);
                    }
                }
            }
        }
        void SetToolStripMenuItemEnable(ToolStripMenuItem toolstripmenuitem)
        {
            if (rowMergeView1.Rows.Count > 0)
            {
                if (rowMergeView1.CurrentRow.Cells["PeriodTime"].Value.ToString() != "" && rowMergeView1.CurrentRow.Cells["PeriodTime"].Value.ToString() != "合计")
                {
                    toolstripmenuitem.Enabled = true;
                }
                else
                {
                    toolstripmenuitem.Enabled = false;
                }
            }
            else
            {
                toolstripmenuitem.Enabled = false;
            }
        }

        private void btn_OutData_Click(object sender, EventArgs e)
        {
            if (!(UsersHelp.systemAdimin || UsersHelp.Dayparting_DataOut))
            {
                MessageBox.Show("抱歉，您没有使用该功能的权限");
                return;
            }
            
            if (rowMergeView1.CurrentRow == null)
            {
                MessageBox.Show("没有可导出的数据");
                return;
            }
            ExcelHelperForCs.ExportToExcel(rowMergeView1);
            MessageBox.Show("导出完成");
        }

        private void rowMergeView1_Scroll(object sender, ScrollEventArgs e)
        {
            this.rowMergeView1.Refresh();
        }

        /// <summary>
        /// 触发定时器
        /// </summary>
        /// <param name="i"></param>
        public void timer1Start(int i)
        {
            timer1.Interval = i;
            timer1.Tick += timer1_Tick;
            timer1.Enabled = true;

            lab_Message.Text = "定时刷新开始，" + "每" + (i / 60000).ToString() + "分钟刷新一次";

            btni_TimedRefresh.Text = "结束定数刷新";
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            dti_end.Value = DateTime.Now;
            this.QuertClick1();
        }

        void timer1Stop()
        {
            timer1.Enabled = false;
            lab_Message.Text = "";
            btni_TimedRefresh.Text = "开始定数刷新";
        }
        void TimedRefresh_Click1()
        {
            if (btni_TimedRefresh.Text == "结束定数刷新")
            {
                this.timer1Stop();
            }
            else
            {
                TimedRefreshCondition trc = new TimedRefreshCondition("分时段记录定时", this);
                trc.ShowDialog();
            }
        }

        private void btni_TimedRefresh_Click(object sender, EventArgs e)
        {
            this.TimedRefresh_Click1();
        }

    }

           
}
