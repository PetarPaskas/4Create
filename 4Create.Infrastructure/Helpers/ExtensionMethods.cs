using _4Create.Domain.Interfaces;
using _4Create.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Create.Infrastructure.Helpers
{
    public static class ExtensionMethods
    {
        public static IServiceCollection Register4CreateContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<_4CreateContext>(options =>
            {
                options.UseSqlServer(connectionString);
                //options.UseInMemoryDatabase("InMemDB");
            });

            return services;
        }

        public static IServiceCollection RegisterRepository(this IServiceCollection services)
        {
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection RegisterMediator(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(_4Create.Domain.Members.Commands.CreateCompany.CreateCompanyCommand)));
            return services;
        }


    }
}
