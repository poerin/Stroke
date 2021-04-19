using System;
using System.Drawing;
using System.Windows.Forms;

namespace Stroke.Configure
{
    public partial class PenConfigure : Form
    {
        public PenConfigure()
        {
            InitializeComponent();

            textBoxColor.Text = (((int)Settings.Pen.Color.R << 16) + ((int)Settings.Pen.Color.G << 8) + ((int)Settings.Pen.Color.B)).ToString("X");
            trackBarOpacity.Value = (int)(Settings.Pen.Opacity * 10);
            trackBarThickness.Value = (int)Settings.Pen.Thickness;
        }

        private void trackBarOpacity_ValueChanged(object sender, EventArgs e)
        {
            Settings.Pen.Opacity = (double)trackBarOpacity.Value / 10;
            labelOpacityInfo.Text = trackBarOpacity.Value * 10 + " %";
        }

        private void trackBarThickness_ValueChanged(object sender, EventArgs e)
        {
            Settings.Pen.Thickness = (byte)trackBarThickness.Value;
            labelThicknessInfo.Text = trackBarThickness.Value + " px";
        }

        private void textBoxColor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Settings.Pen.Color = Color.FromArgb(Convert.ToInt32(textBoxColor.Text, 16) + (0xFF << 24));
                pictureBoxColor.BackColor = Settings.Pen.Color;
            }
            catch
            {
                Settings.Pen.Color = Color.FromArgb(0, 0, 0);
                pictureBoxColor.BackColor = Settings.Pen.Color;
            }
        }
    }
}
