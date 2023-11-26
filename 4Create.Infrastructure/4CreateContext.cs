using _4Create.Domain.Models;
using _4Create.Infrastructure.EntityModelConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace _4Create.Infrastructure
{
    public class _4CreateContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<CompanyEmployee> CompanyEmployees { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Log> Logs { get; set; }

        public _4CreateContext(DbContextOptions<_4CreateContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CompanyTypeConfiguration());
            builder.ApplyConfiguration(new EmployeeTypeConfiguration());
            builder.ApplyConfiguration(new CompanyEmployeesTypeConfiguration());
            builder.ApplyConfiguration(new LogTypeConfiguration());

        }
    }
}
