using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface ITeamRepository
    {
        IEnumerable<Team> GetTeams();
        void AddTeam(TeamDto teamDto);
        bool ModifyTeam(string teamName, string teamPrincipal);
        bool DeleteTeam(int id);
    }
}
