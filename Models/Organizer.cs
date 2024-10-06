namespace Hackaton.Models
{
    public class Organizer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Hackathon> Hackathons { get; set; }
    }
}