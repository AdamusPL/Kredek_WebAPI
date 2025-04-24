using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1;

public class AppDbContext : DbContext
{
    public DbSet<Team> Teams { get; set; }
    public DbSet<Driver> Drivers { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Team>()
            .HasKey(t => t.Id);
        modelBuilder.Entity<Team>()
            .Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(64);
        modelBuilder.Entity<Team>()
            .Property(t => t.Base)
            .IsRequired()
            .HasMaxLength(64);
        modelBuilder.Entity<Team>()
            .Property(t => t.Chief)
            .IsRequired()
            .HasMaxLength(64);
        modelBuilder.Entity<Team>()
            .HasMany(t => t.Drivers)
            .WithOne(d => d.Team)
            .HasForeignKey(d => d.TeamId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Driver>()
            .HasKey(d => d.Id);
        modelBuilder.Entity<Driver>()
            .HasOne(d => d.Team)
            .WithMany(t => t.Drivers)
            .HasForeignKey(d => d.TeamId);

        base.OnModelCreating(modelBuilder);
    }
}
