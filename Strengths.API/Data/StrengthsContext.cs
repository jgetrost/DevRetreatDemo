using System.Collections.Generic;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

using Strengths.Shared.Models;

namespace Strengths.API.Data {
    public class StrengthsContext : DbContext {
        public DbSet<Theme> Themes { get; set; }

        public DbSet<Domain> Domains { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=dev.jamesgetrost.net;Database=strengths;Username=USERNAMEREMOVED;Password=PASSWORDREMOVED");

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Domain>(entity =>
            {
                entity.ToTable("Domain");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired();
            });

            builder.Entity<Domain>().HasData(
                new { Id = 1, Title = "Strategic Thinking" }, 
                new { Id = 2, Title = "Executing" }, 
                new { Id = 3, Title = "Influencing" }, 
                new { Id = 4, Title = "Relationship Building" }
            );

            builder.Entity<Theme>(entity =>
            {
                entity.ToTable("Theme");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired();
                entity.HasOne(e => e.Domain);
            });

            builder.Entity<Theme>().HasData(
                new { Id = 1, Title = "Analytical", DomainId = 1 },
                new { Id = 2, Title = "Context", DomainId = 1 },
                new { Id = 3, Title = "Futuristic", DomainId = 1 },
                new { Id = 4, Title = "Ideation", DomainId = 1 },
                new { Id = 5, Title = "Input", DomainId = 1 },
                new { Id = 6, Title = "Intellection", DomainId = 1 },
                new { Id = 7, Title = "Learner", DomainId = 1 },
                new { Id = 8, Title = "Strategic", DomainId = 1 },
                new { Id = 9, Title = "Achiever", DomainId = 2 },
                new { Id = 10, Title = "Arranger", DomainId = 2 },
                new { Id = 11, Title = "Belief", DomainId = 2 },
                new { Id = 12, Title = "Consistency", DomainId = 2 },
                new { Id = 13, Title = "Deliberative", DomainId = 2 },
                new { Id = 14, Title = "Discipline", DomainId = 2 },
                new { Id = 15, Title = "Focus", DomainId = 2 },
                new { Id = 16, Title = "Responsibility", DomainId = 2 },
                new { Id = 17, Title = "Restorative", DomainId = 2 },
                new { Id = 18, Title = "Activator", DomainId = 3 },
                new { Id = 19, Title = "Command", DomainId = 3 },
                new { Id = 20, Title = "Communication", DomainId = 3 },
                new { Id = 21, Title = "Competition", DomainId = 3 },
                new { Id = 22, Title = "Maximizer", DomainId = 3 },
                new { Id = 23, Title = "Self-Assurance", DomainId = 3 },
                new { Id = 24, Title = "Significance", DomainId = 3 },
                new { Id = 25, Title = "Woo", DomainId = 3 },
                new { Id = 26, Title = "Adaptability", DomainId = 4 },
                new { Id = 27, Title = "Connectedness", DomainId = 4 },
                new { Id = 28, Title = "Developer", DomainId = 4 },
                new { Id = 29, Title = "Empathy", DomainId = 4 },
                new { Id = 30, Title = "Harmony", DomainId = 4 },
                new { Id = 31, Title = "Includer", DomainId = 4 },
                new { Id = 32, Title = "Individualization", DomainId = 4 },
                new { Id = 33, Title = "Positivity", DomainId = 4 },
                new { Id = 34, Title = "Relator", DomainId = 4 }
            );

            builder.Entity<User>(entity => {
                entity.ToTable("User");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.LastName).IsRequired();
                entity.HasOne(e => e.Theme1);
                entity.HasOne(e => e.Theme2);
                entity.HasOne(e => e.Theme3);
                entity.HasOne(e => e.Theme4);
                entity.HasOne(e => e.Theme5);
                entity.Ignore(e => e.FullName);
            });

            builder.Entity<User>().HasData(
                new { Id = 1, FirstName = "James", LastName = "Getrost", 
                        Theme1Id = 1, Theme2Id = 2, Theme3Id = 34, Theme4Id = 21, Theme5Id = 4 }
            );
        }
    }
}