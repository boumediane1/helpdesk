namespace helpdesk.Models;

public class ReporterResponse
{
    public long Id { get; set; }
    public string Name { get; set; }

    public static AssigneeResponse From(ApplicationUser applicationUser)
    {
        return new AssigneeResponse
        {
            Id = applicationUser.Id,
            Name = applicationUser.Name,
        };
    }
}