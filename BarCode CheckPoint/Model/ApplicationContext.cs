using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CheckPoint.Model.Entities;

namespace CheckPoint.Model
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
            : base("name=CheckPointDB")
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<ShiftCheck> ShiftChecks { get; set; }

    }
}