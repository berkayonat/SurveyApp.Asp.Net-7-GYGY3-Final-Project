using SurveyApp.Application.Features.Question.Commands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.DTOs.Response
{
    public class SurveyDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public IList<QuestionDto>? Questions { get; set; }

    }
}
