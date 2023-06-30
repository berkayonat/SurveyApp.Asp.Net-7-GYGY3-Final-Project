using AutoMapper;
using MediatR;
using SurveyApp.Application.Helpers;
using SurveyApp.Application.Interfaces;
using SurveyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Features.Survey.Commands.Create
{
    public class CreateSurveyCommandHandler : IRequestHandler<CreateSurveyCommand, string>
    {
        private readonly ISurveyRepository _surveyRepository;
        private readonly IMapper _mapper;
        private readonly ITokenGenerator _tokenGenerator;

        public CreateSurveyCommandHandler(ISurveyRepository surveyRepository, IMapper mapper, ITokenGenerator tokenGenerator)
        {
            _surveyRepository = surveyRepository;
            _mapper = mapper;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<string> Handle(CreateSurveyCommand request, CancellationToken cancellationToken)
        {
            var surveyToken = _tokenGenerator.GenerateUniqueToken(6);

            var survey = _mapper.Map<SurveyApp.Domain.Entities.Survey>(request);
            survey.Token = surveyToken;
            if (request.Questions != null)
            {
                survey.Questions = new List<SurveyApp.Domain.Entities.Question>();
                foreach (var createQuestionCommand in request.Questions)
                {
                    var question = _mapper.Map<SurveyApp.Domain.Entities.Question>(createQuestionCommand);
                    
                    if (createQuestionCommand.AnswerOptions != null) 
                    {
                        question.AnswerOptions = new List<SurveyApp.Domain.Entities.AnswerOption>();

                        foreach (var createAnswerOptionCommand in createQuestionCommand.AnswerOptions)
                        {
                            var answerOption = _mapper.Map<SurveyApp.Domain.Entities.AnswerOption>(createAnswerOptionCommand);
                            question.AnswerOptions?.Add(answerOption);
                        }

                    }
                    survey.Questions?.Add(question);
                }
            }
            await _surveyRepository.CreateAsync(survey);

            return surveyToken;
        }
    }
}
