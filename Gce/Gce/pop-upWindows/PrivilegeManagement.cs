using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gce_Bll;
using Gce_Common;
using Gce_Model;
using DevComponents.DotNetBar.Controls;

namespace Gce.pop_upWindows
{
    public partial class PrivilegeManagement : Office2007Form
    {
        UsersBll ub = new UsersBll();
        PUsers_FunctionBll puf = new PUsers_FunctionBll();
        PUsers_Function_DetailedBll pufd = new PUsers_Function_DetailedBll();

        List<Users> UList = new List<Users>();
        List<PUsers_Function> pufList = new List<PUsers_Function>();
        List<PUsers_Function_Detailed> pufdList = new List<PUsers_Function_Detailed>();
        List<string> strList = new List<string>();

        Dictionary<string, List<PUsers_Function>> pufDic = new Dictionary<string, List<PUsers_Function>>();
        Dictionary<string, List<PUsers_Function_Detailed>> pufdDic = new Dictionary<string, List<PUsers_Function_Detailed>>();

        string state = "browse";
        public PrivilegeManagement()
        {
            InitializeComponent();
        }

        private void PrivilegeManagement_Load(object sender, EventArgs e)
        {
            this.GetData();
            this.SetTreeview();
            this.UpdateControls();
        }

        void SetsuperTabControl1(List<PUsers_Function> puflist,List<PUsers_Function_Detailed> pufdlist,bool limite,bool adduser)
        {
            superTabControl1.Tabs.Clear();

            List<string> strlist = new List<string>();

            foreach (PUsers_Function item in puflist)
            {
                if (!strlist.Contains(item.FunctionName))
                {
                    SuperTabItem tabItem = superTabControl1.CreateTab(item.FunctionName);
                    tabItem.Text = item.FunctionName;
                    tabItem.Tag = item.FunctionGUID;

                    CheckBoxX check = new CheckBoxX();
                    check.Text = item.FunctionName;
                    check.Tag = item.FunctionGUID;
                    check.Checked = item.FunctionJurisdiction;
                    check.CheckBoxPosition = eCheckBoxPosition.Right;
                    check.Location = new Point(17,20);
                    check.Width = 100;
                    check.Height = 23;
                    check.AutoSize = true;
                    check.Visible = true;

                    check.CheckValueChanged += new EventHandler(check_CheckValueChanged);
                    check.Click += check_Click;
                    

                    tabItem.AttachedControl.Controls.Add(check);

                    int YY = 80;
                    foreach (PUsers_Function_Detailed item1 in pufdlist)
                    {
                        if (item.FunctionGUID == item1.FunctionGUID)
                        {
                            YY += 40;

                            CheckBoxX check1 = new CheckBoxX();
                            check1.Text = item1.FunctionName;
                            check1.Tag = item1.FunctionGUID;
                            check1.Name = item.FunctionName;
                            check1.Checked = item1.FunctionJurisdiction;
                            check1.CheckBoxPosition = eCheckBoxPosition.Right;
                            check1.Location = new Point(17, YY);
                            check1.Width = 100;
                            check1.Height = 23;
                            check1.AutoSize = true;
                            check1.Visible = true;
                            check1.Enabled = check.Checked;

                            check1.Click += check1_Click;      

                            tabItem.AttachedControl.Controls.Add(check1);
                        }
                    }
                }

                strlist.Add(item.FunctionName);
            }
            SuperTabItem tabItem1 = superTabControl1.CreateTab("其他");
            tabItem1.Text = "其他";

            CheckBoxX check2 = new CheckBoxX();
            check2.Text = "赋予权限";
            check2.Checked = limite;
            check2.CheckBoxPosition = eCheckBoxPosition.Right;
            check2.Location = new Point(17, 20);
            check2.Width = 100;
            check2.Height = 23;
            check2.AutoSize = true;
            check2.Visible = true;

            check2.Click += check2_Click;

            tabItem1.AttachedControl.Controls.Add(check2);

            CheckBoxX check3 = new CheckBoxX();
            check3.Text = "添加用户";
            check3.Checked = adduser;
            check3.CheckBoxPosition = eCheckBoxPosition.Right;
            check3.Location = new Point(17, 60);
            check3.Width = 100;
            check3.Height = 23;
            check3.AutoSize = true;
            check3.Visible = true;

            check3.Click += check3_Click;

            tabItem1.AttachedControl.Controls.Add(check3);
        }

