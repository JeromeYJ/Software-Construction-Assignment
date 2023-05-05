using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Order;

namespace OrderForms
{
    public partial class Form1 : Form
    {
        OrderService orderService = new OrderService();  //用于存储订单链表、进行订单操作的对象
        public Form1()
        {
            InitializeComponent();
            orderService = new OrderService();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            if (form2.DialogResult == DialogResult.OK)
            {
                orderService.AddOrder(form2.Order);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //orderService的初始化
            Client client1 = new Client("Jerome");
            Client client2 = new Client("Flora");
            Client client3 = new Client("李华");
            List<OrderDetails> details1 = new List<OrderDetails>() { new OrderDetails(new Goods("《百年孤独》", 50), 2), new OrderDetails(new Goods("iPad", 5000), 1) };
            List<OrderDetails> details2 = new List<OrderDetails>() { new OrderDetails(new Goods("投影机", 2000), 1), new OrderDetails(new Goods("音响", 1500), 2) };
            List<OrderDetails> details3 = new List<OrderDetails>() { new OrderDetails(new Goods("《算法图解》", 30), 1), new OrderDetails(new Goods("胶卷", 80), 3) };
            List<OrderDetails> details4 = new List<OrderDetails>() { new OrderDetails(new Goods("《算法图解》", 30), 1), new OrderDetails( new Goods("胶卷", 80), 2) };
            List<OrderDetails> details5 = new List<OrderDetails>() { new OrderDetails(new Goods("投影机", 1000), 1), new OrderDetails( new Goods("胶卷", 80), 3) };
            Order.Order order1 = new Order.Order(client1, details1);
            Order.Order order2 = new Order.Order(client2, details2);
            Order.Order order3 = new Order.Order(client3, details3);
            Order.Order order4 = new Order.Order(client1, details4);
            Order.Order order5 = new Order.Order(client3, details5);
            orderService.AddOrder(order1);
            orderService.AddOrder(order2);
            orderService.AddOrder(order3);
            orderService.AddOrder(order4);
            orderService.AddOrder(order5);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            List<Order.Order> orders = new List<Order.Order>() { };
            Order.Order? o;
            switch (cboQuery.SelectedIndex)
            {
                case 0:
                    o = orderService.QueryId(Int32.Parse(txtQuery.Text));
                    if (o != null)
                        orders.Add(o);
                    else
                        MessageBox.Show("订单号不存在，请重新输入！");
                    break;
                case 1:
                    orders = orderService.QueryName(txtQuery.Text);
                    break;
                case 2:
                    orders = orderService.QueryClient(txtQuery.Text);
                    break;
                case 3:
                    orders = orderService.QueryPrice(Double.Parse(txtQuery.Text));
                    break;
                case 4:
                    orders = orderService.QueryAll();
                    break;
                default:
                    MessageBox.Show("请手动选择查询依据！");
                    break;
            }
            orderBindingSource.DataSource = orders;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvOrder.SelectedRows)
            {
                Order.Order o = orderBindingSource.Current as Order.Order;
                dgvOrder.Rows.Remove(row);
                MessageBox.Show("删除成功！");
                if (orderService.QueryId(o.OrderId) != null)
                {
                    orderService.DeleteOrder(o.OrderId);
                }
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(orderService);
            form3.ShowDialog();
        }
    }
}
