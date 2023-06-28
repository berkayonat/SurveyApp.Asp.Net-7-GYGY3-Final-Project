using Microsoft.VisualBasic.FileIO;
using SurveyApp.Domain.Entities.Common;
using SurveyApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Domain.Entities
{
    public class Question : BaseEntity
    {
        public string Text { get; set; }
        public QuestionType Type { get; set; }

        public int SurveyId { get; set; }
        public Survey? Survey { get; set; }
        
        public ICollection<AnswerOption>? AnswerOptions { get; set; }
        public ICollection<Answer>? Answers { get; set; }
        public Question()
        {
            this.AnswerOptions = new HashSet<AnswerOption>();
            this.Answers = new HashSet<Answer>();
        }
    }
}
