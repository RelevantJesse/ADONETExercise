using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class EditOrder : Form
    {
        private readonly int _orderId;
        private OrderDetails _orderDetails;
        public EditOrder(int orderId)
        {
            _orderId = orderId;

            InitializeComponent();
        }

        private void EditOrder_Load(object sender, EventArgs e)
        {
            DataAccess da = new DataAccess();
            _orderDetails = da.GetOrderById(_orderId);

            txtOrderId.Text = _orderDetails.OrderId.ToString();
            txtBuyer.Text = _orderDetails.BuyerName;
            txtAddress.Text = _orderDetails.Address;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataAccess da = new DataAccess();

            _orderDetails.Address = txtAddress.Text;

            da.SaveOrderDetailAddress(_orderDetails);
        }
    }
}
