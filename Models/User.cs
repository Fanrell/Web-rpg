namespace RPG.Models;

public class User : BaseEntity
{
    public string Username { get; set;}
    public string PasswordHash { get; set;}
    public string EmailHash { get; set;}

}