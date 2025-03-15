namespace helpdesk.Models;

public class AssigneeResponse
{
    public long Id { get; set; }
    public string Name { get; set; }

    public static AssigneeResponse? From(ApplicationUser? user)
    {
        return user == null
            ? null
            : new AssigneeResponse
            {
                Id = user.Id
            };
    }
}