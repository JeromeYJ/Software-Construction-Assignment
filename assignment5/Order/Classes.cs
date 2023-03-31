using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    //货物(商品)类
    public class Goods
    {
        public string GoodsName { get; set; }
        public double GoodsPrice { get; set; }
        public Goods(string name,double price)
        {
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
        public string ClientName { get; set; }
        public Client(string clientName)
        {
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
        public int OrderId { get; set; }
        public Client Client { get; set; }
        public List<OrderDetails> Details { get; set; }
        public double Price => CalPrice();
        double CalPrice()
        {
            double sum = 0;
            foreach(OrderDetails detail in Details)
            {
                sum += detail.Price;
            }
            return sum;
        }
        public Order(int id,Client client,List<OrderDetails> details)
        {
            OrderId = id;
            Client = client;
            this.Details = details;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            Order order = (Order)obj;
            for(int i = 0; i < Details.Count; i++)
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
            foreach(OrderDetails detail in Details)
            {
                s += detail.ToString();
            }
            return s;
        }
    }

    //订单明细类
    public class OrderDetails
    {
        public Goods Goods { get; set; }
        public int Amount { get; set; }
        public double Price => Amount * Goods.GoodsPrice;   //只读的简写形式

        public OrderDetails(Goods goods,int amount)
        {
            Goods = goods;
            Amount = amount;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            OrderDetails detail = (OrderDetails)obj;
            return (this.Goods.GoodsName==detail.Goods.GoodsName 
                    && this.Goods.GoodsPrice==detail.Goods.GoodsPrice
                    && this.Amount==detail.Amount); 
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
        List<Order> orders;

        public OrderService()
        {
            orders = new List<Order>() { };
        }

        //添加订单(添加的订单不可重复，易漏)
        public void AddOrder(Order order)
        {
            if (orders != null)
            {
                foreach (Order item in orders)
                {
                    if (item.Equals(order))
                        throw new ApplicationException("添加的订单已存在！");
                }
            }
            orders.Add(order);
        }
        //删除订单
        public void DeleteOrder(int id)
        {
            bool complete = false;
            foreach(Order item in orders)
            {
                if (item.OrderId == id)
                {
                    orders.Remove(item);
                    complete = true;
                    break;
                }
            }
            if (!complete)
                throw new ApplicationException("删除订单失败！");
        }
        //修改订单
        public void ChangeOrder(int id, Client client, List<OrderDetails> details)
        {
            Order? order = QueryId(id);
            if (order != null)
            {
                order.Client = client;
                order.Details = details;
            }
            else throw new ApplicationException("修改订单失败！");
        }
        //查询订单（按订单号）
        public Order? QueryId(int id)
        {
            return orders.FirstOrDefault(o => o.OrderId == id);
        }
        //查询（按商品名称）
        public List<Order> QueryName(string name)
        {
            var queryName = from n in orders
                            from detail in n.Details
                            where detail.Goods.GoodsName==name
                            orderby n.Price
                            select n;
            return queryName.ToList();
        }
        //查询orders中所有订单
        public List<Order> QueryAll()
        {
            return orders;
        }
        //查询（按客户）
        public List<Order> QueryClient(string client)
        {
            var queryClient = from n in orders
                              where n.Client.ClientName == client
                              orderby n.Price
                              select n;
            return queryClient.ToList();
        }
        //查询（按订单金额）
        public List<Order> QueryPrice(double price)
        {
            var queryPrice = from n in orders
                             where n.Price == price
                             select n;
            return queryPrice.ToList();
        }
        //排序（默认）
        public void SortId()
        {
            orders.Sort((order1, order2) => order1.OrderId - order2.OrderId);
        }
        //排序（可自定义）
        public void Sort(Comparison<Order> comparison)
        {
            orders.Sort(comparison);
        }
    }
}