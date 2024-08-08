using BookShop.Models;
using BookShop.Patterns.ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.ViewModels
{
	public class VmHome
	{
        public List<Category> categories { get; set; }
        public List<Book> books { get; set; }
        public User user { get; set; }
		//for filtering
		public int categoryId { get; set; }
		public bool isPopularityChecked { get; set; }
		public int cartQty = Cart.getInstance().GetQuantity();

	}
}