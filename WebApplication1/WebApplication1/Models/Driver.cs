namespace WebApplication1.Models;

public class Driver
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Country { get; set; }

    public int TeamId { get; set; }
    public Team Team { get; set; } = null!;
}
