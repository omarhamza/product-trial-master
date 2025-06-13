using ProductTrial.Domain.Entities;

namespace ProductTrial.Domain.Interfaces;

public interface IUserRepository
{
    Task<User> GetByEmailAsync(string email, string password);
    Task<User> AddAsync(User user);
}
