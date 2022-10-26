using DomainLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer.Data
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser> 
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) {
     
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Category> Category
        {
            get;
            set;
        }
        public DbSet<Product> Products
        {
            get;
            set;
        }

    }
}
