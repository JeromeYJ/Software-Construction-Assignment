using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Client c= new Client("Jerome");
            List<OrderDetails> details1 = new List<OrderDetails>() { new OrderDetails(new Goods("《百年孤独》", 50), 2), new OrderDetails(new Goods("iPad", 5000), 1) };
            Order order = new Order(c, details1);
            OrderService s = new OrderService();
            s.AddOrder(order);
        }
    }
}
