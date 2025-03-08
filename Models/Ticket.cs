namespace helpdesk.Models;

public class Ticket
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Descriptions { get; set; }
    public State State { get; set; }
    public User User { get; set; }
    public List<Tag> Tags { get; set; }
}
