using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CayleyTree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.panel1.CreateGraphics();
            string a = this.textBox1.Text;
            string b = this.textBox2.Text;
            string c = this.textBox3.Text;
            string d = this.textBox4.Text;
            string g = this.textBox5.Text;
            string f = this.textBox6.Text;
            double th1 = (Double.Parse(g)) * Math.PI / 180;
            double th2 = (Double.Parse(f)) * Math.PI / 180;
            double per1 = (Double.Parse(c));
            double per2 = (Double.Parse(d));
            int n = (int.Parse(a));
            double leng = double.Parse(b);
            drawCayleyTree(n, 200, 310, leng, -Math.PI / 2);
        }

        private Graphics graphics;
        /*double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;*/
       /* string a = this.textBox1.Text;
        string b = this.textBox2.Text;
        string c = this.textBox3.Text;
        string d = this.textBox4.Text;
        string g = this.textBox5.Text;
        string f = this.textBox6.Text;
        double th1 = (Double.Parse(g)) * Math.PI / 180;
        double th2 = (Double.Parse(f)) * Math.PI / 180;
        double per1 = (Double.Parse(c));
        double per2 = (Double.Parse(d));*/

        void drawCayleyTree(int n,
                double x0, double y0, double leng, double th)
        {
            string c = this.textBox3.Text;
            string d = this.textBox4.Text;
            string g = this.textBox5.Text;
            string f = this.textBox6.Text;
            double th1 = (Double.Parse(g)) * Math.PI / 180;
            double th2 = (Double.Parse(f)) * Math.PI / 180;
            double per1 = (Double.Parse(c));
            double per2 = (Double.Parse(d));
            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1);

            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }
        Pen colorpen(string color)
        {
            Pen result=null;
            switch(color)
            {
                case "红":
                    result = Pens.Red;
                    break;
                case "蓝":
                    result = Pens.Blue;
                    break;

            }
            return result;
        }
        void drawLine(double x0, double y0, double x1, double y1)
        {
            string color = comboBox1.Text;

                    graphics.DrawLine(colorpen(color), (int)x0, (int)y0, (int)x1, (int)y1);
                    
            }
           // graphics.DrawLine(Pens.Blue,(int)x0, (int)y0, (int)x1, (int)y1);
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)//擦除按钮
        {
           
                graphics.Clear(this.BackColor);
           
        }
    }
}
