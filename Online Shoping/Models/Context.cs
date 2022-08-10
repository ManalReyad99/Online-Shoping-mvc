
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Online_Shoping.Models;
using Online_Shoping.ViewModels;

namespace Online_Shoping.Models

{
    public class Context:IdentityDbContext<ApplicationUser>
    {
        public Context() : base()
        {

        }
        public Context(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
   
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetails> orderdetails { get; set; }
        public DbSet<Cart> carts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-HO7F0A8\SQLEXPRESS;Initial Catalog=Onlineshops;Integrated Security=True");
        }


    }
}
