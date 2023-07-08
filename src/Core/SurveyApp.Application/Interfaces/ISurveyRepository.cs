using SurveyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Interfaces
{
    public interface ISurveyRepository : IGenericRepository<Survey>
    {
        Task<Survey?> GetSurveyByToken(string token);
        Task<Survey?> GetSurveyByTokenForResult(string token);
        Task<IEnumerable<Survey>> GetSurveysByUserIdAsync(string userId);
        Task<bool> TokenExistsAsync(string token);
    }
}
