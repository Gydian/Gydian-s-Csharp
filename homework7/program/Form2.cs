using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ordertest;
using System.Linq;
using System.Data;

namespace program
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();           
        }

        Customer customer1 = new Customer();
        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            customer1.Name = textBox1.Text;
        }

        Goods goods1 = new Goods();
        public void textBox3_TextChanged(object sender, EventArgs e)
        {
            goods1.Name = textBox3.Text;
        }

        public void textBox4_TextChanged(object sender, EventArgs e)
        {
            goods1.Price = double.Parse(textBox4.Text);
        }

        OrderDetail orderDetails1 = new OrderDetail();
        public void textBox5_TextChanged(object sender, EventArgs e)
        {            
            orderDetails1.Quantity = Int32.Parse(textBox5.Text);
            orderDetails1.Id = 1;
            orderDetails1.Goods = goods1;
        }

       
        public void button1_Click(object sender, EventArgs e)
        {
            Order order1 = new Order(1, customer1.Name,goods1.Name,goods1.Price);
            order1.AddDetails(orderDetails1);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            List<Order> orders = os.QueryAllOrders();
            foreach (Order od in orders)
                Console.WriteLine(od.ToString());

            Form1 frm1;
            frm1 = (Form1)this.Owner;
            frm1.textBox4.Text = textBox1.Text+textBox2.Text+textBox3.Text+textBox4.Text+textBox5.Text;

            this.Close();
        }
    }
}