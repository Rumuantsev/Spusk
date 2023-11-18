using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace Lab5
{
    public partial class Form1 : Form
    {
      public static double Fun(double x)
      {
        return (27 - 18 * x + 2 * Math.Pow(x, 2)) * Math.Exp(-(x / 3));
      }

        public static double DisFun(double x)
        {
            return -(27 - 18 * x + 2 * Math.Pow(x, 2)) * Math.Exp(-(x / 3));
        }


        public double CoordinateDescent(double a, double b, int accuracy)
        {
            double x = (a + b) / 2;
            double delta = 1 / Math.Pow(10, accuracy);
            while (!(x - delta <= a || x + delta >= b))
            {      
                if (Fun(x) > Fun(x - delta))
                {
                    x -= delta;
                }
                else if (Fun(x) > Fun(x + delta))
                {
                    x += delta;
                }
                else
                { 
                    break; 
                }
            }
            return Math.Round(x, accuracy);
        }
        public double DisCoordinateDescent(double a, double b, int accuracy)
        {
            //double delta = 1 / Math.Pow(10, accuracy);
            //double x = (a + b) / 2; // Инициализация начального значения x


            //while (b - a > delta) // Условие остановки
            //{
            //    if (DisFun(a) > DisFun(b))
            //        a = x; // Если значение функции в точке a больше, обновляем начальную границу
            //    else
            //        b = x; // Иначе обновляем конечную границу

            //    x = (a + b) / 2; // Вычисление нового значения x
            //}

            //return Math.Round(x, accuracy);
            double x = (a + b) / 2;
            double delta = 1 / Math.Pow(10, accuracy);
            while (!(x - delta <= a || x + delta >= b))
            {
                if (DisFun(x) > DisFun(x - delta))
                {
                    x -= delta;
                }
                else if (DisFun(x) > DisFun(x + delta))
                {
                    x += delta;
                }
                else
                {
                    break;
                }
            }
            return Math.Round(x, accuracy);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void clearButton_Click(object sender, EventArgs e)
        {
            textBoxA.Clear();
            textBoxB.Clear();
            textBoxE.Clear();
            Max.Clear();
            Min.Clear();
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            double a = double.Parse(textBoxA.Text), b = double.Parse(textBoxB.Text);
            double h = 0.1, x, y;
            this.chart1.Series[0].Points.Clear();
            x = a;
            while (x <= b)
            {
                y = Fun(x);
                this.chart1.Series[0].Points.AddXY(x, y);
                x += h;
            }
  
                try
                {
                    if ((textBoxA.Text == String.Empty) | (textBoxB.Text == String.Empty) | (textBoxE.Text == String.Empty))
                    {
                        MessageBox.Show("Заполните все поля ввода!");
                    }
                    else
                    {
                        double A = double.Parse(textBoxA.Text);
                        double B = double.Parse(textBoxB.Text);
                        int E = int.Parse(textBoxE.Text);
                        Min.Text = Convert.ToString(CoordinateDescent(A, B, E));
                        Max.Text = Convert.ToString(DisCoordinateDescent(A, B, E));
                    }
                }
                catch (System.FormatException)
                {
                    MessageBox.Show("Можно вводить только цифры!");
                }          
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
