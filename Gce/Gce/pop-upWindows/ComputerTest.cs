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
using Bll;
using Model;
using System.Globalization;
using Gce_Bll;

namespace Gce.pop_upWindows
{
    public partial class ComputerTest : Office2007Form
    {
        ProductPerformanceBll ppb = new ProductPerformanceBll();
        LTestLogMessageBll ltlmb = new LTestLogMessageBll();
        ProductionLinePCBll plplb = new ProductionLinePCBll();

        private List<ProductPerformance> listppf = new List<ProductPerformance>();//订单数据集合
        private List<BadMachineFrmModel> listbmfm = new List<BadMachineFrmModel>();//坏机数据集合
        private List<string> listComputer = new List<string>();//计算机名集合，遍历所有订单数据集合中的计算机名，取不重复名称，这代表有多少台计算机在为这张单据工作
        private List<ComputerTestModel> listDataSours = new List<Gce_Model.ComputerTestModel>();//datagridview数据源集合

        private string productionType;
        private string Command;
        private string Command1;
        private string Order;
        private string Linename;
        private bool Flag;
        private DateTime BeginTime;
        private DateTime EndTime;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="protype">工位名</param>
        /// <param name="command">订单数据查询SQL命令</param>
        /// <param name="command1">坏机数据查询SQL命令</param>
        /// <param name="order">订单号</param>
        /// <param name="begintime">开始时间</param>
        /// <param name="endtime">结束时间</param>
        public ComputerTest(string protype, string command, string command1, string order, bool flag,string linename, DateTime begintime, DateTime endtime)
        {
            this.productionType = protype;
            this.Command = command;
            this.Command1 = command1;
            this.Order = order;
            this.Linename = linename;
            this.Flag = flag;
            this.BeginTime = begintime;
            this.EndTime = endtime;
            InitializeComponent();
        }
        private void CreatDatagridvie()
        {
                DataGridViewTextBoxColumn newcol = new DataGridViewTextBoxColumn();
                newcol.HeaderText = "工位名";
                newcol.Name = "productionType"; newcol.DataPropertyName = "productionType";
                //newcol.DividerWidth = 50;
                newcol.Tag = 0;
                dataGridViewX1.Columns.Insert(0, newcol);

                DataGridViewTextBoxColumn newcol2 = new DataGridViewTextBoxColumn();
                newcol2.HeaderText = "计算机名";
                newcol2.Name = "ComputerName"; newcol2.DataPropertyName = "ComputerName";
                newcol2.Width = 120;
                newcol2.Tag = 1;
                dataGridViewX1.Columns.Insert(1, newcol2);

                DataGridViewTextBoxColumn newcol3 = new DataGridViewTextBoxColumn();
                newcol3.HeaderText = "成功测试数";
                newcol3.Name = "Sum"; newcol3.DataPropertyName = "Sum";
                //newcol3.DividerWidth = 50;
                newcol3.Tag = 2;
                dataGridViewX1.Columns.Insert(2, newcol3);

                DataGridViewTextBoxColumn newcol4 = new DataGridViewTextBoxColumn();
                newcol4.HeaderText = "错误记录";
                newcol4.Name = "MessageNumber"; newcol4.DataPropertyName = "MessageNumber";
                //newcol4.DividerWidth = 50;
                newcol4.Tag = 3;
                dataGridViewX1.Columns.Insert(3, newcol4);

                DataGridViewTextBoxColumn newcol5 = new DataGridViewTextBoxColumn();
                newcol5.HeaderText = "开始时间";
                newcol5.Name = "StartTime"; newcol5.DataPropertyName = "StartTime";
                newcol5.Width = 120;
                newcol5.Tag = 4;
                dataGridViewX1.Columns.Insert(4, newcol5);

                DataGridViewTextBoxColumn newcol6 = new DataGridViewTextBoxColumn();
                newcol6.HeaderText = "结束时间";
                newcol6.Name = "OnTime"; newcol6.DataPropertyName = "OnTime";
                newcol6.Width = 120;
                newcol6.Tag = 5;
                dataGridViewX1.Columns.Insert(5, newcol6);

                DataGridViewTextBoxColumn newcol7 = new DataGridViewTextBoxColumn();
                newcol7.HeaderText = "合计时(分钟)";
                newcol7.Name = "sumTime"; newcol7.DataPropertyName = "sumTime";
                newcol7.Tag = 6;
                dataGridViewX1.Columns.Insert(6, newcol7);

                DataGridViewTextBoxColumn newcol8 = new DataGridViewTextBoxColumn();
                newcol8.HeaderText = "";
                newcol8.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                newcol8.Tag = 7;
                dataGridViewX1.Columns.Insert(7, newcol8);
        }
        private void ComputerTest_Load(object sender, EventArgs e)
        {            
            txt_Order.Text = Order;
            CreatDatagridvie();
            Load1();
            Load2();
            Load3();
        }
        private void Load1()
        {
            if (Command != "")
            {
                this.listppf = ppb.GetProductPerformanceBll(Order, "",this.Flag, BeginTime, EndTime, Command);
            }
            if (Linename != "" && Linename != "所有产线")
            {
                List<ProductPerformance> newlistppf1 = new List<ProductPerformance>();
                List<string> strlist = plplb.selectProductionLinePCBll1(Linename, "selectProductionLinePC");

                foreach (ProductPerformance item in listppf)
                {
                    if (strlist.Contains(plplb.getComputerName(item.Computer)))
                    {
                        newlistppf1.Add(item);
                    }
                }
                listppf = newlistppf1;
            }
            if (listppf.Count > 0)
            {
                txt_OrderNumber.Text = Convert.ToString(listppf.Count);
            }
            if (Command1 != "")
            {
                listbmfm = ltlmb.selectMessageBll(Order, BeginTime, EndTime, Command1);
            }
            foreach (ProductPerformance item in listppf)
            {
                if (!listComputer.Contains(item.Computer))//如果集合已存在该名称，则不添加，反之则添加
                {
                    listComputer.Add(item.Computer);
                }
            }
        }

