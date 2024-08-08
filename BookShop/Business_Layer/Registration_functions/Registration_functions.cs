using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookShop.Models;

namespace BookShop.Business_Layer.Registration_functions
{
	public class Registration_functions
	{
		ApplicationDbContext _context = new ApplicationDbContext();

		public void addUser(User user)
		{
			_context.Uusers.Add(user);
			_context.SaveChanges();
		}
		public bool userFound(User user)
		{
			var usr = _context.Uusers.SingleOrDefault(u=>u.username==user.username && u.password==user.password);
			if (usr == null)
				return false;
			else
				return true;
		}
		public User getUser(int id)
		{
			var user = _context.Uusers.SingleOrDefault(u=>u.id==id);
			return user;
		}
	}
}