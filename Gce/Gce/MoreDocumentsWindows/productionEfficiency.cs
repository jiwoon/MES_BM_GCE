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
using Gce_Bll;
using Gce_Common;
using System.Threading;
using Gce_Model;
using Gce.pop_upWindows;
using System.Globalization;
using Gce.Class;

namespace Gce.Windows
{
    public sealed partial class productionEfficiency : Office2007Form
    {
        ////单列模式
        //private static productionEfficiency _instance;

        //private static readonly object _syncLock = new object();

        Gce gce;
        /// <summary>
        /// UI线程的同步上下文
        /// </summary>
        SynchronizationContext m_SyncContext = null; 
        //后台线程
        Thread th;
        Thread th1;
        Thread TableTransferTh;
        //线程集合
        List<Thread> listTh = new List<Thread>();
        //类对象
        ProductPerformanceBll ppb = new ProductPerformanceBll();

        ProductSet_NewBll psnb = new ProductSet_NewBll();

        ProductSet_New_titleBll psnbtitle = new ProductSet_New_titleBll();

        LTestLogMessageBll ltlmb = new LTestLogMessageBll();

        ConditionQueryBll cqb = new ConditionQueryBll();

        LOrderMessageBll lomb = new LOrderMessageBll();

        PCapacityConfigurationBll pcb=new PCapacityConfigurationBll();

        ProductionTypeBll ptb = new ProductionTypeBll();

        ProductionEfficiencySummaryBll pesb = new ProductionEfficiencySummaryBll();

        ProductionLinePC_titleBll productionLinePC_titleBll = new ProductionLinePC_titleBll();

        PWorkScheduleBll pwsb = new PWorkScheduleBll();

        ProductionLinePCBll plplb = new ProductionLinePCBll();
        //初始数据集

        Dictionary<string, List<ProductPerformance>> pplist = new Dictionary<string, List<ProductPerformance>>();
        //选择后产品类型数据集合
        List<ProductSet_New> pslist2 = new List<ProductSet_New>();
        //List<int> listHours = new List<int>();
        List<ProductionType> listpt2 = new List<ProductionType>();
        Dictionary<string, ProductSet_New_Model> listHours = new Dictionary<string, ProductSet_New_Model>();
        List<PWorkSchedule> pwslist2 = new List<PWorkSchedule>();

        List<ProductionEfficiencyModel> listDataSource = new List<ProductionEfficiencyModel>();
       // BindingList<ProductionEfficiencyModel> listDataSource = new BindingList<ProductionEfficiencyModel>();
        //订单号查询集合
        private List<productionOrder> polist = new List<productionOrder>();
        //机型查询集合
        private List<ProductionSoftModel> psmlist = new List<ProductionSoftModel>();
        //遍历工位表集合
        List<ProductionType> listpt = new List<ProductionType>();
        //订单总数
        int sumOrderNumber;        
        Dictionary<string, int> listNumber = new Dictionary<string, int>();

        //单号查询条件
        string OrderText = "";
        string OrderSoftModel = "";
        DateTime OrderBegin;
        DateTime OrderEnd;
        //机型查询条件
        string SoftModelText = "";
        string SoftModelOrder = "";
        DateTime SoftModelBegin;
        DateTime SoftModelEnd;
        //是否按时间查询
        bool Flag = false;
        //是否初始化时间空间
        bool FlagTime = false;

        System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();

        ////单列模式
        //public static productionEfficiency Instance(Gce g)
        //{
        //    if (_instance == null)
        //    {
        //        lock (_syncLock)
        //        {
        //            if (_instance == null)
        //            {
        //                _instance = new productionEfficiency(g);
        //            }
        //        }
        //    }
        //    return _instance;
        //}
        public productionEfficiency(Gce g)
        {
            InitializeComponent();
            //获取UI线程同步上下文
            m_SyncContext = SynchronizationContext.Current;
            this.gce = g;
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            if (!(UsersHelp.systemAdimin || UsersHelp.Production_efficiency_management_Parameter_setting))
            {
                MessageBox.Show("抱歉，您没有使用该功能的权限");
                return;
            }
            
            ParameterSettings ps = new ParameterSettings();
            ps.ShowDialog();
        }

        private void productionEfficiency_Load(object sender, EventArgs e)
        {
            if (!FlagTime)
            {
                //初始化控件
                setDateTime();
            }
            listpt = ptb.selectProductionTypeBll("selectProductionType");
            this.cb_Flag.Checked = true;
        }

