using MauricioAguilar.Product.Service.Models;
using MauricioAguilar.Product.Service.Data;
using Microsoft.EntityFrameworkCore;

namespace MauricioAguilar.Product.Service.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductModel>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<ProductModel?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task AddAsync(ProductModel product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }
    }
}
