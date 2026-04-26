using System;
using System.Windows.Forms;

namespace Stroke
{
    static class Program
    {
        public static Stroke Stroke;

        [STAThread]
        static void Main()
        {
            try
            {
                if (System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length > 1)
                {
                    Application.Exit();
                    return;
                }
                Settings.ReadSettings();
            }
            catch
            {
                Application.Exit();
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Stroke = new Stroke();
            MouseHook.StartHook();
            Script.CompileScript();
            Application.Run(Stroke);
            MouseHook.StopHook();
        }
    }
}
