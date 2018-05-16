namespace Gce.pop_upWindows
{
    partial class PrivilegeManagement
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
            this.btni_save = new DevComponents.DotNetBar.ButtonItem();
            this.btni_cancle = new DevComponents.DotNetBar.ButtonItem();
            this.btni_modify = new DevComponents.DotNetBar.ButtonItem();
            this.btni_looupk = new DevComponents.DotNetBar.ButtonItem();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(197, 450);
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
            this.btni_save,
            this.btni_cancle,
            this.btni_modify,
            this.btni_looupk,
            this.labelItem1});
            this.bar1.Location = new System.Drawing.Point(197, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(596, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 1;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
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
            this.btni_cancle.Click += new System.EventHandler(this.bytni_cancle_Click);
            // 
            // btni_modify
            // 
            this.btni_modify.Name = "btni_modify";
            this.btni_modify.Text = "修改权限";
            this.btni_modify.Click += new System.EventHandler(this.btni_modify_Click);
            // 
            // btni_looupk
            // 
            this.btni_looupk.Name = "btni_looupk";
            this.btni_looupk.Text = "查找";
            this.btni_looupk.Visible = false;
            this.btni_looupk.Click += new System.EventHandler(this.btni_looupk_Click);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.superTabControl1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(197, 27);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(596, 423);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 2;
            // 
            // superTabControl1
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl1.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl1.ControlBox.MenuBox.Name = "";
            this.superTabControl1.ControlBox.Name = "";
            this.superTabControl1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl1.ControlBox.MenuBox,
            this.superTabControl1.ControlBox.CloseBox});
            this.superTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.superTabControl1.Location = new System.Drawing.Point(0, 0);
            this.superTabControl1.Name = "superTabControl1";
            this.superTabControl1.ReorderTabsEnabled = true;
            this.superTabControl1.SelectedTabFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.superTabControl1.SelectedTabIndex = 0;
            this.superTabControl1.Size = new System.Drawing.Size(596, 423);
            this.superTabControl1.TabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.superTabControl1.TabIndex = 0;
            this.superTabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.VisualStudio2008Document;
            this.superTabControl1.Text = "superTabControl1";
            // 
            // labelItem1
            // 
            this.labelItem1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelItem1.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.labelItem1.Name = "labelItem1";
            // 
            // PrivilegeManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 450);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.bar1);
            this.Controls.Add(this.treeView1);
            this.Name = "PrivilegeManagement";
            this.Text = "权限管理";
            this.Load += new System.EventHandler(this.PrivilegeManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonItem btni_save;
        private DevComponents.DotNetBar.ButtonItem btni_cancle;
        private DevComponents.DotNetBar.SuperTabControl superTabControl1;
        private DevComponents.DotNetBar.ButtonItem btni_modify;
        private DevComponents.DotNetBar.ButtonItem btni_looupk;
        private DevComponents.DotNetBar.LabelItem labelItem1;
    }
}