using System;
using MySqlConnector;
using System.Data;
using TrustBoxes.Models;
using System.Numerics;
using System.Xml.Linq;

namespace TrustBoxes.Data
{
	public class custConnectoins
	{
        public async Task<Customer[]> GetCustDetails(string CustName, String Email)
        {
            List<Customer> list = new List<Customer>();
            using (MySqlConnection conn = mySQLSqlHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("Select * From customers", conn))
                {
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add(new MySqlParameter
                    //{
                    //    ParameterName = "@CustNames",
                    //    DbType = DbType.String,
                    //    Value = CustName,
                    //    Direction = ParameterDirection.Input,
                    //});
                    //cmd.Parameters.Add(new MySqlParameter
                    //{
                    //    ParameterName = "@Emails",
                    //    DbType = DbType.String,
                    //    Value = Email,
                    //    Direction = ParameterDirection.Input,
                    //});
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Customer()
                            {
                                id = reader.GetInt32("id"),
                                name = reader.GetString("name"),
                                email = reader.GetString("email"),
                                phone = reader.GetString("phone"),
                            });
                        }
                    }
                }
            }
            return list.ToArray();
        }

        public async Task<Customer> FindCustomer(int id)
        {
            Customer customer = new Customer();
            using (MySqlConnection conn = mySQLSqlHelper.GetConnection())
            {
                conn.Open();
                string query = "Select * From customers WHERE id=" + id;
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customer.id = reader.GetInt32("id");
                            customer.name = reader.GetString("name");
                            customer.email = reader.GetString("email");
                            customer.phone = reader.GetString("phone");
                        }
                    }
                }
            }
            return customer;
        }

        public async Task<Customer> CreateCustomer(Customer customer)
        { 
            using (MySqlConnection conn = mySQLSqlHelper.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO customers (`name`, `email`, `phone`) VALUES ('"
                    + customer.name + "','" + customer.email + "','" + customer.phone + "')";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                        }
                    }
                }
            }
            return customer;
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            bool status = false;
            using (MySqlConnection conn = mySQLSqlHelper.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM customers WHERE id=" + id;
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            status = true;
                        }
                    }
                }
            }
            return status;
        }
    }
}

