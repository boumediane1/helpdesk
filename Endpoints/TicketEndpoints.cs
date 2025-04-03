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
                .Include(ticket => ticket.Project)
                .ToListAsync();

            return tickets.Select(TicketResponse.From);
        }).RequireAuthorization();

        app.MapPost("/tickets", async (ClaimsPrincipal principal, CreateTicketRequest request, AppDbContext db) =>
        {
            var username = principal.Identity?.Name;

            var reporter = await db.Users .Where(user => user.UserName == username) .FirstAsync();

            var assignee = await db.Users.Where(user => user.UserName == request.Assignee).FirstAsync();

            var project = await db.Projects .Where(project => project.Title == request.ProjectTitle) .FirstAsync();

            var tags = await db.Tags.Where(tag => request.Tags.Contains(tag.Title)).ToListAsync();

            var ticket = new Ticket
            {
                Title = request.Title,
                Description = request.Description,
                Reporter = reporter,
                Assignee = assignee,
                Project = project,
                State = State.Open,
                Tags = tags,
                Date = DateTime.UtcNow
            };

            db.Tickets.Add(ticket);
            await db.SaveChangesAsync();
        }).RequireAuthorization();


        app.MapGet("/tags", (AppDbContext db) => { return Task.FromResult(db.Tags.Select(tag => tag.Title)); });

        app.MapGet("/tickets/{title}", async (AppDbContext db, string title) =>
        {
            var ticket = await db.Tickets
                .Include(ticket => ticket.Reporter)
                .Include(ticket => ticket.Assignee)
                .Include(ticket => ticket.Tags)
                .Include(ticket => ticket.Project)
                .Where(ticket => ticket.Title == title)
                .FirstAsync();
            return TicketResponse.From(ticket);
        }).RequireAuthorization();

        app.MapPut("/tickets/{title}", async (string title, AppDbContext db, UpdateTicketRequest request) =>
        {
            var assignee = await db.Users.Where(user => user.UserName == request.Assignee).FirstAsync();
            var project = await db.Projects.Where(project => project.Title == request.ProjectTitle).FirstAsync();
            var tags = await db.Tags.Where(tag => request.Tags.Contains(tag.Title)).ToListAsync();

            var ticket = await db.Tickets.Include(ticket => ticket.Tags).Where(ticket => ticket.Title == title)
                .FirstAsync();

            ticket.Tags.RemoveAll(_ => true);

            ticket.Title = request.Title;
            ticket.Project = project;
            ticket.Assignee = assignee;
            ticket.Description = request.Description;
            ticket.Tags = tags;
            ticket.State = Enum.Parse<State>(request.State);

            db.Tickets.Update(ticket);
            await db.SaveChangesAsync();
        }).RequireAuthorization();
    }
}