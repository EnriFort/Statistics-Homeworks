using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hw1_ex1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Populate the ComboBox with figure options
            figureComboBox.Items.Add("Line");
            figureComboBox.Items.Add("Point");
            figureComboBox.Items.Add("Circle");
            figureComboBox.Items.Add("Rectangle");
            figureComboBox.SelectedIndex = 0; // Set the default selected item (e.g., "Line")
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Clear the PictureBox
            pictureBox1.Image = null;

            // Create a new Bitmap for drawing
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);

            // Determine the selected figure based on the ComboBox's selected item
            string selectedFigure = figureComboBox.SelectedItem.ToString();
            switch (selectedFigure)
            {
                case "Line":
                    // Draw a line
                    Pen pen = new Pen(Color.Black, 2); // Customize color and thickness
                    g.DrawLine(pen, 10, 10, 200, 200); // Draw a line from (10, 10) to (200, 200)
                    pen.Dispose();
                    break;

                case "Point":
                    // Draw a point (small circle)
                    SolidBrush brush = new SolidBrush(Color.Red); // Choose a color for the point
                    g.FillEllipse(brush, 50, 50, 5, 5); // Draw a small circle as a point at (50, 50)
                    brush.Dispose();
                    break;

                case "Circle":
                    // Draw a circle
                    Pen circlePen = new Pen(Color.Blue, 2); // Customize color and thickness
                    g.DrawEllipse(circlePen, 50, 50, 200, 200); // Draw a circle at (50, 50) with a width and height of 200
                    circlePen.Dispose();
                    break;

                case "Rectangle":
                    // Draw a rectangle
                    Pen rectPen = new Pen(Color.Green, 2); // Customize color and thickness
                    g.DrawRectangle(rectPen, 50, 50, 200, 120); // Draw a rectangle at (50, 50) with a width of 200 and a height of 120
                    rectPen.Dispose();
                    break;
            }
            // Display the image in the PictureBox
            pictureBox1.Image = bmp;
        }
    }
}
