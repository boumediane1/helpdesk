using System.Security.Claims;
using helpdesk.Models;
using Microsoft.AspNetCore.Cors;
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
                .Include(ticket => ticket.Assignee)
                .Include(ticket => ticket.Tags)
                .ToListAsync();

            return tickets.Select(TicketResponse.From);
        }).RequireAuthorization();

        app.MapPost("/tickets", async (ClaimsPrincipal principal, CreateTicketRequest request, AppDbContext db) =>
        {
            var assignee = await db.Users.Where(user => user.UserName == request.Assignee).FirstAsync();

            var username = principal.Identity?.Name;

            var project = await db.Projects.Where(project => project.Title == request.ProjectTitle).FirstAsync();

            var reporter = await db.Users.Where(user => user.UserName == username).FirstAsync();

            var tags = await db.Tags.Where(tag => request.Tags.Contains(tag.Title)).ToListAsync();

            var ticket = new Ticket
            {
                Title = request.Title,
                Description = request.Description,
                State = State.Open,
                Project = project,
                Reporter = reporter,
                Assignee = assignee,
                Tags = tags,
                Date = DateTime.UtcNow
            };

            db.Tickets.Add(ticket);
            await db.SaveChangesAsync();
        });


        app.MapGet("/tags", (AppDbContext db) => { return Task.FromResult(db.Tags.Select(tag => tag.Title)); });
    }
}