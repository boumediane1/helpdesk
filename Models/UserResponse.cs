namespace helpdesk.Models;

public class UserResponse
{
    public string Name { get; set; }
    public string? Username { get; set; }
    public DateTime Date { get; set; }
    public string Role { get; set; }

    public static UserResponse From(ApplicationUser user)
    {
        return new UserResponse
        {
            Name = user.Name,
            Username = user.UserName,
            Date = user.Date,
        };
    }

    public static List<UserResponse> From(List<ApplicationUser> users)
    {
        return users.Select(From).ToList();
    }
}