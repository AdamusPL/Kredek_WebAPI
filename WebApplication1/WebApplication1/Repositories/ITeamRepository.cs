using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface ITeamRepository
    {
        IEnumerable<Team> GetTeams();
        void AddTeam(Team team);
        bool ModifyTeam(string teamName, string teamPrincipal);
        bool DeleteTeam(int id);
    }
}
