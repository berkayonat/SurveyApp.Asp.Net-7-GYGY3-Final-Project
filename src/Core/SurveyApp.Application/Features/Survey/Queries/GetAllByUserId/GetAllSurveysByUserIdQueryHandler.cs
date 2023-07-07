using AutoMapper;
using MediatR;
using SurveyApp.Application.DTOs.Response;
using SurveyApp.Application.Features.Survey.Queries.GetAll;
using SurveyApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Features.Survey.Queries.GetAllByUserId
{
    public class GetAllSurveysByUserIdQueryHandler : IRequestHandler<GetAllSurveysByUserIdQuery, IEnumerable<GetAllSurveysDto>>
    {
        private readonly ISurveyRepository _surveyRepository;
        private readonly IMapper _mapper;

        public GetAllSurveysByUserIdQueryHandler(ISurveyRepository surveyRepository, IMapper mapper)
        {
            _surveyRepository = surveyRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllSurveysDto>> Handle(GetAllSurveysByUserIdQuery request, CancellationToken cancellationToken)
        {
            var surveys = await _surveyRepository.GetSurveysByUserIdAsync(request.UserId);
            return _mapper.Map<IEnumerable<GetAllSurveysDto>>(surveys);
        }
    }
}
