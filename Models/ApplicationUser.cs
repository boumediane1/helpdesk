using System.ComponentModel.DataAnnotations.Schema;

namespace helpdesk.Models;

public class ApplicationUser
{
    public long Id { get; set; }
    public string Name { get; set; } 
}
