using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AttacksSimulation
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);

            Color lineColor = Utility.GetRandomColor(); // Use the GetRandomColor function from the Utility class
            Pen pen = new Pen(lineColor, 1);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

            int n_sys = int.Parse(textBox1.Text);
            int n_atk = int.Parse(textBox2.Text);

            double probability = 0.5;
            int lowerBound = -1;
            int upperBound = 1;

            List<Point> pointsList = new List<Point>();
            int y = 0;

            for (int i = 0; i < n_sys; i++)
            {
                for (int x = 0; x < n_atk; x++)
                {
                    y += Utility.GenerateWithProbability(probability, lowerBound, upperBound); // Use GenerateWithProbability from the Utility class
                    (float scaledX, float scaledY) = 
                        Utility.SystemCoordinates(x, y, n_atk, n_atk, pictureBox1.Width, pictureBox1.Height);
                    pointsList.Add(new Point((int)scaledX, (int)scaledY));
                }

                Point[] pointsArray = pointsList.ToArray();
                g.DrawLines(pen, pointsArray);
                y = 0;
                pictureBox1.Image = bmp;
            }
        }
    }
}
