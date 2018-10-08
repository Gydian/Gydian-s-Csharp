using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace project2
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n;

            Console.WriteLine("现在添加一个订单");
            OrderService orderlist = new OrderService();
            List<OrderDetails> order = new List<OrderDetails>();
            orderlist.AddOrder(1, order);

            do
            {             
                Console.Write("service:  1，删除订单  2，修改订单  3，查询订单");
                int service = Int32.Parse(Console.ReadLine());               
                               
                switch (service)
                {                    
                    case 1:
                        try
                        {                            
                            order.Clear();
                        }
                        catch
                        {
                            Console.Write("删除出错了");
                        }
                        break;
                    case 2:
                        Console.Write("1,删除商品  2，添加一个商品");
                        int change = Int32.Parse(Console.ReadLine());
                        switch (change)
                        {
                            case 1:
                                try
                                {
                                    Console.Write("删除第几个商品");
                                    int num = Int32.Parse(Console.ReadLine());
                                    order.RemoveAt(num+1);
                                }
                                catch
                                {
                                    Console.Write("修改出错了");
                                }
                                break;
                            case 2:
                                orderlist.AddOrder(change, order);
                                break;
                        }
                        break;
                    case 3:
                        Console.Write("1,按商品名称查找  2,按照订单号查询  3,按照客户名称查询 ");
                        int search = Int32.Parse(Console.ReadLine());
                        switch (search)
                        {
                            case 1:
                                Console.Write("输入商品名称：");
                                string item = Console.ReadLine();
                                orderlist.SearchByItem(item,order);
                                break;
                            case 2:
                                Console.Write("输入订单号：");
                                int num = Int32.Parse(Console.ReadLine());
                                orderlist.SearchByNum(num,order);
                                break;
                            case 3:
                                Console.Write("输入客户名称：");
                                string name = Console.ReadLine();
                                orderlist.SearchByName(name,order);
                                break;
                        }
                        break;
                }
                Console.Write("1，继续服务  2，结束服务");
                n = Int32.Parse(Console.ReadLine());

            } while(n==1)
          
;

            

           





        }
    }
}
