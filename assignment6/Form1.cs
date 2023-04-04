using Order;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace assignment6
{
    public partial class Form1 : Form
    {
        OrderService orderService = new OrderService();  //���ڴ洢�����������ж��������Ķ���
        public Form1()
        {
            InitializeComponent();
            orderService = new OrderService();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //orderService�ĳ�ʼ��
            Client client1 = new Client("Jerome");
            Client client2 = new Client("Flora");
            Client client3 = new Client("�");
            List<OrderDetails> details1 = new List<OrderDetails>() { new OrderDetails(new Goods("������¶���", 50), 2), new OrderDetails(new Goods("iPad", 5000), 1) };
            List<OrderDetails> details2 = new List<OrderDetails>() { new OrderDetails(new Goods("ͶӰ��", 2000), 1), new OrderDetails(new Goods("����", 1500), 2) };
            List<OrderDetails> details3 = new List<OrderDetails>() { new OrderDetails(new Goods("���㷨ͼ�⡷", 30), 1), new OrderDetails(new Goods("����", 80), 3) };
            List<OrderDetails> details4 = new List<OrderDetails>() { new OrderDetails(new Goods("���㷨ͼ�⡷", 30), 1), new OrderDetails(new Goods("����", 80), 2) };
            List<OrderDetails> details5 = new List<OrderDetails>() { new OrderDetails(new Goods("ͶӰ��", 1000), 1), new OrderDetails(new Goods("����", 80), 3) };
            Order.Order order1 = new Order.Order(10020, client1, details1);
            Order.Order order2 = new Order.Order(20012, client2, details2);
            Order.Order order3 = new Order.Order(30098, client3, details3);
            Order.Order order4 = new Order.Order(40127, client1, details4);
            Order.Order order5 = new Order.Order(51891, client3, details5);
            orderService.AddOrder(order1);
            orderService.AddOrder(order2);
            orderService.AddOrder(order3);
            orderService.AddOrder(order4);
            orderService.AddOrder(order5);

            lblSelected.DataBindings.Add("Text", orderBindingSource, "OrderId");
        }

        //����˰�ť�󵯳��´���
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            if (form2.DialogResult == DialogResult.OK)
            {
                orderService.AddOrder(form2.Order);
            }
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
                        MessageBox.Show("�����Ų����ڣ����������룡");
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
                    MessageBox.Show("���ֶ�ѡ���ѯ���ݣ�");
                    break;
            }
            orderBindingSource.DataSource = orders;
        }

        //��dgvOrder��ѡ����Ӧ�У�����ð�ť���ɽ���ɾ������
        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvOrder.SelectedRows)
            {
                int id = Convert.ToInt32(row.Cells[0].Value);
                dgvOrder.Rows.Remove(row);
                //MessageBox.Show("ɾ���ɹ���");
                if (orderService.QueryId(id) != null)
                {
                    orderService.DeleteOrder(id);
                }
            }
        }

        //����˰�ť�󵯳��´���
        private void btnChange_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(orderService);
            form3.ShowDialog();
        }

        //��dgvOrder��ѡ����Ӧ�У�����ð�ť���ɲ�ѯ��Ӧ�Ķ�����ϸ
        private void btnDetails_Click(object sender, EventArgs e)
        {
            Order.Order order;
            foreach (DataGridViewRow row in dgvOrder.SelectedRows)
            {
                int id = Convert.ToInt32(row.Cells[0].Value);
                if (orderService.QueryId(id) != null)
                {
                    order = orderService.QueryId(id);
                    orderDetailsBindingSource.DataSource = order.Details;
                }
            }
        }
    }
}