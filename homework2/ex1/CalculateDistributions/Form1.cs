using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculateDistributions
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // This function open csv file, clean it and save it as DataGridView
        private void button1_Click(object sender, EventArgs e)
        {
            TableFromCSV();
        }

        void TableFromCSV()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK) // if the user press OK
                {
                    string filePath = openFileDialog.FileName;
                    string[] lines = File.ReadAllLines(filePath); // Read the CSV file

                    // Create a DataTable with the first line as column headers    
                    string[] headers = lines[0].Split(';');

                    foreach (string header in headers)
                    {
                        // Not consider eventually empty cell of the table
                        if (!String.IsNullOrEmpty(header))
                        {
                            dataGridView1.Columns.Add(header, header);
                        }
                    }
                    int numValues = headers.Length; // number of table headers

                    // Start from the second line (index 1, because the first is for the headers) to populate data
                    for (int i = 1; i < lines.Length; i++)
                    {
                        string[] values = lines[i].Split(';');

                        if (values.Length == numValues) // Unlucky some row from the dataset are wrong, so i skip them
                        {
                            for (int j = 0; j < values.Length; j++)
                            {
                                // replace empty value with "-"
                                if (string.IsNullOrEmpty(values[j]))
                                {
                                    values[j] = "-";
                                }
                            }
                            dataGridView1.Rows.Add(values);
                        }
                    }
                }
            }
        }

        void CalculateFrequencies(Dictionary<string, int> frequencies, string variable, DataGridViewRow row)
        {
            // get the corrispective cell value
            DataGridViewCell cell = row.Cells[variable];
            if (cell != null && cell.Value != null)
            {
                string cellValue = cell.Value.ToString();
                string[] values;
                // if the variable represent is a number
                if (int.TryParse(cellValue, out int result) ||
                        double.TryParse(cellValue, out double result2))
                {
                    values = cellValue.Split(' '); // Split only by space
                }
                else // represent a string
                {
                    if (cellValue.Contains(","))
                    {
                        // Split the string by commas (if multiple values)
                        values = cellValue.Split(',');
                    }
                    else
                    {
                        values = cellValue.Split(' ');
                    }
                }
                foreach (string value in values)
                {
                    string value2 = value.ToLower().Replace(" ", "");

                    // Compute Absolute frequency
                    if (!frequencies.ContainsKey(value2))
                    {
                        frequencies[value2] = 1;
                    }
                    else
                    {
                        frequencies[value2]++;
                    }
                }
            }
        }

        void CalculateJoint(Dictionary<string, int> JointFrequencies, DataGridViewRow row, string[] variables)
        {
            string key = "";

            // create the key (a string), formed by multiples variable 
            foreach (string variable in variables) 
            {
                
                DataGridViewCell cell = row.Cells[variable]; // get the corrispective cell value of the table
                
                if (cell != null && cell.Value != null)
                {
                    string var = cell.Value.ToString().ToLower();
                    key += cell.Value.ToString();
                    key += ", ";
                }
            }

            // Compute Absolute frequency
            if (!JointFrequencies.ContainsKey(key))
            {
                JointFrequencies[key] = 1;
            }
            else
            {
                JointFrequencies[key]++;
            }    
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // if user checked "frequency Distribution"
            if (radioButton1.Checked)
            {
                // Choose the 3 variables and create dict
                string[] variables = new string[] { "Main hobbies", "Age", "height" };

                // Create a dictionary to store the frequencies
                Dictionary<string, int> frequencyQual = new Dictionary<string, int>();
                Dictionary<string, int> frequencyQuantDisc = new Dictionary<string, int>();
                Dictionary<string, int> frequencyQuantCont = new Dictionary<string, int>();

                // Create a dictionary of dictionary
                Dictionary<string, Dictionary<string, int>> variableDictionary = new Dictionary<string, Dictionary<string, int>>();

                // Add the dictionaries to the variableDictionary with the variables as keys
                // The dict contains variable name as key and frequency dict as value
                variableDictionary.Add(variables[0], frequencyQual);
                variableDictionary.Add(variables[1], frequencyQuantDisc);
                variableDictionary.Add(variables[2], frequencyQuantCont);

                // Update frequencies
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    // For all the choosen variables
                    foreach (string variable in variables)
                    {
                        CalculateFrequencies(variableDictionary[variable], variable, row);

                    }
                }

                // Print all type of frequencies
                foreach (string variable in variables)
                {
                    richTextBox1.AppendText(variable + ": " + "\n \n");

                    foreach (var kvp in variableDictionary[variable])
                    {
                        richTextBox1.AppendText($"{kvp.Key}; Absolute: {kvp.Value}; Relative: {((double)kvp.Value / frequencyQual.Count):F3}; " +
                            $"Percentage: {((double)kvp.Value / frequencyQual.Count) * 100:F3}\n");
                    }

                    richTextBox1.AppendText("\n");
                }
            }

            // if user checked "joint Distribution"
            else if (radioButton2.Checked)
            {
                Dictionary<string, int> joint = new Dictionary<string, int>();

                string[] variables = textBox1.Text.Split(','); // read the variables pass by the users (can be any number of values)
                

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    CalculateJoint(joint, row, variables);
                }

                foreach (var k in joint)
                {
                    richTextBox1.AppendText($"{k.Key}; {k.Value}" + "\n");
                }
            }
        }
    }
}


