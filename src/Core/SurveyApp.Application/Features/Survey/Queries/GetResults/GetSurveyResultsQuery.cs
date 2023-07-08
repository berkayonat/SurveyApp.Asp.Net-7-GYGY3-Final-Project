using MediatR;
using SurveyApp.Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Features.Survey.Queries.GetResults
{
    public class GetSurveyResultsQuery : IRequest<SurveyResult>
    {
        public string? Token { get; set; }

        public GetSurveyResultsQuery(string? token)
        {
            Token = token;
        }
    }
}
