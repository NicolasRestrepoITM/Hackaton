namespace Hackaton.Models
{
    public class Hackathon
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public required string MainTheme { get; set; }
        public required string Organizer { get; set; }
    }
}