namespace Gce.pop_upWindows
{
    partial class Create_ExceptionTypes
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
            this.txt_ExceptionTypes = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.btn_Ok = new DevComponents.DotNetBar.ButtonX();
            this.btn_cancle = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // txt_ExceptionTypes
            // 
            // 
            // 
            // 
            this.txt_ExceptionTypes.Border.Class = "TextBoxBorder";
            this.txt_ExceptionTypes.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_ExceptionTypes.Location = new System.Drawing.Point(89, 33);
            this.txt_ExceptionTypes.Name = "txt_ExceptionTypes";
            this.txt_ExceptionTypes.PreventEnterBeep = true;
            this.txt_ExceptionTypes.Size = new System.Drawing.Size(157, 21);
            this.txt_ExceptionTypes.TabIndex = 0;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(27, 36);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(56, 18);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "异常类型";
            // 
            // btn_Ok
            // 
            this.btn_Ok.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_Ok.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_Ok.Location = new System.Drawing.Point(36, 81);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 23);
            this.btn_Ok.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_Ok.TabIndex = 2;
            this.btn_Ok.Text = "完成";
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // btn_cancle
            // 
            this.btn_cancle.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_cancle.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_cancle.Location = new System.Drawing.Point(171, 81);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(75, 23);
            this.btn_cancle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_cancle.TabIndex = 3;
            this.btn_cancle.Text = "取消";
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // Create_ExceptionTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 106);
            this.Controls.Add(this.btn_cancle);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.txt_ExceptionTypes);
            this.Name = "Create_ExceptionTypes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "创建异常类型";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txt_ExceptionTypes;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX btn_Ok;
        private DevComponents.DotNetBar.ButtonX btn_cancle;
    }
}