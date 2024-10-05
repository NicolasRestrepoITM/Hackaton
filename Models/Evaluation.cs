namespace Hackaton.Models
{
        public class Evaluation
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int MentorId { get; set; }
        public int Score { get; set; }
        public required string Comments { get; set; }
    }
}