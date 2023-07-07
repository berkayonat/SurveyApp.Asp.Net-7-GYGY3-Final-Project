using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public ICollection<Survey> Surveys { get; set; }

        public AppUser() => this.Surveys = new HashSet<Survey>();
    }
}
