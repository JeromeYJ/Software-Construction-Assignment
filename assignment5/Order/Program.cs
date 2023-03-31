namespace Order
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OrderService orderService = new OrderService();

            //加入五个订单，初始化
            Client client1 = new Client("Jerome");
            Client client2 = new Client("Flora");
            Client client3 = new Client("李华");
            List<OrderDetails> details1 = new List<OrderDetails>() { new OrderDetails(new Goods("《百年孤独》", 50), 2), new OrderDetails(new Goods("iPad", 5000), 1) };
            List<OrderDetails> details2 = new List<OrderDetails>() { new OrderDetails(new Goods("投影机", 2000), 1), new OrderDetails(new Goods("音响", 1500), 2) };
            List<OrderDetails> details3 = new List<OrderDetails>() { new OrderDetails(new Goods("《算法图解》", 30), 1), new OrderDetails(new Goods("胶卷", 80), 3) };
            List<OrderDetails> details4 = new List<OrderDetails>() { new OrderDetails(new Goods("《算法图解》", 30), 1), new OrderDetails(new Goods("胶卷", 80), 2) };
            List<OrderDetails> details5 = new List<OrderDetails>() { new OrderDetails(new Goods("投影机", 1000), 1), new OrderDetails(new Goods("胶卷", 80), 3) };
            Order order1 = new Order(1, client1, details1);
            Order order2 = new Order(2, client2, details2);
            Order order3 = new Order(3, client3, details3);
            Order order4 = new Order(4, client1, details4);
            Order order5 = new Order(5, client3, details5);
            orderService.AddOrder(order1);
            orderService.AddOrder(order2);
            orderService.AddOrder(order3);
            orderService.AddOrder(order4);
            orderService.AddOrder(order5);

            //第一次查询订单
            Order? order= orderService.QueryId(2);
            Console.Write("（一）第一次进行查询，Id为2的订单：");
            if(order!=null)
                Console.WriteLine(order.OrderId);
            Console.WriteLine();

            //修改订单
            Console.WriteLine("（二）进行修改订单，修改Id为5的订单。修改后的订单信息：");
            List<OrderDetails> details6 = new List<OrderDetails>() { new OrderDetails(new Goods("投影机", 1500), 1), new OrderDetails(new Goods("胶卷", 80), 5) };
            orderService.ChangeOrder(5, client3, details6);
            List<Order> list1 = orderService.QueryAll();
            list1.ForEach((order) => Console.WriteLine(order));
            Console.WriteLine();

            //删除订单
            Console.WriteLine("（三）进行删除订单，删除Id为3的订单。删除后的订单信息：");
            orderService.DeleteOrder(3);
            list1.ForEach((order) => Console.WriteLine(order));
            Console.WriteLine();

            //按商品名称查询
            list1 = orderService.QueryName("投影机");
            Console.WriteLine("（四）按商品名称进行查询，查询商品名为“投影机”的订单：");
            list1.ForEach(order => Console.WriteLine(order));
            Console.WriteLine();

            //排序
            Console.WriteLine("（五）按照Id进行排序。排序后的订单信息：");
            orderService.SortId();
            list1 = orderService.QueryAll();
            list1.ForEach(order => Console.WriteLine(order));
        }
    }
}