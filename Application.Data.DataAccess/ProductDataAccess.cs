using Application.Dal.Contract;
using Application.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data.DataAccess
{
    public class ProductDataAccess : IDataAccess<Product, int>
    {
        SqlConnection Conn;
        SqlCommand Cmd;

        public ProductDataAccess()
        {
            Conn = new SqlConnection("Data Source=.;Initial Catalog=OrderManagement;Integrated Security=true");
        }
        Product IDataAccess<Product, int>.Create(Product entity)
        {
            try
            {
                Conn.Open();
                // Create a COmmand Object BAsed on Connection
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Insert into Products Values ({entity.ProductId}, '{entity.ProductName}', '{entity.CategoryName}', {entity.UnitPrice})";
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

        Product IDataAccess<Product, int>.Delete(int id)
        {
            Product product = null;
            try
            {
                Conn.Open();
                // Create a COmmand Object BAsed on Connection
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Delete From Products where ProductId={id}";
                int result = Cmd.ExecuteNonQuery();

            }

            catch (SqlException ex)
            {
                Console.WriteLine($"Error Occured while Processoing Request {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error {ex.Message}");
            }
            finally
            {
                Conn.Close();
            }
            return product;
        }

        IEnumerable<Product> IDataAccess<Product, int>.Get()
        {
            List<Product> productList = new List<Product>();
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from products";
                SqlDataReader reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    productList.Add(new Product()
                    {
                        ProductId = Convert.ToInt32(reader["ProductId"]),
                        ProductName = reader["ProductName"].ToString(),
                        CategoryName = reader["CategoryName"].ToString(),
                        UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
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
            return productList;
        }

        Product IDataAccess<Product, int>.Get(int id)
        {
            Product product = null;
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandText = $"Select ProductId, ProductName, CategoryName, UnitPrice from Products where ProductId = {id}";
                SqlDataReader reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    product = new Product()
                    {
                        ProductId = Convert.ToInt32(reader["ProductId"]),
                        ProductName = reader["ProductName"].ToString(),
                        CategoryName = reader["CategoryName"].ToString(),
                        UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
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
            return product;
        }

        Product IDataAccess<Product, int>.Update(int id, Product entity)
        {
            try
            {
                Conn.Open();
                // Create a COmmand Object BAsed on Connection
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Update Products Set ProductName='{entity.ProductName}', CategoryName='{entity.CategoryName}',UnitPrice={entity.UnitPrice} where ProductId={id}";
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
