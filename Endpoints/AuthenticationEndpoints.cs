using helpdesk.Models;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LoginRequest = helpdesk.Models.LoginRequest;
using RegisterRequest = helpdesk.Models.RegisterRequest;

namespace helpdesk.Endpoints;

public static class AuthenticationEndpoints
{
    public static void RegisterAuthenticationEndpoints(this WebApplication app)
    {
        app.MapPost("/register", async (RegisterRequest request, AppDbContext db) =>
        {
            
            var user = new ApplicationUser
            {
                UserName = request.UserName,
                NormalizedUserName = request.UserName.ToUpper(),
                Name = request.Name,
            };
            
            var passwordHasher = new PasswordHasher<ApplicationUser>();
            
            user.PasswordHash = passwordHasher.HashPassword(user, request.Password);

            db.Users.Add(user);
            await db.SaveChangesAsync();
        });
        
        app.MapPost("/login", async Task<Results<Ok<AccessTokenResponse>, EmptyHttpResult, ProblemHttpResult>>
            ([FromBody] LoginRequest login, [FromQuery] bool? useCookies, [FromQuery] bool? useSessionCookies, [FromServices] IServiceProvider sp) =>
        {
            var signInManager = sp.GetRequiredService<SignInManager<ApplicationUser>>();

            var useCookieScheme = (useCookies == true) || (useSessionCookies == true);
            var isPersistent = (useCookies == true) && (useSessionCookies != true);
            signInManager.AuthenticationScheme = useCookieScheme ? IdentityConstants.ApplicationScheme : IdentityConstants.BearerScheme;

            var result = await signInManager.PasswordSignInAsync(login.UserName, login.Password, isPersistent, lockoutOnFailure: true);

            if (!result.Succeeded)
            {
                return TypedResults.Problem(result.ToString(), statusCode: StatusCodes.Status401Unauthorized);
            }

            return TypedResults.Empty;
        });
    }
    
    
}