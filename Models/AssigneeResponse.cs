namespace helpdesk.Models;

public class AssigneeResponse
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }

    public static AssigneeResponse? From(User? user)
    {
        return user == null
            ? null
            : new AssigneeResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role.ToString()
            };
    }
}