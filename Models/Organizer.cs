using System.ComponentModel.DataAnnotations;

namespace Hackaton.Models
{
    public class Organizer
    {
        public int Id { get; set; }
        
        [Required, StringLength(100)]
        public string? Name { get; set; }

        public virtual ICollection<Hackathon>? Hackathons { get; set; }
    }

}