namespace helpdesk.Models;

public class ReporterResponse
{
    public string Name { get; set; }

    public static AssigneeResponse From(ApplicationUser applicationUser)
    {
        return new AssigneeResponse
        {
            Name = applicationUser.Name,
        };
    }
}