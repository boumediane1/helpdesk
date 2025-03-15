namespace helpdesk.Models;

public class CreateTicketRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public long AssigneeId { get; set; }
    public List<string> Tags { get; set; }
}