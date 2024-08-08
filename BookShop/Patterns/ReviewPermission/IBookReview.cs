using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Models;

namespace BookShop.Patterns.ReviewPermission
{
	internal interface IBookReview
	{
		bool PostReview(Review review);
	}
}
