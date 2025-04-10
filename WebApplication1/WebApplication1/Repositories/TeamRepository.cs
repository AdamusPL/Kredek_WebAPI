using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private static readonly ICollection<Team> TeamList = new List<Team>
        {
            new Team(1, "McLaren", "Woking, United Kingdom", "Zak Brown"),
            new Team(2, "Red Bull", "Milton Keynes, United Kingdom", "Christian Horner"),
            new Team(3, "Ferrari", "Maranello, Italy", "Frédéric Vasseur"),
            new Team(4, "Mercedes", "Brackley, United Kingdom", "Toto Wolff"),
            new Team(5, "Aston Martin", "Silverstone, United Kingdom", "Mike Krack")
        };

        public void AddTeam(Team team)
        {
            TeamList.Add(team);
        }

        public IEnumerable<Team> GetTeams()
        {
            return TeamList.ToArray();
        }

        public bool ModifyTeam(string teamName, string teamPrincipal)
        {
            Team team = TeamList.FirstOrDefault(t => t.Name.Equals(teamName, StringComparison.OrdinalIgnoreCase));
            if (team != null)
            {
                team.Chief = teamPrincipal;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteTeam(int id)
        {
            Team team = TeamList.FirstOrDefault(t => t.Id.Equals(id));

            if (team != null)
            {
                TeamList.Remove(team);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
