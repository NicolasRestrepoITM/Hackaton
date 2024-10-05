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
    }
}