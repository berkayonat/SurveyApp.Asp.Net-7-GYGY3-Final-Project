using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.DTOs.Response
{
    public class QuestionResult
    {
        public string? QuestionText { get; set; }
        public List<AnswerOptionResult>? AnswerOptionResults { get; set; }
        public List<string>? TextAnswers { get; set; }
        public decimal? RatingAverage { get; set; }
    }
}
