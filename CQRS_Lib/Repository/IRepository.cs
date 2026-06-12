using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Lib.Repository
{
    public interface IRepository<T> where T : class
    {
       Task CreateAsync(T entity);
        void UpdateAsync(T entity);
        void Delete(T entity);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null
            , Expression<Func<T, bool>>[]? includes = null, bool track = true);
        Task<IEnumerable<T>> GetOneAsync(Expression<Func<T, bool>> expression = null
            , Expression<Func<T, bool>>[]? includes = null, bool track = true);
       Task<int> SaveChanges();
    }
}