        private void setDateTime()
        {
            DateTime dt = DateTime.Now;
            DateTime startTime = new DateTime(dt.Year, dt.Month, dt.Day, 00, 00, 00);
            DateTime endTime = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
            Dti_Begin.Value = startTime;
            Dti_End.Value = endTime;
        }
        /// <summary>
        /// 获得数据库中各个工位的工作数据
        /// </summary>
        /// <param name="strorder"></param>
        /// <param name="strSoftModel"></param>
        /// <param name="sqlcommand"></param>
        /// <param name="datetimebegin"></param>
        /// <param name="datetimeend"></param>
        private void Setpplist(string produType,string strorder, string strSoftModel, string sqlcommand, bool flag, DateTime datetimebegin, DateTime datetimeend)
        {
            //传入SQL命令，
            if (sqlcommand != "")
            {
                pplist.Add(produType,ppb.GetProductPerformanceBll(strorder, strSoftModel,flag, datetimebegin, datetimeend, sqlcommand));
            }
            else
            {
                List<ProductPerformance> list = new List<ProductPerformance>();
                list.Add(new ProductPerformance()
                {
                    Order="",
                    SoftModel="",
                    Time=DateTime.Now
                });
                pplist.Add(produType, list);
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
        private void selectMessageUI(string ProductType,string strorder, string strSoftModel, string sqlcommand, DateTime datetimebegin, DateTime datetimeend)
        {
            if (sqlcommand != "")
            {
                //传入SQL命令
                listNumber.Add(ProductType, ltlmb.selectLTestLogMessageBll(strorder, strSoftModel, datetimebegin, datetimeend, sqlcommand));
            }
            else
            {
                listNumber.Add(ProductType, 0);
            }
        }
        private ProductionEfficiencyModel GetProductPerformance(List<ProductPerformance> listppf1, List<ProductSet_New> pslist2, string Linename, string ProductionClass, ProductSet_New_Model Hours, int MessageNumber, string strorder, string strSoftModel, DateTime datetimebegin, DateTime datetimeend)
        {
            List<ProductPerformance> listppf2 = new List<ProductPerformance>();
            if (Linename != "" && Linename != "所有产线")
            { 
                List<ProductPerformance> newlistppf1 = new List<ProductPerformance>();
                List<string> strlist = plplb.selectProductionLinePCBll1(Linename, "selectProductionLinePC");
                foreach (ProductPerformance item in listppf1)
                {
                    if (strlist.Contains(plplb.getComputerName(item.Computer)))
                    {
                        newlistppf1.Add(item);
                    }
                }

                listppf2 = newlistppf1;
            }
            else
            {
                listppf2 = listppf1;
            }

            if (listppf2.Count > 0)
            {
                strSoftModel = listppf2[0].SoftModel;
            }
            ProductionEfficiencyModel list = new ProductionEfficiencyModel();
            //声明柱形图数据源集合
            List<string> listX = new List<string>();
            List<int> listY = new List<int>();
            //时间初始化，开始时间与上一张单据时间
            DateTime startTime = DateTime.Now;
            DateTime onTime = DateTime.Now;
            DateTime overTime = DateTime.Now;
            //总数和时间总数初始化
            int sum = 0;
            double sumHours = 0.0;
            //如果集合中有数据则获得第一张单据的时间,并且获得总数
            if (listppf2.Count > 0)
            {
                startTime = listppf2[0].Time;
                onTime = listppf2[0].Time;
                overTime = listppf2[listppf2.Count - 1].Time;
                sum = listppf2.Count;
            }
            else
            {
                sum = listppf1.Count;
            }
            //累计数量
            int Number = 0;
            //if (Hours != 0)//如果标准产能不为零则计算产能，如果为零则不计算
            //{
            foreach (ProductPerformance item in listppf2)
                {
                    Number++;


                    if (item.Time > onTime.AddMinutes(15d))
                    {

                        if (checkProductPerformanceNumber(startTime, onTime, Hours.EfficiencyQuantity, Number - 1))
                        {
                            //sum += Number - 1;
                            sumHours += GetsumHours(startTime, onTime);
                        }
                        listY.Add(Number - 1);
                        listX.Add(Convert.ToString(startTime) + "(" + Convert.ToString(this.GetMinutes(startTime, onTime)) + "分钟" + ")");

                        //sum += Number - 1;
                        startTime = item.Time;
                        Number = 0;
                    }
                    else
                    {
                        if (item.Time > startTime.AddHours(1d) || item.Time == overTime)
                        {

                            if (checkProductPerformanceNumber(startTime, onTime, Hours.EfficiencyQuantity, Number))
                            {
                                //sum += Number;
                                sumHours += GetsumHours(startTime, onTime);
                            }
                            listY.Add(Number);
                            listX.Add(Convert.ToString(startTime) + "(" + Convert.ToString(this.GetMinutes(startTime, onTime)) + "分钟" + ")");

                            //sum += Number - 1;
                            startTime = item.Time;
                            Number = 0;
                        }
                    }
                    onTime = item.Time;
                }

                if (Number != 0)
                {
                    if (checkProductPerformanceNumber(startTime, onTime, Hours.EfficiencyQuantity, Number))
                    {
                        //sum += Number;
                        sumHours += GetsumHours(startTime, onTime);
                    }
                    listY.Add(Number);
                    listX.Add(Convert.ToString(startTime) + "(" + Convert.ToString(this.GetMinutes(startTime, onTime)) + "分钟"  + ")");

                    //sum += Number;
                    Number = 0;
                }
            //}
            if (strorder != "")
            {
                sumOrderNumber = lomb.selectSumZhiDanNumberBll(strorder, "selectSumZhiDanNumber");
            }
            if (Hours.EfficiencyQuantity!=0)
            {
                if (listppf2.Count > 0)
                {
                    if (strSoftModel != "" && strorder == "")
                    {

                        list.ProductionClass = ProductionClass;
                        list.Order = strorder;
                        list.SoftModel = strSoftModel;
                        list.ProductClass = pslist2[0].ProductClass;
                        list.Hours =Convert.ToString(Hours.EfficiencyQuantity);
                        list.actualHours = Convert.ToString(GetactualHoursEfficiency(sumHours, sum));
                        list.PerCapitaProductivity = Convert.ToString(GetactualHoursEfficiency(sumHours, sum) / Convert.ToInt32(pslist2[0].TheNumberOf));
                        list.Ratio = getPercentage((double)GetactualHoursEfficiency(sumHours, sum) / Hours.EfficiencyQuantity);
                        list.TheNumberOf = Hours.TheNumberOf.ToString();
                        list.sumHours = Convert.ToString(Convert.ToDouble(sumHours.ToString("F2")));
                        list.sumWorkingHours = Convert.ToString(Convert.ToDouble(sumHours.ToString("F2")) * Convert.ToInt32(pslist2[0].TheNumberOf));
                        list.sum = Convert.ToString(sum);
                        list.FailureRate = getPercentage(GetFailureRate(sum, MessageNumber));
                        list.FailureNuber =Convert.ToString(MessageNumber);
                        list.StraightRate = getPercentage(1.00 - GetFailureRate(sum, MessageNumber));
                        list.sumOrder = Convert.ToString(sumOrderNumber);
                        list.OrderStartTime = listppf1[0].Time.ToString();
                        list.OrderOverTime = listppf1[listppf1.Count - 1].Time.ToString();
                        list.listX = listX;
                        list.listY = listY;

                        return list;
                    }
                    else
                    {
                        list.ProductionClass = ProductionClass;
                        list.Order = strorder;
                        list.SoftModel = strSoftModel;
                        list.ProductClass = pslist2[0].ProductClass;
                        list.TheNumberOf = Hours.TheNumberOf.ToString();
                        list.Hours = Convert.ToString(Hours.EfficiencyQuantity);
                        list.actualHours = Convert.ToString(GetactualHoursEfficiency(sumHours, sum));
                        list.PerCapitaProductivity = Convert.ToString(GetactualHoursEfficiency(sumHours, sum) / Convert.ToInt32(pslist2[0].TheNumberOf));
                        list.Ratio = getPercentage((double)GetactualHoursEfficiency(sumHours, sum) / Hours.EfficiencyQuantity);
                        list.sumHours =  Convert.ToString(Convert.ToDouble(sumHours.ToString("F2")));
                        list.sumWorkingHours = Convert.ToString(Convert.ToDouble(sumHours.ToString("F2")) * Convert.ToInt32(pslist2[0].TheNumberOf));
                        list.sum = Convert.ToString(sum);
                        list.FailureRate = getPercentage(GetFailureRate(sum, MessageNumber));
                        list.FailureNuber = Convert.ToString(MessageNumber);
                        list.StraightRate = getPercentage(1.00 - GetFailureRate(sum, MessageNumber));
                        list.sumOrder = Convert.ToString(sumOrderNumber);
                        list.OrderStartTime = listppf1[0].Time.ToString();
                        list.OrderOverTime = listppf1[listppf1.Count - 1].Time.ToString();
                        list.listX = listX;
                        list.listY = listY;
                        return list;
                    }
                }
                else
                {
                    if (Linename != "" && Linename != "所有产线")
                    {
                        list.ProductionClass = "delete";
                    }
                    else
                    {
                        list.ProductionClass = ProductionClass;
                        list.Order = strorder;
                        list.ProductClass = pslist2[0].ProductClass;
                        list.SoftModel = strSoftModel;
                        list.Hours = Convert.ToString(Hours.EfficiencyQuantity);
                        list.sumOrder = Convert.ToString(sumOrderNumber);
                    }
                    return list;
                }
            }
            else
            {
                if (listppf2.Count > 0)
                {
                    list.ProductionClass = ProductionClass;
                    list.Order = strorder;
                    list.ProductClass = "未配置";
                    list.actualHours = Convert.ToString(GetactualHoursEfficiency(sumHours, sum));
                    list.sumHours = Convert.ToString(Convert.ToDouble(sumHours.ToString("F2")));
                    list.sum = Convert.ToString(sum);
                    list.SoftModel = strSoftModel;
                    list.sumOrder = Convert.ToString(sumOrderNumber);
                    list.FailureRate = getPercentage(GetFailureRate(sum, MessageNumber));
                    list.FailureNuber = Convert.ToString(MessageNumber);
                    list.StraightRate = getPercentage(1.00 - GetFailureRate(sum, MessageNumber));
                    list.OrderStartTime = listppf1[0].Time.ToString();
                    list.OrderOverTime = listppf1[listppf1.Count - 1].Time.ToString();
                    list.listX = listX;
                    list.listY = listY;
                    return list;
                }
                else
                {

                    list.ProductionClass = "delete";
                    return list;
                }
            }
        }
        private void GetProductPerformanceUI(List<ProductSet_New> pslist2,string CompanyName, string strorder, string strSoftModel,string Linename, bool flag, DateTime datetimebegin, DateTime datetimeend, List<ProductionType> listpt2)
        {
            List<ProductionEfficiencyModel> list = new List<ProductionEfficiencyModel>();
            List<Thread> listThC = new List<Thread>();
            try
            {
                polist = cqb.selectOrder1Bll("selectzOrder1", CompanyName, datetimebegin, datetimeend);
                if (strorder == "" && strSoftModel == "")
                {
                    for (int j = 0; j < polist.Count; j++)
                    {
                        pplist.Clear();
                        listNumber.Clear();//失败数集合清理
                        listThC.Clear();
                        pslist2.Clear();
                        listHours.Clear();
                        strorder = polist[j].Order;
                        pslist2 = psnb.selectProductClassBll(pcb.selectPCapacityConfigurationProductClassBll(strorder, "selectPCapacityConfigurationProductClass"), "selectProductSet_NewClass");//获取每个订单的标准产能

                        foreach (ProductionType item in listpt2)
                        {
                            int ints = 0;
                            foreach (ProductSet_New item1 in pslist2)
                            {
                                if (item1.Stations == item.ProductType)
                                {
                                    ints += 1;
                                    ProductSet_New_Model psnm = new ProductSet_New_Model()
                                    {
                                        EfficiencyQuantity = Convert.ToInt32(item1.EfficiencyQuantity),
                                        TheNumberOf = Convert.ToInt32(item1.TheNumberOf)
                                    };
                                    listHours.Add(item.ProductType, psnm);
                                }
                            }
                            if (ints == 0)
                            {
                                listHours.Add(item.ProductType, new ProductSet_New_Model() {EfficiencyQuantity=0,TheNumberOf=0 });
                            }
                        }

                        if (strorder != "" && strorder != null)
                        {
                            for (int i = 0; i < listpt2.Count; i++)
                            {
                                var a = i;
                                Setpplist(listpt2[i].ProductType,strorder, strSoftModel, listpt2[a].Command, flag, datetimebegin, datetimeend);

                                selectMessageUI( listpt2[i].ProductType,strorder, strSoftModel, listpt2[a].Command1, datetimebegin, datetimeend);
                            }
                            int checki = 0;//标记如果所有工位无效，则不用添加间隔行
                            foreach (ProductionType item in listpt2)
                            {                                
                                list.Add(this.GetProductPerformance(pplist[item.ProductType], pslist2, Linename, item.ProductType, listHours[item.ProductType], listNumber[item.ProductType], strorder, strSoftModel, datetimebegin, datetimeend));
                                if (list[list.Count - 1].ProductionClass == "delete")
                                {
                                    list.Remove(list[list.Count - 1]);
                                    checki += 1;
                                }
                            }
                            if (listpt2.Count > checki)
                            {
                                list.Add(new ProductionEfficiencyModel() { ProductionClass = "" });
                            }
                        }
                    }
                }
                else
                {
                    listNumber.Clear();//失败数集合清理
                    listHours.Clear();
                    pplist.Clear();
                    listTh.Clear();
                    pslist2.Clear();

                    pslist2 = psnb.selectProductClassBll(pcb.selectPCapacityConfigurationProductClassBll(strorder, "selectPCapacityConfigurationProductClass"), "selectProductSet_NewClass");//获取每个订单的标准产能

                    foreach (ProductionType item in listpt2)
                    {
                        int ints = 0;
                        foreach (ProductSet_New item1 in pslist2)
                        {
                            if (item1.Stations == item.ProductType)
                            {
                                ints += 1;
                                ProductSet_New_Model psnm = new ProductSet_New_Model()
                                {
                                    EfficiencyQuantity = Convert.ToInt32(item1.EfficiencyQuantity),
                                    TheNumberOf = Convert.ToInt32(item1.TheNumberOf)
                                };
                                listHours.Add(item.ProductType, psnm);
                            }
                        }
                        if (ints == 0)
                        {
                            listHours.Add(item.ProductType, new ProductSet_New_Model() {EfficiencyQuantity = 0,TheNumberOf = 0 });
                        }
                    }

                    for (int i = 0; i < listpt2.Count; i++)
                    {
                        var a = i;
                        Setpplist(listpt2[i].ProductType,strorder, strSoftModel, listpt2[a].Command, flag, datetimebegin, datetimeend);

                        selectMessageUI(listpt2[i].ProductType,strorder, strSoftModel, listpt2[a].Command1, datetimebegin, datetimeend);

                    }

                    foreach (ProductionType item in listpt2)
                    {
                        list.Add(this.GetProductPerformance(pplist[item.ProductType], pslist2, Linename, item.ProductType, listHours[item.ProductType], listNumber[item.ProductType], strorder, strSoftModel, datetimebegin, datetimeend));
                        if (list[list.Count - 1].ProductionClass == "delete")
                        {
                            list.Remove(list[list.Count - 1]);
                        }
                    }
                    
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                //上下文UI线程更新方法
                //SetListSafePost更新UI方法
                //SetListSafePost的list集合参数
                m_SyncContext.Post(SetListSafePost, list);
                if (strorder != "")
                {
                    TableTransferTh = new Thread(delegate()
                    {
                        TableTransfer(strorder, sumOrderNumber, list);
                    });
                    TableTransferTh.IsBackground = true;
                    TableTransferTh.Start();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void TableTransfer(string strorder, int sumordernumber, List<ProductionEfficiencyModel> list)
        {
            if (sumordernumber <= 0)
            {
                return;
            }
            if (cqb.selectSumCartonBoxTwentyNumberBll(strorder, "selectSumCartonBoxTwentyNumber") >= sumordernumber)
            {
                List<ProductionEfficiencyModel> list1 = new List<ProductionEfficiencyModel>();
                foreach (ProductionEfficiencyModel item in list)
                {
                    if (item.sumHours != "0.00")
                    {
                        list1.Add(item);
                        pesb.InsertProductionEfficiencySummaryBll(list1, "InsertProductionEfficiencySummary");
                    }
                }
            }
        }
        /// <summary>
        /// 判断是否符合最低产量值
        /// </summary>
        /// <param name="startime">开始时间</param>
        /// <param name="endtime">结束时间</param>
        /// <param name="AssemblyHours">最低产量</param>
        /// <param name="i">当前产量</param>
        /// <returns>bool</returns>
        private bool checkProductPerformanceNumber(DateTime startime, DateTime endtime, int AssemblyHours,int i)
        {
            TimeSpan ts = endtime - startime;
            double nub = ts.TotalHours;
            if (nub == 0)
            {
                return false;
            }
            if (i != 0)
            {
                if (i > AssemblyHours * nub / 5)//如果不低于20%就认为符合
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }

        }
        /// <summary>
        /// 实际生产效能/小时
        /// </summary>
        /// <param name="Hours">总小时数</param>
        /// <param name="sum">产品总数</param>
        /// <returns></returns>
        private int GetactualHoursEfficiency(double Hours,int sum)
        {
            if (sum == 0)
            {
                return 0;
            }
            if (Hours == 0)
            { 
                return 0;
            }
            return Convert.ToInt32(sum / Hours);
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
            return  ts.TotalHours;
        }
        /// <summary>
        /// 获取分钟
        /// </summary>
        /// <param name="starTime">时间段开始时间</param>
        /// <param name="endTime">时间段结束</param>
        /// <returns>double</returns>
        private int GetMinutes(DateTime starTime, DateTime endTime)
        {
            TimeSpan ts = endTime - starTime;
            return Convert.ToInt32(ts.TotalMinutes);
        }
        /// <summary>
        /// 获得失败率
        /// </summary>
        /// <param name="sum">生产总数</param>
        /// <returns></returns>
        private double GetFailureRate(int sum, int MessageNuber)
        {
           double dsum = Convert.ToDouble(sum);
            double db;
            if (MessageNuber > 0 && dsum > 0)
            {
                db = Convert.ToDouble(Convert.ToDouble(MessageNuber / dsum).ToString("F2"));
                return db;
            }
            else
            {
                return 0.00;
            }
            
        }

        private void SetListSafePost(object olist)
        {
            listDataSource = olist as List<ProductionEfficiencyModel>;
            Dgv_Production.DataSource = listDataSource;
            //datagridviewCull();
            gce.Setlb_QueryState("完成");
            Dgv_Production.Refresh();//刷新控件
            th1 = new Thread(Killthread1);
            th1.IsBackground = true;
            th1.Start();
        }
        private void Killthread1()
        {
            if (listTh.Count > 0)
            {
                for (int i = 0; i < listTh.Count; i++)
                {
                    listTh[i].Abort();
                }
            }
        }
        private void btn_Query_Click(object sender, EventArgs e)
        {
            this.Query_click();
        }

        public void Query_click()
        {
            bar1.Focus();
            if (Dti_Begin.Value == null)
            {
                MessageBox.Show("开始日期不能为空！");
                return;
            }
            if (Dti_End.Value == null)
            {
                MessageBox.Show("结束日期不能为空!");
                return;
            }
            gce.Setlb_QueryState("正在查询...");
            if (th != null)
            {
                th.Abort();
            }

            if (txt_OnWorkClass.Text.Trim() != "")
            {
                List<ProductionType> newlistpt = new List<ProductionType>();
                foreach (ProductionType item in listpt)
                {
                    if (item.OnWorkTimeTypeNight == "")
                    {
                        if (item.OnWorkTimeType.Trim() == txt_OnWorkClass.Text.Trim())
                        {
                            newlistpt.Add(item);
                        }
                    }
                    else
                    {
                        if (item.OnWorkTimeTypeNight.Trim() == txt_OnWorkClass.Text.Trim())
                        {
                            newlistpt.Add(item);
                        }
                    }
                }
                listpt2 = newlistpt;
            }
            else
            {
                listpt2 = listpt;
            }

            try
            {
                //txt_Order.Text.Trim(), Dti_Begin.Value, Dti_End.Value, object strorder, object datetimebegin, object datetimeend
                //线程UI变量
                string strOrder = this.txt_Order.Text.Trim();
                string strSoftModel = this.txt_SoftModel.Text.Trim();
                string LineName = comb_LineName.Text.Trim();
                string CompanyName = txt_OnWorkClass.Text.Trim();
                DateTime dateTimeBegin = this.Dti_Begin.Value;
                DateTime dateTimeEnd = this.Dti_End.Value;
                List<ProductSet_New> pslistx2 = pslist2;
                //  匿名委托线程传参
                th = new Thread(delegate()
                {
                    GetProductPerformanceUI(pslistx2, CompanyName, strOrder, strSoftModel, LineName, this.Flag, dateTimeBegin, dateTimeEnd, listpt2);
                });
                th.IsBackground = true;
                th.Start();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private string getPercentage(double db)
        {
            string str;
            db = db * 100;
            str = db.ToString("F2");
            return str + "%";
        }
        public void setTxt_Order(string order)
        {
            this.txt_Order.Text = order;
            this.txt_productClass.Text = pcb.selectPCapacityConfigurationProductClassBll(txt_Order.Text.Trim(), "selectPCapacityConfigurationProductClass");
        }
        public void setTxt_SoftModel(string SoftModel)
        {
            this.txt_SoftModel.Text = SoftModel;
        }
        private void txt_Order_ButtonCustomClick(object sender, EventArgs e)
        {
            if (Dti_Begin.Value == null)
            { 
                MessageBox.Show("开始时间不能为空！");
                return;
            }
            if (Dti_End.Value == null)
            {
                MessageBox.Show("结束时间不能为空！");
                return;
            }
            List<string> strlist = new List<string>();
            strlist.Add("订单号");
            //如果查询条件没改变则不重新再数据库查询数据
            if (OrderText == txt_Order.Text.Trim() && OrderBegin == Dti_Begin.Value && OrderEnd == Dti_End.Value&&polist.Count>0&&OrderSoftModel==txt_SoftModel.Text.Trim())
            {
                ConditionsQuery cq = new ConditionsQuery("订单号查询", strlist, polist, this);
                cq.ShowDialog();
            }
            else
            {
                OrderText = txt_Order.Text.Trim();
                OrderSoftModel = txt_SoftModel.Text.Trim();
                OrderBegin = Dti_Begin.Value;
                OrderEnd = Dti_End.Value;
                try
                {
                    polist = cqb.selectOrderBll("selectzOrderAndSoftModel", txt_Order.Text.Trim(), txt_SoftModel.Text.Trim(), Dti_Begin.Value, Dti_End.Value);
                    ConditionsQuery cq = new ConditionsQuery("订单号查询", strlist, polist, this);
                    cq.ShowDialog();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        //杀死线程
        private void KillThread()
        { 
            //关闭线程
            if (th != null)
            {
                th.Abort();
            }
            if (th1 != null)
            {
                th1.Abort();
            }
            if (listTh.Count > 0)
            {
                for (int i = 0; i < listTh.Count; i++)
                {
                    listTh[i].Abort();
                }
            }
        }
        private void productionEfficiency_FormClosed(object sender, FormClosedEventArgs e)
        {
            KillThread();
            gce.lb_QueryStateVisible();
        }
        /// <summary>
        /// 点击控件选择，设置为选择一整行数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_Production_SelectionChanged(object sender, EventArgs e)
        {
            this.Dgv_Production.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        /// <summary>
        /// 右键点击详情按钮时，弹出相对应的柱形图窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 详情ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //当有任何行时
            if (this.Dgv_Production.CurrentRow != null&&listDataSource.Count>0)
            {
                if (this.Dgv_Production.Rows[this.Dgv_Production.CurrentRow.Index].Cells["ProductionClass"].Value.ToString() != "")
                {
                    if (listDataSource[this.Dgv_Production.CurrentRow.Index].listX != null && listDataSource[this.Dgv_Production.CurrentRow.Index].listY != null)
                    {
                        CapacityDetails cd = new CapacityDetails(this.Dgv_Production.Rows[this.Dgv_Production.CurrentRow.Index].Cells["ProductionClass"].Value.ToString(), listDataSource[this.Dgv_Production.CurrentRow.Index].listX, listDataSource[this.Dgv_Production.CurrentRow.Index].listY);
                        cd.ShowDialog();
                    }
                }              
            }
        }

        private void btn_outData_Click(object sender, EventArgs e)
        {
            if (!(UsersHelp.systemAdimin || UsersHelp.Production_efficiency_management_DataOut))
            {
                MessageBox.Show("抱歉，您没有使用该功能的权限");
                return;
            }
            
            if (this.Dgv_Production.CurrentRow == null)
            {
                MessageBox.Show("没有可导出的数据!");
                return;
            }

            DataOutForm dof = new DataOutForm(txt_OnWorkClass.Text.Trim(), this);
            dof.ShowDialog();

        }

        public void DataOut(string OnWorkClass, int Number_Min, bool BlankLine)
        {
            if (ExcelHelperForCs.ExportToExcelproductionEfficiency(Dgv_Production, OnWorkClass, Number_Min, BlankLine) != null)
            {
                MessageBox.Show("导出完成");
            }
        }
        private void productionEfficiency_FormClosing(object sender, FormClosingEventArgs e)
        {
            gce.lb_QueryStateVisible();
            formDepot.productionEfficiency = this;
        }

        private void txt_SoftModel_ButtonCustomClick(object sender, EventArgs e)
        {
            try
            {
                List<string> strlist = new List<string>();
                strlist.Add("机型");
                if (SoftModelText == txt_SoftModel.Text.Trim() && SoftModelOrder == txt_Order.Text.Trim() && SoftModelBegin == Dti_Begin.Value && SoftModelEnd == Dti_Begin.Value)
                {
                    ConditionsQuery cq = new ConditionsQuery("机型查询", strlist, psmlist, this);
                    cq.ShowDialog();
                }
                else
                {
                    SoftModelText = txt_SoftModel.Text.Trim();
                    SoftModelOrder = txt_Order.Text.Trim();
                    SoftModelBegin = Dti_Begin.Value;
                    SoftModelEnd = Dti_Begin.Value;
                    psmlist = cqb.selectSoftModelBll("selectSoftModel", this.txt_SoftModel.Text.Trim(), txt_Order.Text.Trim(), Dti_Begin.Value, Dti_End.Value);
                    ConditionsQuery cq = new ConditionsQuery("机型查询", strlist, psmlist, this);
                    cq.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_call_Click(object sender, EventArgs e)
        {
            if (!(UsersHelp.systemAdimin || UsersHelp.Production_efficiency_management_Parameter_call))
            {
                MessageBox.Show("抱歉，您没有使用该功能的权限");
                return;
            }
            
            ParametersCall pc = new ParametersCall();
            pc.ShowDialog();
        }

        private void txt_Order_Leave(object sender, EventArgs e)
        {
            if (txt_Order.Text == "")
            {
                return;
            }
           this.txt_productClass.Text = pcb.selectPCapacityConfigurationProductClassBll(txt_Order.Text.Trim(), "selectPCapacityConfigurationProductClass");
           pslist2 = psnb.selectProductClassBll(txt_productClass.Text.Trim(), "selectProductSet_NewClass");//获取每个订单的标准产能
        }

        private void 失败产品详情ToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            //当有任何行时
            if (this.Dgv_Production.CurrentRow != null && listDataSource.Count > 0)
            {
                if (Convert.ToInt32(listDataSource[this.Dgv_Production.CurrentRow.Index].FailureNuber) == 0)
                {
                    MessageBox.Show("此行找不到失败产品记录！");
                    return;
                }
                if (this.Dgv_Production.Rows[this.Dgv_Production.CurrentRow.Index].Cells["ProductionClass"].Value.ToString() != "")
                {
                    BadMachineFrm bmf = new BadMachineFrm(listDataSource[this.Dgv_Production.CurrentRow.Index].ProductionClass,listDataSource[this.Dgv_Production.CurrentRow.Index].Order,listpt,Dti_Begin.Value,Dti_End.Value);
                    bmf.ShowDialog();
                }
            }
        }

        private void Dgv_Production_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(this.Dgv_Production.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, CultureInfo.CurrentUICulture),
                e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            }
        }

        private void txt_SoftModel_Leave(object sender, EventArgs e)
        {
            if (txt_SoftModel.Text == "")
            {
                return;
            }
            pslist2 = psnb.selectProductClassBll(psnbtitle.selectProductSet_New_titleTop1Bll("selectProductSet_New_titleTop1"), "selectProductSet_NewClass");

        }

        private void 按计算机名分析人员工作情况ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Dgv_Production.CurrentRow != null && listDataSource.Count > 0)
            {
                if (this.Dgv_Production.Rows[this.Dgv_Production.CurrentRow.Index].Cells["ProductionClass"].Value.ToString() != ""&&this.Dgv_Production.Rows[this.Dgv_Production.CurrentRow.Index].Cells["Order"].Value.ToString() != "")
                {
                    int i = -1;
                    foreach (ProductionType item in listpt2)
                    {
                        if (item.ProductType == this.Dgv_Production.Rows[this.Dgv_Production.CurrentRow.Index].Cells["ProductionClass"].Value.ToString())
                        {
                            i = listpt2.IndexOf(item);
                        }
                    }
                    if (i >= 0)
                    {
                        ComputerTest ct = new ComputerTest(this.Dgv_Production.Rows[this.Dgv_Production.CurrentRow.Index].Cells["ProductionClass"].Value.ToString(), listpt[i].Command, listpt[i].Command2, this.Dgv_Production.Rows[this.Dgv_Production.CurrentRow.Index].Cells["Order"].Value.ToString(),this.Flag,comb_LineName.Text.Trim(), Dti_Begin.Value, Dti_End.Value);
                        ct.ShowDialog();
                    }                    
                }
            }
        }

        private void txt_Order_TextChanged(object sender, EventArgs e)
        {
            if (txt_Order.Text == "")
            {
                cb_Flag.Checked = true;
                cb_Flag.Enabled = false;
                cb_All.Enabled = true;
            }
            else
            {
                cb_Flag.Checked = false;
                cb_Flag.Enabled = true;
                cb_All.Enabled = false;
            }
        }

        private void cb_Flag_CheckedChanged(object sender, EventArgs e)
        {
            this.cb_All.Checked = !cb_Flag.Checked;
            this.Flag = !cb_Flag.Checked;
        }

        private void cb_All_CheckedChanged(object sender, EventArgs e)
        {
            this.cb_Flag.Checked = !this.cb_All.Checked;
        }

        public void JumpSetDatetime(DateTime BeginTime,DateTime EndTime1)
        {
            FlagTime = true;
            this.Dti_Begin.Value = BeginTime;
            this.Dti_End.Value = EndTime1;

            this.buttonX1.PerformClick();
        }

        private void radialMenu1_ItemClick(object sender, EventArgs e)
        {
            if (listDataSource.Count <= 0)
            {
                return;
            }
            RadialMenuItem item = sender as RadialMenuItem;
            //MessageBox.Show(string.Format("我是 {0} ", item.Text));
            if (item == null)
            {
                return;
            }
            switch (item.Text)
            { 
                case "显示全部":
                    this.radialMI_All_Click();
                    break;
                case "显示未达标":
                    this.radialMI_NotStandard_Click();
                    break;
                case "显示达标":
                    this.radialMI_Standard_Click();
                    break;
                case "订单未配置":
                    this.radialMI_OrderNotConfigured_Click();
                    break;
                case "直通率筛选":
                    this.radialMI_StraightRate_Click();
                    break;
            }
        }
        //显示全部
        void radialMI_All_Click()
        {
            this.Dgv_Production.DataSource = new List<ProductionEfficiencyModel>();
            this.Dgv_Production.DataSource = listDataSource;
            Dgv_Production.Refresh();//刷新控件
        }
        //显示未达标
        void radialMI_NotStandard_Click()
        {
            Production_Screen ps = new Production_Screen("达标率（包含）","%",this,1);
            ps.ShowDialog();
        }
        //显示达标 
        void radialMI_Standard_Click()
        {
            Production_Screen ps = new Production_Screen("达标率（包含）","%",this,2);
            ps.ShowDialog();
        }
        /// <summary>
        /// 订单未配置
        /// </summary>
        void radialMI_OrderNotConfigured_Click()
        {
            List<ProductionEfficiencyModel> list = new List<ProductionEfficiencyModel>();
            foreach (ProductionEfficiencyModel item in listDataSource)
            {
                if (item.Order != null)
                {
                    if (item.ProductClass == "未配置")
                    {
                        list.Add(item);
                    }
                }
                else
                {
                    if (list.Count > 0)
                    {
                        if (list[list.Count - 1].Order != null)
                        {
                            list.Add(item);
                        }
                    }
                }
            }

            Dgv_Production.DataSource = new List<ProductionEfficiencyModel>();
            Dgv_Production.DataSource = list;
        }
        /// <summary>
        /// 直通率筛选
        /// </summary>
        void radialMI_StraightRate_Click()
        {
            Production_Screen ps = new Production_Screen("直通率","",this,3);
            ps.ShowDialog();
        }

        double GetRatioDouble(string ratio)
        {
            if (ratio == "" || ratio == null)
            {
                return -1;
            }
            return Convert.ToDouble(ratio.Replace("%", " ").Trim());
        }

        private void comb_LineName_DropDown(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            list = productionLinePC_titleBll.selectProductionLinePC_titleLineNameBll(txt_OnWorkClass.Text.Trim(), "selectProductionLinePC_titleLineName");

            list.Insert(0, "所有产线");
            comb_LineName.DataSource = list;
        }

        private void txt_OnWorkClass_ButtonCustomClick(object sender, EventArgs e)
        {
            List<PWorkSchedule> listPWorkSchedule = new List<PWorkSchedule>();
            List<string> list = new List<string>();
            list.Add("公司上下班时间类型");
            list.Add("1");
            list.Add("2");
            list.Add("3");
            list.Add("4");
            list.Add("5");
            list.Add("6");

            listPWorkSchedule = pwsb.selectPWorkScheduleBll("selectPWorkSchedule");
            ConditionsQuery cq = new ConditionsQuery("公司上下班时间类型查询", list, listPWorkSchedule, this);
            cq.ShowDialog();
        }

        public void SetTextbox_CompanyName(string CompanyName, List<PWorkSchedule> pwslist)
        {
            txt_OnWorkClass.Text = CompanyName;
            this.pwslist2 = pwslist;
        }

        private void txt_OnWorkClass_Leave(object sender, EventArgs e)
        {
            if (txt_OnWorkClass.Text != "")
            {
                comb_LineName.Text = "所有产线";
            }

        }

        public void radialMI_Standard_Click_1(string str,int i,bool bl)
        {
            switch (i)
            {
                case 1:
                    List<ProductionEfficiencyModel> list = new List<ProductionEfficiencyModel>();
                    foreach (ProductionEfficiencyModel item in listDataSource)
                    {
                        if (item.Order != null)
                        {
                            if (GetRatioDouble(item.Ratio) < Convert.ToDouble(str) && item.Ratio != null)
                            {
                                list.Add(item);
                            }
                        }
                        else
                        {
                            if (list.Count > 0)
                            {
                                if (list[list.Count - 1].Order != null)
                                {
                                    list.Add(item);
                                }
                            }
                        }
                    }

                    Dgv_Production.DataSource = new List<ProductionEfficiencyModel>();
                    Dgv_Production.DataSource = list;
                    break;
                case 2:
                    List<ProductionEfficiencyModel> list1 = new List<ProductionEfficiencyModel>();
                    foreach (ProductionEfficiencyModel item in listDataSource)
                    {
                        if (item.Order != null)
                        {
                            if (GetRatioDouble(item.Ratio) >= Convert.ToDouble(str))
                            {
                                list1.Add(item);
                            }
                        }
                        else
                        {
                            if (list1.Count > 0)
                            {
                                if (list1[list1.Count - 1].Order != null)
                                {
                                    list1.Add(item);
                                }
                            }
                        }
                    }

                    Dgv_Production.DataSource = new List<ProductionEfficiencyModel>();
                    Dgv_Production.DataSource = list1;
                    break;
                case 3:
                    List<ProductionEfficiencyModel> list2 = new List<ProductionEfficiencyModel>();
                    foreach (ProductionEfficiencyModel item in listDataSource)
                    {
                        if (item.Order != null)
                        {
                            if (bl)
                            {
                                if (GetRatioDouble(item.StraightRate) >= Convert.ToDouble(str))
                                {
                                    list2.Add(item);
                                }
                            }
                            else
                            {
                                if (GetRatioDouble(item.StraightRate) <= Convert.ToDouble(str))
                                {
                                    list2.Add(item);
                                }
                            }
                        }
                        else
                        {
                            if (list2.Count > 0)
                            {
                                if (list2[list2.Count - 1].Order != null)
                                {
                                    list2.Add(item);
                                }
                            }
                        }
                    }

                    Dgv_Production.DataSource = new List<ProductionEfficiencyModel>();
                    Dgv_Production.DataSource = list2;
                    break;
            }
        }

        private void btni_TimedRefresh_Click(object sender, EventArgs e)
        {
            this.TimedRefresh_Click1();
        }

        void TimedRefresh_Click1()
        {
            if (btni_TimedRefresh.Text == "结束定数刷新")
            {
                this.timer1Stop();
            }
            else
            {
                TimedRefreshCondition trc = new TimedRefreshCondition("生产效能定时", this);
                trc.ShowDialog();
            }
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

            lab_Message.Text = "定时刷新开始，" + "每" + (i/60000).ToString() + "分钟刷新一次";

            btni_TimedRefresh.Text = "结束定数刷新";
        }

        void timer1Stop()
        {
            timer1.Enabled = false;
            lab_Message.Text = "";
            btni_TimedRefresh.Text = "开始定数刷新";
        }
        /// <summary>
        /// 定时器事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timer1_Tick(object sender, EventArgs e)
        {
            Dti_End.Value = DateTime.Now;
            this.Query_click();
        }
    }
}
