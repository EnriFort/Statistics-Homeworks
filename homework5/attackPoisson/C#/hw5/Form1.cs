using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hw5
{
    public partial class Form1 : Form
    {
     
        private int nSystems;
        private int nAttacks;
        private int lambda;

        public Form1()
        {
            InitializeComponent();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            nSystems = int.Parse(textBox1.Text);
            nAttacks = int.Parse(textBox2.Text);
            lambda = int.Parse(textBox3.Text);

            Rectangle rectChart = new Rectangle(20, 30, pictureBox1.Width - 200, pictureBox1.Height - 60);

        }
    }
}
