using System;
using System.Windows.Forms;

namespace Stroke.Configure
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MouseHook.StartHook();
            Application.Run(new Configure());
            MouseHook.StopHook();
        }
    }
}
