using System;

namespace Stroke
{
    [Serializable]
    public class Action
    {
        public string Name;
        public string Gesture;
        public string Code;

        public Action(string name, string gesture, string code)
        {
            Name = name;
            Gesture = gesture;
            Code = code;
        }
    }
}
