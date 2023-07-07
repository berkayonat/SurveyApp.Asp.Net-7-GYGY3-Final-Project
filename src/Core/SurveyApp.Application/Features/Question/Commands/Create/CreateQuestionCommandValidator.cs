using FluentValidation;
using SurveyApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Features.Question.Commands.Create
{
    public class CreateQuestionCommandValidator : AbstractValidator<CreateQuestionCommand>
    {
        public CreateQuestionCommandValidator() 
        {
            RuleFor(a => a.Text)
                .NotEmpty();
            RuleFor(a => a.Type)
                .IsInEnum();
            
            RuleFor(a => a.AnswerOptions)
                .NotEmpty()
                .When(a => a.Type == QuestionType.MultipleChoice)
                .WithMessage("AnswerOptions list must not be empty for questions with MultipleChoice type.");

            RuleFor(a => a.AnswerOptions)
                .Empty()
                .When(a => a.Type != QuestionType.MultipleChoice)
                .WithMessage("AnswerOptions list must be empty for questions with types other than MultipleChoice.");
        }
    }
}
