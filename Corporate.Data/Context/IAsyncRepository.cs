using Corporate.Domain.Entities;
using Corporate.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Corporate.Data.Context
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<PagedList<T>> GetPagedAsync(int pageNumber,int pageSize);
        Task<T> FindAsyncById(int id);
        Task<T> AddAsync(T tEntity);
        Task UpdateAsync(T tEntity);
        Task<int> PhysicalDeleteAsync(T tEntity);
        Task<int> LogincalDeleteAsync(T tEntity) ;
    }

}
