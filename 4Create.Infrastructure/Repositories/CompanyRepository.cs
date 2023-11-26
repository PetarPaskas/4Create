using _4Create.Domain.Interfaces;
using _4Create.Domain.Models;
using _4Create.Domain.Models.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Create.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private _4CreateContext _context;
        public CompanyRepository(_4CreateContext context)
        {
            _context = context;
        }

        public async Task<Company> CreateCompany(Company createCompany)
        {
            _context.Companies.Add(createCompany);

            await _context.SaveChangesAsync();

            return createCompany;
        }

        public async Task<ICollection<Employee>> GetEmployeesOfACompany(Company company)
        {
            var companyWithEmployees = await _context.CompanyEmployees
                .Where(x=>x.CompanyId.Equals(company.CompanyId))
                .Include(x=>x.Employee)
                .Include(x=>x.Company)
                .ToListAsync();

            if(companyWithEmployees is not null)
            {
                var map = companyWithEmployees.Select(x => x.Employee);
                if (map is not null)
                    return (ICollection<Employee>)map;
            }

            return null;
        }

        public async Task<Company> AddEmployeesToCompany(Company company,IEnumerable<Employee> employees)
        {
            bool isInTransaction = false;
           var targetCompany = await searchForCompany(company);

            if (targetCompany is null)
            {
                _context.Database.BeginTransaction();
                isInTransaction = true;
                targetCompany = await CreateCompany(company);
            }

           if(targetCompany.Employees is null)
                targetCompany.Employees = new List<CompanyEmployee>();

            foreach (var employee in employees)
            {
                targetCompany.Employees.Add(new CompanyEmployee()
                {
                    Company = company,
                    Employee = employee
                });
            }

            if (isInTransaction)
            {
                await _context.Database.CommitTransactionAsync();
            }
            else
            {
                await _context.SaveChangesAsync();
            }

            return targetCompany;
        }

        public async Task<Company> GetCompany(Company company)
        {
            return await searchForCompany(company);
        }

        private async Task<Company> searchForCompany(Company company)
        {
            Company result = null;

            if(!company.CompanyId.Equals(Guid.Empty) || !String.IsNullOrWhiteSpace(company.Name))
            {
                result = await _context.Companies
                    .Include(x => x.Employees)
                    .SingleOrDefaultAsync(x => x.CompanyId.Equals(company.CompanyId) || x.Name.Equals(company.Name));
            }

            return result;
        }

    }
}
