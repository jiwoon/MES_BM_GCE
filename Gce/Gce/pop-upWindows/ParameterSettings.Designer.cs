namespace Gce.Windows
{
    partial class ParameterSettings
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
            this.tv_ProductClass = new System.Windows.Forms.TreeView();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.Insert = new DevComponents.DotNetBar.ButtonItem();
            this.Save = new DevComponents.DotNetBar.ButtonItem();
            this.Cancel = new DevComponents.DotNetBar.ButtonItem();
            this.btni_complete = new DevComponents.DotNetBar.ButtonItem();
            this.Modify = new DevComponents.DotNetBar.ButtonItem();
            this.Delete = new DevComponents.DotNetBar.ButtonItem();
            this.Query = new DevComponents.DotNetBar.ButtonItem();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.input_TheNumberOf = new DevComponents.Editors.IntegerInput();
            this.intput_MinimumCapacity = new DevComponents.Editors.IntegerInput();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.comb_ProductionClass = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Stations = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EfficiencyQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TheNumberOf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtB_ProductClass = new DevComponents.DotNetBar.Controls.TextBoxX();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input_TheNumberOf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intput_MinimumCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // tv_ProductClass
            // 
            this.tv_ProductClass.Dock = System.Windows.Forms.DockStyle.Left;
            this.tv_ProductClass.Location = new System.Drawing.Point(0, 0);
            this.tv_ProductClass.Name = "tv_ProductClass";
            this.tv_ProductClass.Size = new System.Drawing.Size(203, 383);
            this.tv_ProductClass.TabIndex = 4;
            this.tv_ProductClass.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_ProductClass_AfterSelect);
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.Insert,
            this.Save,
            this.Cancel,
            this.btni_complete,
            this.Modify,
            this.Delete,
            this.Query});
            this.bar1.Location = new System.Drawing.Point(203, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(342, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 5;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // Insert
            // 
            this.Insert.Name = "Insert";
            this.Insert.Text = "新建";
            this.Insert.Click += new System.EventHandler(this.Insert_Click);
            // 
            // Save
            // 
            this.Save.Name = "Save";
            this.Save.Text = "保存";
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Cancel
            // 
            this.Cancel.Name = "Cancel";
            this.Cancel.Text = "取消";
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // btni_complete
            // 
            this.btni_complete.Name = "btni_complete";
            this.btni_complete.Text = "完成";
            this.btni_complete.Click += new System.EventHandler(this.btni_complete_Click);
            // 
            // Modify
            // 
            this.Modify.Name = "Modify";
            this.Modify.Text = "修改";
            this.Modify.Click += new System.EventHandler(this.Modify_Click);
            // 
            // Delete
            // 
            this.Delete.Name = "Delete";
            this.Delete.Text = "删除";
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Query
            // 
            this.Query.Name = "Query";
            this.Query.Text = "查找";
            this.Query.Click += new System.EventHandler(this.Query_Click);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.input_TheNumberOf);
            this.panelEx1.Controls.Add(this.intput_MinimumCapacity);
            this.panelEx1.Controls.Add(this.labelX4);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.comb_ProductionClass);
            this.panelEx1.Controls.Add(this.dataGridViewX1);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.txtB_ProductClass);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Enabled = false;
            this.panelEx1.Location = new System.Drawing.Point(203, 27);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(342, 356);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 6;
            // 
            // input_TheNumberOf
            // 
            // 
            // 
            // 
            this.input_TheNumberOf.BackgroundStyle.Class = "DateTimeInputBackground";
            this.input_TheNumberOf.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.input_TheNumberOf.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.input_TheNumberOf.Location = new System.Drawing.Point(126, 125);
            this.input_TheNumberOf.MinValue = 0;
            this.input_TheNumberOf.Name = "input_TheNumberOf";
            this.input_TheNumberOf.ShowUpDown = true;
            this.input_TheNumberOf.Size = new System.Drawing.Size(90, 21);
            this.input_TheNumberOf.TabIndex = 23;
            // 
            // intput_MinimumCapacity
            // 
            // 
            // 
            // 
            this.intput_MinimumCapacity.BackgroundStyle.Class = "DateTimeInputBackground";
            this.intput_MinimumCapacity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.intput_MinimumCapacity.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.intput_MinimumCapacity.Location = new System.Drawing.Point(126, 90);
            this.intput_MinimumCapacity.MinValue = 0;
            this.intput_MinimumCapacity.Name = "intput_MinimumCapacity";
            this.intput_MinimumCapacity.ShowUpDown = true;
            this.intput_MinimumCapacity.Size = new System.Drawing.Size(90, 21);
            this.intput_MinimumCapacity.TabIndex = 22;
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(76, 128);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(44, 18);
            this.labelX4.TabIndex = 21;
            this.labelX4.Text = "人  数";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(27, 93);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(93, 18);
            this.labelX3.TabIndex = 20;
            this.labelX3.Text = "每小时最低产能";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(64, 60);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(56, 18);
            this.labelX1.TabIndex = 19;
            this.labelX1.Text = "生产类型";
            // 
            // comb_ProductionClass
            // 
            this.comb_ProductionClass.DisplayMember = "Text";
            this.comb_ProductionClass.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comb_ProductionClass.FormattingEnabled = true;
            this.comb_ProductionClass.ItemHeight = 15;
            this.comb_ProductionClass.Location = new System.Drawing.Point(126, 57);
            this.comb_ProductionClass.Name = "comb_ProductionClass";
            this.comb_ProductionClass.Size = new System.Drawing.Size(138, 21);
            this.comb_ProductionClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comb_ProductionClass.TabIndex = 18;
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Stations,
            this.EfficiencyQuantity,
            this.TheNumberOf,
            this.ProductClass,
            this.UpdateTime});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 161);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.ReadOnly = true;
            this.dataGridViewX1.RowTemplate.Height = 23;
            this.dataGridViewX1.Size = new System.Drawing.Size(342, 195);
            this.dataGridViewX1.TabIndex = 17;
            this.dataGridViewX1.SelectionChanged += new System.EventHandler(this.dataGridViewX1_SelectionChanged);
            // 
            // Stations
            // 
            this.Stations.DataPropertyName = "Stations";
            this.Stations.HeaderText = "生产类型";
            this.Stations.Name = "Stations";
            this.Stations.ReadOnly = true;
            // 
            // EfficiencyQuantity
            // 
            this.EfficiencyQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EfficiencyQuantity.DataPropertyName = "EfficiencyQuantity";
            this.EfficiencyQuantity.HeaderText = "每小时最低产能";
            this.EfficiencyQuantity.Name = "EfficiencyQuantity";
            this.EfficiencyQuantity.ReadOnly = true;
            // 
            // TheNumberOf
            // 
            this.TheNumberOf.DataPropertyName = "TheNumberOf";
            this.TheNumberOf.HeaderText = "人数";
            this.TheNumberOf.Name = "TheNumberOf";
            this.TheNumberOf.ReadOnly = true;
            this.TheNumberOf.Width = 80;
            // 
            // ProductClass
            // 
            this.ProductClass.DataPropertyName = "ProductClass";
            this.ProductClass.HeaderText = "类型";
            this.ProductClass.Name = "ProductClass";
            this.ProductClass.ReadOnly = true;
            this.ProductClass.Visible = false;
            // 
            // UpdateTime
            // 
            this.UpdateTime.DataPropertyName = "UpdateTime";
            this.UpdateTime.HeaderText = "更新时间";
            this.UpdateTime.Name = "UpdateTime";
            this.UpdateTime.ReadOnly = true;
            this.UpdateTime.Visible = false;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(64, 20);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(56, 18);
            this.labelX2.TabIndex = 10;
            this.labelX2.Text = "产能类型";
            // 
            // txtB_ProductClass
            // 
            // 
            // 
            // 
            this.txtB_ProductClass.Border.Class = "TextBoxBorder";
            this.txtB_ProductClass.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtB_ProductClass.Location = new System.Drawing.Point(126, 17);
            this.txtB_ProductClass.Name = "txtB_ProductClass";
            this.txtB_ProductClass.PreventEnterBeep = true;
            this.txtB_ProductClass.Size = new System.Drawing.Size(138, 21);
            this.txtB_ProductClass.TabIndex = 9;
            // 
            // ParameterSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 383);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.bar1);
            this.Controls.Add(this.tv_ProductClass);
            this.MaximizeBox = false;
            this.Name = "ParameterSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "产品产能设置";
            this.Load += new System.EventHandler(this.ProductSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input_TheNumberOf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intput_MinimumCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tv_ProductClass;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtB_ProductClass;
        private DevComponents.DotNetBar.ButtonItem Insert;
        private DevComponents.DotNetBar.ButtonItem Save;
        private DevComponents.DotNetBar.ButtonItem Modify;
        private DevComponents.DotNetBar.ButtonItem Delete;
        private DevComponents.DotNetBar.ButtonItem Cancel;
        private DevComponents.DotNetBar.ButtonItem Query;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comb_ProductionClass;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.Editors.IntegerInput input_TheNumberOf;
        private DevComponents.Editors.IntegerInput intput_MinimumCapacity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stations;
        private System.Windows.Forms.DataGridViewTextBoxColumn EfficiencyQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn TheNumberOf;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateTime;
        private DevComponents.DotNetBar.ButtonItem btni_complete;
    }
}