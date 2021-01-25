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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataAccess dataAccess = new DataAccess();

            dgOrders.DataSource = dataAccess.GetOrders();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Order selectedOrder = (Order)dgOrders.SelectedRows[0].DataBoundItem;

            EditOrder editForm = new EditOrder(selectedOrder.OrderId);

            editForm.ShowDialog();
        }
    }
}
