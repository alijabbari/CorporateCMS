using Corporate.Data.Context;
using Corporate.Domain.Entities;
using Corporate.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Corporate.Services.IServices
{
    public interface ICategoryService :IAsyncRepository<Category>
    {

        Task<List<Category>> GetTopMenuCategories();

    }
}
