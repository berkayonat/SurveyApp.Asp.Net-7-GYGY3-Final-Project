using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.DTOs.Response
{
    public class GetAllSurveysDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Token { get; set; }
    }
}
