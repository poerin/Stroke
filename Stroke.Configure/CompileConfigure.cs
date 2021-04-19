using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Stroke.Configure
{
    public partial class CompileConfigure : Form
    {
        public CompileConfigure()
        {
            InitializeComponent();
        }

        private void CompileConfigure_Load(object sender, EventArgs e)
        {
            textBoxAssemblies.Text = string.Join("\r\n", Settings.Assemblies);
            textBoxNamespaces.Text = string.Join("\r\n", Settings.Namespaces);
        }

        private void CompileConfigure_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Assemblies = new List<string>();
            foreach (string assembly in textBoxAssemblies.Text.Replace("\n", "").Split('\r'))
            {
                if (!Settings.Assemblies.Contains(assembly) && assembly != "")
                {
                    Settings.Assemblies.Add(assembly);
                }
            }

            Settings.Namespaces = new List<string>();
            foreach (string name in textBoxNamespaces.Text.Replace("\n", "").Split('\r'))
            {
                if (!Settings.Namespaces.Contains(name) && name != "")
                {
                    Settings.Namespaces.Add(name);
                }
            }
        }

    }
}
