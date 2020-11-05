using Corporate.Data.Context;
using Corporate.Domain.Entities;
using Corporate.Infrastructure;
using Corporate.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corporate.Services.Services
{
    public class CategoryService : EFRepository<Category>, ICategoryService
    {
        public CategoryService(CorporateDb corporateDb) : base(corporateDb)
        {

        }

        public async Task<List<Category>> GetTopMenuCategories()
        {
            return await _repository.Where(x => x.IncludeInTopMenu == true && x.IsDeleted == false).AsNoTracking().ToListAsync();
        }
    }
}
