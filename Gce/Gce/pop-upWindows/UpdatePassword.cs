using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gce_Common;
using Gce_Bll;

namespace Gce.pop_upWindows
{
    public partial class UpdatePassword : Office2007Form
    {
        UsersBll ub = new UsersBll();
        public UpdatePassword()
        {
            InitializeComponent();
        }

        private void txt_DeterminePassword_Leave(object sender, EventArgs e)
        {
            if (txt_NewPassword.Text == txt_DeterminePassword.Text)
            {
                la_passwordCheck.Text = "√";
                la_passwordCheck.ForeColor = Color.Green;
            }
            else
            {
                la_passwordCheck.Text = "密码不一致！";
                la_passwordCheck.ForeColor = Color.Red;
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (ub.GetMd5(txt_OldPassword.Text) != UsersHelp.Userslist[0].UserPassword)
            {
                MessageBox.Show("旧密码错误！");
                txt_OldPassword.Text = "";
                txt_OldPassword.Focus();
                return;
            }
            if (la_passwordCheck.Text == "密码不一致！")
            {
                MessageBox.Show("密码不一致");
                txt_DeterminePassword.Text = "";
                txt_DeterminePassword.Focus();
                return;
            }
            if (ub.UpdatePasswordBll(UsersHelp.Userslist[0].UserName, txt_NewPassword.Text.Trim(), "updateUsersPassword"))
            {
                MessageBox.Show("密码修改成功！");
                this.Close();
            }
            else
            {
                MessageBox.Show("密码修改失败！");
            }
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
