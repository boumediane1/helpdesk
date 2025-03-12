using helpdesk.Endpoints;
using helpdesk.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(
    builder.Configuration.GetConnectionString("HelpDeskContext"),
    o => o.SetPostgresVersion(16, 4)
));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.RegisterProjectEndpoints();
app.RegisterTicketEndpoints();
app.RegisterUserEndpoints();

app.Run();