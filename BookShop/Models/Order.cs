using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Models
{
	public class Order
	{
		public Order()
		{
			user = new User();
			orderBooks = new HashSet<OrderBook>();
		}
		public int id { get; set; }
        public int userId { get; set; }
        public DateTime date { get; set; }
        public string status { get; set; }
        public decimal totalPrice { get; set; }
        public string address { get; set; }
        public string paymentMethod { get; set; }
        public virtual User user { get; set; }
        public  virtual ICollection<OrderBook> orderBooks { get; set; }
    }
}