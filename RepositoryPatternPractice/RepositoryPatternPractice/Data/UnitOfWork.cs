using Microsoft.Extensions.Logging;
using RepositoryPatternPractice.Core.IConfiguration;
using RepositoryPatternPractice.Core.IRepositories;
using RepositoryPatternPractice.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPatternPractice.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        protected AppDbContext _context;
        protected ILogger _logger;
        public IUserRepository Users { get; private set; }

        public UnitOfWork(AppDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("Logs");
            Users = new UserRepository(_context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
