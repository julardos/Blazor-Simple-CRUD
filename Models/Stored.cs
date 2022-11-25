using System;
namespace TrustBoxes.Models
{
    public class Stored
    {
        public int id { get; set; }
        public int item_id { get; set; }
        //public ICollection<Items> items { get; set; }
        public DateOnly start_at { get; set; }
        public DateOnly end_at { get; set; }
        public int status_id { get; set; }
        public Status status { get; set; }
        public int customer_id { get; set; }
        public Customer customer { get; set; }
	}
}

