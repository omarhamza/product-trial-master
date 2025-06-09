using ProductTrial.Application.Interfaces;
using ProductTrial.Domain.Entities;
using ProductTrial.Domain.Interfaces;

namespace ProductTrial.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IJwtService _jwtService;

    public UserService(IUserRepository repository, IJwtService jwtService)
    {
        _repository = repository;
        _jwtService = jwtService;
    }

    public Task<string> AuthAsync(string email, string password)
    {
        var user = _repository.AuthAsync(email, password);
        if (user is not null)
        {
            return Task.FromResult(_jwtService.GenerateToken(email));
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
