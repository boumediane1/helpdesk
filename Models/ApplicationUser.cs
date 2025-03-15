using System.ComponentModel.DataAnnotations.Schema;

namespace helpdesk.Models;

public class ApplicationUser
{
    public long Id { get; set; }
    public string Name { get; set; } 
    public string Email { get; set; } 
    public string Password { get; set; } 
    [Column(TypeName = "varchar(255)")]
    public Role Role { get; set; } 
}
