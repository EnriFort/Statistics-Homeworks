using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AttacksSimulation
{
    public partial class Form1 : Form
    {
        private Histogram histogram;

        public Form1()
        {
            InitializeComponent();
        }
        
        // Draw the chart and return the # of attack suffered by process i at time N
        private int DrawChart(Graphics g, double n_atk, Rectangle rect, string freqType, double prob)
        {
            Color lineColor = utils.GetRandomColor(); // Get a random color 
            Pen pen = new Pen(lineColor, 1);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

            List<Point> pointsList = new List<Point>();
            double y = 0; // reset the number of penetration for process n
            double f;
            int yDevice, xDevice;
            int uppB = 1;
            int lowB = (freqType == "null") ? -1 : 0; // This expression sets lowB to -1 when freqType is equal to "Null," and to 0 in all other cases
            int lastY = 0;

            for (int x = 0; x < n_atk; x++)
            {
                y += utils.GenerateWithProbability(prob, lowB, uppB);

                if (x == 0)
                {
                    pointsList.Clear();
                }

                f = utils.GenerateCumulatedFrequency(y, n_atk, x, freqType); // Calculate the corrispective frequency                
                
                if (freqType == "norm")
                {
                    yDevice = utils.FromYRealToYVirtual(f, 0, n_atk / Math.Sqrt(n_atk), rect.Top, rect.Height, freqType);
                }
                else
                {
                    yDevice = utils.FromYRealToYVirtual(f, 0, n_atk, rect.Top, rect.Height, freqType);
                }

                xDevice = utils.FromXRealToXVirtual(x, 0, n_atk, rect.Left, rect.Width);
                pointsList.Add(new Point(xDevice, yDevice));

                if (x == n_atk - 1)
                {
                    lastY = yDevice;
                }
            }
            Point[] pointsArray = pointsList.ToArray();
            g.DrawLines(pen, pointsArray);
            g.DrawRectangle(Pens.WhiteSmoke, rect); // Draw the rectangle covering 1/4 of the bitmap
            return lastY; // Return the frequency of process i at time N converted into device value
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            int n_sys = int.Parse(textBox1.Text);
            double n_atk = int.Parse(textBox2.Text);

            double probability = 0.5;

            int rectWidth = pictureBox1.Width / 2; // Width of the larger rectangle
            int rectHeight = pictureBox1.Height / 2; // Height of the larger rectangle

            List<int> penetrations = new List<int>();
            int bins = 50;

            Rectangle rectTopLeft = new Rectangle(0, 0, rectWidth, rectHeight);
            Rectangle rectTopRight = new Rectangle(rectWidth, 0, rectWidth, rectHeight);
            Rectangle rectBottomLeft = new Rectangle(0, rectHeight, rectWidth, rectHeight);
            Rectangle rectBottomRight = new Rectangle(rectWidth, rectHeight, rectWidth, rectHeight);

            Dictionary<string, Rectangle> freqTypes = new Dictionary<string, Rectangle>{ {"null", rectTopLeft},{"abs", rectTopRight},
                {"rel", rectBottomLeft},{"norm", rectBottomRight} };

            foreach (var tuple in freqTypes)
            {
                string frequencyType = tuple.Key;
                Rectangle rect = tuple.Value;

                // Adjust the starting X-coordinate for drawing the histogram
                int histogramStartX = tuple.Value.Left; // You can change this to position the histogram
                int histogramStartY = tuple.Value.Top;

                for (int i = 0; i < n_sys; i++)
                {
                    penetrations.Add(DrawChart(g, n_atk, rect, frequencyType, probability));
                }
                double maxValue = penetrations.Max();
                double[] bar_frequency = utils.CountValuesInIntervals(penetrations, maxValue, bins);

                // Create a Histogram object with the bin counts
                histogram = new Histogram(bar_frequency);
                // Draw the histogram starting from the adjusted X-coordinate
                histogram.DrawHistogramOnBitmap(g, bar_frequency, rect.Width, rect.Height, bins, histogramStartX, histogramStartY);
            }
            pictureBox1.Image = bmp;
        }

        
    }
}
