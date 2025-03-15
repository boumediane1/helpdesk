using System.Security.Claims;
using helpdesk.Models;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.EntityFrameworkCore;

namespace helpdesk.Endpoints;

public static class TicketEndpoints
{
    public static void RegisterTicketEndpoints(this WebApplication app)
    {
        app.MapGet("/tickets", async (AppDbContext db) =>
        {
            var tickets = await db.Tickets
                .Include(ticket => ticket.Reporter)
                .Include(ticket => ticket.Tags).ToListAsync();

            return tickets.Select(TicketResponse.From);
        }).RequireAuthorization();

        app.MapPost("/tickets", async (CreateTicketRequest request, AppDbContext db) =>
        {
            var user = await db.Users.FindAsync(request.UserId);

            var tags = await db.Tags.Where(tag => request.Tags.Contains(tag.Title)).ToListAsync();

            var ticket = new Ticket
            {
                Title = request.Title,
                Description = request.Description,
                State = State.Open,
                Reporter = user,
                Tags = tags
            };

            db.Tickets.Add(ticket);
            await db.SaveChangesAsync();
        });
    }
}