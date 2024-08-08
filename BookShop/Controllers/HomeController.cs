using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using BookShop.Business_Layer.Home_Functions;
using BookShop.Business_Layer.Registration_functions;
using BookShop.Models;
using BookShop.Patterns.Filtering;
using BookShop.Patterns.ReviewPermission;
using BookShop.Patterns.ShoppingCart;
using BookShop.ViewModels;
using Microsoft.AspNet.Identity;

namespace BookShop.Controllers
{
	public class HomeController : Controller
	{
		//User user = new User();
		ApplicationDbContext _context = new ApplicationDbContext();
		Registration_functions registrationFunctions=new Registration_functions();
		defaultHome home = new defaultHome();

		public ActionResult Index(User user)
		{
			VmHome vm = new VmHome();
			 vm.books = home.getAllBooks();
			 vm.categories = home.getAllCategories();
			 vm.user = user;
			return View(vm);
		}
		public ActionResult ShoppingCart(User user)
		{
			VmCart vm = new VmCart();
			vm.user = user;
			return View(vm);
		}
		public ActionResult DeleteBookFromCart(int bookId, int userId)
		{
			VmCart vm = new VmCart();
			vm.cart.RemoveBook(bookId);
			vm.user = _context.Uusers.FirstOrDefault(U=>U.id==userId);
			return View("ShoppingCart", vm);
		}
		public ActionResult EditBooksFromCart(int userId,int bookId,int qty)
		{
			VmCart vm = new VmCart();
			vm.user = _context.Uusers.FirstOrDefault(U=>U.id==userId);
			return View("ShoppingCart", vm);
		}
		public ActionResult PaymentMethod(VmCart vm)
		{
			
			return View("ShoppingCart", vm);
		}
		public ActionResult AddToShoppingCart(VmBookDetails vm)
		{
			Book book = home.getBook(vm.bookId);
			Cart.getInstance().AddBook(book.id,vm.quantityToBeInCart);
			int Qty = Cart.getInstance().GetQuantity();
			decimal total = Cart.getInstance().GetTotal();
			vm.book = book;
			vm.user = registrationFunctions.getUser(vm.userId);
			return RedirectToAction("BookDetails", vm);
		}
		public ActionResult FilterItems(VmHome vm)
		{
			
			 vm.books = home.getAllBooks();
			 vm.categories = home.getAllCategories();

			IFilter filteredBooks = new ItemList(vm.books);
			if (vm.categoryId != 0)
				filteredBooks = new CategoryFilterDecorator(filteredBooks, vm.categoryId);

			if (vm.isPopularityChecked)
				filteredBooks = new PopularityFilterDecorator(filteredBooks);

			vm.books = filteredBooks.ApplyFilter(vm.books);
			
			vm.user = registrationFunctions.getUser(vm.user.id);

			return View(vm);
		}
		public ActionResult BookDetails(int bookId,int userId)
		{
			VmBookDetails vm = new VmBookDetails();
			vm.book = home.getBook(bookId);
			vm.user = registrationFunctions.getUser(userId);
			vm.bookId = bookId;
			vm.userId = userId;
			return View(vm);
		}
		public ActionResult PostReview(VmBookDetails vm)
		{

			vm.book = home.getBook(vm.bookId);
			vm.user = registrationFunctions.getUser(vm.userId);
			Review review = new Review();
			//review.user = vm.user;
			//review.book = vm.book;
			review.user = _context.Uusers.SingleOrDefault(u => u.id == vm.userId);
			review.book = _context.Books.SingleOrDefault(b => b.id == vm.bookId);
			Category category = _context.Categories.FirstOrDefault(c => c.id == vm.book.categoryId);
			review.book.category = category;
			review.bookId = vm.bookId;
			review.userId = vm.userId;
			review.statement = vm.statement;
			RealBookReview checkReview = new RealBookReview();
			IBookReview proxy = new BookReviewProxy(checkReview);
			bool canPost = proxy.PostReview(review);
			if (canPost)
			{
				_context.Reviews.Add(review);
				_context.SaveChanges();
			}
			else
			{
				vm.notAllowedToReviewMsg = "You can only post a review once you have purchased this book";
				return View("BookDetails", vm);
			}
			return RedirectToAction("BookDetails", vm);
		}
		public ActionResult SignUp()
		{
			Cart.getInstance().books.Clear();
			Cart cart = Cart.getInstance();
			cart = null;
			return View();
			
		} 
		public ActionResult SignUpProcess(User usr)
		{
			if (!ModelState.IsValid || registrationFunctions.userFound(usr))
				return View("SignUp",usr);
			
			registrationFunctions.addUser(usr);

			return RedirectToAction("LogIn");
			
		} 
		public ActionResult LogIn()
		{	
			return View();
		}
		public ActionResult LogInProcess(User usr)
		{
			if (registrationFunctions.userFound(usr)) 
			{ 
				usr = _context.Uusers.FirstOrDefault(u => u.username == usr.username && u.password == usr.password);
				return RedirectToAction("Index", usr);
			}
			else
				return View("LogIn", usr);
		}
	
	
	}
}