using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace programme2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();
            drawCayLeyTree(10, 200, 310, 100, -Math.PI / 2);
        }

        private Graphics graphics;
        
        // n 代表每个分叉上分支数目（包括主干）；x0和y0代表树根部坐标（锚点在左上角）；leng表示初始树枝的长度
        void drawCayLeyTree(int n,double x0,double y0,double leng,double th)
        {
            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            double x2 = x0 + leng * 0.5 * Math.Cos(th);
            double y2 = y0 + leng * 0.7 * Math.Sin(th);

            drawLine(x0, y0, x1, y1);

            changeRightAngle();
            changeLeftAngle();
            changeRightLength();
            changeLeftLength();

            double th1 = changeRightAngle() * Math.PI / 180;
            double th2 = changeLeftAngle() * Math.PI / 180;

            drawCayLeyTree(n - 1, x1, y2, changeRightLength() * leng, th + th1);           //递归 画右边分支
            drawCayLeyTree(n - 1, x1, y1, changeLeftLength() * leng, th - th2);           //递归 画左边分支

        }


        void drawLine(double x0,double y0,double x1,double y1)
        {
            //颜色
            string color1 = listBox1.SelectedItem.ToString();
            if(color1=="red")
                graphics.DrawLine(Pens.Red, (int)x0, (int)y0, (int)x1, (int)y1);
            else if(color1=="blue")
                graphics.DrawLine(Pens.Blue, (int)x0, (int)y0, (int)x1, (int)y1);
            else if(color1=="green")
                graphics.DrawLine(Pens.Green, (int)x0, (int)y0, (int)x1, (int)y1);
        }

        double changeRightAngle()
        {
            double angleRight = Double.Parse(textBox1.Text);
            return angleRight;
        }
        double changeLeftAngle()
        {
            double angleLeft = Double.Parse(textBox2.Text);
            return angleLeft;
        }
        double changeRightLength()
        {
            double lengthRight = Double.Parse(textBox3.Text);
            return lengthRight;
        }
        double changeLeftLength()
        {
            double lengthLeft = Double.Parse(textBox4.Text);
            return lengthLeft;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] colors = { "金色", "棕色", "绿色" };                       //添加颜色选择
            for (int i = 0; i < colors.Length; i++)
            {
                this.listBox1.Items.Add(colors[i]);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
