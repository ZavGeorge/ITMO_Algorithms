using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorithms_lab_4
{
    public partial class Conv : Form
    {
        private string Number;
        public Conv()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Number = textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int number =0;

            try
            {
                number = int.Parse(Number);
            }
            catch
            {
                MessageBox.Show("Число должно быть целочисленное");

            }
            if (radioButton1.Checked && number > 0)
            {
                result.Text = Convert.ToString(number, 2);
            }
            else if (radioButton2.Checked && number > 0)
            {
                result.Text = Convert.ToString(number, 8);
            }
            else if (radioButton3.Checked && number > 0) 
            {
                result.Text = Convert.ToString(number, 16);
            }
            else 
            {
                MessageBox.Show("Система счисления не выбрана");
            }

        }
    }
}
