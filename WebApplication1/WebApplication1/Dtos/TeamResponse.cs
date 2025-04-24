using WebApplication1.Models;

namespace WebApplication1.Dtos;

public class TeamResponse
{
    public string Name { get; set; }
    public string Base { get; set; }
    public string Chief { get; set; }
    public List<DriverResponse> Drivers { get; set; }

    public TeamResponse(Team team)
    {
        Name = team.Name;
        Base = team.Base;
        Chief = team.Chief;
        Drivers = team.Drivers.Select(d => new DriverResponse()
        {
            Name = d.Name,
            Country = d.Country,
            Description = d.Description,
        }).ToList();
    }
}
