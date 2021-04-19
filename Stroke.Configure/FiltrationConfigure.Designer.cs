namespace Stroke.Configure
{
    partial class FiltrationConfigure
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
            this.textBoxFiltrations = new System.Windows.Forms.TextBox();
            this.buttonSpy = new System.Windows.Forms.Button();
            this.labelAssemblies = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxFiltrations
            // 
            this.textBoxFiltrations.AcceptsReturn = true;
            this.textBoxFiltrations.AcceptsTab = true;
            this.textBoxFiltrations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFiltrations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFiltrations.Font = new System.Drawing.Font("Consolas", 12F);
            this.textBoxFiltrations.Location = new System.Drawing.Point(12, 37);
            this.textBoxFiltrations.MaxLength = 2147483647;
            this.textBoxFiltrations.Multiline = true;
            this.textBoxFiltrations.Name = "textBoxFiltrations";
            this.textBoxFiltrations.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxFiltrations.Size = new System.Drawing.Size(760, 512);
            this.textBoxFiltrations.TabIndex = 2;
            this.textBoxFiltrations.WordWrap = false;
            // 
            // buttonSpy
            // 
            this.buttonSpy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSpy.Location = new System.Drawing.Point(707, 6);
            this.buttonSpy.Name = "buttonSpy";
            this.buttonSpy.Size = new System.Drawing.Size(65, 25);
            this.buttonSpy.TabIndex = 1;
            this.buttonSpy.Text = "添加路径";
            this.buttonSpy.UseVisualStyleBackColor = true;
            this.buttonSpy.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonSpy_MouseDown);
            // 
            // labelAssemblies
            // 
            this.labelAssemblies.AutoSize = true;
            this.labelAssemblies.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelAssemblies.Location = new System.Drawing.Point(352, 17);
            this.labelAssemblies.Name = "labelAssemblies";
            this.labelAssemblies.Size = new System.Drawing.Size(80, 17);
            this.labelAssemblies.TabIndex = 0;
            this.labelAssemblies.Text = "程序路径模式";
            // 
            // FiltrationConfigure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.labelAssemblies);
            this.Controls.Add(this.buttonSpy);
            this.Controls.Add(this.textBoxFiltrations);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FiltrationConfigure";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "过滤设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FiltrationConfigure_FormClosing);
            this.Load += new System.EventHandler(this.FiltrationConfigure_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox textBoxFiltrations;
        private System.Windows.Forms.Button buttonSpy;
        private System.Windows.Forms.Label labelAssemblies;
    }
}