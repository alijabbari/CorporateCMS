using Corporate.Data.Context;
using Corporate.Domain.Entities;
using Corporate.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Corporate.Services.Services
{
    public class UsersService :EFRepository<User>, IUsersService
    {

        private readonly ISecurityService _securityService;
        private readonly IHttpContextAccessor _contextAccessor;
        public UsersService(CorporateDb corporateDb,ISecurityService securityService,IHttpContextAccessor httpContextAccessor) : base(corporateDb)
        {
            _securityService = securityService;
            _contextAccessor=httpContextAccessor;
        }
        public async Task<User> FindUserAsync(int userId)
        {
            return await _repository.FindAsync(userId);
            //return await _dbContext.Users.FindAsync(userId);
        }

        public async Task<User> FindUserAsync(string username, string password)
        {
            var passwordHash = _securityService.GetSha256Hash(password);
            return await _repository.FirstOrDefaultAsync(x => x.Username == username && x.Password == passwordHash);
        }

        public async Task<string> GetSerialNumberAsync(int userId)
        {
            var user = await FindUserAsync(userId);
            return user.SerialNumber;
        }

        public async Task UpdateUserLastActivityDateAsync(int userId)
        {
            var user = await FindUserAsync(userId);
            if (user.LastLoggedIn != null)
            {
                var updateLastActivityDate = TimeSpan.FromMinutes(2);
                var currentUtc = DateTimeOffset.UtcNow;
                var timeElapsed = currentUtc.Subtract(user.LastLoggedIn.Value);
                if (timeElapsed < updateLastActivityDate)
                {
                    return;
                }
            }
            user.LastLoggedIn = DateTimeOffset.UtcNow;
            await _dbContext.SaveChangesAsync();
        }

        public int GetCurrentUserId()
        {
            var claimsIdentity = _contextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var userDataClaim = claimsIdentity?.FindFirst(ClaimTypes.UserData);
            var userId = userDataClaim?.Value;
            return string.IsNullOrWhiteSpace(userId) ? 0 : int.Parse(userId);
        }

        public async ValueTask<User> GetCurrentUserAsync()
        {
            var userId = GetCurrentUserId();
            return await FindUserAsync(userId);
        }

        public async Task<(bool Succeeded, string Error)> ChangePasswordAsync(User user, string currentPassword, string newPassword)
        {
            var currentPasswordHash = _securityService.GetSha256Hash(currentPassword);
            if (user.Password != currentPasswordHash)
            {
                return (false, "Current password is wrong.");
            }

            user.Password = _securityService.GetSha256Hash(newPassword);
            // user.SerialNumber = Guid.NewGuid().ToString("N"); // To force other logins to expire.
            await _dbContext.SaveChangesAsync();
            return (true, string.Empty);
        }

    }
}
