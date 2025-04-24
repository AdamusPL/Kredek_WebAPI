using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1;

public class DbSeeder
{
    private readonly AppDbContext _context;

    private readonly List<Team> _teams =
    [
        new Team("Red Bull Racing", "Milton Keynes, UK", "Christian Horner"),
        new Team("Mercedes AMG", "Brackley, UK", "Toto Wolff"),
        new Team("Ferrari", "Maranello, Italy", "Frédéric Vasseur"),
        new Team("McLaren", "Woking, UK", "Andrea Stella"),
        new Team("Aston Martin", "Silverstone, UK", "Mike Krack")
    ];

    private readonly List<Driver> _drivers =
    [
        new Driver { Name = "Max", Country = "Netherlands", Description = "test", TeamId = 2 },
        new Driver { Name = "Sergio", Country = "Mexico", Description = "test", TeamId = 2 },

        new Driver { Name = "Lewis", Country = "United Kingdom", Description = "test", TeamId = 3 },
        new Driver { Name = "George", Country = "United Kingdom", Description = "test", TeamId = 3 }
    ];

    public DbSeeder(AppDbContext context)
    {
        _context = context;
    }

    public void Seed()
    {
        if (!_context.Database.CanConnect())
        {
            Console.WriteLine("Could not connect to DB.");
            return;
        }

        var pendingMigrations = _context.Database.GetPendingMigrations();
        if (pendingMigrations.Any())
        {
            Console.WriteLine("Migrations need to be performed.");
            return;
        }

        if (!_context.Teams.Any())
        {
            _context.Teams.AddRange(_teams);
            _context.SaveChanges();
        }

        if (!_context.Drivers.Any())
        {
            _context.Drivers.AddRange(_drivers);
            _context.SaveChanges();
        }
    }
}