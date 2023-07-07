using SurveyApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Domain.Entities
{
    public class Survey : BaseEntity
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Token { get; set; }
        public bool Status { get; set; } = true;

        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public ICollection<Question>? Questions { get; set; }

        public Survey() => this.Questions = new HashSet<Question>();
    }
}
