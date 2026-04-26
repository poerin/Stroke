using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Stroke
{
    public static class Script
    {
        private static Type Scripts;
        private static object Instance;
        private static Dictionary<string, string> Functions = new Dictionary<string, string>();
        private static readonly List<Worker> Workers = new List<Worker>();
        private static int CurrentIndex;
        private static readonly object Lock = new object();
        private static bool Initialized;

        private static string Indent(int level)
        {
            return new string(' ', level * 4);
        }

        public static string GenerateSource()
        {
            StringBuilder builder = new StringBuilder();
            foreach (string name in Settings.Namespaces)
            {
                builder.AppendLine($"using {name};");
            }
            builder.AppendLine();
            builder.AppendLine("namespace Stroke");
            builder.AppendLine("{");
            builder.AppendLine();
            builder.AppendLine(Indent(1) + "public class Scripts");
            builder.AppendLine(Indent(1) + "{");
            builder.AppendLine();

            uint index = 0;
            foreach (ActionPackage package in Settings.ActionPackages)
            {
                foreach (Action action in package.Actions)
                {
                    if (Functions.ContainsKey($"{package.Name}.{action.Name}"))
                    {
                        continue;
                    }

                    Functions.Add($"{package.Name}.{action.Name}", "Function_" + index++);
                    builder.AppendLine(Indent(2) + $" // {package.Name}.{action.Name}");
                    builder.AppendLine(Indent(2) + $"static public void {Functions[$"{package.Name}.{action.Name}"]}(int _)");
                    builder.AppendLine(Indent(2) + "{");
                    foreach (string line in action.Code.Replace("\r", "").Split('\n'))
                    {
                        builder.AppendLine(Indent(3) + line);
                    }
                    builder.AppendLine(Indent(2) + "}");
                    builder.AppendLine();
                }
            }

            builder.AppendLine(Indent(1) + "}");
            builder.AppendLine("}");
            return builder.ToString();
        }

        public static void CompileScript()
        {
            CompilerParameters parameter = new CompilerParameters();
            parameter.GenerateExecutable = false;
            parameter.GenerateInMemory = true;
            parameter.TreatWarningsAsErrors = false;

            foreach (string assembly in Settings.Assemblies)
            {
                parameter.ReferencedAssemblies.Add(assembly);
            }

            FileInfo[] files = (new DirectoryInfo(Application.StartupPath)).GetFiles("*.dll");
            for (int i = 0; i < files.Length; i++)
            {
                parameter.ReferencedAssemblies.Add(files[i].FullName);
            }

            using (CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp"))
            {
                CompilerResults results = provider.CompileAssemblyFromSource(parameter, GenerateSource());

                if (results.Errors.HasErrors)
                {
                    List<string> errors = new List<string>();
                    foreach (CompilerError error in results.Errors)
                    {
                        if (!errors.Contains(error.ErrorText))
                        {
                            errors.Add(error.ErrorText);
                        }
                    }
                    MessageBox.Show(string.Join("\n", errors));
                    Environment.Exit(0);
                }

                Instance = results.CompiledAssembly.CreateInstance("Stroke.Scripts");
                Scripts = results.CompiledAssembly.GetType("Stroke.Scripts");
            }
        }

        public static void RunScript(string name, int mark)
        {
            if (!TryGetMethod(name, out MethodInfo method))
                return;

            Worker worker = AcquireWorker();

            worker.Target.BeginInvoke(new System.Action(() =>
            {
                try
                {
                    method.Invoke(Instance, new object[] { mark });
                }
                catch (TargetInvocationException exception) when (exception.InnerException != null)
                {
                    Report(name, exception.InnerException);
                }
                catch (Exception exception)
                {
                    Report(name, exception);
                }
            }));
        }

        private static Worker AcquireWorker()
        {
            lock (Lock)
            {
                if (!Initialized)
                {
                    AppDomain.CurrentDomain.UnhandledException += (_, eventArgs) =>
                    {
                        if (eventArgs.ExceptionObject is Exception exception)
                            Report(null, exception);
                    };

                    for (int i = 0; i < Settings.ScriptThreadCount; i++)
                        Workers.Add(CreateWorker());
                    Initialized = true;
                }

                for (int i = Workers.Count - 1; i >= 0; i--)
                {
                    Worker worker = Workers[i];
                    if (worker.Target == null || !worker.Target.IsHandleCreated || worker.Target.IsDisposed)
                    {
                        Workers.RemoveAt(i);
                        worker.Target?.Dispose();
                    }
                }

                while (Workers.Count < Settings.ScriptThreadCount)
                    Workers.Add(CreateWorker());

                Worker selected = Workers[CurrentIndex % Workers.Count];
                CurrentIndex = (CurrentIndex + 1) % Workers.Count;
                return selected;
            }
        }

        private static Worker CreateWorker()
        {
            Worker worker = new Worker();
            using (ManualResetEvent signal = new ManualResetEvent(false))
            {
                Thread thread = new Thread(() =>
                {
                    try
                    {
                        worker.Target = new Control();
                        _ = worker.Target.Handle;
                        Application.ThreadException += (_, eventArgs) => Report(null, eventArgs.Exception);
                        signal.Set();
                        Application.Run();
                    }
                    catch { }
                })
                {
                    IsBackground = true
                };

                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                signal.WaitOne();
            }
            return worker;
        }

        private static bool TryGetMethod(string name, out MethodInfo method)
        {
            method = null;

            if (string.IsNullOrWhiteSpace(name))
                return false;
            if (!Functions.TryGetValue(name, out string methodName))
                return false;
            if (Scripts == null || Instance == null)
                return false;

            method = Scripts.GetMethod(methodName);
            return method != null;
        }

        private static void Report(string source, Exception exception)
        {
            try
            {
                Form form = Program.Stroke;
                if (form != null && !form.IsDisposed && form.IsHandleCreated)
                {
                    form.BeginInvoke(new System.Action(() =>
                    {
                        try
                        {
                            MessageBox.Show(form, exception.ToString(), source ?? "Stroke");
                        }
                        catch { }
                    }));
                }
            }
            catch { }
        }

        private class Worker
        {
            public Control Target;
        }
    }
}