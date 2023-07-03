using AutoMapper;
using MediatR;
using SurveyApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Features.Answer.Commands.Submit
{
    public class SubmitSurveyAnswersCommandHandler : IRequestHandler<SubmitSurveyAnswersCommand>
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;


        public SubmitSurveyAnswersCommandHandler(IAnswerRepository answerRepository, IMapper mapper)
        {
            _answerRepository = answerRepository;
            _mapper = mapper;
        }

        public async Task Handle(SubmitSurveyAnswersCommand request, CancellationToken cancellationToken)
        {
            var answers = _mapper.Map<IList<SurveyApp.Domain.Entities.Answer>>(request.Answers);

            await _answerRepository.AddRangeAsync(answers);
        }
    }
}
