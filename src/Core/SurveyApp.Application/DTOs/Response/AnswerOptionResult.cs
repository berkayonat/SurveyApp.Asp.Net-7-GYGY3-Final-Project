using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.DTOs.Response
{
    public class AnswerOptionResult
    {
        public string? AnswerOptionText { get; set; }
        public decimal Percentage { get; set; }
    }
}
