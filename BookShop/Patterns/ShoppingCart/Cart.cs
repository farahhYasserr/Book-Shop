using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Patterns.ShoppingCart
{
	public class Cart
	{		
		private static Cart _instance;
		public Dictionary<int, int> books;
        private Cart()
		{
			books = new Dictionary<int, int>();
		}

		public static Cart getInstance()
		{
			if (_instance == null)
			{
				_instance = new Cart();
			}
			return _instance;
		}

		public void AddBook(int bookId,int quantity)
		{
			if (!books.ContainsKey(bookId))
				books.Add(bookId, quantity);
			else
				books[bookId]+=quantity;
		}	
		public void EditBook(int bookId,int quantity)
		{
				books[bookId]=quantity;
		}
		public void RemoveBook(int bookId)
		{
			books.Remove(bookId);
		}
		public int GetQuantity()
		{
			int quantity = 0;
			foreach (int qty in books.Values)
			{
				quantity += qty;
			}
			return quantity;
		}
        public decimal GetTotal() {
			decimal total_price = 0;
			Book book;
			ApplicationDbContext _context = new ApplicationDbContext();
			foreach(int bookId in books.Keys)
			{
				book = _context.Books.FirstOrDefault(b => b.id == bookId);
				total_price += book.price * books[bookId];
			}
			return total_price;
		}
    }
}