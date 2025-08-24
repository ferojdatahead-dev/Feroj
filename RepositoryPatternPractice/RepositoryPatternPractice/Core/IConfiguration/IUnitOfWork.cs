using RepositoryPatternPractice.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPatternPractice.Core.IConfiguration
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        Task CompleteAsync();
    }
}
