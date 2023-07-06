using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Helpers
{
    public class DefaultUrlGenerator : IUrlGenerator
    {
        private readonly IConfiguration _configuration;

        public DefaultUrlGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateSurveyUrl(string surveyToken)
        {
            var domain = _configuration.GetSection("DomainSettings:MvcBaseUrl").Value;
            return $"{domain}/Survey/{surveyToken}";
        }
    }
}
