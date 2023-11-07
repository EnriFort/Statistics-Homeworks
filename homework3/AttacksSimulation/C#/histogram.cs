using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*==== Histogram Object ====*/
public class Histogram
{
    private double[] binCounts;

    public Histogram(double[] counts)
    {
        // Initialize the histogram with the provided bin counts
        binCounts = counts;
    }

    public int GetBinCount(int binIndex)
    {
        if (binIndex >= 0 && binIndex < binCounts.Length)
        {
            return (int)binCounts[binIndex];
        }
        return 0;
    }

    public int GetTotalCounts()
    {
        int total = 0;
        foreach (int count in binCounts)
        {
            total += count;
        }
        return total;
    }

    public void DrawHistogramOnBitmap(Graphics g, double[] frequencies, int width, int height, int bins, int startX, int startY)
    {
        double maxFrequency = frequencies.Max();
        int gap = 1; // Adjust the gap between bars as needed
        double barHeightFactor = 0.5; // Adjust this factor to control bar height

        using (Font font = SystemFonts.DefaultFont)
        {
            for (int i = 0; i < bins && i < frequencies.Length; i++)
            {
                int barWidth = (int)((double)frequencies[i] / maxFrequency * (width / 2));
                int barHeight = (int)((height - (bins - 1) * gap) / bins * barHeightFactor);
                int x = startX + width - barWidth; // Start from the right and move to the left
                int y = startY + (i + 1) * (barHeight + gap); // Start from the bottom and move upward

                Brush brush = Brushes.MistyRose;
                g.FillRectangle(brush, new Rectangle(x, y, barWidth, barHeight));
            }
        }
    }
}