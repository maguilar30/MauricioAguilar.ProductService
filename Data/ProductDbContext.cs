using Microsoft.EntityFrameworkCore;
using MauricioAguilar.Product.Service.Models;


namespace MauricioAguilar.Product.Service.Data
{
    public class ProductDbContext(DbContextOptions<ProductDbContext> options) : DbContext(options)
    {
        public DbSet<ProductModel> Products => Set<ProductModel>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("prd");
        }
    }
}
