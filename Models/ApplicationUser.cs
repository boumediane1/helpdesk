using Microsoft.AspNetCore.Identity;

namespace helpdesk.Models;

public class ApplicationUser : IdentityUser
{
    public string Name { get; set; } 
    public DateTime Date { get; set; }
    public List<Ticket> tickets { get; set; }
    public List<Project> Projects { get; set; }
}
