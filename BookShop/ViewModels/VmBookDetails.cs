using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookShop.Models;
using BookShop.Patterns.ShoppingCart;

namespace BookShop.ViewModels
{
	public class VmBookDetails
	{
		public Book book { get; set; }
        public User user { get; set; }
        public string statement { get; set; }
        public string notAllowedToReviewMsg { get; set; }
        public int userId { get; set; }
        public int bookId { get; set; }
        public int quantityToBeInCart { get; set; }
        public int cartQty = Cart.getInstance().GetQuantity();
    }
}