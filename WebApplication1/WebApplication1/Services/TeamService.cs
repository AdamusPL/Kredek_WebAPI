using WebApplication1.Dtos;
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

        public void AddTeam(TeamRequest team)
        {
            _teamRepository.AddTeam(team);
        }

        public bool DeleteTeam(int id)
        {
            return _teamRepository.DeleteTeam(id);
        }

        public IEnumerable<TeamResponse> GetTeams()
        {
            return _teamRepository.GetTeams()
                .Select(t => new TeamResponse(t));
        }

        public bool ModifyTeam(int id, string teamName, string teamPrincipal)
        {
            return _teamRepository.ModifyTeam(id, teamName, teamPrincipal);
        }
    }
}
