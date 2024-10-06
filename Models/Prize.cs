using System.ComponentModel.DataAnnotations;

namespace Hackaton.Models
{
    public class Prize
    {
        public int Id { get; set; }
        
        [Required, StringLength(100)]
        public string? Name { get; set; }
        
        [Required, StringLength(500)]
        public string? Description { get; set; }
        
        [Required]
        public int HackathonId { get; set; }
        public virtual Hackathon? Hackathon { get; set; }
    }

}