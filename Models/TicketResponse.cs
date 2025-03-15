namespace helpdesk.Models;

public class TicketResponse
{
    public class TagResponse
    {
        public long Id { get; set; }
        public string Title { get; set; }

        public static TagResponse from(Tag tag)
        {
            return new TicketResponse.TagResponse
            {
                Id = tag.Id,
                Title = tag.Title
            };
        }
    }

    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string State { get; set; }
    public UserResponse? Assignee { get; set; }
    public List<TagResponse> Tags { get; set; }

    public static TicketResponse From(Ticket ticket)
    {
        return new TicketResponse
        {
            Id = ticket.Id,
            Title = ticket.Title,
            Description = ticket.Description,
            State = ticket.State.ToString(),
            Assignee = UserResponse.From(ticket.Reporter),
            Tags = [..ticket.Tags.Select(TicketResponse.TagResponse.from)]
        };
    }
}