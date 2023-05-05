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

namespace OrderForms
{
    public partial class Form2 : Form
    {
        public Order.Order Order { get; set; }
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

        private void btnAddDetails_Click(object sender, EventArgs e)
        {
            Goods goods = new Goods("", 0);
            OrderDetails detail = new OrderDetails(goods, 0);
            orderDetailsBindingSource.Add(detail);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Order = new Order.Order(new Client(txtClient.Text), details);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
