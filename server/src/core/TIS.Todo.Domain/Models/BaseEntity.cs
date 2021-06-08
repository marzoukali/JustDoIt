using System;

namespace TIS.Todo.Domain.Models
{
    /// <summary>
    ///     This can easily be modified to be BaseEntity<T> and public T Id to support different key types.
    /// </summary>
    public class BaseEntity
    {
        public Guid Id { get; set; }
    }
}