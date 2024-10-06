namespace Hackaton.Models
{
    public class Hackathon
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public required string MainTheme { get; set; }

        public int OrganizerId { get; set; }
        public Organizer Organizer { get; set; }

        public ICollection<Team> Teams { get; set; }
        public ICollection<Mentor> Mentors { get; set; }
        public ICollection<Prize> Prizes { get; set; }
    }

}