using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Stroke.Configure
{
    public static class Localization
    {
        private static readonly Dictionary<string, string> _strings;

        static Localization()
        {
            _strings = new Dictionary<string, string>
            {
                ["FormConfigure_Title"] = "配置",
                ["FormPenConfigure_Title"] = "画笔设置",
                ["FormGestureConfigure_Title"] = "手势设置",
                ["FormCompileConfigure_Title"] = "编译设置",
                ["FormFiltrationConfigure_Title"] = "过滤设置",
                ["FormThreadConfigure_Title"] = "线程设置",

                ["ButtonOK"] = "确定",
                ["ButtonCancel"] = "取消",
                ["ButtonPen"] = "画笔",
                ["ButtonGesture"] = "手势",
                ["ButtonCompile"] = "编译",
                ["ButtonFiltration"] = "过滤",
                ["ButtonThread"] = "线程",
                ["ButtonSpy"] = "添加路径",

                ["LabelAssemblies"] = "引用程序集",
                ["LabelNamespaces"] = "命名空间",
                ["LabelFiltrations"] = "进程路径模式",
                ["LabelThreadCount"] = "线程数量",
                ["LabelColor"] = "颜色",
                ["LabelOpacity"] = "不透明度",
                ["LabelThickness"] = "笔触粗细",

                ["MouseItem_Middle"] = "中键",
                ["MouseItem_Left"] = "左键",
                ["MouseItem_Right"] = "右键",
                ["MouseItem_X1"] = "X1",
                ["MouseItem_X2"] = "X2",

                ["GestureSpecial_MiddleClick"] = "中键点击",
                ["GestureSpecial_LeftClick"] = "左键点击",
                ["GestureSpecial_RightClick"] = "右键点击",
                ["GestureSpecial_X1Click"] = "X1 键点击",
                ["GestureSpecial_X2Click"] = "X2 键点击",
                ["GestureSpecial_WheelUp"] = "滚轮向上",
                ["GestureSpecial_WheelDown"] = "滚轮向下",

                ["ContextMenu_AddActionPackage"] = "添加〔动作包〕",
                ["ContextMenu_RemoveActionPackage"] = "删除〔动作包〕",
                ["ContextMenu_AddAction"] = "添加〔动作〕",
                ["ContextMenu_RemoveAction"] = "删除〔动作〕",
                ["ContextMenu_AddGesture"] = "添加〔手势〕",
                ["ContextMenu_RemoveGesture"] = "删除〔手势〕",

                ["Unit_Pixel"] = "像素",
                ["PercentFormat"] = "{0}%"
            };

            try
            {
                string culture = CultureInfo.CurrentUICulture.Name;
                string[] candidates = { culture, culture.Split('-')[0], "en" };

                foreach (string name in candidates)
                {
                    string path = Path.Combine(Application.StartupPath, "Languages", name);
                    if (File.Exists(path))
                    {
                        foreach (string line in File.ReadLines(path, Encoding.UTF8))
                        {
                            if (string.IsNullOrWhiteSpace(line) || line.TrimStart().StartsWith("#"))
                                continue;

                            var pair = ParseLine(line);
                            if (pair != null)
                                _strings[pair.Value.Key] = pair.Value.Value;
                        }
                        break;
                    }
                }
            }
            catch
            {
            }
        }

        private static KeyValuePair<string, string>? ParseLine(string line)
        {
            if (string.IsNullOrEmpty(line))
                return null;

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '\\')
                {
                    i++;
                    if (i >= line.Length)
                        break;
                }
                else if (line[i] == '=')
                {
                    string key = Unescape(line.Substring(0, i));
                    string value = Unescape(line.Substring(i + 1));
                    return new KeyValuePair<string, string>(key, value);
                }
            }

            return new KeyValuePair<string, string>(Unescape(line), string.Empty);
        }

        private static string Unescape(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            StringBuilder builder = new StringBuilder(input.Length);
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '\\' && i + 1 < input.Length && (input[i + 1] == '=' || input[i + 1] == '\\'))
                    builder.Append(input[++i]);
                else
                    builder.Append(input[i]);
            }

            return builder.ToString();
        }

        public static string GetString(string key)
        {
            return _strings.TryGetValue(key, out string value) ? value : key;
        }
    }
}