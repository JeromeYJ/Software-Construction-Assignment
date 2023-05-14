using System.ComponentModel.DataAnnotations;

namespace assignment9.Models
{
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
}
