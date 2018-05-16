namespace Gce.pop_upWindows
{
    partial class UpdatePassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txt_OldPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_NewPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txt_DeterminePassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.btn_ok = new DevComponents.DotNetBar.ButtonX();
            this.btn_cancle = new DevComponents.DotNetBar.ButtonX();
            this.la_passwordCheck = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(76, 46);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(56, 18);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "旧密码：";
            // 
            // txt_OldPassword
            // 
            // 
            // 
            // 
            this.txt_OldPassword.Border.Class = "TextBoxBorder";
            this.txt_OldPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_OldPassword.Location = new System.Drawing.Point(127, 43);
            this.txt_OldPassword.Name = "txt_OldPassword";
            this.txt_OldPassword.PasswordChar = '*';
            this.txt_OldPassword.PreventEnterBeep = true;
            this.txt_OldPassword.Size = new System.Drawing.Size(172, 21);
            this.txt_OldPassword.TabIndex = 1;
            // 
            // txt_NewPassword
            // 
            // 
            // 
            // 
            this.txt_NewPassword.Border.Class = "TextBoxBorder";
            this.txt_NewPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_NewPassword.Location = new System.Drawing.Point(127, 96);
            this.txt_NewPassword.Name = "txt_NewPassword";
            this.txt_NewPassword.PasswordChar = '*';
            this.txt_NewPassword.PreventEnterBeep = true;
            this.txt_NewPassword.Size = new System.Drawing.Size(172, 21);
            this.txt_NewPassword.TabIndex = 3;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(76, 99);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(56, 18);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "新密码：";
            // 
            // txt_DeterminePassword
            // 
            // 
            // 
            // 
            this.txt_DeterminePassword.Border.Class = "TextBoxBorder";
            this.txt_DeterminePassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_DeterminePassword.Location = new System.Drawing.Point(127, 144);
            this.txt_DeterminePassword.Name = "txt_DeterminePassword";
            this.txt_DeterminePassword.PasswordChar = '*';
            this.txt_DeterminePassword.PreventEnterBeep = true;
            this.txt_DeterminePassword.Size = new System.Drawing.Size(172, 21);
            this.txt_DeterminePassword.TabIndex = 5;
            this.txt_DeterminePassword.Leave += new System.EventHandler(this.txt_DeterminePassword_Leave);
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(64, 147);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(68, 18);
            this.labelX3.TabIndex = 4;
            this.labelX3.Text = "确定密码：";
            // 
            // btn_ok
            // 
            this.btn_ok.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_ok.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_ok.Location = new System.Drawing.Point(64, 213);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_ok.TabIndex = 6;
            this.btn_ok.Text = "确定";
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancle
            // 
            this.btn_cancle.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_cancle.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_cancle.Location = new System.Drawing.Point(237, 213);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(75, 23);
            this.btn_cancle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_cancle.TabIndex = 7;
            this.btn_cancle.Text = "取消";
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // la_passwordCheck
            // 
            // 
            // 
            // 
            this.la_passwordCheck.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.la_passwordCheck.Location = new System.Drawing.Point(305, 147);
            this.la_passwordCheck.Name = "la_passwordCheck";
            this.la_passwordCheck.Size = new System.Drawing.Size(81, 18);
            this.la_passwordCheck.TabIndex = 8;
            // 
            // UpdatePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 262);
            this.Controls.Add(this.la_passwordCheck);
            this.Controls.Add(this.btn_cancle);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.txt_DeterminePassword);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.txt_NewPassword);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.txt_OldPassword);
            this.Controls.Add(this.labelX1);
            this.Name = "UpdatePassword";
            this.Text = "修改密码";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_OldPassword;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_NewPassword;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_DeterminePassword;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.ButtonX btn_ok;
        private DevComponents.DotNetBar.ButtonX btn_cancle;
        private DevComponents.DotNetBar.LabelX la_passwordCheck;
    }
}