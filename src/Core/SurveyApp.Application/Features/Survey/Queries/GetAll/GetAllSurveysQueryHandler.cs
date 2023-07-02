using AutoMapper;
using MediatR;
using SurveyApp.Application.DTOs.Response;
using SurveyApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Features.Survey.Queries.GetAll
{
    public class GetAllSurveysQueryHandler : IRequestHandler<GetAllSurveysQuery, IEnumerable<GetAllSurveysDto>>
    {
        private readonly ISurveyRepository _surveyRepository;
        private readonly IMapper _mapper;

        public GetAllSurveysQueryHandler(ISurveyRepository surveyRepository, IMapper mapper)
        {
            _surveyRepository = surveyRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllSurveysDto>> Handle(GetAllSurveysQuery request, CancellationToken cancellationToken)
        {
            var surveys = await _surveyRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetAllSurveysDto>>(surveys);
        }
    }
}
