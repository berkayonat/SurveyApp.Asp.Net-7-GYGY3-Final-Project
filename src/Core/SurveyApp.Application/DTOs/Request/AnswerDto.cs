using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.DTOs.Request
{
    public class AnswerDto
    {
        public string? Text { get; set; }
        public byte? Rating { get; set; }
        public int QuestionId { get; set; }
        public int? AnswerOptionId { get; set; }

    }
}
