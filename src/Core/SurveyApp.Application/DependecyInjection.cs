using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using SurveyApp.Application.Features.Question.Commands.Create;
using SurveyApp.Application.Features.Survey.Commands.Create;
using SurveyApp.Application.Helpers;
using SurveyApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application
{
    public static class DependecyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<IUrlGenerator, DefaultUrlGenerator>();
            services.AddValidatorsFromAssemblyContaining<CreateSurveyCommandValidator>();
            
        }
    }
}
