namespace helpdesk.Models;

public class TicketResponse
{
    public class TagResponse
    {
        public long Id { get; set; }
        public string Title { get; set; }
    }
    
    public long Id { get; set; }
    public string Title { get; set; }
    public string Descriptions { get; set; }
    public State State { get; set; }
    public UserResponse Assignee { get; set; }
    public List<TagResponse> Tags { get; set; }
}