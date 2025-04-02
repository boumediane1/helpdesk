namespace helpdesk.Models;

public class CreateTicketRequest
{
    public string Title { get; set; }
    public string ProjectTitle { get; set; }
    public string Description { get; set; }
    public string Assignee { get; set; }
    public List<string> Tags { get; set; }
}