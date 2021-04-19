namespace Stroke.Configure
{
    partial class GestureConfigure
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
            this.panel = new System.Windows.Forms.Panel();
            this.listViewGesture = new System.Windows.Forms.ListView();
            this.pictureBoxGesture = new System.Windows.Forms.PictureBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGesture)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.AliceBlue;
            this.panel.Controls.Add(this.listViewGesture);
            this.panel.Controls.Add(this.pictureBoxGesture);
            this.panel.Controls.Add(this.textBoxName);
            this.panel.Location = new System.Drawing.Point(12, 12);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(760, 538);
            this.panel.TabIndex = 0;
            // 
            // listViewGesture
            // 
            this.listViewGesture.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listViewGesture.HideSelection = false;
            this.listViewGesture.Location = new System.Drawing.Point(13, 10);
            this.listViewGesture.MultiSelect = false;
            this.listViewGesture.Name = "listViewGesture";
            this.listViewGesture.Size = new System.Drawing.Size(246, 516);
            this.listViewGesture.TabIndex = 0;
            this.listViewGesture.TileSize = new System.Drawing.Size(56, 56);
            this.listViewGesture.UseCompatibleStateImageBehavior = false;
            this.listViewGesture.View = System.Windows.Forms.View.Tile;
            this.listViewGesture.SelectedIndexChanged += new System.EventHandler(this.listViewGesture_SelectedIndexChanged);
            this.listViewGesture.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewGesture_MouseClick);
            // 
            // pictureBoxGesture
            // 
            this.pictureBoxGesture.BackColor = System.Drawing.Color.White;
            this.pictureBoxGesture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxGesture.Location = new System.Drawing.Point(269, 46);
            this.pictureBoxGesture.Name = "pictureBoxGesture";
            this.pictureBoxGesture.Size = new System.Drawing.Size(480, 480);
            this.pictureBoxGesture.TabIndex = 4;
            this.pictureBoxGesture.TabStop = false;
            this.pictureBoxGesture.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGesture_MouseClick);
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxName.Location = new System.Drawing.Point(269, 10);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(480, 26);
            this.textBoxName.TabIndex = 1;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // GestureConfigure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "GestureConfigure";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "手势设置";
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGesture)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.PictureBox pictureBoxGesture;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.ListView listViewGesture;
    }
}