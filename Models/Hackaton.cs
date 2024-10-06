using System.ComponentModel.DataAnnotations;

namespace Hackaton.Models
{
    public class Hackathon
    {
        public int Id { get; set; }
        
        [Required, StringLength(100)]
        public string? Name { get; set; }
        
        [Required]
        public DateTime StartDate { get; set; }
        
        [Required]
        public DateTime EndDate { get; set; }
        
        [Required, StringLength(200)]
        public string? MainTheme { get; set; }
        
        [Required]
        public int OrganizerId { get; set; }
        public virtual Organizer? Organizer { get; set; }

        public virtual ICollection<Team>? Teams { get; set; }
        public virtual ICollection<Mentor>? Mentors { get; set; }
        public virtual ICollection<Prize>? Prizes { get; set; }
    }

}