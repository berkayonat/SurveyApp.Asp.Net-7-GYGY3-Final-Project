using MediatR;
using SurveyApp.Application.Features.Question.Commands.Create;
using SurveyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SurveyApp.Application.Features.Survey.Commands.Create
{
    public class CreateSurveyCommand : IRequest<string>
    {
        public string Title { get; set; }
        public string? Description { get; set; }

        [JsonIgnore]
        public string? AppUserId { get; set; }

        public IList<CreateQuestionCommand>? Questions { get; set; }
    }
}
