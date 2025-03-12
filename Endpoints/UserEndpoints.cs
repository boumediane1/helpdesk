using helpdesk.Models;
using Microsoft.EntityFrameworkCore;

namespace helpdesk.Endpoints;

public static class UserEndpoints
{
    public static void RegisterUserEndpoints(this WebApplication app)
    {
        app.MapGet("/users", async (AppDbContext db) =>
        {
             var users = await db.Users.ToListAsync();
             
             return users.Select(user => {
                 var userResponse = new UserResponse
                 {
                     Id = user.Id,
                     Name = user.Name,
                     Email = user.Email,
                     Role = user.Role
                 };
                 
                 return userResponse;
             });
        });
    }
}