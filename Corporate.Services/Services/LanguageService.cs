using Corporate.Data.Context;
using Corporate.Domain.Entities;
using Corporate.Services.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Corporate.Services.Services
{
    public class LanguageService : EFRepository<Language>, ILanguageService
    {
        public LanguageService(CorporateDb corporateDb) : base(corporateDb) { }
    }
}
