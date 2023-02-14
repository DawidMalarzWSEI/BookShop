using BookShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Data
{
	public class AppDbContext:DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
		public DbSet<Author> Authors { get; set; }
		public DbSet<Book> Books { get; set; }

		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }

		public DbSet<ShoppingCartItem> ShoppingCartItems { get; set;}
	}
	

}
