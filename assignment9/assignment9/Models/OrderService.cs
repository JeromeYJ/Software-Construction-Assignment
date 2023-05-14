using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;
using System.Xml.Linq;

namespace assignment9.Models
{
    public class OrderService
    {
        //List<Order> orders;

        OrderContext orderContext;
        public OrderService(OrderContext orderContext)
        {
            this.orderContext = orderContext;
        }

        //添加订单
        public void AddOrder(Order order)
        {
            orderContext.Orders.Add(order);
            orderContext.SaveChanges();
        }
        //删除订单
        public void DeleteOrder(int id)
        {
            var order = orderContext.Orders.FirstOrDefault(o => o.OrderId == id);
            
            if (order == null)
                throw new ApplicationException("删除订单失败！");
            else
            {
                var detail = orderContext.OrderDetails.FirstOrDefault(d => d.OrderId == order.OrderId);
                orderContext.OrderDetails.RemoveRange(detail);
                orderContext.Orders.Remove(order);
                orderContext.SaveChanges();
            }
        }
        //修改订单
        public void ChangeOrder(int id, Client client, List<OrderDetails> details)
        {
            var order = QueryId(id);
            if (order != null)
            {
                DeleteOrder(id);
                Order orderNew = new Order(id, client, details);
                orderContext.Orders.Add(orderNew);
                orderContext.SaveChanges();
                orderContext.Entry(order).State = EntityState.Detached;
            }
            else throw new ApplicationException("修改订单失败！");
        }
        //查询订单（按订单号）
        public Order? QueryId(int id)
        {
            return orderContext.Orders
                .Include(o => o.Client)
                .Include(o => o.Details)
                .ThenInclude(d => d.Goods)
                .FirstOrDefault(o => o.OrderId == id);
        }
        //查询（按商品名称）
        public List<Order> QueryName(string name)
        {
            var query = from o in orderContext.Orders
                        where o.Details.Any(d => d.GoodsName == name)
                        select new Order
                        {
                            OrderId = o.OrderId,
                            Client = o.Client,
                            Price = o.Price,
                            ClientId = o.ClientId,
                            ClientName = o.ClientName,
                            Details = o.Details,
                        };
            return query.ToList<Order>();
        }
        //查询orders中所有订单
        public List<Order> QueryAll()
        {
            var query = from o in orderContext.Orders
                        select new Order
                        {
                            OrderId = o.OrderId,
                            Client = o.Client,
                            Price =o.Price,
                            ClientId = o.ClientId,
                            ClientName = o.ClientName,
                            Details = o.Details,
                        };
            return query.ToList<Order>();
        }
        //查询（按客户）
        public List<Order> QueryClient(string client)
        {
            var query = from o in orderContext.Orders
                        where o.ClientName == client
                        select new Order
                        {
                            OrderId = o.OrderId,
                            Client = o.Client,
                            Price = o.Price,
                            ClientId = o.ClientId,
                            ClientName = o.ClientName,
                            Details = o.Details,
                        };
            return query.ToList<Order>();
        }
        //查询（按订单金额）
        public List<Order> QueryPrice(double price)
        {
            var query = from o in orderContext.Orders
                        where o.Price == price
                        select new Order
                        {
                            OrderId = o.OrderId,
                            Client = o.Client,
                            Price = o.Price,
                            ClientId = o.ClientId,
                            ClientName = o.ClientName,
                            Details = o.Details,
                        };
            return query.ToList<Order>();
        }
    }
}
