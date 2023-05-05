using MySql.Data.EntityFramework;
using System;
using System.Data.Entity;
using System.Linq;

namespace Order
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class OrderContext : DbContext
    {
        public OrderContext()
            : base("name=Model1")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<OrderContext>());
        }

        //为您要在模型中包含的每种实体类型都添加 DbSet。
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Goods> Goods { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}