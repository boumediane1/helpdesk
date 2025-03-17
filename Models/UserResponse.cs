namespace helpdesk.Models;

public class UserResponse
{
    public string Name { get; set; }
    public string? UserName { get; set; }

    public static UserResponse From(ApplicationUser user)
    {
        return new UserResponse
        {
            Name = user.Name,
            UserName = user.UserName
        };
    }
}