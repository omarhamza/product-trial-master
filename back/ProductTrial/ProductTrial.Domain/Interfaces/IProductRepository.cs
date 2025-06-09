using ProductTrial.Domain.Entities;

namespace ProductTrial.Domain.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product> AddAsync(Product product);
}
