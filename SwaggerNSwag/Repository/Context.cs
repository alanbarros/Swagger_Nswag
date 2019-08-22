﻿using Microsoft.EntityFrameworkCore;
using SwaggerNSwag.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerNSwag.Repository
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        
        public DbSet<User> Users { get; set; }
    }
}
