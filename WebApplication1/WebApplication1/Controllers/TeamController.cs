using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/f1/v1")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet("GetTeams")]
        public IEnumerable<TeamResponse> GetTeam()
        {
            return _teamService.GetTeams();
        }

        [HttpPost("AddTeam")]
        public void AddTeam([FromBody] TeamRequest team)
        {
            _teamService.AddTeam(team);
            Ok();
        }

        [HttpPut("ChangeTeamPrincipal/{id}")]
        public IActionResult ChangeTeamPrincipal([FromRoute] int id, [FromQuery] string teamName, [FromQuery] string teamPrincipal)
        {
            bool managed = _teamService.ModifyTeam(id, teamName, teamPrincipal);
            if (managed)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteTeam")]
        public IActionResult DeleteTeam([FromHeader] int id)
        {
            bool managed = _teamService.DeleteTeam(id);
            if (managed)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
