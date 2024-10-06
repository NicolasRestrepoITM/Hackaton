﻿// <auto-generated />
using System;
using Hackaton.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Hackaton.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20241006013518_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HackathonMentor", b =>
                {
                    b.Property<int>("HackathonsId")
                        .HasColumnType("integer");

                    b.Property<int>("MentorsId")
                        .HasColumnType("integer");

                    b.HasKey("HackathonsId", "MentorsId");

                    b.HasIndex("MentorsId");

                    b.ToTable("HackathonMentor");
                });

            modelBuilder.Entity("Hackaton.Models.Evaluation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("MentorId")
                        .HasColumnType("integer");

                    b.Property<int>("ProjectId")
                        .HasColumnType("integer");

                    b.Property<int>("Score")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MentorId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Evaluations");
                });

            modelBuilder.Entity("Hackaton.Models.Hackathon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("MainTheme")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OrganizerId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("OrganizerId");

                    b.ToTable("Hackathons");
                });

            modelBuilder.Entity("Hackaton.Models.Mentor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ExpertiseArea")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Mentors");
                });

            modelBuilder.Entity("Hackaton.Models.MentorTeam", b =>
                {
                    b.Property<int>("MentorId")
                        .HasColumnType("integer");

                    b.Property<int>("TeamId")
                        .HasColumnType("integer");

                    b.HasKey("MentorId", "TeamId");

                    b.HasIndex("TeamId");

                    b.ToTable("MentorTeams");
                });

            modelBuilder.Entity("Hackaton.Models.Organizer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Organizers");
                });

            modelBuilder.Entity("Hackaton.Models.Participant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TeamId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("Hackaton.Models.Prize", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("HackathonId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("HackathonId");

                    b.ToTable("Prizes");
                });

            modelBuilder.Entity("Hackaton.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DevelopmentStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TeamId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TeamId")
                        .IsUnique();

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Hackaton.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("DesignExperience")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DevelopmentExperience")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("HackathonId")
                        .HasColumnType("integer");

                    b.Property<int>("MemberCount")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProjectManagementExperience")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("HackathonId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("HackathonMentor", b =>
                {
                    b.HasOne("Hackaton.Models.Hackathon", null)
                        .WithMany()
                        .HasForeignKey("HackathonsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hackaton.Models.Mentor", null)
                        .WithMany()
                        .HasForeignKey("MentorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Hackaton.Models.Evaluation", b =>
                {
                    b.HasOne("Hackaton.Models.Mentor", "Mentor")
                        .WithMany("Evaluations")
                        .HasForeignKey("MentorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hackaton.Models.Project", "Project")
                        .WithMany("Evaluations")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mentor");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Hackaton.Models.Hackathon", b =>
                {
                    b.HasOne("Hackaton.Models.Organizer", "Organizer")
                        .WithMany("Hackathons")
                        .HasForeignKey("OrganizerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organizer");
                });

            modelBuilder.Entity("Hackaton.Models.MentorTeam", b =>
                {
                    b.HasOne("Hackaton.Models.Mentor", "Mentor")
                        .WithMany("MentorTeams")
                        .HasForeignKey("MentorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hackaton.Models.Team", "Team")
                        .WithMany("MentorTeams")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mentor");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Hackaton.Models.Participant", b =>
                {
                    b.HasOne("Hackaton.Models.Team", "Team")
                        .WithMany("Participants")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Hackaton.Models.Prize", b =>
                {
                    b.HasOne("Hackaton.Models.Hackathon", "Hackathon")
                        .WithMany("Prizes")
                        .HasForeignKey("HackathonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hackathon");
                });

            modelBuilder.Entity("Hackaton.Models.Project", b =>
                {
                    b.HasOne("Hackaton.Models.Team", "Team")
                        .WithOne("Project")
                        .HasForeignKey("Hackaton.Models.Project", "TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Hackaton.Models.Team", b =>
                {
                    b.HasOne("Hackaton.Models.Hackathon", "Hackathon")
                        .WithMany("Teams")
                        .HasForeignKey("HackathonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hackathon");
                });

            modelBuilder.Entity("Hackaton.Models.Hackathon", b =>
                {
                    b.Navigation("Prizes");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("Hackaton.Models.Mentor", b =>
                {
                    b.Navigation("Evaluations");

                    b.Navigation("MentorTeams");
                });

            modelBuilder.Entity("Hackaton.Models.Organizer", b =>
                {
                    b.Navigation("Hackathons");
                });

            modelBuilder.Entity("Hackaton.Models.Project", b =>
                {
                    b.Navigation("Evaluations");
                });

            modelBuilder.Entity("Hackaton.Models.Team", b =>
                {
                    b.Navigation("MentorTeams");

                    b.Navigation("Participants");

                    b.Navigation("Project")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}