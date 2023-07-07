using MediatR;
using SurveyApp.Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Features.Survey.Queries.GetAllByUserId
{
    public class GetAllSurveysByUserIdQuery : IRequest<IEnumerable<GetAllSurveysDto>>
    {
        public string? UserId { get; set; }

        public GetAllSurveysByUserIdQuery(string? userId)
        {
            UserId = userId;
        }
    }
}
