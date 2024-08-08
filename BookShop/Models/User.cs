using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookShop.Models
{
	public class User
	{
		public User()
		{
			orders = new HashSet<Order>();
			reviews = new HashSet<Review>();
		}
		public int id { get; set; }
		[Required(ErrorMessage = "Please enter a value.")]
		public string username { get; set; }
		[Required(ErrorMessage = "Please enter a value.")]
		public string address { get; set; }
		[Required(ErrorMessage = "Please enter a value.")]
		public string phone { get; set; }
		[Required(ErrorMessage = "Please enter a value.")]
		public string password { get; set; }
        public virtual ICollection<Order> orders { get; set; }
        public virtual ICollection<Review> reviews { get; set; }
    }
}