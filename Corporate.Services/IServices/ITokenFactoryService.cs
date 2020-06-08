﻿using Corporate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Corporate.Services.IServices
{
    public interface ITokenFactoryService
    {
        public class JwtTokensData
        {
            public string AccessToken { get; set; }
            public string RefreshToken { get; set; }
            public string RefreshTokenSerial { get; set; }
            public IEnumerable<Claim> Claims { get; set; }
        }

        Task<JwtTokensData> CreateJwtTokensAsync(User user);
        string GetRefreshTokenSerial(string refreshTokenValue);
    }
}
