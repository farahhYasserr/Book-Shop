using BookShop.Business_Layer.Home_Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookShop.ViewModels;
using BookShop.Models;
using BookShop.Business_Layer.Registration_functions;
using System.IO;

namespace BookShop.Controllers
{
    public class AdminController : Controller
    {
		// GET: Admin
		defaultHome functions = new defaultHome();
        ApplicationDbContext _context=new ApplicationDbContext();
        public ActionResult Index()
		{
			VmAdminManageBooks vm = new VmAdminManageBooks();
			vm.categories = functions.getAllCategories();
			return View(vm);
        }
		public ActionResult DeleteCategory(int id)
		{
			Category category = _context.Categories.SingleOrDefault(c => c.id == id);
			category.isDeleted = true;
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult AddCategory(VmAdminManageBooks vm)
        {
            if (vm.categoryToBeAdded !=null)
            {
                Category category = new Category();
                category.name = vm.categoryToBeAdded;
                category.isDeleted = false;
                _context.Categories.Add(category);
                _context.SaveChanges();
            }
			return RedirectToAction("Index");
        } 
        public ActionResult AddBook(int id)
        {
            VmAdminAddBook vm = new VmAdminAddBook();
            vm.choosenCategoryId = id;
            return View(vm);
        }   
        public ActionResult EditBook(int bookId)
        {
			VmAdminEditBook vm = new VmAdminEditBook();
            vm.book = _context.Books.FirstOrDefault(b => b.id == bookId);
			return View(vm);
        }
		public ActionResult DeleteBook(int id)
		{
			Book book = _context.Books.SingleOrDefault(b => b.id == id);
			Category category = _context.Categories.SingleOrDefault(c => c.id == book.categoryId);
			book.category = category;
			book.status = "deleted";
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult AddBookProcess(VmAdminAddBook vm)
        {
            if (!ModelState.IsValid)
                return View("AddBook", vm);
             
			Category category = _context.Categories.FirstOrDefault(c => c.id == vm.choosenCategoryId);
            string image = vm.book.name + ".jpg";
            vm.book.category = category;
            vm.book.image=image;
            _context.Books.Add(vm.book);
            string serverPath = Path.Combine(Server.MapPath("~/Content/images"), vm.book.name + ".jpg");
            vm.imageFile.SaveAs(serverPath);
            _context.SaveChanges();
			return RedirectToAction("Index");
        }
		public ActionResult EditBookProcess(VmAdminEditBook vm)
		{
			if (!ModelState.IsValid)
				return View("EditBook", vm);

			Category category = _context.Categories.FirstOrDefault(c => c.id == vm.book.categoryId);

			Book book = _context.Books.SingleOrDefault(b => b.id == vm.book.id);
			book.name = vm.book.name;
			book.price = vm.book.price;
			book.popularity = vm.book.popularity;
			book.qunatity = vm.book.qunatity;
			book.status = vm.book.status;
			book.category = category;
			book.categoryId = vm.book.categoryId;
			book.authorName = vm.book.authorName;
			if (vm.book.edition != null)
				book.edition = vm.book.edition;
			if (vm.imageFile != null) { 
			string image = vm.book.name + ".jpg";
			book.image = image;
			string serverPath = Path.Combine(Server.MapPath("~/Content/images"), vm.book.name + ".jpg");
			vm.imageFile.SaveAs(serverPath); 
			}
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		

	}
}