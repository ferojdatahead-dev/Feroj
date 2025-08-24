﻿using Microsoft.EntityFrameworkCore;
using RepositoryPatternPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPatternPractice.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
