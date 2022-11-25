using System;
using MySqlConnector;
using System.Data;
using TrustBoxes.Models;

namespace TrustBoxes.Data
{
	public class itemsConnections
	{
        public async Task<Items[]> GetItemsDetails()
        {
            List<Items> list = new List<Items>();
            using (MySqlConnection conn = mySQLSqlHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("Select * From `items`", conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Items()
                            {
                                id = reader.GetInt32("id"),
                                name = reader.GetString("name"),
                            });
                        }
                    }
                }
            }
            return list.ToArray();
        }
    }
}

