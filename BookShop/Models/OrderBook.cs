using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Models
{
	public class OrderBook
	{
		public OrderBook()
		{
			book = new Book();
			order = new Order();
		}

		public int bookId { get; set; }
		public int orderId { get; set; }
		public int quantity { get; set; }
		public virtual Book book { get; set; }
		public virtual Order order { get; set; }
	}
}