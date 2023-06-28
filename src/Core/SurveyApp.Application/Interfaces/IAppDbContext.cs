using Microsoft.EntityFrameworkCore;
using SurveyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Answer> Answers { get; }
        DbSet<AnswerOption> AnswerOptions { get; }
        DbSet<Question> Questions { get; }
        DbSet<Survey> Surveys { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
