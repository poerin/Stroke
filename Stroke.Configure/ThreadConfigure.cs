using System;
using System.Windows.Forms;

namespace Stroke.Configure
{
    public partial class ThreadConfigure : Form
    {
        public ThreadConfigure()
        {
            InitializeComponent();
        }

        private void ApplyLocalization()
        {
            this.Text = Localization.GetString("FormThreadConfigure_Title");
            labelThread.Text = Localization.GetString("LabelThreadCount");
        }

        private void ThreadConfigure_Load(object sender, EventArgs e)
        {
            numericUpDownThread.Value = Settings.ScriptThreadCount;
            ApplyLocalization();
        }

        private void ThreadConfigure_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.ScriptThreadCount = (int)numericUpDownThread.Value;
        }
    }
}