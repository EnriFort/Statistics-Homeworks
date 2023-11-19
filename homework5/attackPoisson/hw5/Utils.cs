using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

public static class Utils
{

    public static class RandomUtils
    {
        private static Random random = new Random();

        public static int BernoulliDist(double p)
        {
            return (random.NextDouble() <= p) ? 1 : 0;
        }

        public static int RademacherDist(double p)
        {
            return (random.NextDouble() <= p) ? 1 : -1;
        }

        // To generate a random color
        public static Color GetRandomColor()
        {
            HashSet<Color> usedColors = new HashSet<Color>();
            while (true)
            {
                int R = random.Next(256);
                int G = random.Next(256);
                int B = random.Next(256);

                Color randomColor = Color.FromArgb(R, G, B);

                if (!usedColors.Contains(randomColor))
                {
                    usedColors.Add(randomColor);
                    return randomColor;
                }
            }
        }

    }


    public static class Drawing
    {

        public static int XtoDevice(double X, int minX, int rangeX, double left, double width)
        {
            return (int)(left + width * (X - minX) / rangeX);
        }

        public static int YtoDevice(int Y, int minY, double rangeY, double top, double height)
        {
            return (int)(top + height - (height * (Y - minY) / rangeY));
        }

        public static void DrawHistogramsFromDict(Graphics g, Dictionary<int, int> frequencies, Rectangle devRect, Color startGrdColor, Color endGrdColor)
        {
            int bins = frequencies.Count;
            int maxFrequency = int.MinValue;

            // Find the maximum frequency
            foreach (int frequency in frequencies.Values)
            {
                if (frequency > maxFrequency)
                {
                    maxFrequency = frequency;
                }
            }

            foreach (KeyValuePair<int, int> entry in frequencies)
            {
                int yValue = entry.Key;
                int barWidth = (int)((entry.Value / (double)maxFrequency) * (devRect.Width - 2));
                int barHeight = (int)((devRect.Height - bins - 1) / (double)bins * 0.2);

                Rectangle rectHisto = new Rectangle(devRect.X + 1, yValue, barWidth, barHeight);

                // Draw rectangle
                g.DrawRectangle(Pens.Black, rectHisto);

                // Create gradient
                LinearGradientBrush gradientBrush = new LinearGradientBrush(rectHisto, startGrdColor, endGrdColor, LinearGradientMode.Horizontal);

                // Fill with gradient
                g.FillRectangle(gradientBrush, rectHisto);
            }
        }

    }
}