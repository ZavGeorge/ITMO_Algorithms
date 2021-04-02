using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Algorithms_lab_4
{
    public partial class Input : Form
    {
        private string a, b, c;
        private double A, B, C;

        public bool Perimeter, Square;

        public Input()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            a = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            b = textBox2.Text;

        }

        public double getTriangleA()
        {
            return A;
        }
        public double getTriangleB()
        {
            return B;
        }
        public double getTriangleC()
        {
            return C;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            c = textBox3.Text;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            Perimeter = checkBox.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            Square = checkBox.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                A = double.Parse(a);
                B = double.Parse(b);
                C = double.Parse(c);

            }
            catch
            {
                MessageBox.Show("Данные введены не правильно");
            }
            if ((A > 0 && B>0 && C> 0) && 
               (A + C > B) && (A+B > C) && (B+C > A) && 
               (Perimeter || Square))
            {
                MessageBox.Show("Данные сохранены");
                Close();
            }
            else if (!(Perimeter || Square))
            {
                MessageBox.Show("Параметры расчета не выбраны");
            }
            else if ((A <= 0 || B<= 0 || C <= 0) || (A + B <= C) ||
                (B +C <=A) || (C + A <= B))
            {
                MessageBox.Show("Треугольника с такими сторонами не существует");
            }



        }




    }
}
