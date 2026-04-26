namespace Stroke.Configure
{
    partial class ThreadConfigure
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelThread = new System.Windows.Forms.Label();
            this.numericUpDownThread = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThread)).BeginInit();
            this.SuspendLayout();
            // 
            // labelThread
            // 
            this.labelThread.AutoSize = true;
            this.labelThread.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelThread.Location = new System.Drawing.Point(28, 28);
            this.labelThread.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelThread.Name = "labelThread";
            this.labelThread.Size = new System.Drawing.Size(69, 20);
            this.labelThread.TabIndex = 0;
            this.labelThread.Text = "";
            // 
            // numericUpDownThread
            // 
            this.numericUpDownThread.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownThread.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numericUpDownThread.Location = new System.Drawing.Point(144, 25);
            this.numericUpDownThread.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownThread.Maximum = new decimal(new int[] { 64, 0, 0, 0 });
            this.numericUpDownThread.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numericUpDownThread.Name = "numericUpDownThread";
            this.numericUpDownThread.Size = new System.Drawing.Size(43, 27);
            this.numericUpDownThread.TabIndex = 1;
            this.numericUpDownThread.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownThread.Value = new decimal(new int[] { 8, 0, 0, 0 });
            // 
            // ThreadConfigure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(222, 66);
            this.Controls.Add(this.labelThread);
            this.Controls.Add(this.numericUpDownThread);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(240, 113);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(240, 113);
            this.Name = "ThreadConfigure";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ThreadConfigure_FormClosing);
            this.Load += new System.EventHandler(this.ThreadConfigure_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThread)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label labelThread;
        private System.Windows.Forms.NumericUpDown numericUpDownThread;
    }
}