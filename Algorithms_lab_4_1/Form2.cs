using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorithms_lab_4_1
{
    public partial class Latter : Form
    {
        private string letter, text;
        
        public Latter(Form1 mainform)
        {
            InitializeComponent();
            text = mainform.getText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int letterCount = 0;
            if (letter.Length != 1)
            {
                MessageBox.Show("Символ введен неправильно");
                return;
            }
            if (letter == null)
            {
                MessageBox.Show("Символ не введен");
                return;
            }
            foreach (var c in text.ToLower())
            {
                if (c == letter[0])
                {
                    letterCount++;
                }
            }
            MessageBox.Show("Количество " + letter + " в тексте: " + letterCount);
            Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            letter = textBox1.Text;
        }
    }
}
