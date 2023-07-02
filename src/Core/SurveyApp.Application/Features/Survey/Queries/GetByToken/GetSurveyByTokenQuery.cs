using MediatR;
using SurveyApp.Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Features.Survey.Queries.GetByToken
{
    public class GetSurveyByTokenQuery : IRequest<SurveyDto>
    {
        public string? Token { get; set; }

        public GetSurveyByTokenQuery(string? token)
        {
            Token = token;
        }
    }
}
