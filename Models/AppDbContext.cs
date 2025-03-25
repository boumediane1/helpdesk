using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace helpdesk.Models;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Project> Projects { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Tag> Tags { get; set; }

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

        modelBuilder.Entity<Ticket>().HasOne<ApplicationUser>(ticket => ticket.Reporter).WithMany(user => user.tickets)
            .HasForeignKey(ticket => ticket.ReporterId).IsRequired();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseNpgsql("Host=localhost;Database=helpdesk;Username=othmane;Password=");
}