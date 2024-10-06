namespace Hackaton.Models
{
    public class Team
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int MemberCount { get; set; }
        public required string DevelopmentExperience { get; set; }
        public required string DesignExperience { get; set; }
        public required string ProjectManagementExperience { get; set; }

        
        public int HackathonId { get; set; }
        public Hackathon Hackathon { get; set; }

        public ICollection<Participant> Participants { get; set; }
        public ICollection<MentorTeam> MentorTeams { get; set; }
        public Project Project { get; set; }
    }
}