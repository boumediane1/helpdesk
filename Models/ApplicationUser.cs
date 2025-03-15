using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace helpdesk.Models;

public class ApplicationUser : IdentityUser
{
    public long Id { get; set; }
    public string Name { get; set; } 
}
