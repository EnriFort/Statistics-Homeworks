using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hw5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void drawLine(Graphics g, int nAttacks, int lambda, Dictionary<int,int> frequencies, Rectangle rect)
        {    
            int minValue = 0;
            double maxValue = lambda * 1.5;

            int y = 0;
            int lastY = 0;

            // The line start from the origin
            List<Point> myLine = new List<Point> { new Point(rect.Left, rect.Top + rect.Height) };

            for (int x = 1; x <= nAttacks; x++)
            {

                y += Utils.RandomUtils.BernoulliDist((double)lambda / nAttacks);
                
                int xDevice = Utils.Drawing.XtoDevice((double)x / nAttacks, 0, 1, rect.Left, rect.Width);
                int yDevice = Utils.Drawing.YtoDevice(y, minValue, maxValue - minValue, rect.Top, rect.Height);

                myLine.Add(new Point(xDevice, yDevice));

                if (x == nAttacks) { lastY = yDevice; }
            }

            if (frequencies.ContainsKey(lastY))
            {
                frequencies[lastY] += 1;
            }
            else
            {
                frequencies[lastY] = 1;
            }

            Color lineColor = Utils.RandomUtils.GetRandomColor(); // Get a random color 
            Pen pen = new Pen(lineColor, 1){DashStyle = DashStyle.Solid};
            Point[] lineArray = myLine.ToArray();

            g.DrawLines(pen, lineArray);
        }

        // Main
        private void button1_Click(object sender, EventArgs e)
        {
            int nSystems = int.Parse(textBox1.Text);
            int nAttacks = int.Parse(textBox2.Text);
            int lambda = int.Parse(textBox3.Text);

            pictureBox1.Image = null;
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.HighQuality;

            Rectangle rectChart = new Rectangle(20, 30, pictureBox1.Width - 250, pictureBox1.Height - 60); // rectangle for the lines
            Dictionary<int, int> histoFrequencies = new Dictionary<int, int>();

            for (int m = 1; m <= nSystems; m++)
            {
                drawLine(g, nAttacks, lambda, histoFrequencies, rectChart);  
            }

            g.DrawRectangle(Pens.WhiteSmoke, rectChart);
            //textBox4.Text = (pictureBox1.Width - rectChart.Width - 2 * rectChart.Left).ToString();
            Rectangle rectHisto = new Rectangle(Utils.Drawing.XtoDevice(nAttacks, 0, nAttacks, rectChart.X, rectChart.Width), rectChart.Y, 210, rectChart.Height);  // rectangle for the histograms 
            g.DrawRectangle(new Pen(Color.LightBlue) {DashStyle = DashStyle.Dash}, rectHisto); // dotted line

            Utils.Drawing.DrawHistogramsFromDict(g, histoFrequencies, rectHisto, Color.Red, Color.LightGreen);
            pictureBox1.Image = bmp;
        }
    }
}
