using CQRS_Lib.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Lib.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        private DbSet<T> _dbset;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            _dbset = _db.Set<T>();
        }
        //CRUD

        public async Task CreateAsync(T entity)
        {
            await _dbset.AddAsync(entity);
        }
        //public void UpdateAsync(T entity)
        //{
        //    _dbset.Update(entity);
        //}
        public void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        //public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T,bool>> expression =null
        //    , Expression<Func<T, bool>>[]? includes=null ,bool Tracke = true)
        //{
        //    var Categories = _dbset.AsQueryable();
        //    if(expression is not null)
        //    {
        //        Categories = Categories.Where(expression);
        //    }
        //    if(!Tracke)
        //    {
        //        Categories = Categories.AsNoTracking();
        //    }
        //    if(includes is not null)
        //    {
        //        foreach (var include in includes)
        //        {
        //            Categories = Categories.Include(include);
        //        }
        //    }
        //    return await Categories.ToListAsync();
        //     //return await Categories.AsAsyncEnumerable();   
        //}
        //public async Task<T?> GetOneAsync(Expression<Func<T,bool>>? expression=null
        //    , Expression<Func<T, bool>>[]? includes= null ,bool Tracke = true)
        //{
        //  return(await GetAllAsync(expression , includes , Tracke)).FirstOrDefault();
        //}

        public async Task<int> SaveChanges()
        {
            try
            {
                return await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An Error is A Function is , {ex.ToString()}");
                return 0;
            }
            
        }

        public void ubdate(T entity)
        {
           _dbset.Update(entity);
        }

        public async Task<IEnumerable<T>> GetAllasync(Expression<Func<T, bool>>? expression = null, Expression<Func<T, object>>[]? includes = null, bool Tracke = true)
        {

            var Categories = _dbset.AsQueryable();
            if (expression is not null)
            {
                Categories = Categories.Where(expression);
            }
            if (!Tracke)
            {
                Categories = Categories.AsNoTracking();
            }
            if (includes is not null)
            {
                foreach (var include in includes)
                {
                    Categories = Categories.Include(include);
                }
            }
            //return await Categories.ToListAsync();
            return await Categories.ToListAsync();
        }

        public async Task<T?> GetoneAsync(Expression<Func<T, bool>>? expression = null, Expression<Func<T, object>>[]? includes = null, bool Tracke = true)
        {
            return (await GetAllasync(expression ,includes , Tracke)).FirstOrDefault();
        }

        //Task<IEnumerable<T>> IRepository<T>.GetOneAsync(Expression<Func<T, bool>> expression, Expression<Func<T, bool>>[]? includes, bool track)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
