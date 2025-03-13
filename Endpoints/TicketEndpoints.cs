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

            return tickets.Select(TicketResponse.from);
        });
    }
}