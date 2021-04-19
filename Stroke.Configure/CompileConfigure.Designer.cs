namespace Stroke.Configure
{
    partial class CompileConfigure
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
            this.textBoxAssemblies = new System.Windows.Forms.TextBox();
            this.textBoxNamespaces = new System.Windows.Forms.TextBox();
            this.labelAssemblies = new System.Windows.Forms.Label();
            this.labelNamespaces = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxAssemblies
            // 
            this.textBoxAssemblies.AcceptsReturn = true;
            this.textBoxAssemblies.AcceptsTab = true;
            this.textBoxAssemblies.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxAssemblies.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxAssemblies.Font = new System.Drawing.Font("Consolas", 12F);
            this.textBoxAssemblies.Location = new System.Drawing.Point(12, 37);
            this.textBoxAssemblies.MaxLength = 2147483647;
            this.textBoxAssemblies.Multiline = true;
            this.textBoxAssemblies.Name = "textBoxAssemblies";
            this.textBoxAssemblies.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxAssemblies.Size = new System.Drawing.Size(298, 512);
            this.textBoxAssemblies.TabIndex = 2;
            this.textBoxAssemblies.WordWrap = false;
            // 
            // textBoxNamespaces
            // 
            this.textBoxNamespaces.AcceptsReturn = true;
            this.textBoxNamespaces.AcceptsTab = true;
            this.textBoxNamespaces.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNamespaces.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxNamespaces.Font = new System.Drawing.Font("Consolas", 12F);
            this.textBoxNamespaces.Location = new System.Drawing.Point(316, 37);
            this.textBoxNamespaces.MaxLength = 2147483647;
            this.textBoxNamespaces.Multiline = true;
            this.textBoxNamespaces.Name = "textBoxNamespaces";
            this.textBoxNamespaces.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxNamespaces.Size = new System.Drawing.Size(462, 512);
            this.textBoxNamespaces.TabIndex = 3;
            this.textBoxNamespaces.WordWrap = false;
            // 
            // labelAssemblies
            // 
            this.labelAssemblies.AutoSize = true;
            this.labelAssemblies.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelAssemblies.Location = new System.Drawing.Point(127, 17);
            this.labelAssemblies.Name = "labelAssemblies";
            this.labelAssemblies.Size = new System.Drawing.Size(68, 17);
            this.labelAssemblies.TabIndex = 0;
            this.labelAssemblies.Text = "引用程序集";
            // 
            // labelNamespaces
            // 
            this.labelNamespaces.AutoSize = true;
            this.labelNamespaces.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelNamespaces.Location = new System.Drawing.Point(519, 17);
            this.labelNamespaces.Name = "labelNamespaces";
            this.labelNamespaces.Size = new System.Drawing.Size(56, 17);
            this.labelNamespaces.TabIndex = 1;
            this.labelNamespaces.Text = "命名空间";
            // 
            // CompileConfigure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.labelNamespaces);
            this.Controls.Add(this.labelAssemblies);
            this.Controls.Add(this.textBoxNamespaces);
            this.Controls.Add(this.textBoxAssemblies);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "CompileConfigure";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " 编译设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CompileConfigure_FormClosing);
            this.Load += new System.EventHandler(this.CompileConfigure_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox textBoxAssemblies;
        private System.Windows.Forms.TextBox textBoxNamespaces;
        private System.Windows.Forms.Label labelAssemblies;
        private System.Windows.Forms.Label labelNamespaces;
    }
}