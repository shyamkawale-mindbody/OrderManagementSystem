using Application.Entities;
using Application.Dal.Contract;
using System.Data.SqlClient;
using System.Data;

namespace Application.Data.DataAccess
{
    public class CustomerDataAccess : IDataAccess<Customer, int>
    {
        SqlConnection Conn;
        SqlCommand Cmd;

        public CustomerDataAccess()
        {
            Conn = new SqlConnection("Data Source=.;Initial Catalog=OrderManagement;Integrated Security=true");
        }
        Customer IDataAccess<Customer, int>.Create(Customer entity)
        {
            try
            {
                Conn.Open();
                // Create a COmmand Object BAsed on Connection
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Insert into Customers Values ({entity.CustomerId}, '{entity.Name}', '{entity.Email}', {entity.MobileNo}, '{entity.Address}')";
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

        Customer IDataAccess<Customer, int>.Delete(int id)
        {
            Customer customer = null;
            try
            {
                Conn.Open();
                // Create a COmmand Object BAsed on Connection
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Delete From Customers where CustomerId={id}";
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
            return customer;
        }

        IEnumerable<Customer> IDataAccess<Customer, int>.Get()
        {
            List<Customer> customerList = new List<Customer>();
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from Customers";
                SqlDataReader reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    customerList.Add(new Customer()
                    {
                        CustomerId = Convert.ToInt32(reader["CustomerId"]),
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString(),
                        MobileNo = Convert.ToInt32(reader["MobileNo"]),
                        Address = reader["Address"].ToString()
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
            return customerList;
        }

        Customer IDataAccess<Customer, int>.Get(int id)
        {
            Customer customer = null;
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandText = $"Select CustomerId, Name, Email, MobileNo, Address from Customers where CustomerId = {id}";
                SqlDataReader reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    customer = new Customer()
                    {
                        CustomerId = Convert.ToInt32(reader["CustomerId"]),
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString(),
                        MobileNo = Convert.ToInt32(reader["MobileNo"]),
                        Address = reader["Address"].ToString()
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
            return customer;
        }

        Customer IDataAccess<Customer, int>.Update(int id, Customer entity)
        {
            try
            {
                Conn.Open();
                // Create a COmmand Object BAsed on Connection
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Update Customers Set Name='{entity.Name}', Email='{entity.Email}',MobileNo={entity.MobileNo}, Address={entity.Address} where CustomerId = {id}";
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