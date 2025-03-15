using helpdesk.Models;
using Microsoft.EntityFrameworkCore;

namespace helpdesk.Endpoints;

public static class UserEndpoints
{
    public static void RegisterUserEndpoints(this WebApplication app)
    {
        app.MapGet("/users", async (ApplicationDbContext db) =>
        {
             var users = await db.Users.ToListAsync();
             return users.Select(AssigneeResponse.From);
        }).RequireAuthorization();
    }
}