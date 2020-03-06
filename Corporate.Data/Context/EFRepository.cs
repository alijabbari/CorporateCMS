using Corporate.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Corporate.Data.Context
{
    public class EFRepository<T> : IAsyncRepository<T> where T : class
    {
        private readonly CorporateDb _dbContext;
        private DbSet<T> _repository;
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

        public async Task DeleteAsync(T tEntity)
        {
            _repository.Remove(tEntity);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<T> FindAsyncById(int id)
        {
            return await _repository.FindAsync(id);
        }

        public async Task<PagedList<T>> GetPagedAsync()
        {
            var items = await _repository.ToListAsync().ConfigureAwait(false);
            return PagedList<T>.ToPagedList(items);
        }

        public async Task UpdateAsync(T tEntity)
        {
            _dbContext.Entry(tEntity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);

        }
    }
}
