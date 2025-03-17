using helpdesk.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace helpdesk.Endpoints;

public static class UserEndpoints
{
    public static void RegisterUserEndpoints(this WebApplication app)
    {
        app.MapGet("/users", [Authorize(Roles = "Admin")] async (AppDbContext db) =>
        {
            var users = await db.Users.ToListAsync();
            return users.Select(UserResponse.From);
        });
    }
}