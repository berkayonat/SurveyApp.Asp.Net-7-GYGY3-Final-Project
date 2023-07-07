using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Features.AnswerOption.Commands.Create
{
    public class CreateAnswerOptionCommandValidator : AbstractValidator<CreateAnswerOptionCommand>
    {
        public CreateAnswerOptionCommandValidator() 
        {
            RuleFor(a => a.Text)
                .NotEmpty();

        }
    }
}
