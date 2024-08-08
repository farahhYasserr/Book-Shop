using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Models;

namespace BookShop.Patterns.Filtering
{
	public interface IFilter
	{
		List<Book> ApplyFilter(List<Book> books);
	}
}
