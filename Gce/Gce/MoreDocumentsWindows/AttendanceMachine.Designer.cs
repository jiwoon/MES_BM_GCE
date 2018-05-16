namespace Gce.MoreDocumentsWindows
{
    partial class AttendanceMachine
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
            this.expandablePanel1 = new DevComponents.DotNetBar.ExpandablePanel();
            this.btn_ChangeMachineCoding = new DevComponents.DotNetBar.ButtonX();
            this.btn_ClearData = new DevComponents.DotNetBar.ButtonX();
            this.btn_AcceptedData = new DevComponents.DotNetBar.ButtonX();
            this.btn_InspectionAllTime = new DevComponents.DotNetBar.ButtonX();
            this.btn_InspectionTime = new DevComponents.DotNetBar.ButtonX();
            this.btn_TestAllConnection = new DevComponents.DotNetBar.ButtonX();
            this.btn_TestConnection = new DevComponents.DotNetBar.ButtonX();
            this.txt_IPAddress = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.txt_BaudRate = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.com_MachineUse = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.com_COMmouth = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX13 = new DevComponents.DotNetBar.LabelX();
            this.com_machine = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txt_MachineCoding = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btni_edit = new DevComponents.DotNetBar.ButtonItem();
            this.btni_save = new DevComponents.DotNetBar.ButtonItem();
            this.btni_cancle = new DevComponents.DotNetBar.ButtonItem();
            this.btni_delete = new DevComponents.DotNetBar.ButtonItem();
            this.btni_NewMachine = new DevComponents.DotNetBar.ButtonItem();
            this.btni_DataInput = new DevComponents.DotNetBar.ButtonItem();
            this.btni_DataOut = new DevComponents.DotNetBar.ButtonItem();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.panelEx1.SuspendLayout();
            this.expandablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.expandablePanel1);
            this.panelEx1.Controls.Add(this.txt_IPAddress);
            this.panelEx1.Controls.Add(this.labelX5);
            this.panelEx1.Controls.Add(this.txt_BaudRate);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.com_MachineUse);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.com_COMmouth);
            this.panelEx1.Controls.Add(this.labelX13);
            this.panelEx1.Controls.Add(this.com_machine);
            this.panelEx1.Controls.Add(this.txt_MachineCoding);
            this.panelEx1.Controls.Add(this.labelX4);
            this.panelEx1.Controls.Add(this.bar1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1142, 245);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // expandablePanel1
            // 
            this.expandablePanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel1.Controls.Add(this.btn_ChangeMachineCoding);
            this.expandablePanel1.Controls.Add(this.btn_ClearData);
            this.expandablePanel1.Controls.Add(this.btn_AcceptedData);
            this.expandablePanel1.Controls.Add(this.btn_InspectionAllTime);
            this.expandablePanel1.Controls.Add(this.btn_InspectionTime);
            this.expandablePanel1.Controls.Add(this.btn_TestAllConnection);
            this.expandablePanel1.Controls.Add(this.btn_TestConnection);
            this.expandablePanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.expandablePanel1.HideControlsWhenCollapsed = true;
            this.expandablePanel1.Location = new System.Drawing.Point(28, 140);
            this.expandablePanel1.Name = "expandablePanel1";
            this.expandablePanel1.Size = new System.Drawing.Size(694, 100);
            this.expandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandablePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel1.Style.GradientAngle = 90;
            this.expandablePanel1.StyleMouseDown.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.StyleMouseDown.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandablePanel1.StyleMouseDown.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.expandablePanel1.StyleMouseDown.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder;
            this.expandablePanel1.StyleMouseDown.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedText;
            this.expandablePanel1.StyleMouseOver.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.StyleMouseOver.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemHotBackground;
            this.expandablePanel1.StyleMouseOver.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemHotBackground2;
            this.expandablePanel1.StyleMouseOver.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemHotBorder;
            this.expandablePanel1.StyleMouseOver.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemHotText;
            this.expandablePanel1.TabIndex = 85;
            this.expandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel1.TitleStyle.GradientAngle = 90;
            this.expandablePanel1.TitleText = "机器管理";
            // 
            // btn_ChangeMachineCoding
            // 
            this.btn_ChangeMachineCoding.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_ChangeMachineCoding.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_ChangeMachineCoding.Location = new System.Drawing.Point(599, 51);
            this.btn_ChangeMachineCoding.Name = "btn_ChangeMachineCoding";
            this.btn_ChangeMachineCoding.Size = new System.Drawing.Size(85, 23);
            this.btn_ChangeMachineCoding.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_ChangeMachineCoding.TabIndex = 10;
            this.btn_ChangeMachineCoding.Text = "更改机器编码";
            this.btn_ChangeMachineCoding.Click += new System.EventHandler(this.btn_ChangeMachineCoding_Click);
            // 
            // btn_ClearData
            // 
            this.btn_ClearData.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_ClearData.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_ClearData.Location = new System.Drawing.Point(505, 51);
            this.btn_ClearData.Name = "btn_ClearData";
            this.btn_ClearData.Size = new System.Drawing.Size(75, 23);
            this.btn_ClearData.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_ClearData.TabIndex = 9;
            this.btn_ClearData.Text = "清除数据";
            this.btn_ClearData.Click += new System.EventHandler(this.btn_ClearData_Click);
            // 
            // btn_AcceptedData
            // 
            this.btn_AcceptedData.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_AcceptedData.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_AcceptedData.Location = new System.Drawing.Point(412, 51);
            this.btn_AcceptedData.Name = "btn_AcceptedData";
            this.btn_AcceptedData.Size = new System.Drawing.Size(75, 23);
            this.btn_AcceptedData.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_AcceptedData.TabIndex = 8;
            this.btn_AcceptedData.Text = "接收数据";
            this.btn_AcceptedData.Click += new System.EventHandler(this.btn_AcceptedData_Click);
            // 
            // btn_InspectionAllTime
            // 
            this.btn_InspectionAllTime.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_InspectionAllTime.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_InspectionAllTime.Location = new System.Drawing.Point(313, 51);
            this.btn_InspectionAllTime.Name = "btn_InspectionAllTime";
            this.btn_InspectionAllTime.Size = new System.Drawing.Size(81, 23);
            this.btn_InspectionAllTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_InspectionAllTime.TabIndex = 7;
            this.btn_InspectionAllTime.Text = "校验所有时间";
            this.btn_InspectionAllTime.Click += new System.EventHandler(this.btn_InspectionAllTime_Click);
            // 
            // btn_InspectionTime
            // 
            this.btn_InspectionTime.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_InspectionTime.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_InspectionTime.Location = new System.Drawing.Point(218, 51);
            this.btn_InspectionTime.Name = "btn_InspectionTime";
            this.btn_InspectionTime.Size = new System.Drawing.Size(75, 23);
            this.btn_InspectionTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_InspectionTime.TabIndex = 6;
            this.btn_InspectionTime.Text = "校验时间";
            this.btn_InspectionTime.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // btn_TestAllConnection
            // 
            this.btn_TestAllConnection.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_TestAllConnection.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_TestAllConnection.Location = new System.Drawing.Point(111, 51);
            this.btn_TestAllConnection.Name = "btn_TestAllConnection";
            this.btn_TestAllConnection.Size = new System.Drawing.Size(83, 23);
            this.btn_TestAllConnection.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_TestAllConnection.TabIndex = 5;
            this.btn_TestAllConnection.Text = "测试所有连接";
            this.btn_TestAllConnection.Click += new System.EventHandler(this.btn_TestAllConnection_Click);
            // 
            // btn_TestConnection
            // 
            this.btn_TestConnection.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_TestConnection.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_TestConnection.Location = new System.Drawing.Point(12, 51);
            this.btn_TestConnection.Name = "btn_TestConnection";
            this.btn_TestConnection.Size = new System.Drawing.Size(75, 23);
            this.btn_TestConnection.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_TestConnection.TabIndex = 4;
            this.btn_TestConnection.Text = "测试连接";
            this.btn_TestConnection.Click += new System.EventHandler(this.btn_TestConnection_Click);
            // 
            // txt_IPAddress
            // 
            // 
            // 
            // 
            this.txt_IPAddress.Border.Class = "TextBoxBorder";
            this.txt_IPAddress.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_IPAddress.Location = new System.Drawing.Point(599, 103);
            this.txt_IPAddress.Name = "txt_IPAddress";
            this.txt_IPAddress.PreventEnterBeep = true;
            this.txt_IPAddress.Size = new System.Drawing.Size(181, 21);
            this.txt_IPAddress.TabIndex = 84;
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(549, 106);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(44, 18);
            this.labelX5.TabIndex = 83;
            this.labelX5.Text = "IP地址";
            // 
            // txt_BaudRate
            // 
            // 
            // 
            // 
            this.txt_BaudRate.Border.Class = "TextBoxBorder";
            this.txt_BaudRate.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_BaudRate.Location = new System.Drawing.Point(599, 50);
            this.txt_BaudRate.Name = "txt_BaudRate";
            this.txt_BaudRate.PreventEnterBeep = true;
            this.txt_BaudRate.Size = new System.Drawing.Size(181, 21);
            this.txt_BaudRate.TabIndex = 82;
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(549, 53);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(44, 18);
            this.labelX3.TabIndex = 81;
            this.labelX3.Text = "波特率";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(288, 106);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(56, 18);
            this.labelX2.TabIndex = 80;
            this.labelX2.Text = "机器用途";
            // 
            // com_MachineUse
            // 
            this.com_MachineUse.DisplayMember = "Text";
            this.com_MachineUse.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.com_MachineUse.FormattingEnabled = true;
            this.com_MachineUse.ItemHeight = 15;
            this.com_MachineUse.Location = new System.Drawing.Point(350, 103);
            this.com_MachineUse.Name = "com_MachineUse";
            this.com_MachineUse.Size = new System.Drawing.Size(181, 21);
            this.com_MachineUse.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.com_MachineUse.TabIndex = 79;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(307, 53);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(37, 18);
            this.labelX1.TabIndex = 78;
            this.labelX1.Text = "COM口";
            // 
            // com_COMmouth
            // 
            this.com_COMmouth.DisplayMember = "Text";
            this.com_COMmouth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.com_COMmouth.FormattingEnabled = true;
            this.com_COMmouth.ItemHeight = 15;
            this.com_COMmouth.Location = new System.Drawing.Point(350, 50);
            this.com_COMmouth.Name = "com_COMmouth";
            this.com_COMmouth.Size = new System.Drawing.Size(181, 21);
            this.com_COMmouth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.com_COMmouth.TabIndex = 77;
            // 
            // labelX13
            // 
            this.labelX13.AutoSize = true;
            // 
            // 
            // 
            this.labelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX13.Location = new System.Drawing.Point(28, 106);
            this.labelX13.Name = "labelX13";
            this.labelX13.Size = new System.Drawing.Size(56, 18);
            this.labelX13.TabIndex = 76;
            this.labelX13.Text = "机器位置";
            // 
            // com_machine
            // 
            this.com_machine.DisplayMember = "Text";
            this.com_machine.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.com_machine.FormattingEnabled = true;
            this.com_machine.ItemHeight = 15;
            this.com_machine.Location = new System.Drawing.Point(90, 103);
            this.com_machine.Name = "com_machine";
            this.com_machine.Size = new System.Drawing.Size(181, 21);
            this.com_machine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.com_machine.TabIndex = 75;
            // 
            // txt_MachineCoding
            // 
            // 
            // 
            // 
            this.txt_MachineCoding.Border.Class = "TextBoxBorder";
            this.txt_MachineCoding.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_MachineCoding.Location = new System.Drawing.Point(90, 50);
            this.txt_MachineCoding.Name = "txt_MachineCoding";
            this.txt_MachineCoding.PreventEnterBeep = true;
            this.txt_MachineCoding.Size = new System.Drawing.Size(181, 21);
            this.txt_MachineCoding.TabIndex = 70;
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(28, 53);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(56, 18);
            this.labelX4.TabIndex = 69;
            this.labelX4.Text = "机器编码";
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.DockSide = DevComponents.DotNetBar.eDockSide.Top;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btni_edit,
            this.btni_save,
            this.btni_cancle,
            this.btni_delete,
            this.btni_NewMachine,
            this.btni_DataInput,
            this.btni_DataOut});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(1142, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 0;
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
            // btni_NewMachine
            // 
            this.btni_NewMachine.FontBold = true;
            this.btni_NewMachine.Name = "btni_NewMachine";
            this.btni_NewMachine.Text = "新增机器";
            this.btni_NewMachine.Click += new System.EventHandler(this.btni_NewMachine_Click);
            // 
            // btni_DataInput
            // 
            this.btni_DataInput.FontBold = true;
            this.btni_DataInput.Name = "btni_DataInput";
            this.btni_DataInput.Text = "导入Excle";
            this.btni_DataInput.Visible = false;
            // 
            // btni_DataOut
            // 
            this.btni_DataOut.FontBold = true;
            this.btni_DataOut.Name = "btni_DataOut";
            this.btni_DataOut.Text = "导出Excle";
            this.btni_DataOut.Click += new System.EventHandler(this.btni_DataOut_Click);
            // 
            // dataGridViewX1
            // 
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
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 245);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.RowTemplate.Height = 23;
            this.dataGridViewX1.Size = new System.Drawing.Size(1142, 362);
            this.dataGridViewX1.TabIndex = 4;
            this.dataGridViewX1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridViewX1_RowPostPaint);
            this.dataGridViewX1.SelectionChanged += new System.EventHandler(this.dataGridViewX1_SelectionChanged);
            // 
            // AttendanceMachine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 607);
            this.Controls.Add(this.dataGridViewX1);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.Name = "AttendanceMachine";
            this.Text = "考勤机管理";
            this.Load += new System.EventHandler(this.AttendanceMachine_Load);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.expandablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.LabelX labelX13;
        private DevComponents.DotNetBar.Controls.ComboBoxEx com_machine;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_MachineCoding;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_IPAddress;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_BaudRate;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx com_MachineUse;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx com_COMmouth;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.ButtonItem btni_edit;
        private DevComponents.DotNetBar.ButtonItem btni_save;
        private DevComponents.DotNetBar.ButtonItem btni_cancle;
        private DevComponents.DotNetBar.ButtonItem btni_delete;
        private DevComponents.DotNetBar.ButtonItem btni_NewMachine;
        private DevComponents.DotNetBar.ButtonItem btni_DataInput;
        private DevComponents.DotNetBar.ButtonItem btni_DataOut;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel1;
        private DevComponents.DotNetBar.ButtonX btn_TestConnection;
        private DevComponents.DotNetBar.ButtonX btn_TestAllConnection;
        private DevComponents.DotNetBar.ButtonX btn_InspectionTime;
        private DevComponents.DotNetBar.ButtonX btn_InspectionAllTime;
        private DevComponents.DotNetBar.ButtonX btn_ClearData;
        private DevComponents.DotNetBar.ButtonX btn_AcceptedData;
        private DevComponents.DotNetBar.ButtonX btn_ChangeMachineCoding;
    }
}