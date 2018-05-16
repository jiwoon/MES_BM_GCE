namespace Gce.MoreDocumentsWindows
{
    partial class SectorStructure_form
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btni_edit = new DevComponents.DotNetBar.ButtonItem();
            this.btni_save = new DevComponents.DotNetBar.ButtonItem();
            this.btni_cancle = new DevComponents.DotNetBar.ButtonItem();
            this.btni_delete = new DevComponents.DotNetBar.ButtonItem();
            this.btni_NewSibling = new DevComponents.DotNetBar.ButtonItem();
            this.btni_NewSubordinate = new DevComponents.DotNetBar.ButtonItem();
            this.btni_DataInput = new DevComponents.DotNetBar.ButtonItem();
            this.btni_DataOut = new DevComponents.DotNetBar.ButtonItem();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建同级ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建下级ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.ip_ExceedNumberOfStaff = new DevComponents.Editors.IntegerInput();
            this.ip_InTheNumberOfStaff = new DevComponents.Editors.IntegerInput();
            this.ip_NumberOfStaff = new DevComponents.Editors.IntegerInput();
            this.txt_note = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.txt_ParentDepartmentName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.txt_ParentDepartmentNo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txt_DepartmentName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txt_DepartmentNo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.dataGridViewX2 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.tabItem2 = new DevComponents.DotNetBar.TabItem(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.panelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ip_ExceedNumberOfStaff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ip_InTheNumberOfStaff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ip_NumberOfStaff)).BeginInit();
            this.tabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX2)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btni_edit,
            this.btni_save,
            this.btni_cancle,
            this.btni_delete,
            this.btni_NewSibling,
            this.btni_NewSubordinate,
            this.btni_DataInput,
            this.btni_DataOut});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(1127, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 7;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btni_edit
            // 
            this.btni_edit.FontBold = true;
            this.btni_edit.Name = "btni_edit";
            this.btni_edit.Text = "编辑";
            this.btni_edit.Click += new System.EventHandler(this.btni_edit_Click);
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
            // btni_NewSibling
            // 
            this.btni_NewSibling.FontBold = true;
            this.btni_NewSibling.Name = "btni_NewSibling";
            this.btni_NewSibling.Text = "新建同级";
            this.btni_NewSibling.Click += new System.EventHandler(this.btni_NewSibling_Click);
            // 
            // btni_NewSubordinate
            // 
            this.btni_NewSubordinate.FontBold = true;
            this.btni_NewSubordinate.Name = "btni_NewSubordinate";
            this.btni_NewSubordinate.Text = "新建下级";
            this.btni_NewSubordinate.Click += new System.EventHandler(this.btni_NewSubordinate_Click);
            // 
            // btni_DataInput
            // 
            this.btni_DataInput.FontBold = true;
            this.btni_DataInput.Name = "btni_DataInput";
            this.btni_DataInput.Text = "导入Excle";
            this.btni_DataInput.Click += new System.EventHandler(this.btni_DataInput_Click);
            // 
            // btni_DataOut
            // 
            this.btni_DataOut.FontBold = true;
            this.btni_DataOut.Name = "btni_DataOut";
            this.btni_DataOut.Text = "导出Excle";
            this.btni_DataOut.Click += new System.EventHandler(this.btni_DataOut_Click);
            // 
            // treeView1
            // 
            this.treeView1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Location = new System.Drawing.Point(0, 27);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(241, 577);
            this.treeView1.TabIndex = 12;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.编辑ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.新建同级ToolStripMenuItem,
            this.新建下级ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 92);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.编辑ToolStripMenuItem.Text = "编辑";
            this.编辑ToolStripMenuItem.Click += new System.EventHandler(this.btni_edit_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.btni_delete_Click);
            // 
            // 新建同级ToolStripMenuItem
            // 
            this.新建同级ToolStripMenuItem.Name = "新建同级ToolStripMenuItem";
            this.新建同级ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.新建同级ToolStripMenuItem.Text = "新建同级";
            this.新建同级ToolStripMenuItem.Click += new System.EventHandler(this.btni_NewSibling_Click);
            // 
            // 新建下级ToolStripMenuItem
            // 
            this.新建下级ToolStripMenuItem.Name = "新建下级ToolStripMenuItem";
            this.新建下级ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.新建下级ToolStripMenuItem.Text = "新建下级";
            this.新建下级ToolStripMenuItem.Click += new System.EventHandler(this.btni_NewSubordinate_Click);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.tabControl1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(241, 27);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(886, 577);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 13;
            // 
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.Color.Transparent;
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.Controls.Add(this.tabControlPanel1);
            this.tabControl1.Controls.Add(this.tabControlPanel2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 1;
            this.tabControl1.Size = new System.Drawing.Size(886, 577);
            this.tabControl1.TabIndex = 12;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.tabItem1);
            this.tabControl1.Tabs.Add(this.tabItem2);
            this.tabControl1.Text = "tabControl1";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.dataGridViewX1);
            this.tabControlPanel1.Controls.Add(this.panelEx2);
            this.tabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(886, 551);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabItem1;
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(1, 274);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.ReadOnly = true;
            this.dataGridViewX1.RowTemplate.Height = 23;
            this.dataGridViewX1.Size = new System.Drawing.Size(884, 276);
            this.dataGridViewX1.TabIndex = 37;
            this.dataGridViewX1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridViewX1_RowPostPaint);
            this.dataGridViewX1.SelectionChanged += new System.EventHandler(this.dataGridViewX1_SelectionChanged);
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.ip_ExceedNumberOfStaff);
            this.panelEx2.Controls.Add(this.ip_InTheNumberOfStaff);
            this.panelEx2.Controls.Add(this.ip_NumberOfStaff);
            this.panelEx2.Controls.Add(this.txt_note);
            this.panelEx2.Controls.Add(this.labelX5);
            this.panelEx2.Controls.Add(this.labelX6);
            this.panelEx2.Controls.Add(this.labelX7);
            this.panelEx2.Controls.Add(this.labelX8);
            this.panelEx2.Controls.Add(this.txt_ParentDepartmentName);
            this.panelEx2.Controls.Add(this.labelX4);
            this.panelEx2.Controls.Add(this.txt_ParentDepartmentNo);
            this.panelEx2.Controls.Add(this.labelX3);
            this.panelEx2.Controls.Add(this.txt_DepartmentName);
            this.panelEx2.Controls.Add(this.labelX2);
            this.panelEx2.Controls.Add(this.txt_DepartmentNo);
            this.panelEx2.Controls.Add(this.labelX1);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx2.Location = new System.Drawing.Point(1, 1);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(884, 273);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 33;
            // 
            // ip_ExceedNumberOfStaff
            // 
            // 
            // 
            // 
            this.ip_ExceedNumberOfStaff.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ip_ExceedNumberOfStaff.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ip_ExceedNumberOfStaff.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.ip_ExceedNumberOfStaff.Location = new System.Drawing.Point(519, 152);
            this.ip_ExceedNumberOfStaff.MinValue = 0;
            this.ip_ExceedNumberOfStaff.Name = "ip_ExceedNumberOfStaff";
            this.ip_ExceedNumberOfStaff.ShowUpDown = true;
            this.ip_ExceedNumberOfStaff.Size = new System.Drawing.Size(106, 21);
            this.ip_ExceedNumberOfStaff.TabIndex = 50;
            // 
            // ip_InTheNumberOfStaff
            // 
            // 
            // 
            // 
            this.ip_InTheNumberOfStaff.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ip_InTheNumberOfStaff.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ip_InTheNumberOfStaff.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.ip_InTheNumberOfStaff.Location = new System.Drawing.Point(519, 96);
            this.ip_InTheNumberOfStaff.MinValue = 0;
            this.ip_InTheNumberOfStaff.Name = "ip_InTheNumberOfStaff";
            this.ip_InTheNumberOfStaff.ShowUpDown = true;
            this.ip_InTheNumberOfStaff.Size = new System.Drawing.Size(106, 21);
            this.ip_InTheNumberOfStaff.TabIndex = 49;
            this.ip_InTheNumberOfStaff.Leave += new System.EventHandler(this.ip_InTheNumberOfStaff_Leave);
            // 
            // ip_NumberOfStaff
            // 
            // 
            // 
            // 
            this.ip_NumberOfStaff.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ip_NumberOfStaff.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ip_NumberOfStaff.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.ip_NumberOfStaff.Location = new System.Drawing.Point(519, 40);
            this.ip_NumberOfStaff.MinValue = 0;
            this.ip_NumberOfStaff.Name = "ip_NumberOfStaff";
            this.ip_NumberOfStaff.ShowUpDown = true;
            this.ip_NumberOfStaff.Size = new System.Drawing.Size(106, 21);
            this.ip_NumberOfStaff.TabIndex = 48;
            this.ip_NumberOfStaff.Leave += new System.EventHandler(this.ip_NumberOfStaff_Leave);
            // 
            // txt_note
            // 
            // 
            // 
            // 
            this.txt_note.Border.Class = "TextBoxBorder";
            this.txt_note.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_note.Location = new System.Drawing.Point(519, 211);
            this.txt_note.Name = "txt_note";
            this.txt_note.PreventEnterBeep = true;
            this.txt_note.Size = new System.Drawing.Size(273, 21);
            this.txt_note.TabIndex = 47;
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(457, 214);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(56, 18);
            this.labelX5.TabIndex = 46;
            this.labelX5.Text = "备    注";
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(457, 155);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(56, 18);
            this.labelX6.TabIndex = 44;
            this.labelX6.Text = "超编人数";
            // 
            // labelX7
            // 
            this.labelX7.AutoSize = true;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(457, 99);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(56, 18);
            this.labelX7.TabIndex = 42;
            this.labelX7.Text = "在编人数";
            // 
            // labelX8
            // 
            this.labelX8.AutoSize = true;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(457, 43);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(56, 18);
            this.labelX8.TabIndex = 40;
            this.labelX8.Text = "编制人数";
            // 
            // txt_ParentDepartmentName
            // 
            // 
            // 
            // 
            this.txt_ParentDepartmentName.Border.Class = "TextBoxBorder";
            this.txt_ParentDepartmentName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_ParentDepartmentName.Location = new System.Drawing.Point(215, 211);
            this.txt_ParentDepartmentName.Name = "txt_ParentDepartmentName";
            this.txt_ParentDepartmentName.PreventEnterBeep = true;
            this.txt_ParentDepartmentName.Size = new System.Drawing.Size(143, 21);
            this.txt_ParentDepartmentName.TabIndex = 39;
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(128, 214);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(81, 18);
            this.labelX4.TabIndex = 38;
            this.labelX4.Text = "上级部门名称";
            // 
            // txt_ParentDepartmentNo
            // 
            // 
            // 
            // 
            this.txt_ParentDepartmentNo.Border.Class = "TextBoxBorder";
            this.txt_ParentDepartmentNo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_ParentDepartmentNo.Location = new System.Drawing.Point(215, 152);
            this.txt_ParentDepartmentNo.Name = "txt_ParentDepartmentNo";
            this.txt_ParentDepartmentNo.PreventEnterBeep = true;
            this.txt_ParentDepartmentNo.Size = new System.Drawing.Size(143, 21);
            this.txt_ParentDepartmentNo.TabIndex = 37;
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(128, 155);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(81, 18);
            this.labelX3.TabIndex = 36;
            this.labelX3.Text = "上级部门编号";
            // 
            // txt_DepartmentName
            // 
            // 
            // 
            // 
            this.txt_DepartmentName.Border.Class = "TextBoxBorder";
            this.txt_DepartmentName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_DepartmentName.Location = new System.Drawing.Point(215, 96);
            this.txt_DepartmentName.Name = "txt_DepartmentName";
            this.txt_DepartmentName.PreventEnterBeep = true;
            this.txt_DepartmentName.Size = new System.Drawing.Size(143, 21);
            this.txt_DepartmentName.TabIndex = 35;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(153, 99);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(56, 18);
            this.labelX2.TabIndex = 34;
            this.labelX2.Text = "部门名称";
            // 
            // txt_DepartmentNo
            // 
            // 
            // 
            // 
            this.txt_DepartmentNo.Border.Class = "TextBoxBorder";
            this.txt_DepartmentNo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_DepartmentNo.Location = new System.Drawing.Point(215, 40);
            this.txt_DepartmentNo.Name = "txt_DepartmentNo";
            this.txt_DepartmentNo.PreventEnterBeep = true;
            this.txt_DepartmentNo.Size = new System.Drawing.Size(143, 21);
            this.txt_DepartmentNo.TabIndex = 33;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(153, 43);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(56, 18);
            this.labelX1.TabIndex = 32;
            this.labelX1.Text = "部门编号";
            // 
            // tabItem1
            // 
            this.tabItem1.AttachedControl = this.tabControlPanel1;
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "部门信息";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.dataGridViewX2);
            this.tabControlPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(886, 551);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 5;
            this.tabControlPanel2.TabItem = this.tabItem2;
            // 
            // dataGridViewX2
            // 
            this.dataGridViewX2.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dataGridViewX2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewX2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX2.Location = new System.Drawing.Point(1, 1);
            this.dataGridViewX2.Name = "dataGridViewX2";
            this.dataGridViewX2.RowTemplate.Height = 23;
            this.dataGridViewX2.Size = new System.Drawing.Size(884, 549);
            this.dataGridViewX2.TabIndex = 42;
            // 
            // tabItem2
            // 
            this.tabItem2.AttachedControl = this.tabControlPanel2;
            this.tabItem2.Name = "tabItem2";
            this.tabItem2.Text = "员工信息";
            this.tabItem2.Visible = false;
            // 
            // SectorStructure_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 604);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.bar1);
            this.DoubleBuffered = true;
            this.Name = "SectorStructure_form";
            this.Text = "部门结构";
            this.Load += new System.EventHandler(this.SectorStructure_form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ip_ExceedNumberOfStaff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ip_InTheNumberOfStaff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ip_NumberOfStaff)).EndInit();
            this.tabControlPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btni_edit;
        private DevComponents.DotNetBar.ButtonItem btni_save;
        private DevComponents.DotNetBar.ButtonItem btni_cancle;
        private DevComponents.DotNetBar.ButtonItem btni_delete;
        private DevComponents.DotNetBar.ButtonItem btni_NewSibling;
        private DevComponents.DotNetBar.ButtonItem btni_NewSubordinate;
        private System.Windows.Forms.TreeView treeView1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.TabControl tabControl1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_note;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_ParentDepartmentName;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_ParentDepartmentNo;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_DepartmentName;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_DepartmentNo;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.TabItem tabItem1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX2;
        private DevComponents.DotNetBar.TabItem tabItem2;
        private DevComponents.DotNetBar.ButtonItem btni_DataInput;
        private DevComponents.DotNetBar.ButtonItem btni_DataOut;
        private DevComponents.Editors.IntegerInput ip_ExceedNumberOfStaff;
        private DevComponents.Editors.IntegerInput ip_InTheNumberOfStaff;
        private DevComponents.Editors.IntegerInput ip_NumberOfStaff;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建同级ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建下级ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
    }
}