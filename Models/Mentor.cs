using System.ComponentModel.DataAnnotations;

namespace Hackaton.Models
{
      public class Mentor
    {
        public int Id { get; set; }
        
        [Required, StringLength(100)]
        public string? Name { get; set; }
        
        [Required, EmailAddress, StringLength(100)]
        public string? Email { get; set; }
        
        [Required, StringLength(100)]
        public string? ExpertiseArea { get; set; }

        public virtual ICollection<Hackathon>? Hackathons { get; set; }
        public virtual ICollection<MentorTeam>? MentorTeams { get; set; }
        public virtual ICollection<Evaluation>? Evaluations { get; set; }
    }

}