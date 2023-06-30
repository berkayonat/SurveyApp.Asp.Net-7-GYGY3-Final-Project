using SurveyApp.Application.Features.AnswerOption.Commands.Create;
using SurveyApp.Domain.Entities;
using SurveyApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Features.Question.Commands.Create
{
    public class CreateQuestionCommand
    {
        public string Text { get; set; }
        public QuestionType Type { get; set; }
        public int SurveyId { get; set; }
        public IList<CreateAnswerOptionCommand>? AnswerOptions { get; set; }
    }
}
