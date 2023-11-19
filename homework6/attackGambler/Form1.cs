using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace attackGambler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void drawLine(Graphics g, int nAttacks, int S, int [] frequencies, Rectangle rect)
        {
            const int rangeScaler = 4;

            double minValue = -rangeScaler * Math.Sqrt(nAttacks);
            double maxValue = rangeScaler * Math.Sqrt(nAttacks);

            double rangeValues = maxValue - minValue;

            int y = 0; // Y coordinates
            int P; // penetration Score


            // The line start from the origin
            List<Point> myLine = new List<Point> { new Point(rect.Left, rect.Top + rect.Height) };

            for (int x = 1; x <= nAttacks; x++)
            {

                y += Utils.RandomUtils.RademacherDist(0.5); // generate the random value for the attack

                int xDevice = Utils.Drawing.XtoDevice((double)x / nAttacks, 0, 1, rect.Left, rect.Width);
                int yDevice = Utils.Drawing.YtoDevice(y, minValue, rangeValues, rect.Top, rect.Height);

                myLine.Add(new Point(xDevice, yDevice));

                // P penetration score (upper line)
                // S security score (lower line)

                if (y == S) // If the system reaches a security score of S is OKAY
                {
                    continue;
                }
                else
                {
                    for (int k = 0; k < 10; k++)
                    {
                        P = (k + 1) * 10; // Compute value of P bounder
                        if (y == P) // If the system reaches the penetration score P
                        {
                            frequencies[k] += 1; // number of frequencies which fall in intervall k
                        }
                    }
                }

            }

            Color lineColor = Utils.RandomUtils.GetRandomColor(); // Get a random color 
            Pen pen = new Pen(lineColor, 1) { DashStyle = DashStyle.Solid };
            Point[] lineArray = myLine.ToArray();

            g.DrawLines(pen, lineArray);
        }

        // Main
        private void button1_Click(object sender, EventArgs e)
        {
            int nSystems = int.Parse(textBox1.Text);
            int nAttacks = int.Parse(textBox2.Text);
            int securityScore = -int.Parse(textBox3.Text);

            pictureBox1.Image = null;
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.HighQuality;

            Rectangle rectChart = new Rectangle(20, 30, pictureBox1.Width - 250, pictureBox1.Height - 60); // rectangle for the lines
            int[] penetrations = new int[10]; // contains the FREQUENCIES of the penetrations

            for (int m = 1; m <= nSystems; m++)
            {
                drawLine(g, nAttacks, securityScore, penetrations, rectChart);
            }

            g.DrawRectangle(Pens.WhiteSmoke, rectChart);
            Rectangle rectHisto = new Rectangle(Utils.Drawing.XtoDevice(nAttacks, 0, nAttacks, rectChart.X, rectChart.Width), rectChart.Y, 210, rectChart.Height);  // rectangle for the histograms 
            g.DrawRectangle(new Pen(Color.LightBlue) { DashStyle = DashStyle.Dash }, rectHisto); // dotted line

            Utils.Drawing.DrawHistogramsFromArr(g, penetrations, rectHisto, Color.Red, Color.LightGreen);
            pictureBox1.Image = bmp;
        }
    }
}