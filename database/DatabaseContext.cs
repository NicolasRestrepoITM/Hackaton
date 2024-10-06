using Hackaton.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackaton.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public DbSet<Hackathon> Hackathons { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Prize> Prizes { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<MentorTeam> MentorTeams { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MentorTeam>()
                .HasKey(mt => new { mt.MentorId, mt.TeamId });

            modelBuilder.Entity<MentorTeam>()
                .HasOne(mt => mt.Mentor)
                .WithMany(m => m.MentorTeams)
                .HasForeignKey(mt => mt.MentorId);

            modelBuilder.Entity<MentorTeam>()
                .HasOne(mt => mt.Team)
                .WithMany(t => t.MentorTeams)
                .HasForeignKey(mt => mt.TeamId);
        }

    }

}