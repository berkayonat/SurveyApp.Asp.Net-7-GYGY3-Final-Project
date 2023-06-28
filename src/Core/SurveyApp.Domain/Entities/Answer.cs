using SurveyApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Domain.Entities
{
    public class Answer : BaseEntity
    {
        public string? Text { get; set; }
        public byte? Rating { get; set; }

        public int QuestionId { get; set; }
        public Question? Question { get; set; }

        public int? AnswerOptionId { get; set; }
        public AnswerOption? AnswerOption { get; set; }
    }
}
