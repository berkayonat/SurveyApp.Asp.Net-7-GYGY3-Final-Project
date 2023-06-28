using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Helpers
{
    public interface ITokenGenerator
    {
        string GenerateUniqueToken(int length);
    }
}
