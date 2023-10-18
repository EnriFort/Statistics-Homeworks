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

namespace hw2_ex1_C_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // This function open csv file and save it as DataGridView
        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    // Read the CSV file
                    string[] lines = File.ReadAllLines(filePath);


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

                    // Start from the second line (index 1) to populate data
                    for (int i = 1; i < lines.Length; i++)
                    {
                        string[] values = lines[i].Split(';');

                        // Unlucky some row from the datset are wrong, so i skip them
                        if (values.Length == numValues)
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

        private void button2_Click(object sender, EventArgs e)
        {
            // choose the 3 variables and create dict
            string[] variables = new string[] { "Main hobbies", "Age", "height" };

            // Create a dictionary to store the frequencies
            Dictionary<string, int> frequencyQual = new Dictionary<string, int>();
            Dictionary<string, int> frequencyQuantDisc = new Dictionary<string, int>();
            Dictionary<string, int> frequencyQuantCont = new Dictionary<string, int>();

            // create a dictionary of dictionary
            Dictionary<string, Dictionary<string, int>> variableDictionary = new Dictionary<string, Dictionary<string, int>>();

            // Add the dictionaries to the variableDictionary with the variables as keys
            // The dict contains variable name as key and frequency dict as value
            variableDictionary.Add(variables[0], frequencyQual);
            variableDictionary.Add(variables[1], frequencyQuantDisc);
            variableDictionary.Add(variables[2], frequencyQuantCont);

            void UpdateFrequenciesDict(Dictionary<string, int> frequencies, string variable, DataGridViewRow row)
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


            // Update frequencies
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // For all the choosen variables
                foreach (string variable in variables)
                {
                    UpdateFrequenciesDict(variableDictionary[variable], variable, row);

                }
            }

            // Print all type of frequencies
            foreach (string variable in variables)
            {
                foreach (var kvp in variableDictionary[variable])
                {
                    richTextBox1.AppendText($"Variable: {kvp.Key}; Absolute Frequency: {kvp.Value}; Relative Frequency: {((double)kvp.Value / frequencyQual.Count):F3}; " +
                        $"Percentage Frequency: {((double)kvp.Value / frequencyQual.Count) * 100:F3}\n");
                }
            }
        }
    }
}
