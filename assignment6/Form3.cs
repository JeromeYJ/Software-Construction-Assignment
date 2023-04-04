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

namespace assignment6
{

    public partial class Form3 : Form
    {
        List<OrderDetails> details;
        OrderService orderService;
        public Order.Order Order { get; set; }
        public Form3(OrderService orderService)
        {
            InitializeComponent();
            details = new List<OrderDetails>() { };
            this.orderService = orderService;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            Order.Order? o;
            o = orderService.QueryId(Convert.ToInt32(txtId.Text));
            if (o != null)
            {
                Order = o;
                orderDetailsBindingSource.DataSource = Order.Details;
                txtClient.Text = Order.ClientName;
            }
            else
                MessageBox.Show("订单号不存在，请重新输入！");
        }

        private void btnDeleteDetail_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDetails.SelectedRows)
            {
                dgvDetails.Rows.Remove(row);
                int id = Convert.ToInt32(row.Cells[1].Value);
                if (orderService.QueryId(id) != null)
                    orderService.DeleteOrder(id);
            }
        }

        private void btnAddDetails_Click(object sender, EventArgs e)
        {
            OrderDetails detail = new OrderDetails(new Goods("", 0), 0);
            orderDetailsBindingSource.Add(detail);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Order.Client = new Client(txtClient.Text);
            this.Close();
        }
    }
}
