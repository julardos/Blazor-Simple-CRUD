using System;
using MySqlConnector;
using System.Data;
using TrustBoxes.Models;

namespace TrustBoxes.Data
{
	public class storedConnections
	{
        public async Task<Stored[]> GetStoredDetails()
        {
            List<Stored> list = new List<Stored>();
            using (MySqlConnection conn = mySQLSqlHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("Select * From `stored`", conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Stored()
                            {
                                id = reader.GetInt32("id"),
                                start_at = reader.GetDateOnly("start_at"),
                                end_at = reader.GetDateOnly("end_at"),
                                status_id = reader.GetInt32("status_id"),
                                customer_id = reader.GetInt32("customer_id"),
                            });
                        }
                    }
                }
            }
            return list.ToArray();
        }


        public async Task<Stored> CreateStored(Stored stored)
        {
            using (MySqlConnection conn = mySQLSqlHelper.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO `stored` (`item_id`, `start_at`, `end_at`, `status_id`, `customer_id`) VALUES ('"
                    + stored.item_id + "','" + stored.start_at.ToString("yyyy-MM-dd") + "','" + stored.end_at.ToString("yyyy-MM-dd") + "','"+ 1 + "','"+ stored.customer_id + "')";
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
            return stored;
        }
    }
}

