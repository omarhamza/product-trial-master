using ProductTrial.Domain.Entities;

namespace ProductTrial.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product> CreateAsync(Product product);
}
