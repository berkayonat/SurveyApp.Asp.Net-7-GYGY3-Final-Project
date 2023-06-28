using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Helpers
{
    public class TokenGenerator : ITokenGenerator
    {
        private const string Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private readonly Random _random;

        public TokenGenerator()
        {
            _random = new Random();
        }

        public string GenerateUniqueToken(int length)
        {
            var token = new string(Enumerable.Repeat(Characters, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());

            return token;
        }
    }
}
