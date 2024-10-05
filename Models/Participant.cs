namespace Hackaton.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Role { get; set; }
        public int TeamId { get; set; }
    }
}