using DevComponents.DotNetBar;
using Gce_Bll;
using Gce_Common;
using Gce_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gce.Windows
{
    public partial class Login : Office2007Form
    {
        Gce g;
        List<Users> Loginlist = new List<Users>();
        UsersBll ub = new UsersBll();
        PUsers_FunctionBll pufb = new PUsers_FunctionBll();
        PUsers_Function_DetailedBll pufdb = new PUsers_Function_DetailedBll();
        public Login(Gce gce)
        {
            InitializeComponent();
            this.g = gce;
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (txt_UserName.Text == "")
            {
                MessageBox.Show("用户名不能为空!");
                return;
            }
            if (txt_Password.Text == "")
            {
                MessageBox.Show("密码不能为空!");
                return;
            }
            Loginlist = ub.UsersLoginBll(txt_UserName.Text.Trim(), ub.GetMd5(txt_Password.Text), "UsersLogin");

            if (Loginlist.Count > 0)
            {                
                UsersHelp.SetUsers(Loginlist,true,Loginlist[0].Limite,Loginlist[0].AddUser,Loginlist[0].systemAdimin);
                List<PUsers_Function> pufbList = pufb.selectPUsers_FunctionLoginBll("selectPUsers_FunctionLogin",txt_UserName.Text.Trim());//查询主功能权限
                Dictionary<string, Dictionary<string, bool>> pufbDic = new Dictionary<string, Dictionary<string, bool>>();
                pufbDic.Add("UserName", GetDic(pufbList, "PUsers_Function"));//主功能权限信息添加进字典集合
                UsersHelp.SetJurisdiction(pufbDic);

                List<PUsers_Function_Detailed> pufdbList = pufdb.selectPUsers_Function_DetailedLoginBll("selectPUsers_Function_DetailedLogin",txt_UserName.Text.Trim());
                foreach (PUsers_Function item in pufbList)
                {
                    Dictionary<string, Dictionary<string, bool>> pufdbDic = new Dictionary<string, Dictionary<string, bool>>();
                    pufdbDic.Add(item.FunctionName, GetDic(pufdbList, item.FunctionGUID));
                    UsersHelp.SetJurisdiction(pufdbDic);
                }

                g.Setbar_txtb_user(txt_UserName.Text.Trim());
                MessageBox.Show("登录成功!");
                this.Close();
            }
            else
            {
                MessageBox.Show("账号或密码错误");
                txt_Password.Text = "";
            }
        }
        /// <summary>
        /// 获取一个字典集合
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        Dictionary<string,bool> GetDic(object list,string listCalss)
        {
            Dictionary<string, bool> dic = new Dictionary<string, bool>();
            if (listCalss == "PUsers_Function")
            {
                List<PUsers_Function> list1 = list as List<PUsers_Function>;

                if (list1.Count > 0)
                {
                    foreach (PUsers_Function item in list1)
                    {
                        if (item.UserName.Trim() == txt_UserName.Text.Trim())
                        {
                            dic.Add(item.FunctionName, item.FunctionJurisdiction);
                        }
                    }
                    return dic;
                }
                else
                {
                    return dic;
                }
            }
            else
            {
                return dic;
            }
        }

        Dictionary<string, bool> GetDic(List<PUsers_Function_Detailed> list, string str)
        {
            Dictionary<string, bool> dic = new Dictionary<string, bool>();
            if (list.Count > 0)
            {
                foreach (PUsers_Function_Detailed item in list)
                {
                    if (item.FunctionGUID == str)
                    {
                        dic.Add(item.FunctionName, item.FunctionJurisdiction);
                    }
                }
                return dic;
            }
            else
            {
                return dic;
            }
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
