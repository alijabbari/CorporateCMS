using Corporate.Domain.Entities;
using Corporate.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Corporate.Data.Context
{
    public class EFRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        protected readonly CorporateDb _dbContext;
        protected DbSet<T> _repository;
        public EFRepository()
        {

        }
        public EFRepository(CorporateDb corporateDb)
        {
            _dbContext = corporateDb;
            _repository = _dbContext?.Set<T>();
        }

        public async Task<T> AddAsync(T tEntity)
        {
            await _repository.AddAsync(tEntity);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            return tEntity;
        }
        /// <summary>
        /// for delete row physicaly not logical
        /// </summary>
        /// <param name="tEntity"></param>
        /// <returns></returns>
        public async Task<int> PhysicalDeleteAsync(T tEntity)
        {
            _repository.Remove(tEntity);
            return await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<T> FindAsyncById(int id)
        {
            return await _repository.FindAsync(id);
        }

        public async Task<PagedList<T>> GetPagedAsync()
        {
            var items = await _repository.AsNoTracking().ToListAsync().ConfigureAwait(false);
            return PagedList<T>.ToPagedList(items);
        }

        public async Task<PagedList<T>> GetPagedAsync(int pageNumber, int pageSize)
        {
            var items = _repository.AsQueryable();
            return await PagedList<T>.ToPagedList(items, pageNumber, pageSize).ConfigureAwait(false);
        }

        public async Task UpdateAsync(T tEntity)
        {
            _dbContext.Entry(tEntity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);

        }

        public async Task<int> LogincalDeleteAsync(T tEntity)
        {
            tEntity.IsDeleted = true;
            tEntity.DeletedDateTime = DateTimeOffset.UtcNow;
            return await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
