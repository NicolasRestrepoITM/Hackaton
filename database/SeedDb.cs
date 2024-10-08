using System;
using System.Linq;
using Hackaton.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Hackaton.Database
{
    public static class SeedDb
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DatabaseContext(
                serviceProvider.GetRequiredService<DbContextOptions<DatabaseContext>>()))
            {
                // Verifica si la base de datos ya tiene datos
                if (context.Hackathons.Any())
                {
                    return;   // La base de datos ya ha sido sembrada
                }

                // Organizador
                var organizer = new Organizer
                {
                    Name = "Tech Innovators"
                };
                context.Organizers.Add(organizer);
                context.SaveChanges();

                // Hackathon
                var hackathon = new Hackathon
                {
                    Name = "Innovación Tecnológica 2024",
                    StartDate = new DateTime(2024, 6, 1, 0, 0, 0, DateTimeKind.Utc),
                    EndDate = new DateTime(2024, 6, 3, 0, 0, 0, DateTimeKind.Utc),
                    MainTheme = "Inteligencia Artificial para el Bien Social",
                    OrganizerId = organizer.Id
                };
                context.Hackathons.Add(hackathon);
                context.SaveChanges();

                // Equipos
                var team1 = new Team
                {
                    Name = "CodeCrafters",
                    MemberCount = 4,
                    DevelopmentExperience = "Avanzado",
                    DesignExperience = "Intermedio",
                    ProjectManagementExperience = "Intermedio",
                    HackathonId = hackathon.Id
                };
                var team2 = new Team
                {
                    Name = "Innovation Wizards",
                    MemberCount = 3,
                    DevelopmentExperience = "Intermedio",
                    DesignExperience = "Avanzado",
                    ProjectManagementExperience = "Principiante",
                    HackathonId = hackathon.Id
                };
                context.Teams.AddRange(team1, team2);
                context.SaveChanges();

                // Participantes
                var participants = new[]
                {
                    new Participant { Name = "Ana García", Email = "ana@example.com", Role = "Desarrollador", TeamId = team1.Id },
                    new Participant { Name = "Carlos López", Email = "carlos@example.com", Role = "Diseñador", TeamId = team1.Id },
                    new Participant { Name = "Elena Martínez", Email = "elena@example.com", Role = "Líder", TeamId = team1.Id },
                    new Participant { Name = "David Rodríguez", Email = "david@example.com", Role = "Desarrollador", TeamId = team1.Id },
                    new Participant { Name = "Sofia Pérez", Email = "sofia@example.com", Role = "Diseñador", TeamId = team2.Id },
                    new Participant { Name = "Miguel Sánchez", Email = "miguel@example.com", Role = "Desarrollador", TeamId = team2.Id },
                    new Participant { Name = "Laura Torres", Email = "laura@example.com", Role = "Líder", TeamId = team2.Id }
                };
                context.Participants.AddRange(participants);
                context.SaveChanges();

                // Proyectos
                var projects = new[]
                {
                    new Project
                    {
                        Name = "AI for Good",
                        Description = "Una plataforma de IA para conectar voluntarios con causas sociales",
                        DevelopmentStatus = "En progreso",
                        DeliveryDate = new DateTime(2024, 6, 3, 0, 0, 0, DateTimeKind.Utc),
                        TeamId = team1.Id
                    },
                    new Project
                    {
                        Name = "EcoTech",
                        Description = "Aplicación para optimizar el consumo de energía en hogares",
                        DevelopmentStatus = "En progreso",
                        DeliveryDate = new DateTime(2024, 6, 3, 0, 0, 0, DateTimeKind.Utc),
                        TeamId = team2.Id
                    }
                };
                context.Projects.AddRange(projects);
                context.SaveChanges();

                // Mentores
                var mentors = new[]
                {
                    new Mentor
                    {
                        Name = "Dr. Laura Sánchez",
                        Email = "laura.sanchez@example.com",
                        ExpertiseArea = "Inteligencia Artificial y Aprendizaje Automático"
                    },
                    new Mentor
                    {
                        Name = "Ing. Roberto Gómez",
                        Email = "roberto.gomez@example.com",
                        ExpertiseArea = "Desarrollo Web y Móvil"
                    }
                };
                context.Mentors.AddRange(mentors);
                context.SaveChanges();

                // MentorTeams
                var mentorTeams = new[]
                {
                    new MentorTeam { MentorId = mentors[0].Id, TeamId = team1.Id },
                    new MentorTeam { MentorId = mentors[1].Id, TeamId = team2.Id }
                };
                context.MentorTeams.AddRange(mentorTeams);
                context.SaveChanges();

                // Evaluaciones
                var evaluations = new[]
                {
                    new Evaluation
                    {
                        ProjectId = projects[0].Id,
                        MentorId = mentors[0].Id,
                        Score = 85,
                        Comments = "Excelente concepto con un gran potencial de impacto social. Necesita mejorar en la implementación técnica."
                    },
                    new Evaluation
                    {
                        ProjectId = projects[1].Id,
                        MentorId = mentors[1].Id,
                        Score = 90,
                        Comments = "Idea innovadora y bien ejecutada. Considerar ampliar el alcance para incluir empresas."
                    }
                };
                context.Evaluations.AddRange(evaluations);
                context.SaveChanges();

                // Premios
                var prizes = new[]
                {
                    new Prize
                    {
                        Name = "Primer Lugar",
                        Description = "10,000€ en efectivo y 6 meses de mentoría",
                        HackathonId = hackathon.Id
                    },
                    new Prize
                    {
                        Name = "Segundo Lugar",
                        Description = "5,000€ en efectivo y 3 meses de mentoría",
                        HackathonId = hackathon.Id
                    },
                    new Prize
                    {
                        Name = "Tercer Lugar",
                        Description = "2,500€ en efectivo y 1 mes de mentoría",
                        HackathonId = hackathon.Id
                    }
                };
                context.Prizes.AddRange(prizes);
                context.SaveChanges();
            }
        }
    }
}