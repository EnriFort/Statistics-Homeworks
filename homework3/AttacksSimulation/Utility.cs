using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


/*==== This file contains some useful functions used in the form ====*/

public static class Utility
{
    private static Random random = new Random();

    // The 2 functions to calculate from the real coordinates the device one
    public static int FromXRealToXVirtual(double X, double minX, double maxX, int Left, int W)
    {
        return (int)(Left + W * (X - minX) / (maxX - minX));
    }
    public static int FromYRealToYVirtual(double Y, double minY, double maxY, int Top, int H, string freqType)
    {
        if (freqType == "null")
        {
            // Adjust the offset for "null" case
            return (int)(Top + H / 2 - H / 2 * (Y - minY) / (maxY - minY));
        }
        else
        {
            return (int)(Top + H - H * (Y - minY) / (maxY - minY));
        }
    }

    // To generate a random color
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

    // count how many values (contained in vect) fall in each intervall
    public static double[] CountValuesInIntervals(List<int> vect, double maxVal, int numBins)
    {
        // Initialize an array to represent bins with counts initialized to zero
        double[] binCounts = new double[numBins];

        // Calculate the interval length
        double intervalLength = (double)maxVal/numBins;

        // Iterate through each element in the array
        foreach (int value in vect)
        {
            // Calculate the bin index for the value
            int binIndex = (int)(value / intervalLength);

            // Ensure the binIndex is within the valid range
            if (binIndex >= 0 && binIndex < numBins)
            {
                binCounts[binIndex]++;
            }
        }
        return binCounts;
    }

    public static double GenerateCumulatedFrequency(double y, double n_atks, int x, string type) // type could be = aabsolute, relative, normalized
    {
        if (type == "rel")
        {
            return y * n_atks / (x + 1);
        }
        else if (type == "norm")
        {
            return y / Math.Sqrt(x + 1);
        }
        else // Absolute frequency or the first case
        {
            return y;
        }
    }
}