        private void Load2()
        {
            List<ProductPerformance> list = new List<ProductPerformance>();

            DateTime startTime = DateTime.Now;
            DateTime onTime = DateTime.Now;

            if (listppf.Count > 0)
            {
                startTime = listppf[0].Time;
                onTime = listppf[0].Time;
            }
            foreach (ProductPerformance item in listppf)
            {
                list.Add(item);

                if (item.Time > onTime.AddMinutes(15D))
                {
                    this.SetDataSource(list, startTime, onTime);

                    startTime = item.Time;
                    list.Clear();
                }
                else
                {
                    if (item.Time > startTime.AddHours(1D))
                    {
                        this.SetDataSource(list, startTime, onTime);

                        startTime = item.Time;
                        list.Clear();
                    }
                }
                onTime = item.Time;
            }
            if (list.Count > 0)
            {
                this.SetDataSource(list, startTime, onTime);
                list.Clear();
            }
        }
        private void SetDataSource(List<ProductPerformance> listitem, DateTime starttime, DateTime ontime)
        {
            foreach (string item1 in listComputer)
            {
                int MessageNumber = 0;
                int sum = 0;

                foreach (BadMachineFrmModel item in listbmfm)
                {
                    if (item.Computer == item1)
                    {
                        if (item.TestTime >= starttime && item.TestTime <= ontime)
                        {
                            MessageNumber += 1;
                        }
                    }
                }
                foreach (ProductPerformance item2 in listitem)
                {
                    if (item2.Computer == item1)
                    {
                        sum += 1;
                    }
                }

                SetDataSource1(this.productionType, item1, sum, MessageNumber, starttime, ontime);
                MessageNumber = 0;
                sum = 0;
            }
            //for (int i = 0; i < listComputer.Count; i++)
            //{

            //}
            listDataSours.Add(new ComputerTestModel() { });
        }
        private void SetDataSource1(string productiontype,string computerName,int sum,int messageNumber,DateTime starttime,DateTime ontime)
        {
            listDataSours.Add(new ComputerTestModel() { 
                productionType= productiontype,
                ComputerName=computerName,
                Sum= Convert.ToString(sum),
                MessageNumber= Convert.ToString(messageNumber),
                StartTime=starttime,
                OnTime=ontime,
                sumTime= Convert.ToString(GetMinutes(starttime,ontime))
            });
        }
        private void Load3()
        {
            if (listDataSours.Count > 0)
            {
                this.dataGridViewX1.DataSource = listDataSours;
            }
            this.dataGridViewX1.Refresh();//刷新控件
        }
        /// <summary>
        /// 截取计算机名称
        /// </summary>
        /// <param name="str">计算机名包含IP地址</param>
        /// <returns>string</returns>
        private string getComputerName(string str)
        {
            string str1 = "";
            if (str == ""||str==null)
            {
                return "";
            }
            int i = str.IndexOf("IP1:");
            if(i>0)
            {
                str1 = str.Substring(0, i);
            }
            return str1;
        }
        /// <summary>
        /// 添加行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
    }
}
