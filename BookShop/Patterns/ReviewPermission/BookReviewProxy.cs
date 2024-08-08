using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Patterns.ReviewPermission
{
	public class BookReviewProxy : IBookReview
	{
		private readonly RealBookReview realBookReview;
		public BookReviewProxy(RealBookReview realBookReview)
		{
			this.realBookReview = realBookReview;
		}

		public bool PostReview(Review review)
		{
			if (UserHasPurchasedBook(review))
				return realBookReview.PostReview(review);
			else
				return false;
		}
		private bool UserHasPurchasedBook(Review review)
		{
			ApplicationDbContext _context = new ApplicationDbContext();
			List<Order> userOrders = _context.Orders.Where(o => o.userId == review.user.id && o.status=="confirmed").ToList();
			bool foundBook = false;
			foreach(var order in userOrders)
			{
				OrderBook oBook = _context.OrderBooks.FirstOrDefault(o => o.bookId == review.bookId && o.orderId==order.id);
				if (oBook != null)
					foundBook = true;
			}
			return foundBook;
		}
	}
}