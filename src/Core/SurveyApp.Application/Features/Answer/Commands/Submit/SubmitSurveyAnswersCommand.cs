using MediatR;
using SurveyApp.Application.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Features.Answer.Commands.Submit
{
    public class SubmitSurveyAnswersCommand : IRequest
    {
        public IList<AnswerDto>? Answers { get; set; }

        public SubmitSurveyAnswersCommand(IList<AnswerDto>? answers)
        {
            Answers = answers;
        }
    }
}
