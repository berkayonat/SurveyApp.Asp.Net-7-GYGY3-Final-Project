using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Helpers
{
    public interface IUrlGenerator
    {
        string GenerateSurveyUrl(string surveyToken);
    }
}
