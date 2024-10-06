using System.ComponentModel.DataAnnotations;

namespace Hackaton.Models
{
        public class Evaluation
    {
        public int Id { get; set; }
        
        [Required]
        public int ProjectId { get; set; }
        
        [Required]
        public int MentorId { get; set; }
        
        [Range(0, 100)]
        public int Score { get; set; }
        
        [Required, StringLength(500)]
        public string? Comments { get; set; }
        
        public virtual Project? Project { get; set; }
        public virtual Mentor? Mentor { get; set; }
    }

}