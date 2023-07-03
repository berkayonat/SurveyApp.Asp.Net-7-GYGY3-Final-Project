using SurveyApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T?>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllWithPredicateAsync(Expression<Func<T, bool>> predicate);
        Task CreateAsync(T entity);
        Task DeleteAsync(int id);
        Task UpdateAsync(T entity);
        Task<bool> IsExistsAsync(int id);
        Task AddRangeAsync(IEnumerable<T> entities);
    }
}
