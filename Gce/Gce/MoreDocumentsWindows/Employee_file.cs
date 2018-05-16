using DevComponents.DotNetBar;
using Gce.Class;
using Gce.pop_upWindows;
using Gce_Bll;
using Gce_Common;
using Gce_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Gce.MoreDocumentsWindows
{
    public partial class Employee_file : Office2007Form
    {
        SynchronizationContext My_context = null;

        Gce G;


        //利用Windows的API函数：SendMessage 和 ReleaseCapture 
        const uint WM_SYSCOMMAND = 0x0112;
        const uint SC_MOVE = 0xF010;
        const uint HTCAPTION = 0x0002;

        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern int SendMessage(IntPtr hwnd, uint wMsg, uint wParam, uint lParam);
        [DllImport("user32.dll")]
        private static extern int ReleaseCapture();

        TimeAttendance_DepartmentBll TadBll = new TimeAttendance_DepartmentBll();

        TimeAttendance_Employee_FileBll TaefBll = new TimeAttendance_Employee_FileBll();

        Dictionary<string, List<TimeAttendance_Employee_File>> dicData_Line_No = new Dictionary<string, List<TimeAttendance_Employee_File>>();
        Dictionary<string, List<TimeAttendance_Employee_File>> dicData_GroupNo = new Dictionary<string, List<TimeAttendance_Employee_File>>();
        Dictionary<string, List<TimeAttendance_Employee_File>> dicData_DepartmentNo = new Dictionary<string, List<TimeAttendance_Employee_File>>();
        List<TimeAttendance_Employee_File> DataListAll = new List<TimeAttendance_Employee_File>();
        List<TimeAttendance_Employee_File> DataListDynamic = new List<TimeAttendance_Employee_File>();
        string[] com_NationS={"汉族","蒙古族","满族","朝鲜族","赫哲族","达斡尔族","鄂温克族","鄂伦春族","回族","东乡族","土族","撒拉族","保安族","裕固族","维吾尔族","哈萨克族","柯尔克孜族","锡伯族","塔吉克族",
                                 "乌孜别克族","俄罗斯族","塔塔尔族","藏族","门巴族","珞巴族","羌族","彝族","白族","哈尼族","傣族","僳僳族","佤族","拉祜族","纳西族","景颇族","布朗族","阿昌族","普米族","怒族",
                                 "德昂族","独龙族","基诺族","苗族","布依族","侗族","水族","仡佬族","壮族","瑶族","仫佬族","毛南族","京族","土家族","黎族","畲族","高山族","外籍"};
        List<string> com_NationList = new List<string>();

        Point pt;
        Point p = new Point(0, 0);//定义一个点

        string state = "browse";
        public Employee_file()
        {
            InitializeComponent();
        }

        public Employee_file(Gce g)
        {
            InitializeComponent();
            this.G = g;
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
                    Thread th = new Thread(delegate()
                    {
                        ExcelInput(fileName);
                    });
                    th.IsBackground = true;
                    th.Start();

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

        void ExcelInput(string fileName)
        {
            DataTable dt = ExcelHelperForCs.ImportFromExcel(fileName, "员工档案管理", 0);

            foreach (DataRow item in dt.Rows)
            {
                TimeAttendance_Employee_File tad = new TimeAttendance_Employee_File()
                {
                    JobNumber = item["工号"].ToString(),
                    ChineseName = item["中文姓名"].ToString(),
                    Gender = item["性别"].ToString(),
                    Education = item["学历"].ToString(),
                    Post = item["职务"].ToString(),
                    EmployeeCategory = item["员工类别"].ToString(),
                    EntryDate = item["入职日期"].ToString(),
                    DepartmentNo = item["部门编号"].ToString(),
                    DepartmentName = item["部门名称"].ToString(),
                    GroupNo = item["组别编号"].ToString(),
                    GroupName = item["组别名称"].ToString(),
                    Line_No = item["线别编号"].ToString(),
                    LineName = item["线别名称"].ToString(),
                    IDNumber = item["身份证号"].ToString(),
                    IssuingAuthority = item["发证机关"].ToString(),
                    DateOfIssue = item["发证日期"].ToString(),
                    IDTermOfValidity = item["有效期"].ToString(),
                    BirthDay = item["出生日期"].ToString(),
                    PlaceOrigin = item["籍贯"].ToString(),
                    Nation = item["民族"].ToString(),
                    HomeAddress = item["家庭地址"].ToString(),
                    AttendanceData = item["考勤日期"].ToString(),
                    AttendanceRegulations = item["考勤规则"].ToString(),
                    CompletionData = item["转正日期"].ToString(),
                    ProbationPeriod = Convert.ToBoolean(item["试用期"]),
                    SalaryCategory = item["薪资类别"].ToString(),
                    Introducer = item["介绍人"].ToString(),
                    PositionsGrade = item["职等"].ToString(),
                    Rank = item["职级"].ToString(),
                    LogicalCardNumber = item["逻辑卡号"].ToString(),
                    PhysicalCardNumber = item["物理卡号"].ToString(),
                    PhoneNumber = item["电话"].ToString(),
                    EmergencyContact = item["联系人"].ToString(),
                    EmergencyContactPhone = item["紧急联系电话"].ToString(),
                    EmErgencyContactAddress = item["紧急联系地址"].ToString(),
                    PaymentMode = item["计薪方式"].ToString(),
                    Height = item["身高"].ToString(),
                    Weight = item["体重"].ToString(),
                    LeftEyeVision = item["左眼视力"].ToString(),
                    RightEyeVision = item["右眼视力"].ToString(),
                    note = item["备注"].ToString(),
                    ContractNumber = item["合同编号"].ToString(),
                    ContractSigning = item["合同签订"].ToString(),
                    ExpirationContract = item["合同到期"].ToString(),
                    IDCardPeriod = item["身份证期限"].ToString(),
                    Job = Convert.ToBoolean(item["在职"]),
                    leaveDate = item["离职日期"].ToString(),
                    TurnoverType = item["离职类型"].ToString(),
                    ReasonsForLeaving = item["离职原因"].ToString(),
                    Blacklist = Convert.ToBoolean(item["黑名单"]),
                    married = Convert.ToBoolean(item["已婚"]),
                    FreeCard = Convert.ToBoolean(item["免卡"]),
                    OvertimeApplication = Convert.ToBoolean(item["加班需申请"]),
                    createddate = item["建档日期"].ToString(),
                    FilingMan = item["建档人"].ToString(),
                    modificationDate = item["修改日期"].ToString(),
                    Modifier = item["修改人"].ToString(),
                    workType = item["工种"].ToString(),
                    workGrade = item["工种等级"].ToString(),
                    Photo = Convert.ToBoolean(item["已上传员工照片"]),
                    MinimalSector = item["最小部门"].ToString(),
                };
                try
                {
                    if (TaefBll.insertTimeAttendance_Employee_FileBll(tad, "insertTimeAttendance_Employee_File"))
                    {
                        this.treeView1.Nodes.Clear();
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }
        }

        private void LoadData(TreeNodeCollection treeNodeCollection, string fid)
        {
            try
            {
                //根据父ID找到子节点数据
                List<TimeAttendance_Department> DataList = TadBll.selectTimeAttendance_DepartmentParentDepartmentNoBll(fid, "selectTimeAttendance_DepartmentParentDepartmentNo");

                foreach (TimeAttendance_Department item in DataList)
                {
                    TreeNode tn = treeNodeCollection.Add(item.DepartmentName);
                    tn.Name = item.DepartmentNo;
                    tn.Tag = item.ParentDepartmentNo;
                    LoadData(tn.Nodes, item.DepartmentNo);
                }

                //线
                List<TimeAttendance_Employee_File> DataList3 = TaefBll.selectTimeAttendance_Employee_FileDepartmentNoBll(fid, "selectTimeAttendance_Employee_FileLine_No");
                if (DataList3.Count > 0)
                {
                    dicData_Line_No.Add(fid, DataList3);                    
                }

                //组
                List<TimeAttendance_Employee_File> DataList1 = TaefBll.selectTimeAttendance_Employee_FileDepartmentNoBll(fid, "selectTimeAttendance_Employee_FileGroupNo");
                if (DataList1.Count > 0)
                {
                    dicData_GroupNo.Add(fid, DataList1);
                }

                //部门
                List<TimeAttendance_Employee_File> DataList2 = TaefBll.selectTimeAttendance_Employee_FileDepartmentNoBll(fid, "selectTimeAttendance_Employee_FileDepartmentNo");
                if (DataList2.Count > 0)
                {
                    dicData_DepartmentNo.Add(fid, DataList2);
                }
            }
            catch
            {
                MessageBox.Show("加载异常，请检查网络连接情况");
            }
        }
        void SetTreeeview()
        {
            this.treeView1.Nodes.Clear();
            dicData_DepartmentNo.Clear();
            dicData_GroupNo.Clear();
            dicData_Line_No.Clear();
            DataListAll = TaefBll.selectAllTimeAttendance_Employee_File1Bll("selectAllTimeAttendance_Employee_File1");
            List<TimeAttendance_Department> list = TadBll.selectAllTimeAttendance_EmployeeParentDepartmentNoBll("selectAllTimeAttendance_Employee_File1ParentDepartmentNo");
            List<string> strlist = new List<string>();
            List<string> strlist2 = new List<string>();
            foreach (TimeAttendance_Department item in list)
            {
                strlist.Add(item.DepartmentNo);
                strlist2.Add(item.DepartmentName);
            }
            com_DepartmentNo.DataSource = strlist;
            com_DepartmentName.DataSource = strlist2;

            com_DepartmentNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            com_DepartmentNo.AutoCompleteSource = AutoCompleteSource.ListItems;
            com_DepartmentName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            com_DepartmentName.AutoCompleteSource = AutoCompleteSource.ListItems;

            LoadData(treeView1.Nodes, "");

            treeView1.Nodes[0].Expand();
            

        }

        private void Employee_file_Load(object sender, EventArgs e)
        {
            My_context = SynchronizationContext.Current;

            com_NationList.AddRange(com_NationS);
            com_Nation.DataSource = com_NationList;
            com_Nation.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            com_Nation.AutoCompleteSource = AutoCompleteSource.ListItems;

            updateCotrls();
            tabControl1.SelectedTab = tabControl1.Tabs[0];
            SetTreeeview();
            Loead();

            panelEx2.VerticalScroll.Value = panelEx2.VerticalScroll.Maximum;
        }

        private void btni_edit_Click(object sender, EventArgs e)
        {
            state = "modify";

            updateCotrls();
        }

        private void btni_save_Click(object sender, EventArgs e)
        {
            if (!UsersHelp.checkLogin)
            {
                MessageBox.Show("未登录账号，请登录");
                return;
            }
            if (state == "modify")
            {
                G.Setlb_QueryState("正在保存...");
                Thread th = new Thread(delegate()
                {
                    Update1();
                });
                th.IsBackground = true;
                th.Start();
            }
            else if (state == "insert")
            {
                G.Setlb_QueryState("正在保存...");
                Thread th = new Thread(delegate()
                {
                    Insert();
                });
                th.IsBackground = true;
                th.Start();
            }
        }


        void Insert()
        {
            if (TaefBll.insertTimeAttendance_Employee_File1Bll(GetTimeAttendance_Employee_File(), "insertTimeAttendance_Employee_File"))
            {
                My_context.Post(Insert1,new object());
            }
        }

        void Update1()
        {
            if (TaefBll.updateTimeAttendance_Employee_File1Bll(GetTimeAttendance_Employee_File(), "updateTimeAttendance_Employee_File"))
            {
                My_context.Post(Insert1, new object());
            }
        }

        void Insert1(object o)
        {
            this.treeView1.Nodes.Clear();
            SetTreeeview();
            G.Setlb_QueryState("完成");
        }
        private void btni_cancle_Click(object sender, EventArgs e)
        {
            state = "browse";

            updateCotrls();
        }

        private void btni_delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定删除该员工资料？", "系统提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            { 
                
            }
        }

        void updateCotrls()
        {
            if (state == "browse")
            {
                treeView1.Enabled = true;

                btni_save.Enabled = false;
                btni_cancle.Enabled = false;
                btni_delete.Enabled = true;
                btni_edit.Enabled = true;

                btni_DataInput.Enabled = true;
                btni_DataOut.Enabled = true;
                btni_staff.Enabled = true;
            }
            else if (state == "modify")
            {
                treeView1.Enabled = false;

                btni_save.Enabled = true;
                btni_cancle.Enabled = true;
                btni_delete.Enabled = false;
                btni_edit.Enabled = false;
                btni_staff.Enabled = false;

                btni_DataInput.Enabled = false;
                btni_DataOut.Enabled = false;
            }
            else
            {
                treeView1.Enabled = false;

                btni_save.Enabled = true;
                btni_cancle.Enabled = true;
                btni_delete.Enabled = false;
                btni_edit.Enabled = false;
                btni_staff.Enabled = false;

                btni_DataInput.Enabled = false;
                btni_DataOut.Enabled = false;
            }
        }

        void Loead()
        {
            DataGridViewTextBoxColumn newcol = new DataGridViewTextBoxColumn();
            newcol.HeaderText = "工号";
            newcol.Name = "JobNumber";
            newcol.DataPropertyName = "JobNumber";
            newcol.Width = 150;
            newcol.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol.Tag = 0;
            this.dataGridViewX1.Columns.Insert(0, newcol);

            DataGridViewTextBoxColumn newcol1 = new DataGridViewTextBoxColumn();
            newcol1.HeaderText = "中文名";
            newcol1.Name = "ChineseName";
            newcol1.DataPropertyName = "ChineseName";
            newcol1.Width = 120;
            newcol1.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol1.Tag = 1;
            this.dataGridViewX1.Columns.Insert(1, newcol1);

            DataGridViewTextBoxColumn newcol2 = new DataGridViewTextBoxColumn();
            newcol2.HeaderText = "学历";
            newcol2.Name = "Education";
            newcol2.DataPropertyName = "Education";
            newcol2.Width = 120;
            newcol2.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol2.Tag = 2;
            this.dataGridViewX1.Columns.Insert(2, newcol2);


            DataGridViewTextBoxColumn newcol3 = new DataGridViewTextBoxColumn();
            newcol3.HeaderText = "职务";
            newcol3.Name = "Post";
            newcol3.DataPropertyName = "Post";
            newcol3.Width = 120;
            newcol3.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol3.Tag = 3;
            this.dataGridViewX1.Columns.Insert(3, newcol3);

            DataGridViewTextBoxColumn newcol4 = new DataGridViewTextBoxColumn();
            newcol4.HeaderText = "员工类别";
            newcol4.Name = "EmployeeCategory";
            newcol4.DataPropertyName = "EmployeeCategory";
            newcol4.Width = 120;
            newcol4.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol4.Tag = 4;
            this.dataGridViewX1.Columns.Insert(4, newcol4);

            DataGridViewTextBoxColumn newcol5 = new DataGridViewTextBoxColumn();
            newcol5.HeaderText = "入职日期";
            newcol5.Name = "EntryDate";
            newcol5.DataPropertyName = "EntryDate";
            newcol5.Width = 120;
            newcol5.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol5.Tag = 5;
            this.dataGridViewX1.Columns.Insert(5, newcol5);

            DataGridViewTextBoxColumn newcol6 = new DataGridViewTextBoxColumn();
            newcol6.HeaderText = "部门编号";
            newcol6.Name = "DepartmentNo";
            newcol6.DataPropertyName = "DepartmentNo";
            newcol6.Width = 120;
            newcol6.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol6.Tag = 6;
            this.dataGridViewX1.Columns.Insert(6, newcol6);

            DataGridViewTextBoxColumn newcol7 = new DataGridViewTextBoxColumn();
            newcol7.HeaderText = "部门名称";
            newcol7.Name = "DepartmentName";
            newcol7.DataPropertyName = "DepartmentName";
            newcol7.Width = 120;
            newcol7.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol7.Tag = 7;
            this.dataGridViewX1.Columns.Insert(7, newcol7);

            DataGridViewTextBoxColumn newcol8 = new DataGridViewTextBoxColumn();
            newcol8.HeaderText = "组别编号";
            newcol8.Name = "GroupNo";
            newcol8.DataPropertyName = "GroupNo";
            newcol8.Width = 120;
            newcol8.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol8.Tag = 8;
            this.dataGridViewX1.Columns.Insert(8, newcol8);


            DataGridViewTextBoxColumn newcol9 = new DataGridViewTextBoxColumn();
            newcol9.HeaderText = "组别名称";
            newcol9.Name = "GroupName";
            newcol9.DataPropertyName = "GroupName";
            newcol9.Width = 120;
            newcol9.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol9.Tag = 8;
            this.dataGridViewX1.Columns.Insert(9, newcol9);


            DataGridViewTextBoxColumn newcol10 = new DataGridViewTextBoxColumn();
            newcol10.HeaderText = "线别编号";
            newcol10.Name = "Line_No";
            newcol10.DataPropertyName = "Line_No";
            newcol10.Width = 120;
            newcol10.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol10.Tag = 10;
            this.dataGridViewX1.Columns.Insert(10, newcol10);


            DataGridViewTextBoxColumn newcol11 = new DataGridViewTextBoxColumn();
            newcol11.HeaderText = "线别名称";
            newcol11.Name = "LineName";
            newcol11.DataPropertyName = "LineName";
            newcol11.Width = 120;
            newcol11.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol11.Tag = 11;
            this.dataGridViewX1.Columns.Insert(11, newcol11);


            DataGridViewTextBoxColumn newcol12 = new DataGridViewTextBoxColumn();
            newcol12.HeaderText = "身份证号";
            newcol12.Name = "IDNumber";
            newcol12.DataPropertyName = "IDNumber";
            newcol12.Width = 150;
            newcol12.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol12.Tag = 12;
            this.dataGridViewX1.Columns.Insert(12, newcol12);

            DataGridViewTextBoxColumn newcol13 = new DataGridViewTextBoxColumn();
            newcol13.HeaderText = "发证机关";
            newcol13.Name = "IssuingAuthority";
            newcol13.DataPropertyName = "IssuingAuthority";
            newcol13.Width = 120;
            newcol13.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol13.Tag = 13;
            this.dataGridViewX1.Columns.Insert(13, newcol13);

            DataGridViewTextBoxColumn newcol14 = new DataGridViewTextBoxColumn();
            newcol14.HeaderText = "发证日期";
            newcol14.Name = "DateOfIssue";
            newcol14.DataPropertyName = "DateOfIssue";
            newcol14.Width = 80;
            newcol14.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol14.Tag = 14;
            this.dataGridViewX1.Columns.Insert(14, newcol14);

            DataGridViewTextBoxColumn newcol15 = new DataGridViewTextBoxColumn();
            newcol15.HeaderText = "有效期";
            newcol15.Name = "IDTermOfValidity";
            newcol15.DataPropertyName = "IDTermOfValidity";
            newcol15.Width = 80;
            newcol15.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol15.Tag = 15;
            this.dataGridViewX1.Columns.Insert(15, newcol15);

            DataGridViewTextBoxColumn newcol16 = new DataGridViewTextBoxColumn();
            newcol16.HeaderText = "出生日期";
            newcol16.Name = "BirthDay";
            newcol16.DataPropertyName = "BirthDay";
            newcol16.Width = 80;
            newcol16.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol16.Tag = 16;
            this.dataGridViewX1.Columns.Insert(16, newcol16);

            DataGridViewTextBoxColumn newcol17 = new DataGridViewTextBoxColumn();
            newcol17.HeaderText = "籍贯";
            newcol17.Name = "PlaceOrigin";
            newcol17.DataPropertyName = "PlaceOrigin";
            newcol17.Width = 80;
            newcol17.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol17.Tag = 17;
            this.dataGridViewX1.Columns.Insert(17, newcol17);

            DataGridViewTextBoxColumn newcol18 = new DataGridViewTextBoxColumn();
            newcol18.HeaderText = "民族";
            newcol18.Name = "Nation";
            newcol18.DataPropertyName = "Nation";
            newcol18.Width = 80;
            newcol18.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol18.Tag = 18;
            this.dataGridViewX1.Columns.Insert(18, newcol18);

            DataGridViewTextBoxColumn newcol19 = new DataGridViewTextBoxColumn();
            newcol19.HeaderText = "家庭地址";
            newcol19.Name = "HomeAddress";
            newcol19.DataPropertyName = "HomeAddress";
            newcol19.Width = 200;
            newcol19.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol19.Tag = 19;
            this.dataGridViewX1.Columns.Insert(19, newcol19);

            DataGridViewTextBoxColumn newcol20 = new DataGridViewTextBoxColumn();
            newcol20.HeaderText = "考勤日期";
            newcol20.Name = "AttendanceData";
            newcol20.DataPropertyName = "AttendanceData";
            newcol20.Width = 80;
            newcol20.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol20.Tag = 20;
            this.dataGridViewX1.Columns.Insert(20, newcol20);

            DataGridViewTextBoxColumn newcol21 = new DataGridViewTextBoxColumn();
            newcol21.HeaderText = "考勤规则";
            newcol21.Name = "AttendanceRegulations";
            newcol21.DataPropertyName = "AttendanceRegulations";
            newcol21.Width = 80;
            newcol21.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol21.Tag = 21;
            this.dataGridViewX1.Columns.Insert(21, newcol21);

            DataGridViewTextBoxColumn newcol22 = new DataGridViewTextBoxColumn();
            newcol22.HeaderText = "转正日期";
            newcol22.Name = "CompletionData";
            newcol22.DataPropertyName = "CompletionData";
            newcol22.Width = 80;
            newcol22.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol22.Tag = 22;
            this.dataGridViewX1.Columns.Insert(22, newcol22);

            DataGridViewTextBoxColumn newcol23 = new DataGridViewTextBoxColumn();
            newcol23.HeaderText = "试用期";
            newcol23.Name = "ProbationPeriod";
            newcol23.DataPropertyName = "ProbationPeriod";
            newcol23.Width = 80;
            newcol23.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol23.Tag = 23;
            this.dataGridViewX1.Columns.Insert(23, newcol23);

            DataGridViewTextBoxColumn newcol24 = new DataGridViewTextBoxColumn();
            newcol24.HeaderText = "薪资类型";
            newcol24.Name = "SalaryCategory";
            newcol24.DataPropertyName = "SalaryCategory";
            newcol24.Width = 80;
            newcol24.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol24.Tag = 24;
            this.dataGridViewX1.Columns.Insert(24, newcol24);

            DataGridViewTextBoxColumn newcol25 = new DataGridViewTextBoxColumn();
            newcol25.HeaderText = "介绍人";
            newcol25.Name = "Introducer";
            newcol25.DataPropertyName = "Introducer";
            newcol25.Width = 80;
            newcol25.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol25.Tag = 22;
            this.dataGridViewX1.Columns.Insert(25, newcol25);

            DataGridViewTextBoxColumn newcol26 = new DataGridViewTextBoxColumn();
            newcol26.HeaderText = "职等";
            newcol26.Name = "PositionsGrade";
            newcol26.DataPropertyName = "PositionsGrade";
            newcol26.Width = 80;
            newcol26.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol26.Tag = 26;
            this.dataGridViewX1.Columns.Insert(26, newcol26);

            DataGridViewTextBoxColumn newcol27 = new DataGridViewTextBoxColumn();
            newcol27.HeaderText = "职级";
            newcol27.Name = "Rank";
            newcol27.DataPropertyName = "Rank";
            newcol27.Width = 80;
            newcol27.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol27.Tag = 27;
            this.dataGridViewX1.Columns.Insert(27, newcol27);

            DataGridViewTextBoxColumn newcol28 = new DataGridViewTextBoxColumn();
            newcol28.HeaderText = "逻辑卡号";
            newcol28.Name = "LogicalCardNumber";
            newcol28.DataPropertyName = "LogicalCardNumber";
            newcol28.Width = 100;
            newcol28.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol28.Tag = 28;
            this.dataGridViewX1.Columns.Insert(28, newcol28);

            DataGridViewTextBoxColumn newcol29 = new DataGridViewTextBoxColumn();
            newcol29.HeaderText = "物理卡号";
            newcol29.Name = "PhysicalCardNumber";
            newcol29.DataPropertyName = "PhysicalCardNumber";
            newcol29.Width = 100;
            newcol29.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol29.Tag = 29;
            this.dataGridViewX1.Columns.Insert(29, newcol29);

            DataGridViewTextBoxColumn newcol30 = new DataGridViewTextBoxColumn();
            newcol30.HeaderText = "电话";
            newcol30.Name = "PhoneNumber";
            newcol30.DataPropertyName = "PhoneNumber";
            newcol30.Width = 100;
            newcol30.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol30.Tag = 30;
            this.dataGridViewX1.Columns.Insert(30, newcol30);

            DataGridViewTextBoxColumn newcol31 = new DataGridViewTextBoxColumn();
            newcol31.HeaderText = "紧急联系人";
            newcol31.Name = "EmergencyContact";
            newcol31.DataPropertyName = "EmergencyContact";
            newcol31.Width = 120;
            newcol31.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol31.Tag = 31;
            this.dataGridViewX1.Columns.Insert(31, newcol31);

            DataGridViewTextBoxColumn newcol32 = new DataGridViewTextBoxColumn();
            newcol32.HeaderText = "紧急联系人电话";
            newcol32.Name = "EmergencyContactPhone";
            newcol32.DataPropertyName = "EmergencyContactPhone";
            newcol32.Width = 120;
            newcol32.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol32.Tag = 32;
            this.dataGridViewX1.Columns.Insert(32, newcol32);

            DataGridViewTextBoxColumn newcol33 = new DataGridViewTextBoxColumn();
            newcol33.HeaderText = "紧急联系地址";
            newcol33.Name = "EmErgencyContactAddress";
            newcol33.DataPropertyName = "EmErgencyContactAddress";
            newcol33.Width = 200;
            newcol33.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol33.Tag = 33;
            this.dataGridViewX1.Columns.Insert(33, newcol33);

            DataGridViewTextBoxColumn newcol34 = new DataGridViewTextBoxColumn();
            newcol34.HeaderText = "计薪方式";
            newcol34.Name = "PaymentMode";
            newcol34.DataPropertyName = "PaymentMode";
            newcol34.Width = 120;
            newcol34.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol34.Tag = 34;
            this.dataGridViewX1.Columns.Insert(34, newcol34);

            DataGridViewTextBoxColumn newcol35 = new DataGridViewTextBoxColumn();
            newcol35.HeaderText = "身高";
            newcol35.Name = "Height";
            newcol35.DataPropertyName = "Height";
            newcol35.Width = 80;
            newcol35.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol32.Tag = 32;
            this.dataGridViewX1.Columns.Insert(35, newcol35);

            DataGridViewTextBoxColumn newcol36 = new DataGridViewTextBoxColumn();
            newcol36.HeaderText = "体重";
            newcol36.Name = "Weight";
            newcol36.DataPropertyName = "Weight";
            newcol36.Width = 80;
            newcol36.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol36.Tag = 36;
            this.dataGridViewX1.Columns.Insert(36, newcol36);

            DataGridViewTextBoxColumn newcol37 = new DataGridViewTextBoxColumn();
            newcol37.HeaderText = "左眼视力";
            newcol37.Name = "LeftEyeVision";
            newcol37.DataPropertyName = "LeftEyeVision";
            newcol37.Width = 80;
            newcol37.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol37.Tag = 37;
            this.dataGridViewX1.Columns.Insert(37, newcol37);

            DataGridViewTextBoxColumn newcol38 = new DataGridViewTextBoxColumn();
            newcol38.HeaderText = "有眼视力";
            newcol38.Name = "RightEyeVision";
            newcol38.DataPropertyName = "RightEyeVision";
            newcol38.Width = 80;
            newcol38.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol38.Tag = 38;
            this.dataGridViewX1.Columns.Insert(38, newcol38);

            DataGridViewTextBoxColumn newcol39 = new DataGridViewTextBoxColumn();
            newcol39.HeaderText = "备注";
            newcol39.Name = "note";
            newcol39.DataPropertyName = "note";
            newcol39.Width = 200;
            newcol39.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol39.Tag = 39;
            this.dataGridViewX1.Columns.Insert(39, newcol39);

            DataGridViewTextBoxColumn newcol40 = new DataGridViewTextBoxColumn();
            newcol40.HeaderText = "合同编号";
            newcol40.Name = "ContractNumber";
            newcol40.DataPropertyName = "ContractNumber";
            newcol40.Width = 100;
            newcol40.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol40.Tag = 40;
            this.dataGridViewX1.Columns.Insert(40, newcol40);

            DataGridViewTextBoxColumn newcol41 = new DataGridViewTextBoxColumn();
            newcol41.HeaderText = "合同签订";
            newcol41.Name = "ContractSigning";
            newcol41.DataPropertyName = "ContractSigning";
            newcol41.Width = 100;
            newcol41.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol41.Tag = 41;
            this.dataGridViewX1.Columns.Insert(41, newcol41);

            DataGridViewTextBoxColumn newcol42 = new DataGridViewTextBoxColumn();
            newcol42.HeaderText = "合同到期";
            newcol42.Name = "ExpirationContract";
            newcol42.DataPropertyName = "ExpirationContract";
            newcol42.Width = 100;
            newcol42.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol42.Tag = 42;
            this.dataGridViewX1.Columns.Insert(42, newcol42);

            DataGridViewTextBoxColumn newcol43 = new DataGridViewTextBoxColumn();
            newcol43.HeaderText = "身份证期限";
            newcol43.Name = "IDCardPeriod";
            newcol43.DataPropertyName = "IDCardPeriod";
            newcol43.Width = 100;
            newcol43.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol43.Tag = 43;
            this.dataGridViewX1.Columns.Insert(43, newcol43);

            DataGridViewTextBoxColumn newcol44 = new DataGridViewTextBoxColumn();
            newcol44.HeaderText = "在职";
            newcol44.Name = "Job";
            newcol44.DataPropertyName = "Job";
            newcol44.Width = 50;
            newcol44.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol44.Tag = 44;
            this.dataGridViewX1.Columns.Insert(44, newcol44);

            DataGridViewTextBoxColumn newcol45 = new DataGridViewTextBoxColumn();
            newcol45.HeaderText = "离职日期";
            newcol45.Name = "leaveDate";
            newcol45.DataPropertyName = "leaveDate";
            newcol45.Width = 100;
            newcol45.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol45.Tag = 45;
            this.dataGridViewX1.Columns.Insert(45, newcol45);

            DataGridViewTextBoxColumn newcol46 = new DataGridViewTextBoxColumn();
            newcol46.HeaderText = "离职类别";
            newcol46.Name = "TurnoverType";
            newcol46.DataPropertyName = "TurnoverType";
            newcol46.Width = 100;
            newcol46.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol46.Tag = 46;
            this.dataGridViewX1.Columns.Insert(46, newcol46);

            DataGridViewTextBoxColumn newcol47 = new DataGridViewTextBoxColumn();
            newcol47.HeaderText = "离职原因";
            newcol47.Name = "ReasonsForLeaving";
            newcol47.DataPropertyName = "ReasonsForLeaving";
            newcol47.Width = 100;
            newcol47.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol47.Tag = 47;
            this.dataGridViewX1.Columns.Insert(47, newcol47);

            DataGridViewTextBoxColumn newcol48 = new DataGridViewTextBoxColumn();
            newcol48.HeaderText = "黑名单";
            newcol48.Name = "Blacklist";
            newcol48.DataPropertyName = "Blacklist";
            newcol48.Width = 50;
            newcol48.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol48.Tag = 48;
            this.dataGridViewX1.Columns.Insert(48, newcol48);

            DataGridViewTextBoxColumn newcol49 = new DataGridViewTextBoxColumn();
            newcol49.HeaderText = "已婚";
            newcol49.Name = "married";
            newcol49.DataPropertyName = "married";
            newcol49.Width = 50;
            newcol49.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol49.Tag = 49;
            this.dataGridViewX1.Columns.Insert(49, newcol49);

            DataGridViewTextBoxColumn newcol50 = new DataGridViewTextBoxColumn();
            newcol50.HeaderText = "免卡";
            newcol50.Name = "FreeCard";
            newcol50.DataPropertyName = "FreeCard";
            newcol50.Width = 50;
            newcol50.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol50.Tag = 50;
            this.dataGridViewX1.Columns.Insert(50, newcol50);

            DataGridViewTextBoxColumn newcol51= new DataGridViewTextBoxColumn();
            newcol51.HeaderText = "加班需申请";
            newcol51.Name = "OvertimeApplication";
            newcol51.DataPropertyName = "OvertimeApplication";
            newcol51.Width = 100;
            newcol51.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol51.Tag = 51;
            this.dataGridViewX1.Columns.Insert(51, newcol51);

            DataGridViewTextBoxColumn newcol52 = new DataGridViewTextBoxColumn();
            newcol52.HeaderText = "建档日期";
            newcol52.Name = "createddate";
            newcol52.DataPropertyName = "createddate";
            newcol52.Width = 100;
            newcol52.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol52.Tag = 52;
            this.dataGridViewX1.Columns.Insert(52, newcol52);

            DataGridViewTextBoxColumn newcol53 = new DataGridViewTextBoxColumn();
            newcol53.HeaderText = "建档人";
            newcol53.Name = "FilingMan";
            newcol53.DataPropertyName = "FilingMan";
            newcol53.Width = 80;
            newcol53.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol53.Tag = 53;
            this.dataGridViewX1.Columns.Insert(53, newcol53);

            DataGridViewTextBoxColumn newcol54 = new DataGridViewTextBoxColumn();
            newcol54.HeaderText = "修改日期";
            newcol54.Name = "modificationDate";
            newcol54.DataPropertyName = "modificationDate";
            newcol54.Width = 100;
            newcol54.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol54.Tag = 54;
            this.dataGridViewX1.Columns.Insert(54, newcol54);

            DataGridViewTextBoxColumn newcol55 = new DataGridViewTextBoxColumn();
            newcol55.HeaderText = "修改人";
            newcol55.Name = "Modifier";
            newcol55.DataPropertyName = "Modifier";
            newcol55.Width = 80;
            newcol55.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol55.Tag = 55;
            this.dataGridViewX1.Columns.Insert(55, newcol55);

            DataGridViewTextBoxColumn newcol56 = new DataGridViewTextBoxColumn();
            newcol56.HeaderText = "工种";
            newcol56.Name = "workType";
            newcol56.DataPropertyName = "workType";
            newcol56.Width = 80;
            newcol56.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol56.Tag = 56;
            this.dataGridViewX1.Columns.Insert(56, newcol56);

            DataGridViewTextBoxColumn newcol57 = new DataGridViewTextBoxColumn();
            newcol57.HeaderText = "工种等级";
            newcol57.Name = "workGrade";
            newcol57.DataPropertyName = "workGrade";
            newcol57.Width = 80;
            newcol57.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol57.Tag = 57;
            this.dataGridViewX1.Columns.Insert(57, newcol57);

            DataGridViewTextBoxColumn newcol58 = new DataGridViewTextBoxColumn();
            newcol58.HeaderText = "是否上传照片";
            newcol58.Name = "Photo";
            newcol58.DataPropertyName = "Photo";
            newcol58.Width = 100;
            newcol58.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol58.Tag = 58;
            this.dataGridViewX1.Columns.Insert(58, newcol58);

            DataGridViewTextBoxColumn newcol59 = new DataGridViewTextBoxColumn();
            newcol59.HeaderText = "最小部门";
            newcol59.Name = "MinimalSector";
            newcol59.DataPropertyName = "MinimalSector";
            newcol59.Width = 80;
            newcol59.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol59.Tag = 59;
            this.dataGridViewX1.Columns.Insert(59, newcol59);

            DataGridViewTextBoxColumn newcol60 = new DataGridViewTextBoxColumn();
            newcol60.HeaderText = "";
            newcol60.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            newcol60.SortMode = DataGridViewColumnSortMode.NotSortable;
            newcol60.Tag = 60;
            this.dataGridViewX1.Columns.Insert(60, newcol60);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //DataListDynamic.Clear();
            DataListDynamic = GetData(treeView1.SelectedNode.Name);
            dataGridViewX1.DataSource = GetData(treeView1.SelectedNode.Name);

        }

        List<TimeAttendance_Employee_File> GetData(string GroupName)
        {
            List<TimeAttendance_Employee_File> list = new List<TimeAttendance_Employee_File>();

            if (GroupName == "Gce")
            {
                return DataListAll;
            }
            if(dicData_Line_No.Keys.Contains(GroupName))
            {
                return dicData_Line_No[GroupName];
            }
            if (dicData_GroupNo.Keys.Contains(GroupName))
            {
                return dicData_GroupNo[GroupName];
            }
            if (dicData_DepartmentNo.Keys.Contains(GroupName))
            {
                return dicData_DepartmentNo[GroupName];
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

        private void dataGridViewX1_SelectionChanged(object sender, EventArgs e)
        {
            this.dataGridViewX1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (dataGridViewX1.Rows.Count > 0)
            {
                try
                {
                    if (DataListDynamic.Count > 0)
                        SetControls(DataListDynamic[dataGridViewX1.CurrentCell.RowIndex],true);
                    else
                        SetControls(new TimeAttendance_Employee_File(), false);
                }
                catch
                {
                    return;
                }
            }
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

        void SetControls(TimeAttendance_Employee_File data,bool bl)
        {
            if (bl)
            {
                txt_JobNumber.Text = data.JobNumber;
                txt_ChineseName.Text = data.ChineseName;
                txt_IDNumber.Text = data.IDNumber;
                dti_EntryDate.Text = data.EntryDate;
                dti_BirthDay.Text = data.BirthDay;
                dti_DateOfIssue.Text = data.DateOfIssue;
                ip_IDTermOfValidity.Text = data.IDTermOfValidity;
                com_Gender.Text = data.Gender;
                com_Nation.Text = data.Nation;
                com_PlaceOrigin.Text = data.PlaceOrigin;
                ck_FreeCard.Checked = data.FreeCard;
                ck_Job.Checked = data.Job;
                ck_married.Checked = data.married;
                ck_ProbationPeriod.Checked = data.ProbationPeriod;
                cki_OvertimeApplication.Checked = data.OvertimeApplication;
                txt_IssuingAuthority.Text = data.IssuingAuthority;
                txt_HomeAddress.Text = data.HomeAddress;
                txt_PhoneNumber.Text = data.PhoneNumber;
                com_Introducer.Text = data.Introducer;
                com_Post.Text = data.Post;
                com_Education.Text = data.Education;
                com_EmployeeCategory.Text = data.EmployeeCategory;
                com_DepartmentNo.Text = data.DepartmentNo;
                com_DepartmentName.Text = data.DepartmentName;
                com_GroupNo.Text = data.GroupNo;
                com_GroupName.Text = data.GroupName;
                com_Line_No.Text = data.Line_No;
                com_LineName.Text = data.LineName;
                txt_PhysicalCardNumber.Text = data.PhysicalCardNumber;
                dti_CompletionData.Text = data.CompletionData;
                dti_AttendanceData.Text = data.AttendanceData;
                txt_EmergencyContact.Text = data.EmergencyContact;
                com_AttendanceRegulations.Text = data.AttendanceRegulations;
                com_WorkType.Text = data.workType;
                com_WrokGrade.Text = data.workGrade;
                com_ContractNumber.Text = data.ContractNumber;
                com_SalaryCategory.Text = data.SalaryCategory;
                txt_EmergencyContactPhone.Text = data.EmergencyContactPhone;
                dti_ContractSigning.Text = data.ContractSigning;
                dti_ExpirationContract.Text = data.ExpirationContract;
                dti_IDCardPeriod.Text = data.IDCardPeriod;
                txt_EmErgencyContactAddress.Text = data.EmErgencyContactAddress;
                txt_note.Text = data.note;
            }
            else
            {
                txt_JobNumber.Text = "";
                txt_ChineseName.Text = "";
                txt_IDNumber.Text = "";
                dti_EntryDate.Text = "";
                dti_BirthDay.Text = "";
                dti_DateOfIssue.Text = "";
                ip_IDTermOfValidity.Text = "";
                com_Gender.Text = "";
                com_Nation.Text = "";
                com_PlaceOrigin.Text = "";
                ck_FreeCard.Checked = false;
                ck_Job.Checked = false;
                ck_married.Checked = false;
                ck_ProbationPeriod.Checked = false;
                cki_OvertimeApplication.Checked = false;
                txt_IssuingAuthority.Text = "";
                txt_HomeAddress.Text = "";
                txt_PhoneNumber.Text = "";
                com_Introducer.Text = "";
                com_Post.Text = "";
                com_Education.Text = "";
                com_EmployeeCategory.Text = "";
                com_DepartmentNo.Text = "";
                com_DepartmentName.Text = "";
                com_GroupNo.Text = "";
                com_GroupName.Text = "";
                com_Line_No.Text = "";
                com_LineName.Text = "";
                txt_PhysicalCardNumber.Text = "";
                dti_CompletionData.Text = "";
                dti_AttendanceData.Text = "";
                txt_EmergencyContact.Text = "";
                com_AttendanceRegulations.Text = "";
                com_WorkType.Text = "";
                com_WrokGrade.Text = "";
                com_ContractNumber.Text = "";
                com_SalaryCategory.Text = "";
                txt_EmergencyContactPhone.Text = "";
                dti_ContractSigning.Text = "";
                dti_ExpirationContract.Text = "";
                dti_IDCardPeriod.Text = "";
                txt_EmErgencyContactAddress.Text = "";
                txt_note.Text = "";
            }
        }

        TimeAttendance_Employee_File GetTimeAttendance_Employee_File()
        {
            TimeAttendance_Employee_File data = new TimeAttendance_Employee_File()
            {
                JobNumber = txt_JobNumber.Text.Trim(),
                ChineseName = txt_ChineseName.Text.Trim(),
                IDNumber = txt_IDNumber.Text.Trim(),
                EntryDate = dti_EntryDate.Text.Trim(),
                BirthDay = dti_BirthDay.Text.Trim(),
                DateOfIssue = dti_DateOfIssue.Text.Trim(),
                IDTermOfValidity = ip_IDTermOfValidity.Text.Trim(),
                Gender = com_Gender.Text.Trim(),
                Nation = com_Nation.Text.Trim(),
                PlaceOrigin = com_PlaceOrigin.Text.Trim(),
                FreeCard = ck_FreeCard.Checked,
                Job = ck_Job.Checked,
                married = ck_married.Checked,
                ProbationPeriod = ck_ProbationPeriod.Checked,
                OvertimeApplication = cki_OvertimeApplication.Checked,
                IssuingAuthority = txt_IssuingAuthority.Text.Trim(),
                HomeAddress = txt_HomeAddress.Text.Trim(),
                PhoneNumber = txt_PhoneNumber.Text.Trim(),
                Introducer = com_Introducer.Text.Trim(),
                Post = com_Post.Text.Trim(),
                Education = com_Education.Text.Trim(),
                EmployeeCategory = com_EmployeeCategory.Text.Trim(),
                DepartmentNo = com_DepartmentNo.Text.Trim(),
                DepartmentName = com_DepartmentName.Text.Trim(),
                GroupNo = com_GroupNo.Text.Trim(),
                GroupName = com_GroupName.Text,
                Line_No = com_Line_No.Text.Trim(),
                LineName = com_LineName.Text.Trim(),
                PhysicalCardNumber = txt_PhysicalCardNumber.Text.Trim(),
                CompletionData = dti_CompletionData.Text.Trim(),
                AttendanceData = dti_AttendanceData.Text.Trim(),
                EmergencyContact = txt_EmergencyContact.Text.Trim(),
                AttendanceRegulations = com_AttendanceRegulations.Text.Trim(),
                workType = com_WorkType.Text.Trim(),
                workGrade = com_WrokGrade.Text.Trim(),
                ContractNumber = com_ContractNumber.Text.Trim(),
                SalaryCategory = com_SalaryCategory.Text.Trim(),
                EmergencyContactPhone = txt_EmergencyContactPhone.Text.Trim(),
                ContractSigning = dti_ContractSigning.Text.Trim(),
                ExpirationContract = dti_ExpirationContract.Text.Trim(),
                IDCardPeriod = dti_IDCardPeriod.Text.Trim(),
                EmErgencyContactAddress = txt_EmErgencyContactAddress.Text.Trim(),
                note = txt_note.Text,
                FilingMan=UsersHelp.Userslist[0].UserName,

            };

            return data;

        }

        private void btni_staff_Click(object sender, EventArgs e)
        {
            state = "insert";

            updateCotrls();
            SetControls(new TimeAttendance_Employee_File(),false);
        }

        private void txti_select_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                List<TimeAttendance_Employee_File> list = TaefBll.LikeSelectTimeAttendance_Employee_File1Bll(txti_select.Text.Trim(), "LikeSelectTimeAttendance_Employee_File1");
                DataListDynamic = list;
                dataGridViewX1.DataSource = list;
            }
        }

        private void txt_IDNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                IDNumber idn = new IDNumber();
                try
                {
                    DataTable dt = idn.GetIDNumberText(txt_IDNumber.Text.Trim());

                    com_PlaceOrigin.Text = dt.Rows[0]["省份"].ToString();
                    dti_BirthDay.Text = dt.Rows[0]["出生日期"].ToString();
                    com_Gender.Text = dt.Rows[0]["性别"].ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void panelEx2_MouseDown(object sender, MouseEventArgs e)
        {
           //// pt = Cursor.Position;
           // Panel panel = sender as Panel;
           // panelname = panel.Name;
            //if ((int)Control.ModifierKeys == (int)Keys.Control)
            //{//如果按住ctrl键，则更新p点
            //    p = new Point(e.X, e.Y);
            //}
            //else
            //{//否则执行移动，使用api函数
            //    ReleaseCapture();
            //    SendMessage((sender as Control).Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
            //}
        }

        public string panelname;

        private void panelEx2_MouseMove(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //    int px = Cursor.Position.X - pt.X;
            //    int py = Cursor.Position.Y - pt.Y;
            //    panelEx2.Location = new Point(panelEx2.Location.X + px, panelEx2.Location.Y + py);
            //    pt = Cursor.Position;
            //}

            //Panel panel = sender as Panel;//取得当前panel
            //if (e.Button == System.Windows.Forms.MouseButtons.Left)
            //{//如果点击的为鼠标左键
            //    if (ModifierKeys == Keys.Control)
            //    {//如果按住ctrl键，则为缩放panel
            //        panel.Width += e.X - p.X;//取出panel缩放后的实际宽度
            //        panel.Height += e.Y - p.Y;//取出panel缩放后的实际高度
            //        p = new Point(e.X, e.Y);//给点重新赋值
            //        panel.Refresh();//刷新放置绘制出现延迟
            //    }
            //    else
            //    {//否则为拖动panel
            //        panel.Location = new Point(panel.Left + e.X - p.X, panel.Top + e.Y - p.Y);//拖动panel后重新定位位置
            //    }
            //}
        }

        private void com_DepartmentNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com_DepartmentNo.Items.Count > 0 && com_DepartmentName.Items.Count > 0)
            {
                ComboBox cb = sender as ComboBox;
                com_DepartmentName.SelectedIndex = cb.SelectedIndex;
            }
        }

        private void com_DepartmentName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com_DepartmentNo.Items.Count > 0 && com_DepartmentName.Items.Count > 0)
            {
                ComboBox cb = sender as ComboBox;
                com_DepartmentNo.SelectedIndex = cb.SelectedIndex;
            }
        }

        private void com_DepartmentNo_Leave(object sender, EventArgs e)
        {
            GetGroupData(com_DepartmentNo.Text.Trim());
        }

        private void com_DepartmentName_Leave(object sender, EventArgs e)
        {
            GetGroupData(com_DepartmentNo.Text.Trim());
        }

        void GetGroupData(string DepartmentNo)
        {
            List<TimeAttendance_Department> list = TadBll.selectTimeAttendance_DepartmentParentDepartmentNoBll(DepartmentNo, "selectTimeAttendance_DepartmentParentDepartmentNo");
            List<string> strlist = new List<string>();
            List<string> strlist2 = new List<string>();

            foreach (TimeAttendance_Department item in list)
            {
                strlist.Add(item.DepartmentNo);
                strlist2.Add(item.DepartmentName);
            }

            com_GroupNo.DataSource = strlist;
            com_GroupName.DataSource = strlist2;

            com_GroupNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            com_GroupNo.AutoCompleteSource = AutoCompleteSource.ListItems;
            com_GroupName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            com_GroupName.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void com_GroupNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com_GroupNo.Items.Count > 0 && com_GroupName.Items.Count > 0)
            {
                ComboBox cb = sender as ComboBox;
                com_GroupName.SelectedIndex = cb.SelectedIndex;
            }
        }

        private void com_GroupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com_GroupNo.Items.Count > 0 && com_GroupName.Items.Count > 0)
            {
                ComboBox cb = sender as ComboBox;
                com_GroupNo.SelectedIndex = cb.SelectedIndex;
            }
        }

        private void com_GroupNo_Leave(object sender, EventArgs e)
        {
            GetLineData(com_GroupNo.Text.Trim());
        }

        private void com_GroupName_Leave(object sender, EventArgs e)
        {
            GetLineData(com_GroupNo.Text.Trim());
        }
        void GetLineData(string DepartmentNo)
        {
            List<TimeAttendance_Department> list = TadBll.selectTimeAttendance_DepartmentParentDepartmentNoBll(DepartmentNo, "selectTimeAttendance_DepartmentParentDepartmentNo");
            List<string> strlist = new List<string>();
            List<string> strlist2 = new List<string>();

            foreach (TimeAttendance_Department item in list)
            {
                strlist.Add(item.DepartmentNo);
                strlist2.Add(item.DepartmentName);
            }

            com_Line_No.DataSource = strlist;
            com_LineName.DataSource = strlist2;

            com_Line_No.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            com_Line_No.AutoCompleteSource = AutoCompleteSource.ListItems;
            com_LineName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            com_LineName.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void com_Line_No_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com_Line_No.Items.Count > 0 && com_LineName.Items.Count > 0)
            {
                ComboBox cb = sender as ComboBox;
                com_LineName.SelectedIndex = cb.SelectedIndex;
            }
        }

        private void com_LineName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com_Line_No.Items.Count > 0 && com_LineName.Items.Count > 0)
            {
                ComboBox cb = sender as ComboBox;
                com_Line_No.SelectedIndex = cb.SelectedIndex;
            }
        }

        private void 清卡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Message2()) return;
            MachineSelection msel = new MachineSelection("清卡", this.GetMachineSelectionModel());
            msel.ShowDialog();
        }

        private void 发卡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Message2()) return;
            MachineSelection msel = new MachineSelection("发卡", this.GetMachineSelectionModel());
            msel.ShowDialog();
        }

        List<MachineSelectionModel> GetMachineSelectionModel()
        {
            List<MachineSelectionModel> list = new List<MachineSelectionModel>();
            list.Add(new MachineSelectionModel()
            {
                ChineseName=txt_ChineseName.Text.Trim(),
                JobNumber=txt_JobNumber.Text.Trim(),
                LogicalCardNumber=txt_JobNumber.Text.Trim(),
                PhysicalCardNumber=txt_PhysicalCardNumber.Text.Trim()
            });
            return list;
        }


        bool Message2()
        {
            if (txt_JobNumber.Text.Trim() == "")
            {
                MessageBox.Show("工号不能为空!");
                return true;
            }
            else if (txt_PhysicalCardNumber.Text.Trim() == "")
            {
                MessageBox.Show("物理卡号不能为空!");
                return true;
            }
            else if (txt_ChineseName.Text.Trim() == "")
            {
                MessageBox.Show("姓名不能为空不能为空!");
                return true;
            }
            else return false;
        }

 
    }
}
