using SurveyApp.Application.Features.AnswerOption.Commands.Create;
using SurveyApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.DTOs.Response
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public QuestionType Type { get; set; }
        public int SurveyId { get; set; }
        public IList<AnswerOptionDto>? AnswerOptions { get; set; }
    }
}
