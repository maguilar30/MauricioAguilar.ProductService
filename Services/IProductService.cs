using MauricioAguilar.Product.Service.Models;
using MauricioAguilar.Product.Service.DTOs;

namespace MauricioAguilar.Product.Service.Services
{
    public interface IProductService
    {
        Task<List<ProductModel>> GetProducts();

        Task<ProductModel?> GetByIdAsync(int id);

        Task<ProductModel> CreateProduct(CreateProductRequestDto request);
    }
}
