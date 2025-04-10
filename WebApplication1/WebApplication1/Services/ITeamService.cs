using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface ITeamService
    {
        IEnumerable<Team> GetTeams();
        void AddTeam(Team team);
        bool ModifyTeam(string teamName, string teamPrincipal);
        bool DeleteTeam(int id);
    }
}
