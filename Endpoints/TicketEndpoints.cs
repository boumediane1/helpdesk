using helpdesk.Models;
using Microsoft.EntityFrameworkCore;

namespace helpdesk.Endpoints;

public static class TicketEndpoints
{
    public static void RegisterTicketEndpoints(this WebApplication app)
    {
        app.MapGet("/tickets", async (AppDbContext db) =>
        {
            var tickets = await db.Tickets
                .Include(ticket => ticket.User)
                .Include(ticket => ticket.Tags).ToListAsync();

            return tickets.Select(ticket => new TicketResponse
                {
                    Id = ticket.Id,
                    Title = ticket.Title,
                    Descriptions = ticket.Descriptions,
                    State = ticket.State.ToString(),
                    Assignee = UserResponse.from(ticket.User),
                    Tags = [..ticket.Tags.Select(TicketResponse.TagResponse.from)]
                }
            );
        });
    }
}