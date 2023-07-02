using AutoMapper;
using MediatR;
using SurveyApp.Application.DTOs.Response;
using SurveyApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Features.Survey.Queries.GetByToken
{
    public class GetSurveyByTokenQueryHandler : IRequestHandler<GetSurveyByTokenQuery, SurveyDto>
    {
        private readonly ISurveyRepository _surveyRepository;
        private readonly IMapper _mapper;

        public GetSurveyByTokenQueryHandler(ISurveyRepository surveyRepository, IMapper mapper)
        {
            _surveyRepository = surveyRepository;
            _mapper = mapper;
        }

        public async Task<SurveyDto?> Handle(GetSurveyByTokenQuery request, CancellationToken cancellationToken)
        {
            var survey = await _surveyRepository.GetSurveyByToken(request.Token);
            
            var surveyDto = _mapper.Map<SurveyDto>(survey);
            return surveyDto;
        }
    }
}
