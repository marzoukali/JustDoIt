using System.Threading.Tasks;
using TIS.Todo.Domain.Models;

namespace TIS.Todo.Domain.Interfaces.IRepositories
{
    public interface IAppUserRepository
    {
        Task<AppUser> GetUserById(string id);
    }
}