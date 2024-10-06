namespace Hackaton.Models
{
    public class Prize
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public required string Description { get; set; }

        public int HackathonId { get; set; }
        public Hackathon Hackathon { get; set; }
    }
}