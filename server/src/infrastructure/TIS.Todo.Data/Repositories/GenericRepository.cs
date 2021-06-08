using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TIS.Todo.Application.Interfaces.IRepositories;
using TIS.Todo.Domain.Models;

namespace TIS.Todo.Data.Repositories
{
    /// <summary>
    ///     Generic Repository Concrete Implementation using Sync and Async features
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository<T> : IRepository<T>, IAsyncRepository<T> where T : BaseEntity
    {
        protected readonly DataContext DbContext;

        public GenericRepository(DataContext dbContext)
        {
            DbContext = dbContext;
        }


        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await DbContext.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> ListAllAsync()
        {
            return await DbContext.Set<T>().ToListAsync();
        }

        public async Task<int> AddAsync(T entity)
        {
            DbContext.Set<T>().Add(entity);
            return await DbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            return await DbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(T entity)
        {
            DbContext.Set<T>().Remove(entity);
            return await DbContext.SaveChangesAsync();
        }

        public virtual T GetById(Guid id)
        {
            return DbContext.Set<T>().Find(id);
        }

        public IEnumerable<T> ListAll()
        {
            return DbContext.Set<T>().AsEnumerable();
        }

        public int Add(T entity)
        {
            DbContext.Set<T>().Add(entity);
            return DbContext.SaveChanges();
        }

        public int Update(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            return DbContext.SaveChanges();
        }

        public int Delete(T entity)
        {
            DbContext.Set<T>().Remove(entity);
            return DbContext.SaveChanges();
        }
    }
}