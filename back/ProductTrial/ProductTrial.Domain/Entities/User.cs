namespace ProductTrial.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Firstname { get; set; }
    public string Email { get; set; }

    // todo: should save password as a hash
    public string Password { get; set; }
}
