using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Stroke
{
    public static class Settings
    {
        public static MouseButtons StrokeButton;
        public static Pen Pen;
        public static List<Gesture> Gestures;
        public static List<ActionPackage> ActionPackages;
        public static List<string> Assemblies;
        public static List<string> Namespaces;
        public static List<string> Filtrations;


        public static void SaveSettings()
        {
            Dictionary<string, object> settings = new Dictionary<string, object>();
            settings.Add("StrokeButton", StrokeButton);
            settings.Add("Pen", Pen);
            settings.Add("Gestures", Gestures);
            settings.Add("ActionPackages", ActionPackages);
            settings.Add("Assemblies", Assemblies);
            settings.Add("Namespaces", Namespaces);
            settings.Add("Filtrations", Filtrations);

            using (FileStream fileStream = new FileStream("Settings", FileMode.Create))
            {
                new BinaryFormatter().Serialize(fileStream, settings);
            }
        }

        public static void ReadSettings()
        {
            Dictionary<string, object> settings;
            using (FileStream fileStream = new FileStream("Settings", FileMode.Open))
            {
                settings = (new BinaryFormatter()).Deserialize(fileStream) as Dictionary<string, object>;
            }

            StrokeButton = (MouseButtons)settings["StrokeButton"];
            Pen = (Pen)settings["Pen"];
            Gestures = (List<Gesture>)settings["Gestures"];
            ActionPackages = (List<ActionPackage>)settings["ActionPackages"];
            Assemblies = (List<string>)settings["Assemblies"];
            Namespaces = (List<string>)settings["Namespaces"];
            Filtrations = (List<string>)settings["Filtrations"];
        }

    }
}
