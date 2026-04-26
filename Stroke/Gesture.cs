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

        private const int ResampledVectorCount = 128;
        public string Name = "";
        public Vector[] Vectors;

        public void GenerateVectors(List<Point> points)
        {
            for (int index = points.Count - 1; index > 0; index--)
            {
                if (points[index].Equals(points[index - 1]))
                    points.RemoveAt(index);
            }

            if (points.Count < 2)
                return;

            int segmentCount = points.Count - 1;
            Vector[] segmentVectors = new Vector[segmentCount];
            double[] cumulativeDistances = new double[segmentCount];
            double totalLength = 0;

            for (int index = 1; index < points.Count; index++)
            {
                double deltaX = points[index].X - points[index - 1].X;
                double deltaY = points[index].Y - points[index - 1].Y;
                double segmentLength = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

                if (segmentLength <= 0)
                    continue;

                totalLength += segmentLength;
                cumulativeDistances[index - 1] = totalLength;

                double scaledX = deltaX * 127.0 / segmentLength;
                double scaledY = deltaY * 127.0 / segmentLength;
                segmentVectors[index - 1] = new Vector((sbyte)Math.Round(scaledX), (sbyte)Math.Round(scaledY));
            }

            if (totalLength <= 0)
                return;

            Vectors = new Vector[ResampledVectorCount];
            for (int stepIndex = 0, segmentIndex = 0; stepIndex < ResampledVectorCount; stepIndex++)
            {
                while (segmentIndex < cumulativeDistances.Length - 1 && stepIndex > cumulativeDistances[segmentIndex] * ResampledVectorCount / totalLength)
                {
                    segmentIndex++;
                }
                Vectors[stepIndex] = segmentVectors[segmentIndex];
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
                return 0;

            double totalSimilarity = 0;

            for (int index = 0; index < ResampledVectorCount; index++)
            {
                totalSimilarity += (32258 - (Math.Pow((Vectors[index].X - gesture.Vectors[index].X), 2) + Math.Pow((Vectors[index].Y - gesture.Vectors[index].Y), 2))) / 32258;
            }

            return (int)totalSimilarity;
        }
    }
}