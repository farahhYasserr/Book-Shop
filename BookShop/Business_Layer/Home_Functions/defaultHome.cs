using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookShop.Models;

namespace BookShop.Business_Layer.Home_Functions
{
	public class defaultHome
	{
		private ApplicationDbContext _context = new ApplicationDbContext();
	
		public List<Book> getAllBooks()
		{
			List<Book> books = _context.Books.Where(b => b.category.isDeleted == false && b.status != "deleted").ToList();
			return books;
		}
		public List<Category> getAllCategories()
		{
			List<Category> categories = _context.Categories.Where(b => b.isDeleted == false).ToList();
			List<Book> books;
			foreach (var category in categories)
			{
				books = _context.Books.Where(b => b.categoryId == category.id && b.status != "deleted").ToList();
				category.books = books;
			}
			return categories;
		}
		public Book getBook(int bookId)
		{
			Book book = _context.Books.SingleOrDefault(b => b.id == bookId);
			var reviews = _context.Reviews.Where(r => r.bookId == book.id).ToList();
			User user;
			Category category = _context.Categories.FirstOrDefault(c => c.id == book.categoryId);
			book.category = category;
			foreach (var review in reviews)
			{
				user = _context.Uusers.FirstOrDefault(u => u.id == review.userId);
				review.user = user;
			}
			book.reviews = reviews;
			return book;
		}
	}
}