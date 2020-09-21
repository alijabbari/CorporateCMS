using Corporate.Data.Context;
using Corporate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Corporate.Services.IServices
{
    public interface IRoleService //:IAsyncRepository<Role>
    {
        Task<List<Role>> FindUserRolesAsync(int userId);
        Task<bool> IsUserInRoleAsync(int userId, string roleName);
        //Task<List<User>> FindUsersInRoleAsync(string roleName);
    }
}
