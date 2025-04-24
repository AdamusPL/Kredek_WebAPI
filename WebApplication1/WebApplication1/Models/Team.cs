namespace WebApplication1.Models
{
    public class Team
    {
        public Team()
        {

        }

        public Team(string name, string baseX, string chief)
        {
            this.Name = name;
            this.Base = baseX;
            this.Chief = chief;
        }

        public Team(int id, string name, string baseX, string chief)
        {
            this.Id = id;
            this.Name = name;
            this.Base = baseX;
            this.Chief = chief;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Base { get; set; }
        public string Chief { get; set; }

        public List<Driver> Drivers { get; set; } = [];
    }
}
