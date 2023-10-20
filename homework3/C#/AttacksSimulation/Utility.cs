using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public static class Utility
{
    private static Random random = new Random();

    // generate a random color
    public static Color GetRandomColor()
    {
        HashSet<Color> usedColors = new HashSet<Color>();
        while (true)
        {
            int red = random.Next(256);
            int green = random.Next(256);
            int blue = random.Next(256);

            Color randomColor = Color.FromArgb(red, green, blue);

            if (!usedColors.Contains(randomColor))
            {
                usedColors.Add(randomColor);
                return randomColor;
            }
        }
    }

    public static int GenerateWithProbability(double p, int x, int y)
    {
        if (random.NextDouble() < p)
        {
            return x;
        }
        else
        {
            return y;
        }
    }

    // Return the system coordinates from real coordinate X, Y
    public static Tuple<float, float> SystemCoordinates(int X, int Y, int maxX, int maxY, int width, int height)
    {
        float scaledX = X * (width / maxX);
        float scaledY = height/2 - (Y * (height / maxY)); 
        scaledX = Math.Max(0, Math.Min(scaledX, width));
        scaledY = Math.Max(0, Math.Min(scaledY, height));

        return Tuple.Create(scaledX, scaledY);
    }

}
