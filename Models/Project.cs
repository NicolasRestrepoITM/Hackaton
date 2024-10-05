namespace Hackaton.Models
{
 public class Project
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string DevelopmentStatus { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int TeamId { get; set; }
        public int HackathonId { get; set; }
    }   
}