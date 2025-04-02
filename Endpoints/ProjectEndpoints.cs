using helpdesk.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace helpdesk.Endpoints;

public static class ProjectEndpoints
{
    public static void RegisterProjectEndpoints(this WebApplication app)
    {
        app.MapPost("/projects", async (CreateProjectRequest request, AppDbContext db) =>
        {
            var users = await db.Users
                .Where(user => request.Usernames.Contains(user.UserName))
                .ToListAsync();

            var project = new Project
            {
                Title = request.Title,
                Users = users
            };

            db.Add(project);

            await db.SaveChangesAsync();
        });

        app.MapGet("/projects", [Authorize(Roles = nameof(Role.Admin))] async (AppDbContext db) =>
        {
            var projects = await db.Projects
                .Include(project => project.Users)
                .ToListAsync();

            return projects.Select(ProjectResponse.From);
        }).RequireAuthorization();

        app.MapGet("/projects/{title}", [Authorize(Roles = nameof(Role.Admin))] async (string title, AppDbContext db) =>
            {
                var project = await db.Projects.Include(project => project.Users)
                    .Where(project => project.Title == title).FirstAsync();
                return ProjectResponse.From(project);
            })
            .RequireAuthorization();
    }
}