        void check2_Click(object sender, EventArgs e)
        {
            CheckBoxX cb = (CheckBoxX)sender;
            if (!(UsersHelp.systemAdimin||UsersHelp.Limite))
            {
                MessageBox.Show("您没有此权限，所以您也不能赋予其他账号此权限！");
                cb.AutoCheck = false;
                return;
            }
        }

        void check3_Click(object sender, EventArgs e)
        {
            CheckBoxX cb = (CheckBoxX)sender;
            if (!(UsersHelp.systemAdimin||UsersHelp.AddUser))
            {
                MessageBox.Show("您没有此权限，所以您也不能赋予其他账号此权限！");
                cb.AutoCheck = false;
                return;
            }
        }

        void check1_Click(object sender, EventArgs e)
        {
            CheckBoxX cb = (CheckBoxX)sender;
            if (!(UsersHelp.systemAdimin || (UsersHelp.ChildDic.Count > 0 ? UsersHelp.ChildDic[cb.Name][cb.Text.Trim()] : false)))
            {
                MessageBox.Show("您没有此权限，所以您也不能赋予其他账号此权限！");
                cb.AutoCheck = false;
                return;
            }
        }

        void check_Click(object sender, EventArgs e)
        {
            CheckBoxX cb = (CheckBoxX)sender;
            if (!(UsersHelp.systemAdimin || (UsersHelp.ParentDic.Count > 0 ? UsersHelp.ParentDic[cb.Text.Trim()] : false)))
            {
                MessageBox.Show("您没有此权限，所以您也不能赋予其他账号此权限！");
                cb.AutoCheck = false;
                return;
            }
        }

        void check_CheckValueChanged(object sender, EventArgs e)
        {
            CheckBoxX cb = (CheckBoxX)sender;

            foreach (SuperTabItem item in superTabControl1.Tabs)
            {
                if (item.Text == cb.Text)
                {
                    foreach (CheckBoxX item1 in item.AttachedControl.Controls)
                    {
                        if (item1.Text != cb.Text)
                        {
                            item1.Enabled = cb.Checked;
                            if (!cb.Checked)
                            {
                                item1.Checked = cb.Checked;
                            }
                        }
                    }
                }
            }           
        }
        /// <summary>
        /// 加载TreeView
        /// </summary>
        void SetTreeview()
        {
            treeView1.Nodes.Clear();

            TreeNode tn = new TreeNode();
            tn.Text = "用户名";
            treeView1.Nodes.Add(tn);
            for (int i = 0; i < strList.Count; i++)
            {
                if (strList[i] == "")
                {
                    continue;
                }
                TreeNode tnChild = new TreeNode();
                tnChild.Text = strList[i];
                tnChild.Tag = i;
                tn.Nodes.Add(tnChild);

                for (int j = 0; j < UList.Count; j++)
                {
                    if (UList[j].Department == strList[i])
                    {
                        TreeNode tnChild1 = new TreeNode();
                        tnChild1.Text = UList[j].UserName;
                        tnChild1.Tag = j;
                        tnChild.Nodes.Add(tnChild1);
                    }
                    if (UList[j].Department == "" && strList[i] == "其他")
                    {
                        TreeNode tnChild1 = new TreeNode();
                        tnChild1.Text = UList[j].UserName;
                        tnChild1.Tag = j;
                        tnChild.Nodes.Add(tnChild1);
                    }
                }
            }
            
            treeView1.SelectedNode = treeView1.Nodes[0].LastNode;

        }

