using Microsoft.EntityFrameworkCore;
using ProductTrial.Domain.Entities;
using ProductTrial.Domain.Interfaces;
using ProductTrial.Infrastructure.Data;

namespace ProductTrial.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
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

        public async Task<User> AddAsync(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetByEmailAsync(string email, string password)
        {
            return await _context
                            .Users
                            .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }
    }
}
