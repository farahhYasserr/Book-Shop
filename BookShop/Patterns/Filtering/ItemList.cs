using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookShop.Models;

namespace BookShop.Patterns.Filtering
{
	public class ItemList:IFilter
	{
		private List<Book> books;
		public ItemList(List<Book> books)
		{
			this.books = books;
		}

		public List<Book> ApplyFilter(List<Book> books)
		{
			return books;
		}
	}
}