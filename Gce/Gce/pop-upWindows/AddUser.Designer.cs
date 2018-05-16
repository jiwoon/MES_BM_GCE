namespace Gce.pop_upWindows
{
    partial class AddUser
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
            this.txt_UserName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_Password = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txt_Password2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.btn_registered = new DevComponents.DotNetBar.ButtonX();
            this.btn_cancel = new DevComponents.DotNetBar.ButtonX();
            this.lb_usersCheck = new DevComponents.DotNetBar.LabelX();
            this.lb_checkPassword = new DevComponents.DotNetBar.LabelX();
            this.checkBoxX1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.comb_Department = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(72, 35);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(56, 18);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "用户名：";
            // 
            // txt_UserName
            // 
            // 
            // 
            // 
            this.txt_UserName.Border.Class = "TextBoxBorder";
            this.txt_UserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_UserName.Location = new System.Drawing.Point(141, 30);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.PreventEnterBeep = true;
            this.txt_UserName.Size = new System.Drawing.Size(147, 21);
            this.txt_UserName.TabIndex = 1;
            this.txt_UserName.Leave += new System.EventHandler(this.txt_UserName_Leave);
            // 
            // txt_Password
            // 
            // 
            // 
            // 
            this.txt_Password.Border.Class = "TextBoxBorder";
            this.txt_Password.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_Password.Location = new System.Drawing.Point(141, 75);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.PasswordChar = '*';
            this.txt_Password.PreventEnterBeep = true;
            this.txt_Password.Size = new System.Drawing.Size(147, 21);
            this.txt_Password.TabIndex = 3;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(72, 78);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(56, 18);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "密  码：";
            // 
            // txt_Password2
            // 
            // 
            // 
            // 
            this.txt_Password2.Border.Class = "TextBoxBorder";
            this.txt_Password2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_Password2.Location = new System.Drawing.Point(141, 115);
            this.txt_Password2.Name = "txt_Password2";
            this.txt_Password2.PasswordChar = '*';
            this.txt_Password2.PreventEnterBeep = true;
            this.txt_Password2.Size = new System.Drawing.Size(147, 21);
            this.txt_Password2.TabIndex = 5;
            this.txt_Password2.Leave += new System.EventHandler(this.txt_Password2_Leave);
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(60, 118);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(68, 18);
            this.labelX3.TabIndex = 4;
            this.labelX3.Text = "确定密码：";
            // 
            // btn_registered
            // 
            this.btn_registered.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_registered.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_registered.Location = new System.Drawing.Point(53, 214);
            this.btn_registered.Name = "btn_registered";
            this.btn_registered.Size = new System.Drawing.Size(75, 23);
            this.btn_registered.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_registered.TabIndex = 6;
            this.btn_registered.Text = "注册";
            this.btn_registered.Click += new System.EventHandler(this.btn_registered_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_cancel.Location = new System.Drawing.Point(266, 214);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_cancel.TabIndex = 7;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // lb_usersCheck
            // 
            // 
            // 
            // 
            this.lb_usersCheck.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lb_usersCheck.Location = new System.Drawing.Point(294, 33);
            this.lb_usersCheck.Name = "lb_usersCheck";
            this.lb_usersCheck.Size = new System.Drawing.Size(105, 18);
            this.lb_usersCheck.TabIndex = 18;
            // 
            // lb_checkPassword
            // 
            // 
            // 
            // 
            this.lb_checkPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lb_checkPassword.Location = new System.Drawing.Point(290, 118);
            this.lb_checkPassword.Name = "lb_checkPassword";
            this.lb_checkPassword.Size = new System.Drawing.Size(121, 18);
            this.lb_checkPassword.TabIndex = 19;
            // 
            // checkBoxX1
            // 
            this.checkBoxX1.AutoSize = true;
            // 
            // 
            // 
            this.checkBoxX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX1.Location = new System.Drawing.Point(141, 187);
            this.checkBoxX1.Name = "checkBoxX1";
            this.checkBoxX1.Size = new System.Drawing.Size(76, 18);
            this.checkBoxX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX1.TabIndex = 24;
            this.checkBoxX1.Text = "显示密码";
            this.checkBoxX1.CheckedChanged += new System.EventHandler(this.checkBoxX1_CheckedChanged);
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(72, 160);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(56, 18);
            this.labelX4.TabIndex = 26;
            this.labelX4.Text = "部  门：";
            // 
            // comb_Department
            // 
            this.comb_Department.DisplayMember = "Text";
            this.comb_Department.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comb_Department.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comb_Department.FormattingEnabled = true;
            this.comb_Department.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comb_Department.ItemHeight = 15;
            this.comb_Department.Location = new System.Drawing.Point(141, 160);
            this.comb_Department.Name = "comb_Department";
            this.comb_Department.Size = new System.Drawing.Size(147, 21);
            this.comb_Department.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comb_Department.TabIndex = 25;
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 262);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.comb_Department);
            this.Controls.Add(this.checkBoxX1);
            this.Controls.Add(this.lb_checkPassword);
            this.Controls.Add(this.lb_usersCheck);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_registered);
            this.Controls.Add(this.txt_Password2);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.txt_UserName);
            this.Controls.Add(this.labelX1);
            this.MaximizeBox = false;
            this.Name = "AddUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加用户";
            this.Load += new System.EventHandler(this.AddUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_UserName;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_Password;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_Password2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.ButtonX btn_registered;
        private DevComponents.DotNetBar.ButtonX btn_cancel;
        private DevComponents.DotNetBar.LabelX lb_usersCheck;
        private DevComponents.DotNetBar.LabelX lb_checkPassword;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX1;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comb_Department;
    }
}