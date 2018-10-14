using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project2
{
    public class OrderService
    {        

        public void AddOrder(int n, List<OrderDetails> order)
        {            
            Console.Write("please input your item counts: ");
            int count = Int32.Parse(Console.ReadLine());            
            for (int i = 0; i < count; i++)
            {
                OrderDetails goods = new OrderDetails();
                if (i == 0&n!=2)
                {
                    Console.Write("please input your name : ");
                    goods.name= Console.ReadLine();
                    Console.Write("please input your item number(订单号）: ");                   
                    goods.number = Int32.Parse(Console.ReadLine());
                }
                Console.Write("please input your items and price:  ");                
                goods.item= Console.ReadLine();
                goods.price= double.Parse(Console.ReadLine());
                order.Add(goods);
            }  
        }

        public void Clear(List<OrderDetails> order)
        {
            order.Clear();
        }

        public void SearchByItem(string item,List<OrderDetails> order)
        {
            int i;
            for (i = 0; i <order.Count; i++)
            {
                if (order[i].item == item)
                {
                    Console.WriteLine("Count:{0}", order.Count);
                    for (int j = 0; j < order.Count; j++)
                        Console.Write("\t" + order[j].item + "\t" + order[j].price);
                    Console.WriteLine();
                    break;
                }                                
            }
            if (i>=order.Count)
                    Console.Write("未找到");  
        }

        public void SearchByName(string name, List<OrderDetails> order)
        {
            //if (order[0].name == name)
            //{
            //    Console.WriteLine("Count:{0}", order.Count);
            //    for (int j = 0; j < order.Count; j++)
            //        Console.Write("\t" + order[j].item + "\t" + order[j].price);
            //    Console.WriteLine();
            //}
            //else
            //    Console.Write("未找到");
            var result = from a in order where a.name == name select a.name;
            foreach (var n in result)
            {
                if (n == name)
                {
                    Console.WriteLine("Count:{0}", order.Count);
                    for (int j = 0; j < order.Count; j++)
                        Console.Write("\t" + order[j].item + "\t" + order[j].price);
                    Console.WriteLine();
                }
                else
                    Console.Write("未找到");
            }
        }

        public void SearchByNum(int num, List<OrderDetails> order)
        {
            var result = from a in order where a.number == num select a.number;
            foreach (var n in result)
            {
                if (n == num)
                {
                    Console.WriteLine("Count:{0}", order.Count);
                    for (int j = 0; j < order.Count; j++)
                        Console.Write("\t" + order[j].item + "\t" + order[j].price);
                    Console.WriteLine();
                }
                else
                    Console.Write("未找到");
            }
        }

    }
}
