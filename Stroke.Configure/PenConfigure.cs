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

            textBoxColor.Text = (((int)Settings.Pen.Color.R << 16) + ((int)Settings.Pen.Color.G << 8) + ((int)Settings.Pen.Color.B)).ToString("X6");
            trackBarOpacity.Value = (int)(Settings.Pen.Opacity * 10);
            trackBarThickness.Value = (int)Settings.Pen.Thickness;
        }

        private void ApplyLocalization()
        {
            this.Text = Localization.GetString("FormPenConfigure_Title");
            labelColor.Text = Localization.GetString("LabelColor");
            labelOpacity.Text = Localization.GetString("LabelOpacity");
            labelThickness.Text = Localization.GetString("LabelThickness");
            labelOpacityInfo.Text = string.Format(Localization.GetString("PercentFormat"), trackBarOpacity.Value * 10);
            labelThicknessInfo.Text = trackBarThickness.Value + " " + Localization.GetString("Unit_Pixel");
        }

        private void PenConfigure_Load(object sender, EventArgs e)
        {
            ApplyLocalization();
        }

        private void trackBarOpacity_ValueChanged(object sender, EventArgs e)
        {
            Settings.Pen.Opacity = (double)trackBarOpacity.Value / 10;
            labelOpacityInfo.Text = string.Format(Localization.GetString("PercentFormat"), trackBarOpacity.Value * 10);
        }

        private void trackBarThickness_ValueChanged(object sender, EventArgs e)
        {
            Settings.Pen.Thickness = (byte)trackBarThickness.Value;
            labelThicknessInfo.Text = trackBarThickness.Value + " " + Localization.GetString("Unit_Pixel");
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
