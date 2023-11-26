using _4Create.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace _4Create.Infrastructure.EntityModelConfigurations
{
    public class CompanyEmployeesTypeConfiguration : IEntityTypeConfiguration<CompanyEmployee>
    {
        public void Configure(EntityTypeBuilder<CompanyEmployee> builder)
        {
            builder.ToTable("CompanyEmployees");

            builder.HasKey(x => new { x.EmployeeId, x.CompanyId });

            builder.HasOne(x => x.Employee)
                .WithMany(e => e.Companies)
                .HasForeignKey(x => x.EmployeeId);

            builder.HasOne(x => x.Company)
                .WithMany(e => e.Employees)
                .HasForeignKey(x => x.CompanyId);
        }
    }
}
