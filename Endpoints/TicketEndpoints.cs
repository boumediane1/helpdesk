using System.Collections;
using System.Collections.Immutable;
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

            return tickets.Select(ticket =>
            {
                var ticketResponse = new TicketResponse
                {
                    Id = ticket.Id,
                    Title = ticket.Title,
                    Descriptions = ticket.Descriptions,
                    State = ticket.State,
                    Assignee = new UserResponse
                    {
                        Id = ticket.User.Id,
                        Name = ticket.User.Name,
                        Email = ticket.User.Email,
                        Role = ticket.User.Role
                    },
                    Tags = new List<TicketResponse.TagResponse>(ticket.Tags.Select(tag =>
                    {
                        var tagResponse = new TicketResponse.TagResponse
                        {
                            Id = tag.Id,
                            Title = tag.Title
                        };

                        return tagResponse;
                    }))
                };
                
                return ticketResponse;
            });
        });
    }
}