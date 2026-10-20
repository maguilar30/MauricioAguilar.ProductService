using MauricioAguilar.Product.Service.Models;

namespace MauricioAguilar.Product.Service.Repositories
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> GetAllAsync();

        Task<ProductModel?> GetByIdAsync(int id);

        Task AddAsync(ProductModel order);
    }
}
