﻿using RepositoryPatternPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPatternPractice.Core.IRepositories
{
    public interface IUserRepository: IGenericRepository<User>
    {
    }
}
