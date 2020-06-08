using Corporate.Data.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Corporate.Services.IServices
{
    public interface ITokenValidatorService 
    {
        Task ValidateAsync(TokenValidatedContext context);
    }
}
