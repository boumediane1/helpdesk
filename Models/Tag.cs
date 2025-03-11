namespace helpdesk.Models;

public class Tag
{
    public long Id { get; set; }
    public string Title { get; set; }
    public List<Ticket> Tickets { get; set; }
}
