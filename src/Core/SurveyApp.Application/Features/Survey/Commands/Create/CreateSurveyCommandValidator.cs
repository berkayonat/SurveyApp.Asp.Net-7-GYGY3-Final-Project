using FluentValidation;
using SurveyApp.Application.Features.Question.Commands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Features.Survey.Commands.Create
{
    public class CreateSurveyCommandValidator : AbstractValidator<CreateSurveyCommand>
    {
        public CreateSurveyCommandValidator() 
        {
            RuleFor(a => a.Title)
                .NotEmpty()
                .MaximumLength(150)
                .MinimumLength(5);

            RuleFor(a => a.Questions)
                .NotEmpty();

            RuleForEach(a => a.Questions)
            .SetValidator(new CreateQuestionCommandValidator());
        }
    }
    
}
