using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Models
{
	public class Review
	{
		public Review()
		{
			book = new Book();
			user = new User();
		}

		public int id { get; set; }
		public int userId { get; set; }
		public int bookId { get; set; }
		public string statement { get; set; }
		public virtual Book book { get; set; }
		public virtual User user { get; set; }
	}
}