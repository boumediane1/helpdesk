namespace helpdesk.Models;

public class UpdateTicketRequest
{
    public string Title { get; set; }
    public string ProjectTitle { get; set; }
    public string Description { get; set; }
    public string Assignee { get; set; }
    public List<string> Tags { get; set; }
    public string State { get; set; }
}