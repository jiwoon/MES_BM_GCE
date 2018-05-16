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
using Gce_Bll;
using Gce_Common;
using Gce_Model;

namespace Gce.pop_upWindows
{
    public partial class AddUser : Office2007Form
    {
        UsersBll ub = new UsersBll();
        PFunctionMenuBll PFmenuBll = new PFunctionMenuBll();
        PUsers_FunctionBll pufb = new PUsers_FunctionBll();
        PUsers_Function_DetailedBll pufdb = new PUsers_Function_DetailedBll();

        bool checkUserName = false;
        bool checkPassword = false;
        public AddUser()
        {
            InitializeComponent();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            this.LoadAddUser();
            this.SetCombobox();
        }

        void SetCombobox()
        {
            List<PFunctionMenu> pfmList = PFmenuBll.selectPFunctionMenuFID00Bll("selectPFunctionMenuFID00");

            if (!(pfmList.Count > 0))
            {
                return;
            }
            List<string> strlist = new List<string>();
            strlist.Add("无");
            foreach (PFunctionMenu item in pfmList)
            {
                strlist.Add(item.FunctionName.Replace("管理", ""));
            }

            comb_Department.DataSource = strlist;

            comb_Department.SelectedItem = comb_Department.Items[0];
        }
        private void txt_UserName_Leave(object sender, EventArgs e)
        {
            if (txt_UserName.Text != "")
            {
                if (!ub.checkUserNemeBll(txt_UserName.Text.Trim(), "checkUserNeme"))
                {
                    lb_usersCheck.Text = "√";
                    lb_usersCheck.ForeColor = Color.Green;
                    checkUserName = true;
                }
                else
                {
                    lb_usersCheck.Text = "用户名已存在！";
                    lb_usersCheck.ForeColor = Color.Red;
                    checkUserName = false;
                }

            }
            else
            {
                lb_usersCheck.Text = "请输入用户名";
                lb_usersCheck.ForeColor = Color.Red;
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_Password2_Leave(object sender, EventArgs e)
        {
            if (txt_Password.Text == txt_Password2.Text && txt_Password2.Text != "")
            {
                lb_checkPassword.Text = "√";
                lb_checkPassword.ForeColor = Color.Green;
                checkPassword = true;
            }
            else if (txt_Password2.Text=="")
            {
                lb_checkPassword.Text = "确认密码不能为空！";
                lb_checkPassword.ForeColor = Color.Red;
                checkPassword = false;
            }
            else
            {
                lb_checkPassword.Text = "密码不一致！";
                lb_checkPassword.ForeColor = Color.Red;
                checkPassword = false;
            }
        }
        private void LoadAddUser()
        {

        }

        private void btn_registered_Click(object sender, EventArgs e)
        {
            if (!checkUserName)
            {
                MessageBox.Show("用户名已存在!");
                return;
            }
            if (!checkPassword)
            {
                MessageBox.Show("密码不一致");
                return;
            }
            List<Users> list = new List<Users>();
            list.Add(new Users() { 
                UserName = txt_UserName.Text.Trim(),
                UserPassword = ub.GetMd5(txt_Password.Text),
                systemAdimin = false,
                Limite = false,
                Department=comb_Department.Text.Trim()=="无"?"":comb_Department.Text.Trim(),
                AddUser=false
            });
            try
            {
                if (ub.insertUsersBll(list, "insertUsers"))
                {
                    foreach (PFunctionMenu item in PFmenuBll.selectPFunctionMenuFID0Bll("selectPFunctionMenuFID0"))//次级功能权限名
                    {
                        Guid guid = Guid.NewGuid();
                        List<PUsers_Function> pufList = new List<PUsers_Function>();
                        pufList.Add(new PUsers_Function
                        {
                            UserName=list[0].UserName,
                            FunctionName=item.FunctionName,
                            FunctionJurisdiction=false,
                            FunctionGUID=guid.ToString()
                        });
                        if (!pufb.insertPUsers_FunctionBll(pufList, "insertPUsers_Function"))
                        {
                        }
                        foreach (PFunctionMenu item1 in PFmenuBll.selectPFunctionMenuFID0Bll("selectPFunctionMenuFID01"))//最下级功能权限名
                        {
                            if (item1.FID == item.ID)
                            {
                                List<PUsers_Function_Detailed> pufdList = new List<PUsers_Function_Detailed>();
                                pufdList.Add(new PUsers_Function_Detailed()
                                {
                                    UserName=list[0].UserName,
                                    FunctionName=item1.FunctionName,
                                    FunctionJurisdiction=false,
                                    FunctionGUID=guid.ToString()
                                });
                                if (pufdb.insertPUsers_Function_DetailedBll(pufdList, "insertPUsers_Function_Detailed"))
                                {                                         
                                }
                            }
                        }
                    }

                    MessageBox.Show("注册成功！");
                    this.ClearTxt();
                }
                else
                {
                    MessageBox.Show("注册失败！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        void ClearTxt()
        {
            txt_UserName.Text = "";
            txt_Password.Text = "";
            txt_Password2.Text = "";
            comb_Department.SelectedItem = comb_Department.Items[0];
        }
        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxX1.Checked)
            {
                txt_Password.PasswordChar = new char();
                txt_Password2.PasswordChar = new char();
            }
            else
            {
                txt_Password.PasswordChar = '*';
                txt_Password2.PasswordChar = '*';
            }
        }
    }
}
