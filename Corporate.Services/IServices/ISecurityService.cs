using System;
using System.Collections.Generic;
using System.Text;

namespace Corporate.Services.IServices
{
    public interface ISecurityService
    {
        string GetSha256Hash(string input);
        Guid CreateCryptographicallySecureGuid();

    }
}
