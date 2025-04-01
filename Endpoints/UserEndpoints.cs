using helpdesk.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace helpdesk.Endpoints;

public static class UserEndpoints
{
    public static void RegisterUserEndpoints(this WebApplication app)
    {
        app.MapGet("/users", [Authorize(Roles = nameof(Role.Admin))] async (AppDbContext db) =>
        {
            var users = await db.Users.ToListAsync();
            return users.Select(UserResponse.From).Where(user => user.Username != "admin")
                .OrderByDescending(user => user.Date);
        });

        app.MapPost("/users",
            [Authorize(Roles = nameof(Role.Admin))]
            async (AppDbContext db, CreateUserRequest request, UserManager<ApplicationUser> roleManager) =>
            {
                var user = CreateUserRequest.From(request);
                user.Date = DateTime.UtcNow;
                db.Users.Add(user);
                await db.SaveChangesAsync();
                await roleManager.AddToRoleAsync(user, nameof(Role.Member));
            });
    }
}