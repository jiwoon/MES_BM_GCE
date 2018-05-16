namespace Gce.pop_upWindows
{
    partial class ParametersCall
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btni_new = new DevComponents.DotNetBar.ButtonItem();
            this.btni_save = new DevComponents.DotNetBar.ButtonItem();
            this.btni_cancle = new DevComponents.DotNetBar.ButtonItem();
            this.btni_modify = new DevComponents.DotNetBar.ButtonItem();
            this.btni_delete = new DevComponents.DotNetBar.ButtonItem();
            this.btni_lookup = new DevComponents.DotNetBar.ButtonItem();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Stations = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EfficiencyQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TheNumberOf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.cbe_ProductClass = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txt_Order = new DevComponents.DotNetBar.Controls.TextBoxX();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(188, 338);
            this.treeView1.TabIndex = 20;
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
            this.btni_lookup});
            this.bar1.Location = new System.Drawing.Point(188, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(394, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 28;
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
            // btni_modify
            // 
            this.btni_modify.FontBold = true;
            this.btni_modify.Name = "btni_modify";
            this.btni_modify.Text = "修改";
            this.btni_modify.Click += new System.EventHandler(this.btni_modify_Click);
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
            this.btni_lookup.Click += new System.EventHandler(this.btni_lookup_Click);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.dataGridViewX1);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.cbe_ProductClass);
            this.panelEx1.Controls.Add(this.txt_Order);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(188, 27);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(394, 311);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 32;
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 133);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.ReadOnly = true;
            this.dataGridViewX1.RowTemplate.Height = 23;
            this.dataGridViewX1.Size = new System.Drawing.Size(394, 178);
            this.dataGridViewX1.TabIndex = 22;
            // 
            // Stations
            // 
            this.Stations.DataPropertyName = "Stations";
            this.Stations.HeaderText = "生产类型";
            this.Stations.Name = "Stations";
            this.Stations.ReadOnly = true;
            this.Stations.Width = 120;
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
            this.labelX2.Location = new System.Drawing.Point(47, 84);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(68, 18);
            this.labelX2.TabIndex = 19;
            this.labelX2.Text = "产能类型：";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(59, 30);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(56, 18);
            this.labelX1.TabIndex = 18;
            this.labelX1.Text = "订单号：";
            // 
            // cbe_ProductClass
            // 
            this.cbe_ProductClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbe_ProductClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbe_ProductClass.DisplayMember = "Text";
            this.cbe_ProductClass.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbe_ProductClass.FormattingEnabled = true;
            this.cbe_ProductClass.ItemHeight = 15;
            this.cbe_ProductClass.Location = new System.Drawing.Point(121, 81);
            this.cbe_ProductClass.Name = "cbe_ProductClass";
            this.cbe_ProductClass.Size = new System.Drawing.Size(207, 21);
            this.cbe_ProductClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbe_ProductClass.TabIndex = 17;
            this.cbe_ProductClass.SelectionChangeCommitted += new System.EventHandler(this.cbe_ProductClass_SelectionChangeCommitted);
            this.cbe_ProductClass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbe_ProductClass_KeyDown);
            // 
            // txt_Order
            // 
            // 
            // 
            // 
            this.txt_Order.Border.Class = "TextBoxBorder";
            this.txt_Order.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_Order.Location = new System.Drawing.Point(121, 27);
            this.txt_Order.Name = "txt_Order";
            this.txt_Order.PreventEnterBeep = true;
            this.txt_Order.Size = new System.Drawing.Size(207, 21);
            this.txt_Order.TabIndex = 16;
            // 
            // ParametersCall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 338);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.bar1);
            this.Controls.Add(this.treeView1);
            this.MaximizeBox = false;
            this.Name = "ParametersCall";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "参数调用";
            this.Load += new System.EventHandler(this.ParametersCall_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btni_new;
        private DevComponents.DotNetBar.ButtonItem btni_save;
        private DevComponents.DotNetBar.ButtonItem btni_cancle;
        private DevComponents.DotNetBar.ButtonItem btni_modify;
        private DevComponents.DotNetBar.ButtonItem btni_delete;
        private DevComponents.DotNetBar.ButtonItem btni_lookup;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stations;
        private System.Windows.Forms.DataGridViewTextBoxColumn EfficiencyQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn TheNumberOf;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateTime;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbe_ProductClass;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_Order;

    }
}