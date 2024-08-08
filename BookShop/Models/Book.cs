using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookShop.Models
{
	public class Book
	{
        public Book()
        {
            category = new Category();
            reviews = new HashSet<Review>();
			orderBooks = new HashSet<OrderBook>();
        }
        public int id { get; set; }
        public int categoryId { get; set; }
        [Required(ErrorMessage = "Please enter a value.")]
        public string name { get; set; }
		[Required(ErrorMessage = "Please enter a value.")]
		public string authorName { get; set; }
		[Required(ErrorMessage = "Please enter a value.")]
		public decimal price { get; set; }
		public string edition { get; set; }
		public string image { get; set; }
		[Required(ErrorMessage = "Please enter a value.")]
		public int qunatity { get; set; }
		[Required(ErrorMessage = "Please enter a value.")]
		public string status { get; set; }
		[Required(ErrorMessage = "Please enter a value.")]
		public double popularity { get; set; }
        public virtual Category category { get; set; }
        public virtual ICollection<Review> reviews { get; set; }
        public virtual ICollection<OrderBook> orderBooks { get; set; }
    }
}