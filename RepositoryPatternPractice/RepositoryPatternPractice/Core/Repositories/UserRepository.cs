using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RepositoryPatternPractice.Core.IRepositories;
using RepositoryPatternPractice.Data;
using RepositoryPatternPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPatternPractice.Core.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<User>> All()
        {
            try
            {
                return await _dbset.ToListAsync();
            }catch(Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error", typeof(UserRepository));
                return new List<User>();
            }
        }

        public override async Task<bool> Update(User entity)
        {
            try
            {
                var existing = await _dbset.Where(x => x.Id == entity.Id)
                                           .FirstOrDefaultAsync();
                if(existing == null)
                {
                    return await Add(entity);
                }
                existing.FirstName = entity.FirstName;
                existing.LastName = entity.LastName;
                existing.Email = entity.Email;
                return true;
            }catch(Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update method error", typeof(UserRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var existing = await _dbset.Where(x => x.Id == id)
                                     .FirstOrDefaultAsync();
                if(existing != null)
                {
                    _dbset.Remove(existing);
                    return true;
                }
                return false;
            }catch(Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete method error", typeof(UserRepository));
                return false;
            }
        }
    }
}
