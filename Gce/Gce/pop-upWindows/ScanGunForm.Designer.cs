namespace Gce.pop_upWindows
{
    partial class ScanGunForm
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
            this.txt_scan = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // txt_scan
            // 
            // 
            // 
            // 
            this.txt_scan.Border.Class = "TextBoxBorder";
            this.txt_scan.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_scan.Location = new System.Drawing.Point(67, 48);
            this.txt_scan.Name = "txt_scan";
            this.txt_scan.PreventEnterBeep = true;
            this.txt_scan.Size = new System.Drawing.Size(335, 21);
            this.txt_scan.TabIndex = 0;
            this.txt_scan.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_scan_KeyUp);
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(17, 51);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(44, 18);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "扫码框";
            // 
            // ScanGunForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 142);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.txt_scan);
            this.MaximizeBox = false;
            this.Name = "ScanGunForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "扫描枪扫码";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txt_scan;
        private DevComponents.DotNetBar.LabelX labelX1;
    }
}