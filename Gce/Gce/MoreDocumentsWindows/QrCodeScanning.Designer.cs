namespace Gce.Windows
{
    partial class QrCodeScanning
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
            this.ck_MaterialList = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.ck_WarehousingDetails = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.ck_Stock = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.txt_MaterialCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.Dti_Begin = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.Dti_End = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.txt_SupplierName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txt_MaterialName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btni_query = new DevComponents.DotNetBar.ButtonItem();
            this.btni_PeckingOut = new DevComponents.DotNetBar.ButtonItem();
            this.lab_message = new DevComponents.DotNetBar.LabelItem();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dti_Begin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dti_End)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.ck_MaterialList);
            this.panelEx1.Controls.Add(this.ck_WarehousingDetails);
            this.panelEx1.Controls.Add(this.ck_Stock);
            this.panelEx1.Controls.Add(this.txt_MaterialCode);
            this.panelEx1.Controls.Add(this.labelX5);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.labelX4);
            this.panelEx1.Controls.Add(this.Dti_Begin);
            this.panelEx1.Controls.Add(this.Dti_End);
            this.panelEx1.Controls.Add(this.txt_SupplierName);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.txt_MaterialName);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.bar1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1147, 129);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // ck_MaterialList
            // 
            this.ck_MaterialList.AutoSize = true;
            // 
            // 
            // 
            this.ck_MaterialList.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ck_MaterialList.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Right;
            this.ck_MaterialList.Location = new System.Drawing.Point(406, 96);
            this.ck_MaterialList.Name = "ck_MaterialList";
            this.ck_MaterialList.Size = new System.Drawing.Size(101, 18);
            this.ck_MaterialList.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ck_MaterialList.TabIndex = 84;
            this.ck_MaterialList.Text = "领料出库明细";
            this.ck_MaterialList.CheckedChanged += new System.EventHandler(this.ck_MaterialList_CheckedChanged);
            // 
            // ck_WarehousingDetails
            // 
            this.ck_WarehousingDetails.AutoSize = true;
            // 
            // 
            // 
            this.ck_WarehousingDetails.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ck_WarehousingDetails.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Right;
            this.ck_WarehousingDetails.Location = new System.Drawing.Point(312, 96);
            this.ck_WarehousingDetails.Name = "ck_WarehousingDetails";
            this.ck_WarehousingDetails.Size = new System.Drawing.Size(76, 18);
            this.ck_WarehousingDetails.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ck_WarehousingDetails.TabIndex = 83;
            this.ck_WarehousingDetails.Text = "入库明细";
            this.ck_WarehousingDetails.CheckedChanged += new System.EventHandler(this.ck_WarehousingDetails_CheckedChanged);
            // 
            // ck_Stock
            // 
            this.ck_Stock.AutoSize = true;
            // 
            // 
            // 
            this.ck_Stock.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ck_Stock.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Right;
            this.ck_Stock.Location = new System.Drawing.Point(238, 96);
            this.ck_Stock.Name = "ck_Stock";
            this.ck_Stock.Size = new System.Drawing.Size(51, 18);
            this.ck_Stock.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ck_Stock.TabIndex = 82;
            this.ck_Stock.Text = "库存";
            this.ck_Stock.CheckedChanged += new System.EventHandler(this.ck_Stock_CheckedChanged);
            // 
            // txt_MaterialCode
            // 
            this.txt_MaterialCode.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.txt_MaterialCode.Border.Class = "TextBoxBorder";
            this.txt_MaterialCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_MaterialCode.Location = new System.Drawing.Point(92, 93);
            this.txt_MaterialCode.Name = "txt_MaterialCode";
            this.txt_MaterialCode.PreventEnterBeep = true;
            this.txt_MaterialCode.Size = new System.Drawing.Size(123, 21);
            this.txt_MaterialCode.TabIndex = 81;
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(30, 96);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(56, 18);
            this.labelX5.TabIndex = 80;
            this.labelX5.Text = "物料编码";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(639, 46);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(19, 18);
            this.labelX2.TabIndex = 79;
            this.labelX2.Text = "至";
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(447, 46);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(19, 18);
            this.labelX4.TabIndex = 78;
            this.labelX4.Text = "从";
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
            this.Dti_Begin.CustomFormat = "yyyy-MM-dd HH:mm";
            this.Dti_Begin.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.Both;
            this.Dti_Begin.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.Dti_Begin.IsPopupCalendarOpen = false;
            this.Dti_Begin.Location = new System.Drawing.Point(472, 43);
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
            this.Dti_Begin.TabIndex = 77;
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
            this.Dti_End.CustomFormat = "yyyy-MM-dd HH:mm";
            this.Dti_End.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.Both;
            this.Dti_End.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.Dti_End.IsPopupCalendarOpen = false;
            this.Dti_End.Location = new System.Drawing.Point(660, 43);
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
            this.Dti_End.Size = new System.Drawing.Size(170, 21);
            this.Dti_End.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Dti_End.TabIndex = 76;
            // 
            // txt_SupplierName
            // 
            this.txt_SupplierName.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.txt_SupplierName.Border.Class = "TextBoxBorder";
            this.txt_SupplierName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_SupplierName.Location = new System.Drawing.Point(303, 43);
            this.txt_SupplierName.Name = "txt_SupplierName";
            this.txt_SupplierName.PreventEnterBeep = true;
            this.txt_SupplierName.Size = new System.Drawing.Size(123, 21);
            this.txt_SupplierName.TabIndex = 75;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(229, 46);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(68, 18);
            this.labelX1.TabIndex = 74;
            this.labelX1.Text = "供应商名称";
            // 
            // txt_MaterialName
            // 
            this.txt_MaterialName.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.txt_MaterialName.Border.Class = "TextBoxBorder";
            this.txt_MaterialName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_MaterialName.Location = new System.Drawing.Point(92, 43);
            this.txt_MaterialName.Name = "txt_MaterialName";
            this.txt_MaterialName.PreventEnterBeep = true;
            this.txt_MaterialName.Size = new System.Drawing.Size(123, 21);
            this.txt_MaterialName.TabIndex = 73;
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(30, 46);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(56, 18);
            this.labelX3.TabIndex = 72;
            this.labelX3.Text = "物料名称";
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
            this.btni_PeckingOut,
            this.lab_message});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(1147, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 71;
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
            // btni_PeckingOut
            // 
            this.btni_PeckingOut.FontBold = true;
            this.btni_PeckingOut.Name = "btni_PeckingOut";
            this.btni_PeckingOut.Text = "数据导出";
            // 
            // lab_message
            // 
            this.lab_message.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_message.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.lab_message.Name = "lab_message";
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
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 129);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.ReadOnly = true;
            this.dataGridViewX1.RowTemplate.Height = 23;
            this.dataGridViewX1.Size = new System.Drawing.Size(1147, 307);
            this.dataGridViewX1.TabIndex = 25;
            // 
            // QrCodeScanning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 436);
            this.Controls.Add(this.dataGridViewX1);
            this.Controls.Add(this.panelEx1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QrCodeScanning";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "仓库汇总查询";
            this.Load += new System.EventHandler(this.QrCodeScanning_Load);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dti_Begin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dti_End)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btni_query;
        private DevComponents.DotNetBar.ButtonItem btni_PeckingOut;
        private DevComponents.DotNetBar.LabelItem lab_message;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_MaterialName;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_SupplierName;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput Dti_Begin;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput Dti_End;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_MaterialCode;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.CheckBoxX ck_Stock;
        private DevComponents.DotNetBar.Controls.CheckBoxX ck_MaterialList;
        private DevComponents.DotNetBar.Controls.CheckBoxX ck_WarehousingDetails;
    }
}