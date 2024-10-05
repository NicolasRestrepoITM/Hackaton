namespace Hackaton.Models
{
    public class Mentor
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string ExpertiseArea { get; set; }
    }
}