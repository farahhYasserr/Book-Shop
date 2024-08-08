using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Patterns.Filtering
{
	public class CategoryFilterDecorator : IFilter
	{
		private IFilter Filter;
		private int categoryId;
		public CategoryFilterDecorator(IFilter Filter, int categoryId)
		{
			this.Filter = Filter;
			this.categoryId = categoryId;
		}
		public List<Book> ApplyFilter(List<Book> books)
		{
		    ApplicationDbContext _context = new ApplicationDbContext();
			books=_context.Books.Where(b=>b.categoryId==categoryId && b.category.isDeleted == false).ToList();
			return Filter.ApplyFilter(books);
		}
	}
}