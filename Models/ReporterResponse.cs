namespace helpdesk.Models;

public class ReporterResponse
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }

    public static AssigneeResponse From(ApplicationUser applicationUser)
    {
        return new AssigneeResponse
        {
            Id = applicationUser.Id,
            Name = applicationUser.Name,
            Email = applicationUser.Email,
            Role = applicationUser.Role.ToString()
        };
    }
}