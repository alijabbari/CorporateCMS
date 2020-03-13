using Corporate.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Corporate.Data.Context
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<PagedList<T>> GetPagedAsync(int pageNumber,int pageSize);
        Task<T> FindAsyncById(int id);
        Task<T> AddAsync(T tEntity);
        Task UpdateAsync(T tEntity);
        Task DeleteAsync(T tEntity);

    }

}
