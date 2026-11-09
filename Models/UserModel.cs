namespace HelpDesk.Models;

public enum Roles
{
    Admin = 0,
    Tecnico = 1,
    Usuario = 2
}

public class UserModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public Roles Role { get; set; }
    public DateTime CreatedAt { get; set; }
}