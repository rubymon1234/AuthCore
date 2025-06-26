using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShoppyWeb.Models;
using System.Drawing.Drawing2D;

namespace ShoppyWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }

        public DbSet<ProductCatagory> ProductCatagory { get; set; }

        public DbSet<CartDetails> CartDetails { get; set; }
    }
}
