using Corporate.Data.Context;
using Corporate.Domain.Entities;
using Corporate.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corporate.Services.Services
{
    public class RoleService : EFRepository<Role>, IRoleService
    {
        public RoleService(CorporateDb corporateDb) : base(corporateDb) { }
        public async Task<List<Role>> FindUserRolesAsync(int userId)
        {

            var roleQuerable = from roles in _repository //_dbContext.Roles
                               from userRoles in roles.UserRoles
                               where userRoles.UserId == userId
                               select roles;
            return await roleQuerable.OrderBy(x => x.Name).ToListAsync();

        }

        //public async Task<List<User>> FindUsersInRoleAsync(string roleName)
        //{
        //    var roleUserIdsQuery = from role in _repository
        //                           where role.Name == roleName
        //                           from user in role.UserRoles
        //                           select user.UserId;
        //    return await _dbContext.Users.Where(user => roleUserIdsQuery.Contains(user.Id))
        //                 .ToListAsync();

        //}

        public async Task<bool> IsUserInRoleAsync(int userId, string roleName)
        {
            var userRolesQuery = from role in _repository
                                 where role.Name == roleName
                                 from user in role.UserRoles
                                 where user.UserId == userId
                                 select role;
            var userRole = await userRolesQuery.FirstOrDefaultAsync();
            return userRole != null;
        }
    }
}
