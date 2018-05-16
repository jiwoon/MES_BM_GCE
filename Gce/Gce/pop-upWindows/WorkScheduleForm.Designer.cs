namespace Gce.pop_upWindows
{
    partial class WorkScheduleForm
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
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btn_new = new DevComponents.DotNetBar.ButtonItem();
            this.btn_Save = new DevComponents.DotNetBar.ButtonItem();
            this.btn_cancel = new DevComponents.DotNetBar.ButtonItem();
            this.btn_Modify = new DevComponents.DotNetBar.ButtonItem();
            this.btn_Delete = new DevComponents.DotNetBar.ButtonItem();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.dti_NightOnWorkTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dti_AfternoonUnderWorkTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dti_AfternoonOnWorkTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dti_MorningUnderWorkTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.cbox_CompanyName = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.dti_MorningOnWorkTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.cb_night = new DevComponents.DotNetBar.CheckBoxItem();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dti_NightOnWorkTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dti_AfternoonUnderWorkTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dti_AfternoonOnWorkTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dti_MorningUnderWorkTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dti_MorningOnWorkTime)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_new,
            this.btn_Save,
            this.btn_cancel,
            this.btn_Modify,
            this.btn_Delete,
            this.cb_night});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(456, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 6;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btn_new
            // 
            this.btn_new.FontBold = true;
            this.btn_new.Name = "btn_new";
            this.btn_new.Text = "新建";
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.FontBold = true;
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Text = "保存";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.FontBold = true;
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Text = "取消";
            // 
            // btn_Modify
            // 
            this.btn_Modify.FontBold = true;
            this.btn_Modify.Name = "btn_Modify";
            this.btn_Modify.Text = "修改";
            this.btn_Modify.Click += new System.EventHandler(this.btn_Modify_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.FontBold = true;
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Text = "删除";
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.panelEx2);
            this.panelEx1.Controls.Add(this.labelX6);
            this.panelEx1.Controls.Add(this.labelX5);
            this.panelEx1.Controls.Add(this.labelX4);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.dti_NightOnWorkTime);
            this.panelEx1.Controls.Add(this.dti_AfternoonUnderWorkTime);
            this.panelEx1.Controls.Add(this.dti_AfternoonOnWorkTime);
            this.panelEx1.Controls.Add(this.dti_MorningUnderWorkTime);
            this.panelEx1.Controls.Add(this.cbox_CompanyName);
            this.panelEx1.Controls.Add(this.dti_MorningOnWorkTime);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 27);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(456, 226);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 20;
            // 
            // panelEx2
            // 
            this.panelEx2.AutoScroll = true;
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelEx2.Location = new System.Drawing.Point(266, 0);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(190, 226);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 32;
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(4, 203);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(105, 18);
            this.labelX6.TabIndex = 31;
            this.labelX6.Text = "晚上加班上班时间";
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(29, 167);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(81, 18);
            this.labelX5.TabIndex = 30;
            this.labelX5.Text = "下午下班时间";
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(29, 129);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(81, 18);
            this.labelX4.TabIndex = 29;
            this.labelX4.Text = "下午上班时间";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(29, 93);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(81, 18);
            this.labelX3.TabIndex = 28;
            this.labelX3.Text = "上午下班时间";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(29, 56);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(81, 18);
            this.labelX2.TabIndex = 27;
            this.labelX2.Text = "上午上班时间";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(67, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(56, 18);
            this.labelX1.TabIndex = 26;
            this.labelX1.Text = "公司名称";
            // 
            // dti_NightOnWorkTime
            // 
            // 
            // 
            // 
            this.dti_NightOnWorkTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dti_NightOnWorkTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dti_NightOnWorkTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dti_NightOnWorkTime.ButtonDropDown.Visible = true;
            this.dti_NightOnWorkTime.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime;
            this.dti_NightOnWorkTime.IsPopupCalendarOpen = false;
            this.dti_NightOnWorkTime.Location = new System.Drawing.Point(139, 200);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dti_NightOnWorkTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dti_NightOnWorkTime.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dti_NightOnWorkTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dti_NightOnWorkTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dti_NightOnWorkTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dti_NightOnWorkTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dti_NightOnWorkTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dti_NightOnWorkTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dti_NightOnWorkTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dti_NightOnWorkTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dti_NightOnWorkTime.MonthCalendar.DisplayMonth = new System.DateTime(2016, 10, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dti_NightOnWorkTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dti_NightOnWorkTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dti_NightOnWorkTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dti_NightOnWorkTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dti_NightOnWorkTime.MonthCalendar.TodayButtonVisible = true;
            this.dti_NightOnWorkTime.MonthCalendar.Visible = false;
            this.dti_NightOnWorkTime.Name = "dti_NightOnWorkTime";
            this.dti_NightOnWorkTime.Size = new System.Drawing.Size(121, 21);
            this.dti_NightOnWorkTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dti_NightOnWorkTime.TabIndex = 25;
            // 
            // dti_AfternoonUnderWorkTime
            // 
            // 
            // 
            // 
            this.dti_AfternoonUnderWorkTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dti_AfternoonUnderWorkTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dti_AfternoonUnderWorkTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dti_AfternoonUnderWorkTime.ButtonDropDown.Visible = true;
            this.dti_AfternoonUnderWorkTime.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime;
            this.dti_AfternoonUnderWorkTime.IsPopupCalendarOpen = false;
            this.dti_AfternoonUnderWorkTime.Location = new System.Drawing.Point(139, 164);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dti_AfternoonUnderWorkTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dti_AfternoonUnderWorkTime.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dti_AfternoonUnderWorkTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dti_AfternoonUnderWorkTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dti_AfternoonUnderWorkTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dti_AfternoonUnderWorkTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dti_AfternoonUnderWorkTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dti_AfternoonUnderWorkTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dti_AfternoonUnderWorkTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dti_AfternoonUnderWorkTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dti_AfternoonUnderWorkTime.MonthCalendar.DisplayMonth = new System.DateTime(2016, 10, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dti_AfternoonUnderWorkTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dti_AfternoonUnderWorkTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dti_AfternoonUnderWorkTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dti_AfternoonUnderWorkTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dti_AfternoonUnderWorkTime.MonthCalendar.TodayButtonVisible = true;
            this.dti_AfternoonUnderWorkTime.MonthCalendar.Visible = false;
            this.dti_AfternoonUnderWorkTime.Name = "dti_AfternoonUnderWorkTime";
            this.dti_AfternoonUnderWorkTime.Size = new System.Drawing.Size(121, 21);
            this.dti_AfternoonUnderWorkTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dti_AfternoonUnderWorkTime.TabIndex = 24;
            // 
            // dti_AfternoonOnWorkTime
            // 
            // 
            // 
            // 
            this.dti_AfternoonOnWorkTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dti_AfternoonOnWorkTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dti_AfternoonOnWorkTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dti_AfternoonOnWorkTime.ButtonDropDown.Visible = true;
            this.dti_AfternoonOnWorkTime.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime;
            this.dti_AfternoonOnWorkTime.IsPopupCalendarOpen = false;
            this.dti_AfternoonOnWorkTime.Location = new System.Drawing.Point(139, 126);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dti_AfternoonOnWorkTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dti_AfternoonOnWorkTime.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dti_AfternoonOnWorkTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dti_AfternoonOnWorkTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dti_AfternoonOnWorkTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dti_AfternoonOnWorkTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dti_AfternoonOnWorkTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dti_AfternoonOnWorkTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dti_AfternoonOnWorkTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dti_AfternoonOnWorkTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dti_AfternoonOnWorkTime.MonthCalendar.DisplayMonth = new System.DateTime(2016, 10, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dti_AfternoonOnWorkTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dti_AfternoonOnWorkTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dti_AfternoonOnWorkTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dti_AfternoonOnWorkTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dti_AfternoonOnWorkTime.MonthCalendar.TodayButtonVisible = true;
            this.dti_AfternoonOnWorkTime.MonthCalendar.Visible = false;
            this.dti_AfternoonOnWorkTime.Name = "dti_AfternoonOnWorkTime";
            this.dti_AfternoonOnWorkTime.Size = new System.Drawing.Size(121, 21);
            this.dti_AfternoonOnWorkTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dti_AfternoonOnWorkTime.TabIndex = 23;
            // 
            // dti_MorningUnderWorkTime
            // 
            // 
            // 
            // 
            this.dti_MorningUnderWorkTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dti_MorningUnderWorkTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dti_MorningUnderWorkTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dti_MorningUnderWorkTime.ButtonDropDown.Visible = true;
            this.dti_MorningUnderWorkTime.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime;
            this.dti_MorningUnderWorkTime.IsPopupCalendarOpen = false;
            this.dti_MorningUnderWorkTime.Location = new System.Drawing.Point(139, 90);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dti_MorningUnderWorkTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dti_MorningUnderWorkTime.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dti_MorningUnderWorkTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dti_MorningUnderWorkTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dti_MorningUnderWorkTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dti_MorningUnderWorkTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dti_MorningUnderWorkTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dti_MorningUnderWorkTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dti_MorningUnderWorkTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dti_MorningUnderWorkTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dti_MorningUnderWorkTime.MonthCalendar.DisplayMonth = new System.DateTime(2016, 10, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dti_MorningUnderWorkTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dti_MorningUnderWorkTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dti_MorningUnderWorkTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dti_MorningUnderWorkTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dti_MorningUnderWorkTime.MonthCalendar.TodayButtonVisible = true;
            this.dti_MorningUnderWorkTime.MonthCalendar.Visible = false;
            this.dti_MorningUnderWorkTime.Name = "dti_MorningUnderWorkTime";
            this.dti_MorningUnderWorkTime.Size = new System.Drawing.Size(121, 21);
            this.dti_MorningUnderWorkTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dti_MorningUnderWorkTime.TabIndex = 22;
            // 
            // cbox_CompanyName
            // 
            this.cbox_CompanyName.DisplayMember = "Text";
            this.cbox_CompanyName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbox_CompanyName.FormattingEnabled = true;
            this.cbox_CompanyName.ItemHeight = 15;
            this.cbox_CompanyName.Location = new System.Drawing.Point(139, 9);
            this.cbox_CompanyName.Name = "cbox_CompanyName";
            this.cbox_CompanyName.Size = new System.Drawing.Size(121, 21);
            this.cbox_CompanyName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbox_CompanyName.TabIndex = 21;
            this.cbox_CompanyName.SelectionChangeCommitted += new System.EventHandler(this.cbox_CompanyName_SelectionChangeCommitted);
            // 
            // dti_MorningOnWorkTime
            // 
            // 
            // 
            // 
            this.dti_MorningOnWorkTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dti_MorningOnWorkTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dti_MorningOnWorkTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dti_MorningOnWorkTime.ButtonDropDown.Visible = true;
            this.dti_MorningOnWorkTime.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime;
            this.dti_MorningOnWorkTime.IsPopupCalendarOpen = false;
            this.dti_MorningOnWorkTime.Location = new System.Drawing.Point(139, 53);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dti_MorningOnWorkTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dti_MorningOnWorkTime.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dti_MorningOnWorkTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dti_MorningOnWorkTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dti_MorningOnWorkTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dti_MorningOnWorkTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dti_MorningOnWorkTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dti_MorningOnWorkTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dti_MorningOnWorkTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dti_MorningOnWorkTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dti_MorningOnWorkTime.MonthCalendar.DisplayMonth = new System.DateTime(2016, 10, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dti_MorningOnWorkTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dti_MorningOnWorkTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dti_MorningOnWorkTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dti_MorningOnWorkTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dti_MorningOnWorkTime.MonthCalendar.TodayButtonVisible = true;
            this.dti_MorningOnWorkTime.MonthCalendar.Visible = false;
            this.dti_MorningOnWorkTime.Name = "dti_MorningOnWorkTime";
            this.dti_MorningOnWorkTime.Size = new System.Drawing.Size(121, 21);
            this.dti_MorningOnWorkTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dti_MorningOnWorkTime.TabIndex = 20;
            // 
            // cb_night
            // 
            this.cb_night.Name = "cb_night";
            this.cb_night.Text = "是否夜班";
            this.cb_night.CheckedChanged += new DevComponents.DotNetBar.CheckBoxChangeEventHandler(this.cb_night_CheckedChanged);
            // 
            // WorkScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 253);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.bar1);
            this.MaximizeBox = false;
            this.Name = "WorkScheduleForm";
            this.Text = "上下班时间配置";
            this.Load += new System.EventHandler(this.WorkScheduleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dti_NightOnWorkTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dti_AfternoonUnderWorkTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dti_AfternoonOnWorkTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dti_MorningUnderWorkTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dti_MorningOnWorkTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btn_Save;
        private DevComponents.DotNetBar.ButtonItem btn_Modify;
        private DevComponents.DotNetBar.ButtonItem btn_Delete;
        private DevComponents.DotNetBar.ButtonItem btn_new;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dti_NightOnWorkTime;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dti_AfternoonUnderWorkTime;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dti_AfternoonOnWorkTime;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dti_MorningUnderWorkTime;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbox_CompanyName;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dti_MorningOnWorkTime;
        private DevComponents.DotNetBar.ButtonItem btn_cancel;
        private DevComponents.DotNetBar.CheckBoxItem cb_night;
    }
}