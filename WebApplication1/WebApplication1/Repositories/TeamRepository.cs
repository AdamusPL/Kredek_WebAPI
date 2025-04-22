using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly AppDbContext _context;
        public TeamRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddTeam(TeamDto teamDto)
        {
            Team team = new Team(teamDto.Name, teamDto.Base, teamDto.Chief);
            _context.Teams.Add(team);
            _context.SaveChanges();
        }

        public IEnumerable<Team> GetTeams()
        {
            return _context.Teams.ToList();
        }

        public bool ModifyTeam(string teamName, string teamPrincipal)
        {
            Team team = _context.Teams.FirstOrDefault(t => t.Name.Equals(teamName));
            if (team != null)
            {
                team.Chief = teamPrincipal;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteTeam(int id)
        {
            Team team = _context.Teams.FirstOrDefault(t => t.Id.Equals(id));

            if (team != null)
            {
                _context.Teams.Remove(team);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
