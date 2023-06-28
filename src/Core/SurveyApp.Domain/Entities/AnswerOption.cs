using SurveyApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Domain.Entities
{
    public class AnswerOption : BaseEntity
    {
        public string Text { get; set; }

        public int QuestionId { get; set; }
        public Question? Question { get; set; }
        public ICollection<Answer>? Answers { get; set; }

        public AnswerOption() => this.Answers = new HashSet<Answer>();
    }
}
