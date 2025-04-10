using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public void AddTeam(Team team)
        {
            _teamRepository.AddTeam(team);
        }

        public bool DeleteTeam(int id)
        {
            return _teamRepository.DeleteTeam(id);
        }

        public IEnumerable<Team> GetTeams()
        {
            return _teamRepository.GetTeams();
        }

        public bool ModifyTeam(string teamName, string teamPrincipal)
        {
            return _teamRepository.ModifyTeam(teamName, teamPrincipal);
        }
    }
}
