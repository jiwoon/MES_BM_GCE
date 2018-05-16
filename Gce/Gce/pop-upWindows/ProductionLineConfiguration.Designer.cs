namespace Gce.pop_upWindows
{
    partial class ProductionLineConfiguration
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btn_new = new DevComponents.DotNetBar.ButtonItem();
            this.btn_save = new DevComponents.DotNetBar.ButtonItem();
            this.btn_cancel = new DevComponents.DotNetBar.ButtonItem();
            this.btn_Modify = new DevComponents.DotNetBar.ButtonItem();
            this.btn_dalete = new DevComponents.DotNetBar.ButtonItem();
            this.btn_Query = new DevComponents.DotNetBar.ButtonItem();
            this.cell1 = new DevComponents.Tree.Cell();
            this.cell2 = new DevComponents.Tree.Cell();
            this.cell3 = new DevComponents.Tree.Cell();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txt_LineName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cb_CompanyName = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.panelEx1.SuspendLayout();
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
            this.btn_save,
            this.btn_cancel,
            this.btn_Modify,
            this.btn_dalete,
            this.btn_Query});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(508, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 0;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btn_new
            // 
            this.btn_new.Name = "btn_new";
            this.btn_new.Text = "新建";
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // btn_save
            // 
            this.btn_save.Name = "btn_save";
            this.btn_save.Text = "保存";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Text = "取消";
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_Modify
            // 
            this.btn_Modify.Name = "btn_Modify";
            this.btn_Modify.Text = "修改";
            this.btn_Modify.Click += new System.EventHandler(this.btn_Modify_Click);
            // 
            // btn_dalete
            // 
            this.btn_dalete.Name = "btn_dalete";
            this.btn_dalete.Text = "删除";
            this.btn_dalete.Click += new System.EventHandler(this.btn_dalete_Click);
            // 
            // btn_Query
            // 
            this.btn_Query.Name = "btn_Query";
            this.btn_Query.Text = "查找";
            this.btn_Query.Click += new System.EventHandler(this.btn_Query_Click);
            // 
            // cell1
            // 
            this.cell1.Name = "cell1";
            this.cell1.StyleMouseOver = null;
            // 
            // cell2
            // 
            this.cell2.Name = "cell2";
            this.cell2.StyleMouseOver = null;
            // 
            // cell3
            // 
            this.cell3.Name = "cell3";
            this.cell3.StyleMouseOver = null;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Location = new System.Drawing.Point(0, 27);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(150, 314);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewX1);
            this.panel1.Controls.Add(this.panelEx1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(150, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(358, 314);
            this.panel1.TabIndex = 2;
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 164);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.RowTemplate.Height = 23;
            this.dataGridViewX1.Size = new System.Drawing.Size(358, 154);
            this.dataGridViewX1.TabIndex = 9;
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.txt_LineName);
            this.panelEx1.Controls.Add(this.cb_CompanyName);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(358, 164);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 5;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(68, 93);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(81, 18);
            this.labelX2.TabIndex = 7;
            this.labelX2.Text = "公司上班类型";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(93, 54);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(56, 18);
            this.labelX1.TabIndex = 6;
            this.labelX1.Text = "生产线名";
            // 
            // txt_LineName
            // 
            // 
            // 
            // 
            this.txt_LineName.Border.Class = "TextBoxBorder";
            this.txt_LineName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_LineName.Location = new System.Drawing.Point(155, 51);
            this.txt_LineName.Name = "txt_LineName";
            this.txt_LineName.PreventEnterBeep = true;
            this.txt_LineName.Size = new System.Drawing.Size(136, 21);
            this.txt_LineName.TabIndex = 5;
            // 
            // cb_CompanyName
            // 
            this.cb_CompanyName.FormattingEnabled = true;
            this.cb_CompanyName.Location = new System.Drawing.Point(155, 93);
            this.cb_CompanyName.Name = "cb_CompanyName";
            this.cb_CompanyName.Size = new System.Drawing.Size(136, 20);
            this.cb_CompanyName.TabIndex = 4;
            this.cb_CompanyName.SelectionChangeCommitted += new System.EventHandler(this.cb_CompanyName_SelectionChangeCommitted);
            // 
            // ProductionLineConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 341);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.bar1);
            this.Name = "ProductionLineConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "生产线PC配置";
            this.Load += new System.EventHandler(this.ProductionLineConfiguration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btn_new;
        private DevComponents.Tree.Cell cell1;
        private DevComponents.Tree.Cell cell2;
        private DevComponents.Tree.Cell cell3;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonItem btn_save;
        private DevComponents.DotNetBar.ButtonItem btn_Modify;
        private DevComponents.DotNetBar.ButtonItem btn_dalete;
        private DevComponents.DotNetBar.ButtonItem btn_cancel;
        private DevComponents.DotNetBar.ButtonItem btn_Query;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_LineName;
        private System.Windows.Forms.ComboBox cb_CompanyName;

    }
}