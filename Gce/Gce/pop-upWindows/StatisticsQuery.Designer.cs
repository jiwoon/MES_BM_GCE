namespace Gce.pop_upWindows
{
    partial class StatisticsQuery
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.Dti_Begin = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.Dti_End = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btni_query = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.lab_message = new DevComponents.DotNetBar.LabelItem();
            this.labi_Message = new DevComponents.DotNetBar.LabelItem();
            this.input_QualifiedRate = new DevComponents.Editors.IntegerInput();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dti_Begin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dti_End)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input_QualifiedRate)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.BackgroundColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 93);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewX1.RowTemplate.Height = 23;
            this.dataGridViewX1.Size = new System.Drawing.Size(1205, 397);
            this.dataGridViewX1.TabIndex = 14;
            this.dataGridViewX1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridViewX1_RowPostPaint);
            this.dataGridViewX1.SelectionChanged += new System.EventHandler(this.dataGridViewX1_SelectionChanged);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.input_QualifiedRate);
            this.panelEx1.Controls.Add(this.labelX8);
            this.panelEx1.Controls.Add(this.labelX7);
            this.panelEx1.Controls.Add(this.labelX9);
            this.panelEx1.Controls.Add(this.Dti_Begin);
            this.panelEx1.Controls.Add(this.Dti_End);
            this.panelEx1.Controls.Add(this.bar1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1205, 93);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 13;
            // 
            // labelX7
            // 
            this.labelX7.AutoSize = true;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(225, 50);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(19, 18);
            this.labelX7.TabIndex = 59;
            this.labelX7.Text = "至";
            // 
            // labelX9
            // 
            this.labelX9.AutoSize = true;
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(24, 50);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(19, 18);
            this.labelX9.TabIndex = 58;
            this.labelX9.Text = "从";
            // 
            // Dti_Begin
            // 
            // 
            // 
            // 
            this.Dti_Begin.BackgroundStyle.Class = "DateTimeInputBackground";
            this.Dti_Begin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Dti_Begin.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.Dti_Begin.ButtonDropDown.Visible = true;
            this.Dti_Begin.CustomFormat = "yyyy-MM-dd";
            this.Dti_Begin.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.Both;
            this.Dti_Begin.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.Dti_Begin.IsPopupCalendarOpen = false;
            this.Dti_Begin.Location = new System.Drawing.Point(49, 47);
            // 
            // 
            // 
            // 
            // 
            // 
            this.Dti_Begin.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Dti_Begin.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.Dti_Begin.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.Dti_Begin.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.Dti_Begin.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.Dti_Begin.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.Dti_Begin.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Dti_Begin.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.Dti_Begin.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.Dti_Begin.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Dti_Begin.MonthCalendar.DayClickAutoClosePopup = false;
            this.Dti_Begin.MonthCalendar.DisplayMonth = new System.DateTime(2016, 8, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.Dti_Begin.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.Dti_Begin.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.Dti_Begin.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.Dti_Begin.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Dti_Begin.MonthCalendar.TodayButtonVisible = true;
            this.Dti_Begin.Name = "Dti_Begin";
            this.Dti_Begin.Size = new System.Drawing.Size(170, 21);
            this.Dti_Begin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Dti_Begin.TabIndex = 57;
            // 
            // Dti_End
            // 
            // 
            // 
            // 
            this.Dti_End.BackgroundStyle.Class = "DateTimeInputBackground";
            this.Dti_End.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Dti_End.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.Dti_End.ButtonDropDown.Visible = true;
            this.Dti_End.CustomFormat = "yyyy-MM-dd";
            this.Dti_End.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.Both;
            this.Dti_End.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.Dti_End.IsPopupCalendarOpen = false;
            this.Dti_End.Location = new System.Drawing.Point(251, 47);
            // 
            // 
            // 
            // 
            // 
            // 
            this.Dti_End.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Dti_End.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.Dti_End.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.Dti_End.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.Dti_End.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.Dti_End.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.Dti_End.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Dti_End.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.Dti_End.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.Dti_End.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Dti_End.MonthCalendar.DayClickAutoClosePopup = false;
            this.Dti_End.MonthCalendar.DisplayMonth = new System.DateTime(2016, 8, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.Dti_End.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.Dti_End.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.Dti_End.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.Dti_End.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Dti_End.MonthCalendar.TodayButtonVisible = true;
            this.Dti_End.Name = "Dti_End";
            this.Dti_End.Size = new System.Drawing.Size(155, 21);
            this.Dti_End.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Dti_End.TabIndex = 56;
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.DockSide = DevComponents.DotNetBar.eDockSide.Top;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btni_query,
            this.buttonItem1,
            this.lab_message,
            this.labi_Message});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(1205, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 54;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btni_query
            // 
            this.btni_query.FontBold = true;
            this.btni_query.Name = "btni_query";
            this.btni_query.Text = "查询";
            this.btni_query.Click += new System.EventHandler(this.btni_query_Click);
            // 
            // buttonItem1
            // 
            this.buttonItem1.FontBold = true;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "数据导出";
            this.buttonItem1.Click += new System.EventHandler(this.buttonItem1_Click);
            // 
            // lab_message
            // 
            this.lab_message.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_message.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.lab_message.Name = "lab_message";
            // 
            // labi_Message
            // 
            this.labi_Message.FontBold = true;
            this.labi_Message.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labi_Message.Name = "labi_Message";
            // 
            // input_QualifiedRate
            // 
            // 
            // 
            // 
            this.input_QualifiedRate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.input_QualifiedRate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.input_QualifiedRate.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.input_QualifiedRate.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.input_QualifiedRate.Location = new System.Drawing.Point(496, 47);
            this.input_QualifiedRate.MinValue = 0;
            this.input_QualifiedRate.Name = "input_QualifiedRate";
            this.input_QualifiedRate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.input_QualifiedRate.Size = new System.Drawing.Size(100, 21);
            this.input_QualifiedRate.TabIndex = 61;
            // 
            // labelX8
            // 
            this.labelX8.AutoSize = true;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(440, 50);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(50, 18);
            this.labelX8.TabIndex = 60;
            this.labelX8.Text = "目标(%)";
            // 
            // StatisticsQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 490);
            this.Controls.Add(this.dataGridViewX1);
            this.Controls.Add(this.panelEx1);
            this.Name = "StatisticsQuery";
            this.Text = "统计查询";
            this.Load += new System.EventHandler(this.StatisticsQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dti_Begin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dti_End)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input_QualifiedRate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput Dti_Begin;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput Dti_End;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btni_query;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.LabelItem lab_message;
        private DevComponents.DotNetBar.LabelItem labi_Message;
        private DevComponents.Editors.IntegerInput input_QualifiedRate;
        private DevComponents.DotNetBar.LabelX labelX8;
    }
}