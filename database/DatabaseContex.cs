using Hackaton.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackaton.Database
{
    public class DatabaseContex : DbContext
    {
        public DatabaseContex(DbContextOptions<DatabaseContex> options) : base(options)
        {
        }
        public DbSet<Hackathon> Hackathons { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Prize> Prizes { get; set; }


    }

}