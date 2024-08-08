using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Patterns.Filtering
{
	public class PopularityFilterDecorator : IFilter
	{
		private IFilter Filter;
		public PopularityFilterDecorator(IFilter nextFilter)
		{
			this.Filter = nextFilter;
		}
		public List<Book> ApplyFilter(List<Book> books)
		{
			ApplicationDbContext _context = new ApplicationDbContext();
			books = _context.Books.Where(b=>b.category.isDeleted == false).OrderByDescending(b=>b.popularity).ToList();
			return Filter.ApplyFilter(books);
		}
	}
}