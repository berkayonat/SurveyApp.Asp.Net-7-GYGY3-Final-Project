using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SurveyApp.Application.Interfaces;
using SurveyApp.Domain.Entities;
using SurveyApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Persistence.Data
{
    public class AppDbContext : IdentityDbContext<AppUser,AppRole,string>, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<AnswerOption> AnswerOptions { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Survey> Surveys {  get; set; }



        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedAt = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedAt = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Answer>()
                .Property(a => a.Rating)
                .HasMaxLength(10);

            modelBuilder.Entity<Answer>()
                .HasOne<Question>(a => a.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(a => a.QuestionId);

            modelBuilder.Entity<Answer>()
                .HasOne<AnswerOption>(a => a.AnswerOption)
                .WithMany(a => a.Answers)
                .HasForeignKey(a => a.AnswerOptionId);


            modelBuilder.Entity<AnswerOption>()
                .Property(a => a.Text)
                .IsRequired();

            modelBuilder.Entity<AnswerOption>()
                .HasOne<Question>(a=>a.Question)
                .WithMany(q=>q.AnswerOptions)
                .HasForeignKey(a=>a.QuestionId);


            modelBuilder.Entity<Question>()
                .HasOne<Survey>(q => q.Survey)
                .WithMany(s => s.Questions)
                .HasForeignKey(q => q.SurveyId);

            modelBuilder.Entity<Question>()
                .Property(q => q.Text)
                .IsRequired();
            modelBuilder.Entity<Question>()
                .Property(q => q.Type)
                .IsRequired();


            modelBuilder.Entity<Survey>()
                .Property(s=>s.Title)
                .HasMaxLength(150);

            modelBuilder.Entity<Survey>()
                .HasIndex(q => q.Token)
                .IsUnique();
        }
    }
}
