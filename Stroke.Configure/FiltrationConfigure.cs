using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Stroke.Configure
{
    public partial class FiltrationConfigure : Form
    {
        public FiltrationConfigure()
        {
            InitializeComponent();
        }

        private void buttonSpy_MouseDown(object sender, MouseEventArgs e)
        {
            Configure.Spy = true;
            Configure.Receptor = textBoxFiltrations;
            Cursor.Current = Cursors.Cross;
        }

        private void ApplyLocalization()
        {
            this.Text = Localization.GetString("FormFiltrationConfigure_Title");
            labelAssemblies.Text = Localization.GetString("LabelFiltrations");
            buttonSpy.Text = Localization.GetString("ButtonSpy");
        }

        private void FiltrationConfigure_Load(object sender, EventArgs e)
        {
            textBoxFiltrations.Text = string.Join("\r\n", Settings.Filtrations);
            ApplyLocalization();
        }

        private void FiltrationConfigure_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Filtrations = new List<string>();
            foreach (string filtration in textBoxFiltrations.Text.Replace("\n", "").Split('\r'))
            {
                if (!Settings.Filtrations.Contains(filtration) && filtration != "")
                {
                    Settings.Filtrations.Add(filtration);
                }
            }
        }
    }
}
