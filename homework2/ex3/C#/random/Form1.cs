using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace random
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int N))
            {
                int k = 10; // Number of interval classes

                // Initialize an array to count occurrences in each interval class
                int[] intervalCounts = new int[k];

                // Initialize the random number generator
                Random random = new Random();

                // Generate N uniform random variates
                for (int i = 0; i < N; i++)
                {
                    double randomValue = random.NextDouble(); // Generates a random value in [0, 1)

                    // Determine the interval class for the random value
                    int interval = (int)(randomValue * k);

                    // Increment the count for the corresponding interval class
                    intervalCounts[interval]++;
                }

                // Clear the RichTextBox
                richTextBox1.Clear();

                // Calculate and display the relative frequency for each interval class
                for (int i = 0; i < k; i++)
                {
                    double lowerBound = i / (double)k;
                    double upperBound = (i + 1) / (double)k;
                    double relativeFrequency = intervalCounts[i] / (double)N;

                    // Append the result to the RichTextBox
                    richTextBox1.AppendText($"Interval [{lowerBound:F2}, {upperBound:F2}): Relative Frequency = {relativeFrequency:F4}\n");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid integer for N.");
            }


        }
    }
}
