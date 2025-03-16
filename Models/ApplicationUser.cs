using Microsoft.AspNetCore.Identity;

namespace helpdesk.Models;

public class ApplicationUser : IdentityUser
{
    public string Name { get; set; } 
}
