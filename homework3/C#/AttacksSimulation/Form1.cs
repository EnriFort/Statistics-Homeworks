using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttacksSimulation
{
    public partial class Form1 : Form
    {

        private RandomNumberGenerator randomNumberGenerator = new RandomNumberGenerator();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.Black, 2);

            int systems = int.Parse(textBox1.Text);
            int attacks = int.Parse(textBox2.Text);

            double probability = 0.5; // Adjust as needed
            int lowerBound = -1;    // Adjust as needed
            int upperBound = 1;     // Adjust as needed

            for (int i = 0; i < systems; i++)
            {
                List<Point> pointsList = new List<Point>();
                int y = 0;
                pointsList.Add(new Point(0, 0));
                
                for (int x = 0; x < attacks; x++)
                {
                    int xCoordinate = (int)(x * pictureBox1.Width / attacks);

                    if (x == 0)
                    {
                        y = 0;
                    }
                    else
                    {
                        y = pointsList[x - 1].Y + randomNumberGenerator.GenerateWithProbability(probability, lowerBound, upperBound);
                    }
                    
                    int yCoordinate = (int)(y * pictureBox1.Height);
                    pointsList.Add(new Point(xCoordinate, yCoordinate));
                }

                // Convert the List<Point> to an array
                Point[] pointsArray = pointsList.ToArray();

                // Draw a single line connecting the points
                g.DrawLines(pen, pointsArray);
            }

            pictureBox1.Image = bmp; // Set the PictureBox's Image to the generated Bitmap
        }
    }
}

