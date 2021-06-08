using System;
using System.Collections.Generic;
using TIS.Todo.Domain.Models;

namespace TIS.Todo.Application.Interfaces.IRepositories
{
    /// <summary>
    ///     Generic Sync Repository Pattern Interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(Guid id);
        IEnumerable<T> ListAll();
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
    }
}