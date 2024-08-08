using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Patterns.ReviewPermission
{
	public class RealBookReview : IBookReview
	{
		public bool PostReview(Review review)
		{
			//ApplicationDbContext _context = new ApplicationDbContext();
			//_context.Reviews.Add(review);
			//_context.SaveChanges();
			return true;
		}
	}
}