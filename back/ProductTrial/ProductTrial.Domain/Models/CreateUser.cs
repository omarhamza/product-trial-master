namespace ProductTrial.Domain.Models;

public record CreateUser(
    string FirstName,
    string LastName,
    string Email,
    string Password
);

