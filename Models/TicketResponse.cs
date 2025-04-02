namespace helpdesk.Models;

public class TicketResponse
{
    public class TagResponse
    {
        public long Id { get; set; }
        public string Title { get; set; }

        public static TagResponse From(Tag tag)
        {
            return new TagResponse
            {
                Id = tag.Id,
                Title = tag.Title
            };
        }
    }

    public class AssigneeResponse
    {
        public string Name { get; set; }
        public string? Username { get; set; }

        public static AssigneeResponse? From(ApplicationUser? user)
        {
            return user == null
                ? null
                : new AssigneeResponse
                {
                    Name = user.Name,
                    Username = user.UserName
                };
        }
    }

    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string State { get; set; }
    public DateTime Date { get; set; }
    public AssigneeResponse? Assignee { get; set; }
    public UserResponse Reporter { get; set; }
    public string Project { get; set; }
    public List<TagResponse> Tags { get; set; }

    public static TicketResponse From(Ticket ticket)
    {
        return new TicketResponse
        {
            Id = ticket.Id,
            Title = ticket.Title,
            Description = ticket.Description,
            State = ticket.State.ToString(),
            Date = ticket.Date,
            Assignee = AssigneeResponse.From(ticket.Assignee),
            Reporter = UserResponse.From(ticket.Reporter),
            Project = ticket.Project.Title,
            Tags = [..ticket.Tags.Select(TagResponse.From)]
        };
    }
}