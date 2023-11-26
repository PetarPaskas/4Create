using _4Create.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Create.Infrastructure.EntityModelConfigurations
{
    public class EmployeeTypeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");

            builder.HasKey(x => x.EmployeeId);

            builder.HasAlternateKey(x => x.Email);
            builder.HasIndex(x => x.Email);
            builder.Property(x => x.Email)
                .IsRequired();

            builder.Property(x=>x.Title)
                .IsRequired();
        }
    }
}
