using Application.Dal.Contract;
using Application.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data.DataAccess
{
    public class OrderDataAccess : IDataAccess<Order, int>
    {
        SqlConnection Conn;
        SqlCommand Cmd;

        public OrderDataAccess()
        {
            Conn = new SqlConnection("Data Source=.;Initial Catalog=OrderManagement;Integrated Security=true");
        }
        Order IDataAccess<Order, int>.Create(Order entity)
        {
            try
            {
                Conn.Open();
                // Create a COmmand Object BAsed on Connection
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Insert into Orders Values ({entity.OrderId}, '{entity.ProductId}', '{entity.CustomerId}', {entity.Quantity}, {entity.TotalPrice}, {entity.OrderDate}, {entity.IsOrderApproved},{entity.IsOrderDispatched})";
                int result = Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }
            return entity;
        }

        Order IDataAccess<Order, int>.Delete(int id)
        {
            Order order = null;
            try
            {
                Conn.Open();
                // Create a COmmand Object BAsed on Connection
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Delete From Orders where OrderId={id}";
                int result = Cmd.ExecuteNonQuery();

            }

            catch (SqlException ex)
            {
                Console.WriteLine($"Error Occured while Processing Request {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error {ex.Message}");
            }
            finally
            {
                Conn.Close();
            }
            return order;
        }

        IEnumerable<Order> IDataAccess<Order, int>.Get()
        {
            List<Order> orderList = new List<Order>();
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from Orders";
                SqlDataReader reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    orderList.Add(new Order()
                    {
                        OrderId = Convert.ToInt32(reader["OrderId"]),
                        ProductId = Convert.ToInt32(reader["ProductId"]),
                        CustomerId = Convert.ToInt32(reader["CustomerId"]),
                        Quantity = Convert.ToInt32(reader["Quantity"]),
                        TotalPrice = Convert.ToDecimal(reader["TotalPrice"]),
                        OrderDate = Convert.ToDateTime(reader["OrderDate"]),
                        IsOrderApproved = Convert.ToBoolean(reader["IsOrderApproved"]),
                        IsOrderDispatched = Convert.ToBoolean(reader["IsOrderDispatched"])
                    });

                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }
            return orderList;
        }

        Order IDataAccess<Order, int>.Get(int id)
        {
            Order order = null;
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandText = $"Select OrderId, ProductId, CustomerId, Quantity, TotalPrice, OrderDate, IsOrderApproved, IsOrderDispatched from Orders where OrderId = {id}";
                SqlDataReader reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    order = new Order()
                    {
                        OrderId = Convert.ToInt32(reader["OrderId"]),
                        ProductId = Convert.ToInt32(reader["ProductId"]),
                        CustomerId = Convert.ToInt32(reader["CustomerId"]),
                        Quantity = Convert.ToInt32(reader["Quantity"]),
                        TotalPrice = Convert.ToDecimal(reader["TotalPrice"]),
                        OrderDate = Convert.ToDateTime(reader["OrderDate"]),
                        IsOrderApproved = Convert.ToBoolean(reader["IsOrderApproved"]),
                        IsOrderDispatched = Convert.ToBoolean(reader["IsOrderDispatched"])
                    };
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }
            return order;
        }

        Order IDataAccess<Order, int>.Update(int id, Order entity)
        {
            try
            {
                Conn.Open();
                // Create a COmmand Object BAsed on Connection
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Update Orders Set ProductId='{entity.ProductId}', CustomerId='{entity.CustomerId}',Quantity={entity.Quantity}, TotalPrice={entity.TotalPrice}, OrderDate={entity.OrderDate}, IsOrderApproved={entity.IsOrderApproved}, IsOrderDispatched={entity.IsOrderDispatched} where OrderId = {id}";
                int result = Cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }
            return entity;
        }
    }
}
