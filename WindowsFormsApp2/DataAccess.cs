using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class DataAccess
    {
        private readonly string _connectionString = "myConnectionString//randomStuff";

        public List<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT OrderID, CustomerID, OrderDate, RequiredDate, ShippedDate FROM Orders");

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Order order = new Order();
                        order.OrderId = reader.GetInt32(0);
                        order.CustomerId = reader.GetInt32(1);
                        order.OrderDate = reader.GetDateTime(2);

                        orders.Add(order);
                    }
                }
            }

            return orders;
        }

        public OrderDetails GetOrderById(int orderId)
        {
            OrderDetails orderDetails = new OrderDetails();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT OrderId, BuyerName, Address FROM OrderDetails WHERE OrderId = @orderId");
                cmd.Parameters.AddWithValue("@orderId", orderId);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        orderDetails.OrderId = reader.GetInt32(0);
                        orderDetails.BuyerName = reader.GetString(1);
                        orderDetails.Address = reader.GetString(2);
                    }
                }
            }

            return orderDetails;
        }

        public void SaveOrderDetailAddress(OrderDetails orderDetails)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE OrderDetails SET Address = @address WHERE OrderId = @orderId");
                cmd.Parameters.AddWithValue("@address", orderDetails.Address);
                cmd.Parameters.AddWithValue("@orderId", orderDetails.OrderId);


                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
