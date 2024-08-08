using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Models
{
	public class Category
	{
        public Category()
        {
            books = new HashSet<Book>();
        }
        public int id { get; set; }
        public string name { get; set; }
        public bool isDeleted { get; set; }
        public virtual ICollection<Book> books { get; set; }
    }
}