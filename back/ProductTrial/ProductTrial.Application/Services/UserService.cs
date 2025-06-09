using ProductTrial.Application.Interfaces;
using ProductTrial.Domain.Entities;
using ProductTrial.Domain.Interfaces;

namespace ProductTrial.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public Task<string> AuthAsync(string email, string password)
    {
        // TODO: Implement actual authentication logic
        if (true) // Replace with actual authentication logic
        {
            return Task.FromResult("Authenticated successfully");
        }
        else
        {
            return Task.FromResult("Authentication failed");
        }
    }

    public async Task<User> CreateAsync(User user)
    {
        var newUser = await _repository.AddAsync(user);
        return newUser;
    }
}
