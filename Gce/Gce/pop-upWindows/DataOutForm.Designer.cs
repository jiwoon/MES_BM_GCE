namespace Gce.pop_upWindows
{
    partial class DataOutForm
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
            this.comb_Type = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.inter_Min = new DevComponents.Editors.IntegerInput();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.check_BlankLine = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btn_Ok = new DevComponents.DotNetBar.ButtonX();
            this.btn_cancle = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.inter_Min)).BeginInit();
            this.SuspendLayout();
            // 
            // comb_Type
            // 
            this.comb_Type.DisplayMember = "Text";
            this.comb_Type.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comb_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comb_Type.FormattingEnabled = true;
            this.comb_Type.ItemHeight = 15;
            this.comb_Type.Location = new System.Drawing.Point(115, 28);
            this.comb_Type.Name = "comb_Type";
            this.comb_Type.Size = new System.Drawing.Size(163, 21);
            this.comb_Type.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comb_Type.TabIndex = 0;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(53, 31);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(56, 18);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "导出工位";
            // 
            // inter_Min
            // 
            // 
            // 
            // 
            this.inter_Min.BackgroundStyle.Class = "DateTimeInputBackground";
            this.inter_Min.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.inter_Min.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.inter_Min.Location = new System.Drawing.Point(115, 66);
            this.inter_Min.MinValue = 0;
            this.inter_Min.Name = "inter_Min";
            this.inter_Min.ShowUpDown = true;
            this.inter_Min.Size = new System.Drawing.Size(163, 21);
            this.inter_Min.TabIndex = 2;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(53, 69);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(56, 18);
            this.labelX2.TabIndex = 3;
            this.labelX2.Text = "最 小 值";
            // 
            // check_BlankLine
            // 
            this.check_BlankLine.AutoSize = true;
            // 
            // 
            // 
            this.check_BlankLine.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.check_BlankLine.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Right;
            this.check_BlankLine.Location = new System.Drawing.Point(115, 102);
            this.check_BlankLine.Name = "check_BlankLine";
            this.check_BlankLine.Size = new System.Drawing.Size(76, 18);
            this.check_BlankLine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.check_BlankLine.TabIndex = 4;
            this.check_BlankLine.Text = "间隔空行";
            // 
            // btn_Ok
            // 
            this.btn_Ok.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_Ok.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_Ok.Location = new System.Drawing.Point(44, 137);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 23);
            this.btn_Ok.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_Ok.TabIndex = 5;
            this.btn_Ok.Text = "确定";
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // btn_cancle
            // 
            this.btn_cancle.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_cancle.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_cancle.Location = new System.Drawing.Point(225, 137);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(75, 23);
            this.btn_cancle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_cancle.TabIndex = 6;
            this.btn_cancle.Text = "取消";
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // DataOutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 172);
            this.Controls.Add(this.btn_cancle);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.check_BlankLine);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.inter_Min);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.comb_Type);
            this.MaximizeBox = false;
            this.Name = "DataOutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据导出条件选择";
            this.Load += new System.EventHandler(this.DataOutForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.inter_Min)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ComboBoxEx comb_Type;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.Editors.IntegerInput inter_Min;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.CheckBoxX check_BlankLine;
        private DevComponents.DotNetBar.ButtonX btn_cancle;
        private DevComponents.DotNetBar.ButtonX btn_Ok;
    }
}