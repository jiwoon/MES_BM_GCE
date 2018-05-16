namespace Gce.pop_upWindows
{
    partial class ClassType
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
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txt_classType = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btni_new = new DevComponents.DotNetBar.ButtonItem();
            this.btni_save = new DevComponents.DotNetBar.ButtonItem();
            this.btni_cancle = new DevComponents.DotNetBar.ButtonItem();
            this.btni_delete = new DevComponents.DotNetBar.ButtonItem();
            this.btni_lookup = new DevComponents.DotNetBar.ButtonItem();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.txt_classType);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(167, 27);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(320, 327);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 38;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(31, 135);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(56, 18);
            this.labelX1.TabIndex = 18;
            this.labelX1.Text = "异常类型";
            // 
            // txt_classType
            // 
            // 
            // 
            // 
            this.txt_classType.Border.Class = "TextBoxBorder";
            this.txt_classType.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_classType.Location = new System.Drawing.Point(93, 132);
            this.txt_classType.Name = "txt_classType";
            this.txt_classType.PreventEnterBeep = true;
            this.txt_classType.Size = new System.Drawing.Size(157, 21);
            this.txt_classType.TabIndex = 16;
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
            this.btni_delete,
            this.btni_lookup});
            this.bar1.Location = new System.Drawing.Point(167, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(320, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 37;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btni_new
            // 
            this.btni_new.FontBold = true;
            this.btni_new.Name = "btni_new";
            this.btni_new.Text = "新建";
            this.btni_new.Click += new System.EventHandler(this.btni_new_Click);
            // 
            // btni_save
            // 
            this.btni_save.FontBold = true;
            this.btni_save.Name = "btni_save";
            this.btni_save.Text = "保存";
            this.btni_save.Click += new System.EventHandler(this.btni_save_Click);
            // 
            // btni_cancle
            // 
            this.btni_cancle.FontBold = true;
            this.btni_cancle.Name = "btni_cancle";
            this.btni_cancle.Text = "取消";
            this.btni_cancle.Click += new System.EventHandler(this.btni_cancle_Click);
            // 
            // btni_delete
            // 
            this.btni_delete.FontBold = true;
            this.btni_delete.Name = "btni_delete";
            this.btni_delete.Text = "删除";
            this.btni_delete.Click += new System.EventHandler(this.btni_delete_Click);
            // 
            // btni_lookup
            // 
            this.btni_lookup.FontBold = true;
            this.btni_lookup.Name = "btni_lookup";
            this.btni_lookup.Text = "查找";
            this.btni_lookup.Visible = false;
            this.btni_lookup.Click += new System.EventHandler(this.btni_lookup_Click);
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(167, 354);
            this.treeView1.TabIndex = 36;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // ClassType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 354);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.bar1);
            this.Controls.Add(this.treeView1);
            this.Name = "ClassType";
            this.Text = "定义异常类别";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ClassType_FormClosed);
            this.Load += new System.EventHandler(this.ClassType_Load);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_classType;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btni_new;
        private DevComponents.DotNetBar.ButtonItem btni_save;
        private DevComponents.DotNetBar.ButtonItem btni_cancle;
        private DevComponents.DotNetBar.ButtonItem btni_delete;
        private DevComponents.DotNetBar.ButtonItem btni_lookup;
        private System.Windows.Forms.TreeView treeView1;
    }
}