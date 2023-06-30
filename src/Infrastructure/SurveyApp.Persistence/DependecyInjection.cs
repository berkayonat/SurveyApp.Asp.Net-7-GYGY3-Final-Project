using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SurveyApp.Application.Interfaces;
using SurveyApp.Persistence.Data;
using SurveyApp.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Persistence
{
    public static class DependecyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>());
            services.AddScoped<ISurveyRepository, EFSurveyRepository>();
            services.AddScoped<IQuestionRepository, EFQuestionRepository>();
            services.AddScoped<IAnswerOptionRepository, EFAnswerOptionRepository>();
            services.AddScoped<IAnswerRepository, EFAnswerRepository>();
        }
    }
}
