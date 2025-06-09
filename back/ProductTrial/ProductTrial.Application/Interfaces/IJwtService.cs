namespace ProductTrial.Application.Interfaces;

public interface IJwtService
{
    public string GenerateToken(string email);
}
