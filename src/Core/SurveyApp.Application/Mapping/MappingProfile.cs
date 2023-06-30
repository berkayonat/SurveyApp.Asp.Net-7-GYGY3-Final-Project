using AutoMapper;
using SurveyApp.Application.Features.AnswerOption.Commands.Create;
using SurveyApp.Application.Features.Question.Commands.Create;
using SurveyApp.Application.Features.Survey.Commands.Create;
using SurveyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateSurveyCommand, Survey>().ReverseMap();
            CreateMap<CreateQuestionCommand, Question>().ReverseMap();
            CreateMap<CreateAnswerOptionCommand, AnswerOption>().ReverseMap();
        }
    }
}
