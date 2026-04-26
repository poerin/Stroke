using System;
using System.Collections.Generic;

namespace Stroke
{
    [Serializable]
    public class ActionPackage
    {
        public string Name;
        public string Code;
        public List<Action> Actions;

        public ActionPackage(string name, string code)
        {
            Name = name;
            Code = code;
            Actions = new List<Action>();
        }

    }
}
