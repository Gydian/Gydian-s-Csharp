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
using System.Data;
using System.Linq;

namespace program
{
    public partial class Form1 : Form
    {
        List<Order> orders = new List<Order>();
        public string KeyWord { get; set; }

        public Form1()
        {
            InitializeComponent();

            Customer customer1 = new Customer(1, "Customer1");
            Goods milk = new Goods(1, "Milk", 69.9);
            orders.Add(new Order(1,"mike","milk",69.9));
            orderBindingSource.DataSource = orders;
            //绑定查询条件
            queryInput.DataBindings.Add("Text", this, "KeyWord");
        }    

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Owner = this;
            frm2.Show();
            orderBindingSource.DataSource = orders.Where(s => s.Customer.Name == KeyWord);
        }

        int choose;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            choose = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            switch (choose)
            {
                case 1:
                    //orders = os.QueryByCustomerName(textBox1.Text);
                    //foreach (Order od in orders)
                    //    Console.WriteLine(od.ToString());
                    //orderBindingSource.DataSource = orders.Where(s => s.Customer.Name == KeyWord);
                    break;
                case 2:
                    //orders = os.QueryByGoodsName(textBox2.Text);
                    //foreach (Order od in orders)
                    //    Console.WriteLine(od.ToString());
                    break;
                case 3:
                    //orders = os.QueryByPrice(textBox3.Text);
                    //foreach (Order od in orders)
                    //    Console.WriteLine(od.ToString());
                    break;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            choose = 2;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            choose = 3;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
