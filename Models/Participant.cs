using System.ComponentModel.DataAnnotations;

namespace Hackaton.Models
{
        public class Participant
    {
        public int Id { get; set; }
        
        [Required, StringLength(100)]
        public string? Name { get; set; }
        
        [Required, EmailAddress, StringLength(100)]
        public string? Email { get; set; }
        
        [Required, StringLength(50)]
        public string? Role { get; set; }
        
        [Required]
        public int? TeamId { get; set; }
        public virtual Team? Team { get; set; }
    }

}