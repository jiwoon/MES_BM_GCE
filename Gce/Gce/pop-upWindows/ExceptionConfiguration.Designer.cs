namespace Gce.pop_upWindows
{
    partial class ExceptionConfiguration
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.btni_new = new DevComponents.DotNetBar.ButtonItem();
            this.btni_save = new DevComponents.DotNetBar.ButtonItem();
            this.btni_cancle = new DevComponents.DotNetBar.ButtonItem();
            this.btni_modify = new DevComponents.DotNetBar.ButtonItem();
            this.btni_delete = new DevComponents.DotNetBar.ButtonItem();
            this.btni_createType = new DevComponents.DotNetBar.ButtonItem();
            this.btni_lookup = new DevComponents.DotNetBar.ButtonItem();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txt_BarcodeEncoding = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_ProblemDescription = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.comb_ExceptionTypes = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(153, 286);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btni_new,
            this.btni_save,
            this.btni_cancle,
            this.btni_modify,
            this.btni_delete,
            this.btni_createType,
            this.btni_lookup});
            this.bar1.Location = new System.Drawing.Point(153, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(302, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 1;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.comb_ExceptionTypes);
            this.panelEx1.Controls.Add(this.txt_ProblemDescription);
            this.panelEx1.Controls.Add(this.txt_BarcodeEncoding);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(153, 27);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(302, 259);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 2;
            // 
            // btni_new
            // 
            this.btni_new.Name = "btni_new";
            this.btni_new.Text = "新建";
            this.btni_new.Click += new System.EventHandler(this.btni_new_Click);
            // 
            // btni_save
            // 
            this.btni_save.Name = "btni_save";
            this.btni_save.Text = "保存";
            this.btni_save.Click += new System.EventHandler(this.btni_save_Click);
            // 
            // btni_cancle
            // 
            this.btni_cancle.Name = "btni_cancle";
            this.btni_cancle.Text = "取消";
            this.btni_cancle.Click += new System.EventHandler(this.btni_cancle_Click);
            // 
            // btni_modify
            // 
            this.btni_modify.Name = "btni_modify";
            this.btni_modify.Text = "修改";
            this.btni_modify.Click += new System.EventHandler(this.btni_modify_Click);
            // 
            // btni_delete
            // 
            this.btni_delete.Name = "btni_delete";
            this.btni_delete.Text = "删除";
            this.btni_delete.Click += new System.EventHandler(this.btni_delete_Click);
            // 
            // btni_createType
            // 
            this.btni_createType.Name = "btni_createType";
            this.btni_createType.Text = "创建类型";
            this.btni_createType.Click += new System.EventHandler(this.btni_createType_Click);
            // 
            // btni_lookup
            // 
            this.btni_lookup.Name = "btni_lookup";
            this.btni_lookup.Text = "查找";
            this.btni_lookup.Click += new System.EventHandler(this.btni_lookup_Click);
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(22, 18);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(56, 18);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "异常编码";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(22, 112);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(56, 18);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "问题描述";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(22, 68);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(56, 18);
            this.labelX3.TabIndex = 2;
            this.labelX3.Text = "问题类型";
            // 
            // txt_BarcodeEncoding
            // 
            // 
            // 
            // 
            this.txt_BarcodeEncoding.Border.Class = "TextBoxBorder";
            this.txt_BarcodeEncoding.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_BarcodeEncoding.Location = new System.Drawing.Point(84, 15);
            this.txt_BarcodeEncoding.Name = "txt_BarcodeEncoding";
            this.txt_BarcodeEncoding.PreventEnterBeep = true;
            this.txt_BarcodeEncoding.Size = new System.Drawing.Size(190, 21);
            this.txt_BarcodeEncoding.TabIndex = 3;
            // 
            // txt_ProblemDescription
            // 
            // 
            // 
            // 
            this.txt_ProblemDescription.Border.Class = "TextBoxBorder";
            this.txt_ProblemDescription.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_ProblemDescription.Location = new System.Drawing.Point(84, 114);
            this.txt_ProblemDescription.Multiline = true;
            this.txt_ProblemDescription.Name = "txt_ProblemDescription";
            this.txt_ProblemDescription.PreventEnterBeep = true;
            this.txt_ProblemDescription.Size = new System.Drawing.Size(190, 138);
            this.txt_ProblemDescription.TabIndex = 4;
            // 
            // comb_ExceptionTypes
            // 
            this.comb_ExceptionTypes.DisplayMember = "Text";
            this.comb_ExceptionTypes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comb_ExceptionTypes.FormattingEnabled = true;
            this.comb_ExceptionTypes.ItemHeight = 15;
            this.comb_ExceptionTypes.Location = new System.Drawing.Point(84, 65);
            this.comb_ExceptionTypes.Name = "comb_ExceptionTypes";
            this.comb_ExceptionTypes.Size = new System.Drawing.Size(190, 21);
            this.comb_ExceptionTypes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comb_ExceptionTypes.TabIndex = 5;
            // 
            // ExceptionConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 286);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.bar1);
            this.Controls.Add(this.treeView1);
            this.MaximizeBox = false;
            this.Name = "ExceptionConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "异常配置";
            this.Load += new System.EventHandler(this.ExceptionConfiguration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonItem btni_new;
        private DevComponents.DotNetBar.ButtonItem btni_save;
        private DevComponents.DotNetBar.ButtonItem btni_cancle;
        private DevComponents.DotNetBar.ButtonItem btni_modify;
        private DevComponents.DotNetBar.ButtonItem btni_delete;
        private DevComponents.DotNetBar.ButtonItem btni_createType;
        private DevComponents.DotNetBar.ButtonItem btni_lookup;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comb_ExceptionTypes;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_ProblemDescription;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_BarcodeEncoding;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
    }
}