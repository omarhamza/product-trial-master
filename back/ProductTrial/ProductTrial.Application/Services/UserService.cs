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

    public async Task<string> AuthAsync(string email, string password)
    {
        var user = await _repository.GetByEmailAsync(email, password);
        if (user is not null)
        {
            return _jwtService.GenerateToken(email);
        }
        else
        {
            return "Authentication failed";
        }
    }

    public async Task<User> CreateAsync(User user)
    {
        var newUser = await _repository.AddAsync(user);
        return newUser;
    }
}
