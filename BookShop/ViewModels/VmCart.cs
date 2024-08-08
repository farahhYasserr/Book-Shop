using BookShop.Models;
using BookShop.Patterns.ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.ViewModels
{
	public class VmCart
	{
        public User user { get; set; }
        public Cart cart= Cart.getInstance();
    }
}