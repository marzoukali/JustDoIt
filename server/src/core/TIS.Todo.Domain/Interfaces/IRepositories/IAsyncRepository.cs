using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TIS.Todo.Domain.Models;

namespace TIS.Todo.Application.Interfaces.IRepositories
{
    /// <summary>
    ///     Generic Async Repository Pattern Interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(Guid id);
        Task<List<T>> ListAllAsync();
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
    }
}