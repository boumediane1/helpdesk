namespace helpdesk.Models;

public class CreateTicketRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public long UserId { get; set; }
    public List<string> Tags { get; set; }
}