using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void FiltrationConfigure_Load(object sender, EventArgs e)
        {
            textBoxFiltrations.Text = string.Join("\r\n", Settings.Filtrations);
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
