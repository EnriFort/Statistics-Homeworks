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

        public static int XtoDevice(double X, double minX, int rangeX, double left, double width)
        {
            return (int)(left + width * (X - minX) / rangeX);
        }

        public static int YtoDevice(int Y, double minY, double rangeY, double top, double height)
        {
            return (int)(top + height - (height * (Y - minY) / rangeY));
        }

        public static void DrawHistogramsFromArr(Graphics g, int[] frequencies, Rectangle devRect, Color startGrdColor, Color endGrdColor)
        {
            int bins = frequencies.Length;
            int maxFrequency = 0;
            int gap = 1;
            double barHeightFactor = 0.4; // Adjust this factor to control bar height

            // Get the maximum value
            for (int i = 0; i < bins; i++)
            {
                maxFrequency = Math.Max(maxFrequency, frequencies[i]);
            }

            for (int i = 0; i < bins; i++)
            {
                // Width and height are reversed because the histogram is horizontal
                int barWidth = (int)(frequencies[i] / (double)maxFrequency * devRect.Width - 1);
                int barHeight = (int)((devRect.Height - (bins - 1) * gap) / (double)bins * barHeightFactor);


                // Ensure the bar width is at least 1
                barWidth = Math.Max(barWidth, 1);

                int x = devRect.X + 2;
                int y = devRect.Top + (devRect.Height / 4) + (i + 1) * (barHeight + gap);

                Rectangle rectHisto = new Rectangle(x, y, barWidth, barHeight);

                // Draw rectangle
                g.DrawRectangle(Pens.Black, rectHisto);

                // Create gradient
                LinearGradientBrush gradientBrush = new LinearGradientBrush(rectHisto, startGrdColor, endGrdColor, LinearGradientMode.Horizontal);

                // Fill with gradient
                g.FillRectangle(gradientBrush, rectHisto);

                // Add legend
                Font font = new Font("Verdana", 9);
                Brush brush = new SolidBrush(Color.White);
                g.DrawString(frequencies[i].ToString(), font, brush, rectHisto.X, rectHisto.Y + (rectHisto.Height / 2));
            }

        }

    }
}