using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace helpdesk.Models;

public class Ticket
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    
    [Column(TypeName = "varchar(255)")]
    public State State { get; set; }
    
    public ApplicationUser? Assignee { get; set; }
    public ApplicationUser Reporter { get; set; }
    public string ReporterId { get; set; }
    public List<Tag> Tags { get; set; }
}
