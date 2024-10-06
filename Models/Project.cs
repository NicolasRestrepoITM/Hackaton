using System.ComponentModel.DataAnnotations;

namespace Hackaton.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string? Name { get; set; }

        [Required, StringLength(500)]
        public string? Description { get; set; }

        [Required, StringLength(50)]
        public string? DevelopmentStatus { get; set; }

        [Required]
        public DateTime DeliveryDate { get; set; }

        [Required]
        public int TeamId { get; set; }
        public virtual Team? Team { get; set; }

        public virtual ICollection<Evaluation>? Evaluations { get; set; }
    }

}