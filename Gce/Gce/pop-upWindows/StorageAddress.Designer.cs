namespace Gce.pop_upWindows
{
    partial class StorageAddress
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
            this.txt_rasaul = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btn_OK = new DevComponents.DotNetBar.ButtonX();
            this.btn_cancle = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(474, 317);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // txt_rasaul
            // 
            // 
            // 
            // 
            this.txt_rasaul.Border.Class = "TextBoxBorder";
            this.txt_rasaul.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_rasaul.Location = new System.Drawing.Point(53, 348);
            this.txt_rasaul.Name = "txt_rasaul";
            this.txt_rasaul.PreventEnterBeep = true;
            this.txt_rasaul.Size = new System.Drawing.Size(365, 21);
            this.txt_rasaul.TabIndex = 1;
            // 
            // btn_OK
            // 
            this.btn_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_OK.Location = new System.Drawing.Point(53, 420);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_OK.TabIndex = 2;
            this.btn_OK.Text = "完成";
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_cancle
            // 
            this.btn_cancle.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_cancle.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_cancle.Location = new System.Drawing.Point(343, 420);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(75, 23);
            this.btn_cancle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_cancle.TabIndex = 3;
            this.btn_cancle.Text = "取消";
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // StorageAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 455);
            this.Controls.Add(this.btn_cancle);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.txt_rasaul);
            this.Controls.Add(this.treeView1);
            this.Name = "StorageAddress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "获取存放地点";
            this.Load += new System.EventHandler(this.StorageAddress_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_rasaul;
        private DevComponents.DotNetBar.ButtonX btn_OK;
        private DevComponents.DotNetBar.ButtonX btn_cancle;
    }
}