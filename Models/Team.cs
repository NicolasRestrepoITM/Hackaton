using System.ComponentModel.DataAnnotations;
namespace Hackaton.Models
{
    public class Team
    {
        public int Id { get; set; }
        
        [Required, StringLength(50)]
        public string? Name { get; set; }
        
        [Range(1, 10)]
        public int MemberCount { get; set; }
        
        [Required, StringLength(50)]
        public string? DevelopmentExperience { get; set; }
        
        [Required, StringLength(50)]
        public string? DesignExperience { get; set; }
        
        [Required, StringLength(50)]
        public string? ProjectManagementExperience { get; set; }

        [Required]
        public int HackathonId { get; set; }
        public virtual Hackathon? Hackathon { get; set; }

        public virtual ICollection<Participant>? Participants { get; set; }
        public virtual ICollection<MentorTeam>? MentorTeams { get; set; }
        public virtual Project? Project { get; set; }
    }
}