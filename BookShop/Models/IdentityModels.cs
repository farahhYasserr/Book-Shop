using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookShop.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
		public DbSet<Category> Categories { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<User> Uusers { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Review> Reviews { get; set; }
        public DbSet<OrderBook> OrderBooks { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
			this.Configuration.ProxyCreationEnabled = true;
			this.Configuration.LazyLoadingEnabled = true;
		}

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			//Book % Review constraints
			modelBuilder.Entity<Review>()
				.HasRequired(e => e.book)
				.WithMany(e => e.reviews)
				.HasForeignKey(e => e.bookId);

			//Book & Category constraints
			modelBuilder.Entity<Book>()
					.HasRequired(e=>e.category)
					.WithMany(e => e.books)
					.HasForeignKey(e => e.categoryId);


			//User & Order constraints
			modelBuilder.Entity<Order>()
				.HasRequired(e => e.user)
				.WithMany(e => e.orders)
				.HasForeignKey(e => e.userId);
			//User & Review constraints
			modelBuilder.Entity<Review>()
				.HasRequired(e => e.user)
				.WithMany(e => e.reviews)
				.HasForeignKey(e => e.userId);

			//OrderBook constraints
			modelBuilder.Entity<OrderBook>()
			.HasKey(oi => new { oi.orderId, oi.bookId });

			modelBuilder.Entity<OrderBook>()
		   .HasRequired(oi => oi.book)
		   .WithMany(b => b.orderBooks)
		   .HasForeignKey(oi => oi.bookId);

			modelBuilder.Entity<OrderBook>()
				.HasRequired(oi => oi.order)
				.WithMany(o => o.orderBooks)
				.HasForeignKey(oi => oi.orderId);

		}
	}
}