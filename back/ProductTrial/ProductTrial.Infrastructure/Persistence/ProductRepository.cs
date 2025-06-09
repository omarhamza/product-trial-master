using Microsoft.EntityFrameworkCore;
using ProductTrial.Domain.Entities;
using ProductTrial.Domain.Interfaces;
using ProductTrial.Infrastructure.Data;

namespace ProductTrial.Infrastructure.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Product> AddAsync(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products
                .AsNoTracking()
                .ToListAsync()
                .ContinueWith(task => task.Result.AsEnumerable());
        }
    }
}
