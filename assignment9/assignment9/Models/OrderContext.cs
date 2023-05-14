using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace assignment9.Models
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Goods> Goods { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
