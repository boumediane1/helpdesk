using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace helpdesk.Models;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Project> Projects { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Tag> Tags { get; set; }

    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    
        modelBuilder.Entity<Ticket>()
            .HasMany(x => x.Tags)
            .WithMany(x => x.Tickets)
            .UsingEntity<Dictionary<string, object>>("TagTicket",
                x => x.HasOne<Tag>().WithMany().HasForeignKey("TagId"),
                x => x.HasOne<Ticket>().WithMany().HasForeignKey("TicketId"),
                x => x.ToTable("TagTicket", "public"));
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseNpgsql("Host=localhost;Database=helpdesk;Username=othmane;Password=");
}