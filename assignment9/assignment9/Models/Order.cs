using System.ComponentModel.DataAnnotations;

namespace assignment9.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public Client Client { get; set; }
        public double Price { get; set; }
        public int ClientId { get; set; }
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
}
