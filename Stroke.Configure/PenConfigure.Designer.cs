namespace Stroke.Configure
{
    partial class PenConfigure
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
            this.textBoxColor = new System.Windows.Forms.TextBox();
            this.pictureBoxColor = new System.Windows.Forms.PictureBox();
            this.labelColor = new System.Windows.Forms.Label();
            this.labelOpacity = new System.Windows.Forms.Label();
            this.trackBarOpacity = new System.Windows.Forms.TrackBar();
            this.labelThickness = new System.Windows.Forms.Label();
            this.labelOpacityInfo = new System.Windows.Forms.Label();
            this.labelThicknessInfo = new System.Windows.Forms.Label();
            this.trackBarThickness = new System.Windows.Forms.TrackBar();
            this.labelHash = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThickness)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxColor
            // 
            this.textBoxColor.Location = new System.Drawing.Point(109, 20);
            this.textBoxColor.MaxLength = 6;
            this.textBoxColor.Name = "textBoxColor";
            this.textBoxColor.Size = new System.Drawing.Size(80, 21);
            this.textBoxColor.TabIndex = 2;
            this.textBoxColor.TextChanged += new System.EventHandler(this.textBoxColor_TextChanged);
            // 
            // pictureBoxColor
            // 
            this.pictureBoxColor.BackColor = System.Drawing.Color.Black;
            this.pictureBoxColor.Location = new System.Drawing.Point(218, 18);
            this.pictureBoxColor.Name = "pictureBoxColor";
            this.pictureBoxColor.Size = new System.Drawing.Size(25, 25);
            this.pictureBoxColor.TabIndex = 5;
            this.pictureBoxColor.TabStop = false;
            // 
            // labelColor
            // 
            this.labelColor.AutoSize = true;
            this.labelColor.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelColor.Location = new System.Drawing.Point(25, 22);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(32, 17);
            this.labelColor.TabIndex = 0;
            this.labelColor.Text = "颜色";
            // 
            // labelOpacity
            // 
            this.labelOpacity.AutoSize = true;
            this.labelOpacity.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelOpacity.Location = new System.Drawing.Point(25, 65);
            this.labelOpacity.Name = "labelOpacity";
            this.labelOpacity.Size = new System.Drawing.Size(56, 17);
            this.labelOpacity.TabIndex = 3;
            this.labelOpacity.Text = "不透明度";
            // 
            // trackBarOpacity
            // 
            this.trackBarOpacity.LargeChange = 1;
            this.trackBarOpacity.Location = new System.Drawing.Point(88, 65);
            this.trackBarOpacity.Name = "trackBarOpacity";
            this.trackBarOpacity.Size = new System.Drawing.Size(110, 45);
            this.trackBarOpacity.TabIndex = 4;
            this.trackBarOpacity.ValueChanged += new System.EventHandler(this.trackBarOpacity_ValueChanged);
            // 
            // labelThickness
            // 
            this.labelThickness.AutoSize = true;
            this.labelThickness.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelThickness.Location = new System.Drawing.Point(25, 114);
            this.labelThickness.Name = "labelThickness";
            this.labelThickness.Size = new System.Drawing.Size(32, 17);
            this.labelThickness.TabIndex = 6;
            this.labelThickness.Text = "粗细";
            // 
            // labelOpacityInfo
            // 
            this.labelOpacityInfo.AutoSize = true;
            this.labelOpacityInfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelOpacityInfo.Location = new System.Drawing.Point(218, 65);
            this.labelOpacityInfo.Name = "labelOpacityInfo";
            this.labelOpacityInfo.Size = new System.Drawing.Size(30, 17);
            this.labelOpacityInfo.TabIndex = 5;
            this.labelOpacityInfo.Text = "0 %";
            // 
            // labelThicknessInfo
            // 
            this.labelThicknessInfo.AutoSize = true;
            this.labelThicknessInfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelThicknessInfo.Location = new System.Drawing.Point(218, 114);
            this.labelThicknessInfo.Name = "labelThicknessInfo";
            this.labelThicknessInfo.Size = new System.Drawing.Size(33, 17);
            this.labelThicknessInfo.TabIndex = 8;
            this.labelThicknessInfo.Text = "0 px";
            // 
            // trackBarThickness
            // 
            this.trackBarThickness.LargeChange = 1;
            this.trackBarThickness.Location = new System.Drawing.Point(88, 114);
            this.trackBarThickness.Name = "trackBarThickness";
            this.trackBarThickness.Size = new System.Drawing.Size(110, 45);
            this.trackBarThickness.TabIndex = 7;
            this.trackBarThickness.ValueChanged += new System.EventHandler(this.trackBarThickness_ValueChanged);
            // 
            // labelHash
            // 
            this.labelHash.AutoSize = true;
            this.labelHash.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelHash.Location = new System.Drawing.Point(93, 22);
            this.labelHash.Name = "labelHash";
            this.labelHash.Size = new System.Drawing.Size(16, 17);
            this.labelHash.TabIndex = 1;
            this.labelHash.Text = "#";
            // 
            // PenConfigure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.labelHash);
            this.Controls.Add(this.labelThicknessInfo);
            this.Controls.Add(this.trackBarThickness);
            this.Controls.Add(this.labelOpacityInfo);
            this.Controls.Add(this.labelThickness);
            this.Controls.Add(this.trackBarOpacity);
            this.Controls.Add(this.labelOpacity);
            this.Controls.Add(this.labelColor);
            this.Controls.Add(this.pictureBoxColor);
            this.Controls.Add(this.textBoxColor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "PenConfigure";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "画笔设置";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThickness)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox textBoxColor;
        private System.Windows.Forms.PictureBox pictureBoxColor;
        private System.Windows.Forms.Label labelColor;
        private System.Windows.Forms.Label labelOpacity;
        private System.Windows.Forms.TrackBar trackBarOpacity;
        private System.Windows.Forms.Label labelThickness;
        private System.Windows.Forms.Label labelOpacityInfo;
        private System.Windows.Forms.Label labelThicknessInfo;
        private System.Windows.Forms.TrackBar trackBarThickness;
        private System.Windows.Forms.Label labelHash;
    }
}