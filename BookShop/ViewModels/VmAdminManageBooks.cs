using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookShop.Models;
using System.ComponentModel.DataAnnotations;

namespace BookShop.ViewModels
{
	public class VmAdminManageBooks
	{
        public List<Category> categories { get; set; }
        [Required(ErrorMessage = "Please enter a value.")]
        public string categoryToBeAdded { get; set; }
    }
}