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
    public partial class Form1 : Form
    {
        private string text;
        OpenFileDialog openFileDialog = new OpenFileDialog();
        public Form1()
        {
            InitializeComponent();
            
            openFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string filename = openFileDialog.FileName;
            text = System.IO.File.ReadAllText(filename);
            MessageBox.Show("Файл открыт");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (text == null)
            {
                MessageBox.Show("Загрузите файл");
                return;
            }
            char[] sep = new char[] { ' ', '\r', '\n' };
            int wordsCount = text.Split(sep, StringSplitOptions.RemoveEmptyEntries).Length;

            MessageBox.Show("Кол-во слов в тексте: " + wordsCount);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (text == null) 
            {
                MessageBox.Show("Загрузите файл");
                return;
            }
            Latter form = new Latter(this);
            form.Show();
        }
        public string getText()
        {
            return text;
        }
    }
}
