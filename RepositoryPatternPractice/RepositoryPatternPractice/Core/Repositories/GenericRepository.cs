using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RepositoryPatternPractice.Core.IRepositories;
using RepositoryPatternPractice.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPatternPractice.Core.Repositories
{
    public class GenericRepository<T>: IGenericRepository<T> where T: class
    {
        protected AppDbContext _context;
        protected DbSet<T> _dbset;
        protected readonly ILogger _logger;

        public GenericRepository(AppDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            _dbset = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> All()
        {
            return await _dbset.ToListAsync();
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await _dbset.FindAsync(id);
        }

        public virtual async Task<bool> Add(T entity)
        {
            await _dbset.AddAsync(entity);
            return true;
        }

        public virtual Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
