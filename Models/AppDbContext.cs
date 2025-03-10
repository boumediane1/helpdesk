using Microsoft.EntityFrameworkCore;

namespace helpdesk.Models;

public class AppDbContext : DbContext
{
    public DbSet<Project> Projects { get; set; }

    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.
        UseNpgsql("Host=localhost;Database=helpdesk;Username=othmane;Password=");
}
