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
        Task<bool> TokenExistsAsync(string token);
    }
}
