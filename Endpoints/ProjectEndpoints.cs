using helpdesk.Models;
using Microsoft.EntityFrameworkCore;

namespace helpdesk.Endpoints;

public static class ProjectEndpoints
{
    public static void RegisterProjectEndpoints(this WebApplication app)
    {
        app.MapPost("/projects", async (Project p, AppDbContext db) =>
        {
            var project = new Project();
            project.Title = p.Title;
            await db.SaveChangesAsync();
        });

        app.MapGet("/projects", async (AppDbContext db) => await db.Projects.ToListAsync());
    }
}