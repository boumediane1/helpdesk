namespace helpdesk.Models;

public class UserResponse
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }

    public static UserResponse? From(User? user)
    {
        return user == null
            ? null
            : new UserResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role.ToString()
            };
    }
}