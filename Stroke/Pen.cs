using System;
using System.Drawing;

namespace Stroke
{
    [Serializable]
    public class Pen
    {
        private Color color;
        private double opacity;
        private byte thickness;

        public event System.Action PenChanged;

        public Color Color
        {
            get { return color; }
            set
            {
                color = value;
                PenChanged?.Invoke();
            }
        }

        public double Opacity
        {
            get { return opacity; }
            set
            {
                if (value >= 0 && value <= 1)
                {
                    opacity = value;
                    PenChanged?.Invoke();
                }
            }
        }

        public byte Thickness
        {
            get { return thickness; }
            set
            {
                if (value >= 0 && value <= 10)
                {
                    thickness = value;
                    PenChanged?.Invoke();
                }
            }
        }

        public Pen(Color color, double opacity, byte thickness)
        {
            this.color = color;
            this.opacity = opacity;
            this.thickness = thickness;
        }

    }
}
