using ProductTrial.Application.Interfaces;
using ProductTrial.Domain.Entities;
using ProductTrial.Domain.Interfaces;

namespace ProductTrial.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Product> CreateAsync(Product product)
    {
        var newProduct = await _repository.AddAsync(product);
        return newProduct;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }
}
