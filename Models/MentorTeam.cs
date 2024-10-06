using System.ComponentModel.DataAnnotations;

namespace Hackaton.Models

{
    public class MentorTeam
    {
        [Required]
        public int MentorId { get; set; }
        public virtual Mentor? Mentor { get; set; }

        [Required]
        public int TeamId { get; set; }
        public virtual Team? Team { get; set; }
        public int Id { get; internal set; }
    }
}