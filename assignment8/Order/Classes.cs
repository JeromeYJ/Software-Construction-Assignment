using MySqlX.XDevAPI.CRUD;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Data.Entity;

namespace Order
{
    //货物(商品)类
    public class Goods
    {
        [Key]
        public int GoodsId { get; set; }
        public string GoodsName { get; set; }
        public double GoodsPrice { get; set; }

        public Goods() { }
        public Goods(string name, double price)
        {
            GoodsId = BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0);
            GoodsName = name;
            GoodsPrice = price;
        }
        public override string ToString()
        {
            return $"1）商品名:{GoodsName} 2）商品价格:{GoodsPrice}";
        }
    }

    //客户类
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public Client() { }
        public Client(string clientName)
        {
            ClientId = BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0);
            ClientName = clientName;
        }
        public override string ToString()
        {
            return $"客户名为{ClientName}";
        }
    }

    //订单类
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public Client Client { get; set; }
        public double Price { get; set; }
        public string ClientName { get; set; }
        public List<OrderDetails> Details { get; set; }
        double CalPrice()
        {
            double sum = 0;
            foreach (OrderDetails detail in Details)
            {
                sum += detail.Price;
            }
            return sum;
        }
        public Order() { }
        public Order(Client client, List<OrderDetails> details)
        {
            OrderId = BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0);
            Client = client;
            this.Details = details;
            ClientName = client.ClientName;
            Price = CalPrice();
        }
        public Order(int id, Client client, List<OrderDetails> details)
        {
            OrderId = id;
            Client = client;
            this.Details = details;
            ClientName = client.ClientName;
            Price = CalPrice();
        }
        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            Order order = (Order)obj;
            for (int i = 0; i < Details.Count; i++)
            {
                if (!Details[i].Equals(order.Details[i]))
                    return false;
            }
            return (this.OrderId == order.OrderId && this.Client.ClientName == order.Client.ClientName);
        }
        public override int GetHashCode()
        {
            return OrderId.GetHashCode();
        }
        public override string ToString()
        {
            string s = $"订单信息:\n（1）订单号:{OrderId} （2）订单客户:{Client} \n（3）订单明细:\n";
            foreach (OrderDetails detail in Details)
            {
                s += detail.ToString();
            }
            return s;
        }
    }

    //订单明细类
    public class OrderDetails
    {
        [Key]
        public int Id {get; set;}
        public Goods Goods { get; set; }
        public int GoodsId { get; set; }
        public string GoodsName { get; set; }
       
        public double GoodsPrice { get; set; }
        public int Amount { get; set; }
        public double Price => Amount * GoodsPrice;   //只读的简写形式

        public OrderDetails() { }
        public OrderDetails(Goods goods, int amount)
        {
            Id = BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0);
            Goods = goods;
            Amount = amount;
            GoodsId = goods.GoodsId;
            GoodsName = goods.GoodsName;
            GoodsPrice = goods.GoodsPrice;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            OrderDetails detail = (OrderDetails)obj;
            return (this.GoodsName == detail.GoodsName
                    && this.GoodsPrice == detail.GoodsPrice
                    && this.Amount == detail.Amount);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return $"1）商品名称:{Goods.GoodsName}\t 2）商品价格:{Goods.GoodsPrice}\t   3）商品数量:{Amount}\n";
        }
    }

    //订单服务类
    public class OrderService
    {
        //List<Order> orders;

        public OrderService() { }

        //添加订单
        public void AddOrder(Order order)
        {
            using (var orders = new OrderContext())
            {
                orders.Orders.Add(order);
                orders.SaveChanges();
            }
        }
        //删除订单
        public void DeleteOrder(int id)
        {
            using (var orders = new OrderContext())
            {
                var order = orders.Orders
                    .Include("Details")
                    .FirstOrDefault(o => o.OrderId == id);
                if (order == null)
                    throw new ApplicationException("删除订单失败！");
                else
                {
                    orders.OrderDetails.RemoveRange(order.Details);
                    orders.Orders.Remove(order);
                    orders.SaveChanges();
                }
            }
        }
        //修改订单
        public void ChangeOrder(int id, Client client, List<OrderDetails> details)
        {
            using (var orders = new OrderContext())
            {
                var order = QueryId(id);
                if (order != null)
                {
                    DeleteOrder(id);
                    Order orderNew = new Order(id, client, details);
                    orders.Orders.Add(orderNew);
                    orders.SaveChanges();
                }
                else throw new ApplicationException("修改订单失败！");
            }
        }
        //查询订单（按订单号）
        public Order? QueryId(int id)
        {
            using (var orders = new OrderContext())
            {
                return orders.Orders
                    .Include("Client")
                    .Include(o => o.Details.Select(d => d.Goods))
                    .FirstOrDefault(o => o.OrderId == id);
            }
        }
        //查询（按商品名称）
        public List<Order> QueryName(string name)
        {
            using (var orders = new OrderContext())
            {
                return orders.Orders
                    .Include("Client")
                    .Include(o => o.Details.Select(d => d.Goods))
                    .Where(o => o.Details.Any(d => d.GoodsName == name))
                    .OrderBy(o => o.OrderId)
                    .ToList<Order>();
            }
        }
        //查询orders中所有订单
        public List<Order> QueryAll()
        {
            using (var orders = new OrderContext())
            {
                return orders.Orders
                    .Include("Client")
                    .Include(o => o.Details.Select(d => d.Goods))
                    .OrderBy(o => o.OrderId)
                    .ToList<Order>();
            }
        }
        //查询（按客户）
        public List<Order> QueryClient(string client)
        {
            using (var orders = new OrderContext())
            {
                return orders.Orders
                    .Include("Client")
                    .Include(o => o.Details.Select(d => d.Goods))
                    .OrderBy(o => o.OrderId)
                    .Where(o => o.ClientName == client)
                    .ToList<Order>();
            }
        }
        //查询（按订单金额）
        public List<Order> QueryPrice(double price)
        {
            using (var orders = new OrderContext())
            {
                return orders.Orders
                    .Include("Client")
                    .Include(o => o.Details.Select(d => d.Goods))
                    .OrderBy(o => o.OrderId)
                    .Where(o => o.Price == price)
                    .ToList<Order>();
            }
        }
    }
}
