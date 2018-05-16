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

namespace Gce.pop_upWindows
{
    public partial class Create_ExceptionTypes : Office2007Form
    {
        private ExceptionConfiguration ExceptionForm;

        PExceptionTypesBll ptb = new PExceptionTypesBll();

        public Create_ExceptionTypes(ExceptionConfiguration f)
        {
            InitializeComponent();
            ExceptionForm = f;
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (!ptb.checkedPExceptionTypesBll(txt_ExceptionTypes.Text.Trim(), "checkedPExceptionTypes"))
            {
                if (ptb.insertPExceptionTypesBll(txt_ExceptionTypes.Text.Trim(), "insertPExceptionTypes"))
                {
                    ExceptionForm.SetcombList(txt_ExceptionTypes.Text.Trim());
                    this.Close();
                }
                else
                {
                    MessageBox.Show("保存错误");
                }
            }
            else
            {
                MessageBox.Show("该类型已存在!");
                return;
            }
        }
    }
}
