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
    public class CompanyTypeConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companies");

            builder.HasKey(x => x.CompanyId);

            builder.HasAlternateKey(x => x.Name);
            builder.HasIndex(x => x.Name);
            builder.Property(x => x.Name)
                .IsRequired();
        }
    }
}
