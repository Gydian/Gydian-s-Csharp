using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using System.Xml.Xsl;
using System.Xml;
using System.Xml.XPath;

namespace ordertest {
    /// <summary>
    /// OrderService:provide ordering service,
    /// like add order, remove order, query order and so on
    /// 实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户等字段进行查询)
    /// </summary>
    public class OrderService { 

        private Dictionary<uint, Order> orderDict;
        /// <summary>
        /// OrderService constructor
        /// </summary>
        public OrderService() {
            orderDict = new Dictionary<uint, Order>();
        }

        static private String numTest = @"^(?<year>[0-9]{2})(?<month>[0-9]{2})(?<day>[0-9]{2})[0-9]{3}$";
        static private String phoneTest = @"^1[0-9]{10}$";

        static private bool IsRight(string num,string phone)
        {
            Match phoneMatch = Regex.Match(phone, phoneTest);
            Match numMatch = Regex.Match(num, numTest);
            if (!phoneMatch.Success)
            {
                throw new Exception("订单电话号码有误");
                return false;
            }
            else if (!numMatch.Success)
            {
                throw new Exception("订单号有误");
                return false;
            }
            return true;
        }

            /// <summary>
            /// add new order
            /// </summary>
            /// <param name="order">the order will be added</param>
            public void AddOrder(Order order) {
            if (orderDict.ContainsKey(uint.Parse(order.Id)))
                throw new Exception($"Order is already existed!");
            if(IsRight(order.Id,order.Customer.PhoneNum))
            orderDict[uint.Parse(order.Id)] = order;


        }

        /// <summary>
        /// cancel order
        /// </summary>
        /// <param name="orderId">id of the order which will be canceled</param> 
        public void RemoveOrder(uint orderId) {
              orderDict.Remove(orderId);
        }

        /// <summary>
        /// query all orders
        /// </summary>
        /// <returns>List<Order>:all the orders</returns> 
        public List<Order> QueryAllOrders() {
            return orderDict.Values.ToList();
        }

        /// <summary>
        /// query by orderId
        /// </summary>
        /// <param name="orderId">id of the order to find</param>
        /// <returns>List<Order></returns> 
        public Order GetById(uint orderId) {
            if (orderDict.ContainsKey(orderId)){ 
                return orderDict[orderId];
            }
            return null;
        }

        /// <summary>
        /// query by goodsName
        /// </summary>
        /// <param name="goodsName">the name of goods in order's orderDetail</param>
        /// <returns></returns> 
        public List<Order> QueryByGoodsName(string goodsName) {
            var query = orderDict.Values.Where(order =>
                    order.Details.Where(d => d.Goods.Name == goodsName)
                    .Count() > 0
                );
            return query.ToList();
   
        }

        /// <summary>
        /// query by customerName
        /// </summary>
        /// <param name="customerName">customer name</param>
        /// <returns></returns> 
        public List<Order> QueryByCustomerName(string customerName) {
            var query=orderDict.Values
                .Where(order => order.Customer.Name == customerName);
            return query.ToList();
        }

        public List<Order> QueryByPrice(double price)
        {
            var query = orderDict.Values
                .Where(order => order.Amount> price);
            return query.ToList();
        }


        /// <summary>
        /// edit order's customer
        /// </summary>
        /// <param name="orderId"> id of the order whoes customer will be update</param>
        /// <param name="newCustomer">the new customer of the order which will be update</param> 
        public void UpdateCustomer(uint orderId, Customer newCustomer) {
            if (orderDict.ContainsKey(orderId)) {
                orderDict[orderId].Customer = newCustomer;
            } else {
                throw new Exception($"order-{orderId} is not existed!");
            }
        }

        /// <summary>
        /// Store the order object to file orders.xml
        /// </summary>
        public string Export()
        {
            DateTime time = System.DateTime.Now;
            string fileName = "orders_" + time.Year + "_" + time.Month
                + "_" + time.Day + "_" + time.Hour + "_" + time.Minute
                + "_" + time.Second + ".xml";
            Export(fileName);
            return fileName;
        }

        public void Export(String fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                xs.Serialize(fs, orderDict.Values.ToList());
            }
        }

        /// <summary>
        /// import the orders object from xml file in path
        /// return the order imported to service obj
        /// </summary>
        public List<Order> Import(string path)
        {
            if (Path.GetExtension(path) != ".xml")
                throw new ArgumentException("It isn't a xml file!");
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            List<Order> result = new List<Order>();

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                List<Order> temp = (List<Order>)xs.Deserialize(fs);
                temp.ForEach(order =>
                {
                    if (!orderDict.Keys.Contains(uint.Parse(order.Id)))
                    {
                        orderDict[uint.Parse(order.Id)] = order;
                        result.Add(order);
                    }
                });
            }
            return result;
        }

        /*other edit function with write in the future.*/
        static public void ConvertToHTMLAndOpen(string xmlFile)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(xmlFile);
            XPathNavigator nav = xml.CreateNavigator();
            nav.MoveToRoot();
            XslCompiledTransform xsl = new XslCompiledTransform();
            xsl.Load(@"C:\Users\LENOVO\source\repos\homework8\order.xlst");
            string filePath = xmlFile.Substring(0, xmlFile.LastIndexOf("\\"));
            FileStream outStream = File.OpenWrite(filePath + "\\order.html");
            XmlTextWriter writer = new XmlTextWriter(outStream, System.Text.Encoding.UTF8);
            xsl.Transform(nav, null, writer);
            outStream.Close();
            System.Diagnostics.Process.Start(filePath + "\\order.html");
        }
    }
}
