using ProductTrial.Domain.Entities;

namespace ProductTrial.Application.Interfaces;

public interface IUserService
{
    Task<string> AuthAsync(string email, string password);
    Task<User> CreateAsync(User product);
}
