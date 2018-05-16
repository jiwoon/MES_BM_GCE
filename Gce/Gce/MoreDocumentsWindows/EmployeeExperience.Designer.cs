namespace Gce.MoreDocumentsWindows
{
    partial class EmployeeExperience
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.cb_Gender = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.Man = new DevComponents.Editors.ComboItem();
            this.girl = new DevComponents.Editors.ComboItem();
            this.Inpu_Age = new DevComponents.Editors.IntegerInput();
            this.cb_Levels = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.A = new DevComponents.Editors.ComboItem();
            this.B = new DevComponents.Editors.ComboItem();
            this.C = new DevComponents.Editors.ComboItem();
            this.D = new DevComponents.Editors.ComboItem();
            this.E = new DevComponents.Editors.ComboItem();
            this.F = new DevComponents.Editors.ComboItem();
            this.G = new DevComponents.Editors.ComboItem();
            this.cb_WorkTypes = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.dt_FactoryTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.txt_WorkNumber = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_Name = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btni_Query = new DevComponents.DotNetBar.ButtonItem();
            this.btni_Insert = new DevComponents.DotNetBar.ButtonItem();
            this.btni_Save = new DevComponents.DotNetBar.ButtonItem();
            this.btni_Cancel = new DevComponents.DotNetBar.ButtonItem();
            this.btni_Modify = new DevComponents.DotNetBar.ButtonItem();
            this.btni_Delete = new DevComponents.DotNetBar.ButtonItem();
            this.btni_WorkType = new DevComponents.DotNetBar.ButtonItem();
            this.btni_Clear = new DevComponents.DotNetBar.ButtonItem();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btni_Outdata = new DevComponents.DotNetBar.ButtonItem();
            this.cb_CompanyName = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Inpu_Age)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_FactoryTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.cb_CompanyName);
            this.panelEx1.Controls.Add(this.labelX8);
            this.panelEx1.Controls.Add(this.cb_Gender);
            this.panelEx1.Controls.Add(this.Inpu_Age);
            this.panelEx1.Controls.Add(this.cb_Levels);
            this.panelEx1.Controls.Add(this.cb_WorkTypes);
            this.panelEx1.Controls.Add(this.dt_FactoryTime);
            this.panelEx1.Controls.Add(this.txt_WorkNumber);
            this.panelEx1.Controls.Add(this.txt_Name);
            this.panelEx1.Controls.Add(this.labelX7);
            this.panelEx1.Controls.Add(this.labelX6);
            this.panelEx1.Controls.Add(this.labelX5);
            this.panelEx1.Controls.Add(this.labelX4);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.bar1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1049, 116);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // cb_Gender
            // 
            this.cb_Gender.DisplayMember = "Text";
            this.cb_Gender.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_Gender.FormattingEnabled = true;
            this.cb_Gender.ItemHeight = 15;
            this.cb_Gender.Items.AddRange(new object[] {
            this.Man,
            this.girl});
            this.cb_Gender.Location = new System.Drawing.Point(219, 43);
            this.cb_Gender.Name = "cb_Gender";
            this.cb_Gender.Size = new System.Drawing.Size(58, 21);
            this.cb_Gender.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cb_Gender.TabIndex = 17;
            this.cb_Gender.TextChanged += new System.EventHandler(this.cb_Gender_TextChanged);
            // 
            // Man
            // 
            this.Man.Text = "男";
            // 
            // girl
            // 
            this.girl.Text = "女";
            // 
            // Inpu_Age
            // 
            // 
            // 
            // 
            this.Inpu_Age.BackgroundStyle.Class = "DateTimeInputBackground";
            this.Inpu_Age.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Inpu_Age.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.Inpu_Age.Location = new System.Drawing.Point(219, 78);
            this.Inpu_Age.MinValue = 1;
            this.Inpu_Age.Name = "Inpu_Age";
            this.Inpu_Age.ShowUpDown = true;
            this.Inpu_Age.Size = new System.Drawing.Size(58, 21);
            this.Inpu_Age.TabIndex = 16;
            this.Inpu_Age.Value = 1;
            // 
            // cb_Levels
            // 
            this.cb_Levels.DisplayMember = "Text";
            this.cb_Levels.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_Levels.FormattingEnabled = true;
            this.cb_Levels.ItemHeight = 15;
            this.cb_Levels.Items.AddRange(new object[] {
            this.A,
            this.B,
            this.C,
            this.D,
            this.E,
            this.F,
            this.G});
            this.cb_Levels.Location = new System.Drawing.Point(554, 43);
            this.cb_Levels.Name = "cb_Levels";
            this.cb_Levels.Size = new System.Drawing.Size(86, 21);
            this.cb_Levels.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cb_Levels.TabIndex = 14;
            // 
            // A
            // 
            this.A.Text = "A";
            // 
            // B
            // 
            this.B.Text = "B";
            // 
            // C
            // 
            this.C.Text = "C";
            // 
            // D
            // 
            this.D.Text = "D";
            // 
            // E
            // 
            this.E.Text = "E";
            // 
            // F
            // 
            this.F.Text = "F";
            // 
            // G
            // 
            this.G.Text = "G";
            // 
            // cb_WorkTypes
            // 
            this.cb_WorkTypes.DisplayMember = "Text";
            this.cb_WorkTypes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_WorkTypes.FormattingEnabled = true;
            this.cb_WorkTypes.ItemHeight = 15;
            this.cb_WorkTypes.Location = new System.Drawing.Point(358, 43);
            this.cb_WorkTypes.Name = "cb_WorkTypes";
            this.cb_WorkTypes.Size = new System.Drawing.Size(147, 21);
            this.cb_WorkTypes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cb_WorkTypes.TabIndex = 13;
            // 
            // dt_FactoryTime
            // 
            // 
            // 
            // 
            this.dt_FactoryTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dt_FactoryTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dt_FactoryTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dt_FactoryTime.ButtonDropDown.Visible = true;
            this.dt_FactoryTime.IsPopupCalendarOpen = false;
            this.dt_FactoryTime.Location = new System.Drawing.Point(579, 78);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dt_FactoryTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dt_FactoryTime.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dt_FactoryTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dt_FactoryTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dt_FactoryTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dt_FactoryTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dt_FactoryTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dt_FactoryTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dt_FactoryTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dt_FactoryTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dt_FactoryTime.MonthCalendar.DisplayMonth = new System.DateTime(2016, 11, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dt_FactoryTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dt_FactoryTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dt_FactoryTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dt_FactoryTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dt_FactoryTime.MonthCalendar.TodayButtonVisible = true;
            this.dt_FactoryTime.Name = "dt_FactoryTime";
            this.dt_FactoryTime.Size = new System.Drawing.Size(147, 21);
            this.dt_FactoryTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dt_FactoryTime.TabIndex = 12;
            // 
            // txt_WorkNumber
            // 
            // 
            // 
            // 
            this.txt_WorkNumber.Border.Class = "TextBoxBorder";
            this.txt_WorkNumber.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_WorkNumber.Location = new System.Drawing.Point(60, 78);
            this.txt_WorkNumber.Name = "txt_WorkNumber";
            this.txt_WorkNumber.PreventEnterBeep = true;
            this.txt_WorkNumber.Size = new System.Drawing.Size(116, 21);
            this.txt_WorkNumber.TabIndex = 9;
            // 
            // txt_Name
            // 
            // 
            // 
            // 
            this.txt_Name.Border.Class = "TextBoxBorder";
            this.txt_Name.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_Name.ButtonCustom.Visible = true;
            this.txt_Name.Location = new System.Drawing.Point(60, 40);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.PreventEnterBeep = true;
            this.txt_Name.Size = new System.Drawing.Size(116, 21);
            this.txt_Name.TabIndex = 8;
            this.txt_Name.ButtonCustomClick += new System.EventHandler(this.txt_Name_ButtonCustomClick);
            // 
            // labelX7
            // 
            this.labelX7.AutoSize = true;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(517, 81);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(56, 18);
            this.labelX7.TabIndex = 7;
            this.labelX7.Text = "入职时间";
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(517, 43);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(31, 18);
            this.labelX6.TabIndex = 6;
            this.labelX6.Text = "级别";
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(296, 43);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(56, 18);
            this.labelX5.TabIndex = 5;
            this.labelX5.Text = "工作种类";
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(182, 81);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(31, 18);
            this.labelX4.TabIndex = 4;
            this.labelX4.Text = "年龄";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(182, 43);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(31, 18);
            this.labelX3.TabIndex = 3;
            this.labelX3.Text = "性别";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(23, 81);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(31, 18);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "工号";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(23, 43);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(31, 18);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "姓名";
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.DockSide = DevComponents.DotNetBar.eDockSide.Top;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btni_Query,
            this.btni_Insert,
            this.btni_Save,
            this.btni_Cancel,
            this.btni_Modify,
            this.btni_Delete,
            this.btni_WorkType,
            this.btni_Clear,
            this.btni_Outdata});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(1049, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 0;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btni_Query
            // 
            this.btni_Query.FontBold = true;
            this.btni_Query.Name = "btni_Query";
            this.btni_Query.Text = "查询";
            this.btni_Query.Click += new System.EventHandler(this.btni_Query_Click);
            // 
            // btni_Insert
            // 
            this.btni_Insert.FontBold = true;
            this.btni_Insert.Name = "btni_Insert";
            this.btni_Insert.Text = "新增";
            this.btni_Insert.Click += new System.EventHandler(this.btni_Insert_Click);
            // 
            // btni_Save
            // 
            this.btni_Save.FontBold = true;
            this.btni_Save.Name = "btni_Save";
            this.btni_Save.Text = "保存";
            this.btni_Save.Click += new System.EventHandler(this.btni_Save_Click);
            // 
            // btni_Cancel
            // 
            this.btni_Cancel.FontBold = true;
            this.btni_Cancel.Name = "btni_Cancel";
            this.btni_Cancel.Text = "取消";
            this.btni_Cancel.Click += new System.EventHandler(this.btni_Cancel_Click);
            // 
            // btni_Modify
            // 
            this.btni_Modify.FontBold = true;
            this.btni_Modify.Name = "btni_Modify";
            this.btni_Modify.Text = "修改";
            this.btni_Modify.Click += new System.EventHandler(this.btni_Modify_Click);
            // 
            // btni_Delete
            // 
            this.btni_Delete.FontBold = true;
            this.btni_Delete.Name = "btni_Delete";
            this.btni_Delete.Text = "删除";
            this.btni_Delete.Click += new System.EventHandler(this.btni_Delete_Click);
            // 
            // btni_WorkType
            // 
            this.btni_WorkType.FontBold = true;
            this.btni_WorkType.Name = "btni_WorkType";
            this.btni_WorkType.Text = "工种配置";
            this.btni_WorkType.Click += new System.EventHandler(this.btni_WorkType_Click);
            // 
            // btni_Clear
            // 
            this.btni_Clear.FontBold = true;
            this.btni_Clear.Name = "btni_Clear";
            this.btni_Clear.Text = "清空查询条件";
            this.btni_Clear.Click += new System.EventHandler(this.btni_Clear_Click);
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
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 116);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.ReadOnly = true;
            this.dataGridViewX1.RowTemplate.Height = 23;
            this.dataGridViewX1.Size = new System.Drawing.Size(1049, 340);
            this.dataGridViewX1.TabIndex = 4;
            this.dataGridViewX1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridViewX1_RowPostPaint);
            this.dataGridViewX1.SelectionChanged += new System.EventHandler(this.dataGridViewX1_SelectionChanged);
            // 
            // btni_Outdata
            // 
            this.btni_Outdata.FontBold = true;
            this.btni_Outdata.Name = "btni_Outdata";
            this.btni_Outdata.Text = "导出数据";
            this.btni_Outdata.Click += new System.EventHandler(this.btni_Outdata_Click);
            // 
            // cb_CompanyName
            // 
            this.cb_CompanyName.DisplayMember = "Text";
            this.cb_CompanyName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_CompanyName.FormattingEnabled = true;
            this.cb_CompanyName.ItemHeight = 15;
            this.cb_CompanyName.Location = new System.Drawing.Point(358, 78);
            this.cb_CompanyName.Name = "cb_CompanyName";
            this.cb_CompanyName.Size = new System.Drawing.Size(147, 21);
            this.cb_CompanyName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cb_CompanyName.TabIndex = 19;
            // 
            // labelX8
            // 
            this.labelX8.AutoSize = true;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(296, 78);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(56, 18);
            this.labelX8.TabIndex = 18;
            this.labelX8.Text = "公司名称";
            // 
            // EmployeeExperience
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 456);
            this.Controls.Add(this.dataGridViewX1);
            this.Controls.Add(this.panelEx1);
            this.Name = "EmployeeExperience";
            this.Text = "员工履历表";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EmployeeExperience_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EmployeeExperience_FormClosed);
            this.Load += new System.EventHandler(this.EmployeeExperience_Load);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Inpu_Age)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_FactoryTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btni_Query;
        private DevComponents.DotNetBar.ButtonItem btni_Insert;
        private DevComponents.DotNetBar.ButtonItem btni_Save;
        private DevComponents.DotNetBar.ButtonItem btni_Modify;
        private DevComponents.DotNetBar.ButtonItem btni_Delete;
        private DevComponents.DotNetBar.ButtonItem btni_WorkType;
        private DevComponents.DotNetBar.ButtonItem btni_Cancel;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_Name;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_WorkNumber;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dt_FactoryTime;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cb_WorkTypes;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cb_Levels;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cb_Gender;
        private DevComponents.Editors.IntegerInput Inpu_Age;
        private DevComponents.Editors.ComboItem Man;
        private DevComponents.Editors.ComboItem girl;
        private DevComponents.DotNetBar.ButtonItem btni_Clear;
        private DevComponents.Editors.ComboItem A;
        private DevComponents.Editors.ComboItem B;
        private DevComponents.Editors.ComboItem C;
        private DevComponents.Editors.ComboItem D;
        private DevComponents.Editors.ComboItem E;
        private DevComponents.Editors.ComboItem F;
        private DevComponents.Editors.ComboItem G;
        private DevComponents.DotNetBar.ButtonItem btni_Outdata;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cb_CompanyName;
        private DevComponents.DotNetBar.LabelX labelX8;
    }
}