using Order;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace assignment6
{
    public partial class Form2 : Form
    {
        public Order.Order Order{ get; set; }
        public List<OrderDetails> details;
        public Form2()
        {
            InitializeComponent();
            details = new List<OrderDetails>() { };
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            orderDetailsBindingSource.DataSource = details;
        }

        //点击“添加订单”后，窗口关闭。一次只能添加一个订单。
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Order = new Order.Order(Convert.ToInt32(txtId.Text), new Client(txtClient.Text), details);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnAddDetails_Click(object sender, EventArgs e)
        {
            Goods goods = new Goods("", 0);
            OrderDetails detail = new OrderDetails(goods, 0);
            orderDetailsBindingSource.Add(detail);
        }
    }
}
