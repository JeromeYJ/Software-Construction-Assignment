using Microsoft.VisualStudio.TestTools.UnitTesting;
using Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        OrderService orderService = new OrderService();

        [TestInitialize()]
        public void Init()
        {
            Client client1 = new Client("Jerome");
            Client client2 = new Client("Flora");
            List<OrderDetails> details1 = new List<OrderDetails>() { new OrderDetails(new Goods("《百年孤独》", 50), 2), new OrderDetails(new Goods("iPad", 5000), 1) };
            List<OrderDetails> details2 = new List<OrderDetails>() { new OrderDetails(new Goods("投影机", 2000), 1), new OrderDetails(new Goods("音响", 1500), 2) };
            List<OrderDetails> details3 = new List<OrderDetails>() { new OrderDetails(new Goods("《算法图解》", 30), 1), new OrderDetails(new Goods("胶卷", 80), 3) };
            List<OrderDetails> details4 = new List<OrderDetails>() { new OrderDetails(new Goods("《算法图解》", 30), 1), new OrderDetails(new Goods("胶卷", 80), 2) };
            Order order1 = new Order(1, client1, details1);
            Order order2 = new Order(2, client2, details2);
            Order order3 = new Order(3, client2, details3);
            Order order4 = new Order(4, client1, details4);
            orderService.AddOrder(order1);
            orderService.AddOrder(order2);
            orderService.AddOrder(order3);
            orderService.AddOrder(order4);
        }

        [TestMethod()]
        public void AddOrderTest()
        {
            List<OrderDetails> details5 = new List<OrderDetails>() { new OrderDetails(new Goods("投影机", 1000), 1), new OrderDetails(new Goods("胶卷", 80), 3) };
            Client client3 = new Client("李华");
            Order order5 = new Order(5, client3, details5);
            orderService.AddOrder(order5);
            List<Order> orders = orderService.QueryAll();
            Assert.IsNotNull(orders);
            Assert.AreEqual(5, orders.Count);
            CollectionAssert.Contains(orders, order5);
        }

        [TestMethod()]
        public void DeleteOrderTest()
        {
            orderService.DeleteOrder(3);
            List<Order> orders = orderService.QueryAll();
            Assert.AreEqual(3, orders.Count);
        }

        [TestMethod()]
        public void ChangeOrderTest()
        {
            List<OrderDetails> details5 = new List<OrderDetails>() { new OrderDetails(new Goods("投影机", 1000), 1), new OrderDetails(new Goods("胶卷", 80), 3) };
            Client client3 = new Client("李华");
            Order order5 = new Order(5, client3, details5);
            orderService.ChangeOrder(3, client3, details5);
            List<Order> orders = orderService.QueryAll();
            Assert.IsNotNull(orders);
            Assert.AreEqual(4, orders.Count);
            Order? order = orderService.QueryId(3);
            if(order!=null)
                Assert.AreEqual(client3, order.Client);
        }

        [TestMethod()]
        public void QueryIdTest()
        {
            Order? order = orderService. QueryId(2);
            Assert.IsNotNull(order);
            Assert.AreEqual(2, order.OrderId);
            List<OrderDetails> details = new List<OrderDetails>() { new OrderDetails(new Goods("投影机", 2000), 1), new OrderDetails(new Goods("音响", 1500), 2) };
            CollectionAssert.AreEqual(details, order.Details);
        }

        [TestMethod()]
        public void QueryNameTest()
        {
            Assert.AreEqual(1, orderService.QueryName("投影机").Count);
            Assert.AreEqual(2, orderService.QueryName("胶卷").Count);
        }

        [TestMethod()]
        public void QueryClientTest()
        {
            Assert.AreEqual(2, orderService.QueryClient("Flora").Count);
            Assert.AreEqual(2, orderService.QueryClient("Jerome").Count);
        }

        [TestMethod()]
        public void QueryPriceTest()
        {
            Assert.AreEqual(1, orderService.QueryPrice(5000).Count);
            Assert.AreEqual(0, orderService.QueryPrice(80).Count);
        }
    }
}