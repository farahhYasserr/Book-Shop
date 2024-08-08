using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.ViewModels
{
	public class VmAdminEditBook
	{
		public Book book { get; set; }
		public HttpPostedFileBase imageFile { get; set; }
	}
}