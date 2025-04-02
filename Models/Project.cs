namespace helpdesk.Models;

public class Project
{
    public long Id { get; set; }
    public string Title { get; set; }
    public List<ApplicationUser> Users { get; set; }
}
