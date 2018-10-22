using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ordertest;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Customer customer2 = new Customer(2, "Customer2");
            Goods milk = new Goods(1, "Milk", 69.9);
            OrderDetail orderDetails3 = new OrderDetail(3, milk, 1);
            Order order3 = new Order(3, customer2);
            order3.AddDetails(orderDetails3);
            OrderService os = new OrderService();
            os.AddOrder(order3);
            double n = 69.9;
            Assert.IsTrue(n == order3.Amount);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Customer customer2 = new Customer(2, "Customer2");
            Goods milk = new Goods(1, "Milk", 69.9);
            Goods eggs = new Goods(2, "eggs", 4.99);
            OrderDetail orderDetails2 = new OrderDetail(2, eggs, 2);
            OrderDetail orderDetails3 = new OrderDetail(3, milk, 1);
            Order order3 = new Order(3, customer2);
            Order order2 = new Order(2, customer2);
            order2.AddDetails(orderDetails2);
            order2.AddDetails(orderDetails3);
            order3.AddDetails(orderDetails3);
            OrderService os = new OrderService();
            os.AddOrder(order3);
            os.AddOrder(order2);
            os.RemoveOrder(3);
            List<Order> orders = os.QueryAllOrders();
            Assert.IsTrue(orders.Count == 1);
        }

        Order orderFound;
        [TestMethod]
        public void TestMethod3()
        {
            Customer customer2 = new Customer(2, "Customer2");
            Goods milk = new Goods(1, "Milk", 69.9);
            OrderDetail orderDetails3 = new OrderDetail(3, milk, 1);
            Order order3 = new Order(3, customer2);
            order3.AddDetails(orderDetails3);
            OrderService os = new OrderService();
            os.AddOrder(order3);
            List<Order> orders = os.QueryAllOrders();
            foreach (Order order in orders)
            {
                if (order.Id == 3)
                {
                    orderFound = order;
                }
            }
            Assert.AreEqual(orderFound, order3);
        }

        List<Order> result = new List<Order>();
        [TestMethod]
        public void TestMethod4()
        {
            Customer customer2 = new Customer(2, "Customer2");
            Goods milk = new Goods(1, "Milk", 69.9);
            Goods eggs = new Goods(2, "eggs", 4.99);
            OrderDetail orderDetails2 = new OrderDetail(2, eggs, 2);
            OrderDetail orderDetails3 = new OrderDetail(3, milk, 1);
            Order order3 = new Order(3, customer2);
            Order order2 = new Order(2, customer2);
            order2.AddDetails(orderDetails2);
            order2.AddDetails(orderDetails3);
            order3.AddDetails(orderDetails3);
            OrderService os = new OrderService();
            os.AddOrder(order3);
            os.AddOrder(order2);
            List<Order> orders = os.QueryAllOrders();
            foreach (Order order in orders)
            {
                for (int index = 0; index < orders.Count; index++)
                    foreach (OrderDetail details in orders[index].Details)
                    {
                        if (details.Goods.Name == "Milk")
                        {
                            result.Add(order);
                        }
                    }
            }
            Assert.IsTrue(result.Count == 2);//失败
        }

        [TestMethod]
        public void TestMethod5()
        {
            Customer customer2 = new Customer(2, "Customer2");
            Goods milk = new Goods(1, "Milk", 69.9);
            Goods eggs = new Goods(2, "eggs", 4.99);
            OrderDetail orderDetails2 = new OrderDetail(2, eggs, 2);
            OrderDetail orderDetails3 = new OrderDetail(3, milk, 1);
            Order order3 = new Order(3, customer2);
            Order order2 = new Order(2, customer2);
            order2.AddDetails(orderDetails2);
            order2.AddDetails(orderDetails3);
            order3.AddDetails(orderDetails3);
            OrderService os = new OrderService();
            os.AddOrder(order3);
            os.AddOrder(order2);
            List<Order> orders = os.QueryAllOrders();
            foreach (Order order in orders)
            {
                if (order.Customer.Name == "customer2")
                {
                    orderFound = order;
                }
            }
            Assert.AreEqual(orderFound, order3);//失败
        }
    }
}
