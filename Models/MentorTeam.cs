namespace Hackaton.Models

{
    public class MentorTeam
    {
        public int MentorId { get; set; }
        public Mentor Mentor { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}