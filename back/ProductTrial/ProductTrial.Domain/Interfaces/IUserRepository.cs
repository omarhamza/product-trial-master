using ProductTrial.Domain.Entities;

namespace ProductTrial.Domain.Interfaces;

public interface IUserRepository
{
    Task<string> AuthAsync(string email, string password);
    Task<User> AddAsync(User user);
}
