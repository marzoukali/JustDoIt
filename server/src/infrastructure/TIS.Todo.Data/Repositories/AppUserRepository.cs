using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TIS.Todo.Domain.Interfaces.IRepositories;
using TIS.Todo.Domain.Models;

namespace TIS.Todo.Data.Repositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly UserManager<AppUser> _userManager;

        public AppUserRepository(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AppUser> GetUserById(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }
    }
}