namespace helpdesk.Models;

public class UserResponse
{
    public string Name { get; set; }
    public string? Username { get; set; }

    public static UserResponse From(ApplicationUser user)
    {
        return new UserResponse
        {
            Name = user.Name,
            Username = user.UserName,
        };
    }
}