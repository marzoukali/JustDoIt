using TIS.Todo.Domain.Interfaces;
using TIS.Todo.Domain.Models;

namespace TIS.Todo.Data.Repositories
{
    /// <summary>
    ///     In some cases depend only on GenericRepository consider as anti pattern.
    ///     I decided to leave the choose for the developer to depend on GenericRepo and or user Single Repo per entity.
    /// </summary>
    public class ToDosRepository : GenericRepository<TodoItem>, IToDosRepository
    {
        public ToDosRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}