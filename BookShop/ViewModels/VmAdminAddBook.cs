using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BookShop.Models;

namespace BookShop.ViewModels
{
	public class VmAdminAddBook
	{
     
        public Book book { get; set; }
		[Required(ErrorMessage = "Please upload an image")]
		public HttpPostedFileBase imageFile { get; set; }
        public int choosenCategoryId { get; set; }
    }
}