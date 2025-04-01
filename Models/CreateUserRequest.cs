using Microsoft.AspNetCore.Identity;

namespace helpdesk.Models;

public class CreateUserRequest
{
    public string Name { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public static ApplicationUser From(CreateUserRequest request)
    {
        var user = new ApplicationUser
        {
            Name = request.Name,
            UserName = request.Username,
            NormalizedUserName = request.Username.ToUpper()
        };
        
        var passwordHasher = new PasswordHasher<ApplicationUser>();

        user.PasswordHash = passwordHasher.HashPassword(user, request.Password);
        
        return user;
    }
}