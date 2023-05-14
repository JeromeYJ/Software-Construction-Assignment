using System.ComponentModel.DataAnnotations;

namespace assignment9.Models
{
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
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
}
