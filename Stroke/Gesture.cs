using System;
using System.Collections.Generic;
using System.Drawing;

namespace Stroke
{
    [Serializable]
    public class Gesture
    {
        [Serializable]
        public struct Vector
        {
            public sbyte X;
            public sbyte Y;

            public Vector(sbyte x, sbyte y)
            {
                X = x;
                Y = y;
            }
        }

        public string Name = "";
        public Vector[] Vectors;

        public void GenerateVectors(List<Point> points)
        {
            for (int i = points.Count - 1; i > 0; i--)
            {
                if (points[i].Equals(points[i - 1]))
                {
                    points.RemoveAt(i);
                }
            }
            if (points.Count < 2)
            {
                return;
            }

            Vector[] vectors = new Vector[points.Count - 1];
            double[] course = new double[points.Count - 1];
            double length = 0;
            for (int i = 1; i < points.Count; i++)
            {
                double distance = Math.Sqrt(Math.Pow((points[i].X - points[i - 1].X), 2) + Math.Pow((points[i].Y - points[i - 1].Y), 2));
                length += distance;
                course[i - 1] = length;
                int x = points[i].X - points[i - 1].X, y = points[i].Y - points[i - 1].Y;
                vectors[i - 1] = new Vector((sbyte)(x * 127 / distance), (sbyte)(y * 127 / distance));
            }
            Vectors = new Vector[128];
            for (int i = 0, j = 0; i < 128; i++)
            {
                while (i > course[j] * 128 / length)
                {
                    j++;
                }
                this.Vectors[i] = vectors[j];
            }
        }

        public Gesture(string name)
        {
            Name = name;
        }

        public Gesture(string name, List<Point> points)
        {
            Name = name;
            GenerateVectors(points);
        }

        public int Similarity(Gesture gesture)
        {
            if (Vectors == null)
            {
                return 0;
            }

            double similarity = 0;

            for (int i = 0; i < 128; i++)
            {
                similarity += (32258 - (Math.Pow((Vectors[i].X - gesture.Vectors[i].X), 2) + Math.Pow((Vectors[i].Y - gesture.Vectors[i].Y), 2))) / 32258;
            }

            return (int)similarity;
        }

    }
}
