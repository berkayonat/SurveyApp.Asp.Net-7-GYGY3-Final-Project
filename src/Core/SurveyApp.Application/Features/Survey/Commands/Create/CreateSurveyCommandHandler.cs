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
        private readonly IUrlGenerator _urlGenerator;


        public CreateSurveyCommandHandler(ISurveyRepository surveyRepository, IMapper mapper, ITokenGenerator tokenGenerator, IUrlGenerator urlGenerator)
        {
            _surveyRepository = surveyRepository;
            _mapper = mapper;
            _tokenGenerator = tokenGenerator;
            _urlGenerator = urlGenerator;
        }

        public async Task<string> Handle(CreateSurveyCommand request, CancellationToken cancellationToken)
        {
            var surveyToken = _tokenGenerator.GenerateUniqueToken(6);
            while (await _surveyRepository.TokenExistsAsync(surveyToken))
            {
                surveyToken = _tokenGenerator.GenerateUniqueToken(6);
            }

            var survey = _mapper.Map<SurveyApp.Domain.Entities.Survey>(request);
            survey.Token = surveyToken;
            var surveyUrl = _urlGenerator.GenerateSurveyUrl(surveyToken);

            await _surveyRepository.CreateAsync(survey);

            return surveyUrl;
        }
    }
}
