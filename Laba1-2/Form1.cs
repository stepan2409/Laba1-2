using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba1_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetupGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x = (double)xNumericUpDown.Value;
            if (x == -2)
            {
                resultLabel.Text = "Не возможно посчитать значение Y, так как произойдёт\r\nделение на 0";
                return;
            }
            double y = 3 / Math.Abs(x * x * x + 8);
            resultLabel.Text = "Y = " + y.ToString();
            return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double x = (double)laba2XNumericUpDown.Value;
            double y = (double)laba2YNumericUpDown.Value;
            if ((x * x + y * y == 100 && y + x >= 0) || (y == -x && x * x + y * y <= 100))
            {
                laba2ResultLabel.Text = "Точка находится на границе фигуры";
            }
            else if (x * x + y * y < 100 && y + x > 0)
            {
                laba2ResultLabel.Text = "Точка находится внутри фигуры";
            }
            else
            {
                laba2ResultLabel.Text = "Точка находится вне фигуры";
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                laba3ResultLabel.Text = "Вот вам немного женских имён:\r\n" +
                    "-\tАлла\r\n" +
                    "-\tЖанна\r\n" +
                    "-\tВера\r\n" +
                    "-\tАнна\r\n" +
                    "-\tЕкатерина";
            } else if (comboBox1.SelectedIndex == 1)
            {
                laba3ResultLabel.Text = "Вот вам немного мужских имён:\r\n" +
                    "-\tДанила\r\n" +
                    "-\tВольдемар\r\n" +
                    "-\tФома\r\n" +
                    "-\tЛев\r\n" +
                    "-\tКирилл";
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string result = "";
            for (int i = 1; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    int number = i * 100 + j * 10 + i;
                    result += number.ToString() + (number != 999 ? ", " : ".");
                }
                result += "\r\n";
            }
            laba4ResultLabel.Text = result;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string result = "";
            for (int lineNumber = 1; lineNumber <= 5; ++lineNumber)
            {
                for (int j = 1; j <= lineNumber; ++j)
                {
                    result += (j == lineNumber ? "3" : "2") + ' ';
                }
                result += "\r\n";

                int lowerNumber = 11 - lineNumber;
                for (int j = 1; j <= lineNumber; ++j, ++lowerNumber)
                {
                    result += (lowerNumber % 10).ToString() + ' ';
                }
                result += "\r\n";
            }
            laba5ResultLabel.Text = result;
        }

        private void SetupGridView()
        {
            resultDataGridView.ColumnCount = 2;
            resultDataGridView.Columns[0].Name = "X";
            resultDataGridView.Columns[1].Name = "F(X)";
            resultDataGridView.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            resultDataGridView.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            resultDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            resultDataGridView.AutoResizeColumns();
            resultDataGridView.Rows.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double a = (double)ANumericUpDown.Value;
            double b = (double)BNumericUpDown.Value;
            double h = (double)HNumericUpDown.Value;

            resultDataGridView.Rows.Clear();
            for (double x = a; x <= b; x += h)
            {
                resultDataGridView.Rows.Add(String.Format("{0:0.###}", Convert.ToDecimal(x)), String.Format("{0:0.#####}", Convert.ToDecimal(func(x))));
            }
        }

        private static double func(double x)
        {
            if (x < 1)
            {
                return Math.Pow((x * x - 1), 2);
            }
            else if (x > 1)
            {
                return 1 / Math.Pow((x + 1), 2);
            }
            else
            {
                return 0;
            }
        }
    }
}
