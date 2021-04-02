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
    public partial class Form1 : Form
    {
        private Input input;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            input = new Input();
            input.Show();

        }

        public double Perimeter(double a, double b, double c)
        {
            return a + b + c;
        }
        public double Square(double a, double b, double c)
        {
            double P = a + b + c;
            double p = P / 2;
            double S = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return S;
        }

            private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                double a = input.getTriangleA();
                double b = input.getTriangleB();
                double c = input.getTriangleC();
                if (input.Perimeter)
                {
                    result += "Периметр: " + Perimeter(a, b, c) + "\n";
                }
                if (input.Square)
                {
                    result += "Площадь :" + Square(a, b, c) + "\n";
                }
                MessageBox.Show(result);
            }
            catch 
            {
                MessageBox.Show("Стороны не введены");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Conv conv = new Conv();
            conv.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Заварзин Георгий K3220");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