        void GetData()
        {
            UList.Clear();
            pufdList.Clear();
            pufList.Clear();
            strList.Clear();
            pufDic.Clear();
            pufdDic.Clear();

            UList = ub.selectPUsersBll("selectPUsersNotSystemAdimin");
            pufList = puf.selectPUsers_FunctionBll("selectPUsers_Function");
            pufdList = pufd.selectPUsers_Function_DetailedBll("selectPUsers_Function_Detailed");
            strList = ub.selectDistinctPUsersBll("selectDistinctPUsers");
            strList.Add("其他");

            foreach (Users item in UList)
            {
                List<PUsers_Function> list = new List<PUsers_Function>();
                List<PUsers_Function_Detailed> list1 = new List<PUsers_Function_Detailed>();
                foreach (PUsers_Function pufl in pufList)
                {
                    if (item.UserName == pufl.UserName)
                    {                        
                        list.Add(pufl);                        
                    }                    
                }
                pufDic.Add(item.UserName, list);
                foreach (PUsers_Function_Detailed pufdl in pufdList)
                {
                    if (item.UserName == pufdl.UserName)
                    {
                        list1.Add(pufdl);
                    }

                }
                pufdDic.Add(item.UserName, list1);
            }

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode tn = e.Node;

            if (!(tn.Nodes.Count > 0))
            {
                this.SetsuperTabControl1(pufDic[e.Node.Text.Trim()], pufdDic[e.Node.Text.Trim()], UList[Convert.ToInt32(e.Node.Tag)].Limite, UList[Convert.ToInt32(e.Node.Tag)].AddUser);
                this.labelItem1.Text = tn.Text.Trim();
            }
        }

        void UpdateControls()
        {
            switch (state)
            {
                case "browse":
                    btni_save.Enabled = false;
                    btni_cancle.Enabled = false;
                    btni_modify.Enabled = true;

                    treeView1.Enabled = true;
                    
                    //superTabControl1.Enabled = false;
                    break;
                case "modify":
                    btni_save.Enabled = true;
                    btni_cancle.Enabled = true;
                    btni_modify.Enabled = false;

                    treeView1.Enabled = false;
                    
                    //superTabControl1.Enabled = true;
                    break;
            }
        }
        private void btni_save_Click(object sender, EventArgs e)
        {
            this.UpdateJurisdiction();

            state = "browse";
            this.GetData();
            this.SetTreeview();
            MessageBox.Show("完成");
            this.UpdateControls();
        }

        private void bytni_cancle_Click(object sender, EventArgs e)
        {
            state = "browse";

            this.UpdateControls();
        }

        private void btni_modify_Click(object sender, EventArgs e)
        {
            state = "modify";

            UpdateControls();
        }

        private void btni_looupk_Click(object sender, EventArgs e)
        {

        }

        void UpdateJurisdiction()
        {
            try
            {
                foreach (SuperTabItem item in superTabControl1.Tabs)
                {
                    List<PUsers_Function> puflist = new List<PUsers_Function>();
                    CheckBoxX cb = (CheckBoxX)item.AttachedControl.Controls[0];

                    if (item.Text == "其他")
                    {
                        ub.updatePUsersBll(treeView1.SelectedNode.Text.Trim(), cb.Checked, "updatePUsersLimite");
                    }
                    else
                    {
                        puflist.Add(new PUsers_Function()
                        {
                            UserName = treeView1.SelectedNode.Text.Trim(),
                            FunctionName = cb.Text.Trim(),
                            FunctionJurisdiction = cb.Checked,
                            FunctionGUID = cb.Tag.ToString()
                        });
                        try
                        {
                            puf.updatePUsers_FunctionBll(puflist, "updatePUsers_Function");
                        }
                        catch
                        {
                            puf.insertPUsers_FunctionBll(puflist, "insertPUsers_Function");
                        }
                        
                    }
                    for (int i = 1; i < item.AttachedControl.Controls.Count; i++)
                    {
                        List<PUsers_Function_Detailed> pufdlist = new List<PUsers_Function_Detailed>();
                        CheckBoxX cb1 = (CheckBoxX)item.AttachedControl.Controls[i];
                        if (item.Text == "其他")
                        {
                            ub.updatePUsersBll(treeView1.SelectedNode.Text.Trim(), cb1.Checked, "updatePUsersAddUser");
                        }
                        else
                        {
                            pufdlist.Add(new PUsers_Function_Detailed()
                            {
                                UserName = treeView1.SelectedNode.Text.Trim(),
                                FunctionName = cb1.Text.Trim(),
                                FunctionJurisdiction = cb1.Checked,
                                FunctionGUID = cb1.Tag.ToString()
                            });
                            try
                            {
                                pufd.updatePUsers_Function_DetailedBll(pufdlist, "updatePUsers_Function_Detailed");
                            }
                            catch
                            {
                                pufd.insertPUsers_Function_DetailedBll(pufdlist, "insertPUsers_Function_Detailed");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
