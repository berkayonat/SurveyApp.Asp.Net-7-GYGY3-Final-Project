using Microsoft.EntityFrameworkCore;
using SurveyApp.Application.Interfaces;
using SurveyApp.Domain.Entities;
using SurveyApp.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Persistence.Repositories
{
    public class EFSurveyRepository : EFGenericRepository<Survey>, ISurveyRepository
    {
        private readonly AppDbContext _context;
        public EFSurveyRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> TokenExistsAsync(string token)
        {
            return await _context.Surveys.AnyAsync(x => x.Token == token);
        }

        public async Task<Survey?> GetSurveyByToken(string token)
        {
            return await _context.Surveys
                .Include(a => a.Questions)
                .ThenInclude(a => a.AnswerOptions)
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Token == token);
        }

        public async Task<IEnumerable<Survey>> GetSurveysByUserIdAsync(string userId)
        {
            return await _context.Surveys.Where(a => a.AppUserId == userId).AsNoTracking()
                .ToListAsync();
        }
    }
}
