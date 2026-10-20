using MauricioAguilar.Product.Service.Models;
using MauricioAguilar.Product.Service.DTOs;
using MauricioAguilar.Product.Service.Repositories;

namespace MauricioAguilar.Product.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductModel?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<ProductModel>> GetProducts()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ProductModel> CreateProduct(CreateProductRequestDto request)
        {
            var product = new ProductModel
            {
                Sku = request.Sku,
                Name = request.Name,
                Description = request.Description,
                Category = request.Category,
                Brand = request.Brand,
                QuantityOnHand = 1,
                ReorderLevel = 1,
                UnitCost = 1,
                UnitPrice = 1,
                RowVersion = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(product);

            return product;
        }
    }
}
