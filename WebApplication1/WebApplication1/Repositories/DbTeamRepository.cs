using Microsoft.EntityFrameworkCore;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Repositories;

public class DbTeamRepository : ITeamRepository
{
    private readonly AppDbContext _context;

    public DbTeamRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Team> GetTeams()
    {
        return _context.Teams
            .Include(t => t.Drivers)
            .ToList();
    }

    public void AddTeam(TeamRequest team)
    {
        var newTeam = new Team()
        {
            Base = team.Base,
            Chief = team.Chief,
            Name = team.Name,
        };
        _context.Teams.Add(newTeam);
        _context.SaveChanges();
    }

    public bool ModifyTeam(int id, string teamName, string teamPrincipal)
    {
        var found = _context.Teams.FirstOrDefault(t => t.Id == id);
        if (found is null)
        {
            return false;
        }

        found.Name = teamName;
        found.Chief = teamPrincipal;
        _context.SaveChanges();
        return true;
    }

    public bool DeleteTeam(int id)
    {
        var found = _context.Teams.FirstOrDefault(t => t.Id == id);
        if (found is null)
        {
            return false;
        }

        _context.Teams.Remove(found);
        _context.SaveChanges();
        return true;
    }
}
