using _4Create.Domain.Interfaces;
using _4Create.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Create.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IEmployeeRepository EmployeeRepository { get; set; }
        public ICompanyRepository CompanyRepository { get; set; }
        private readonly _4CreateContext _context;

        public UnitOfWork(IEmployeeRepository employeeRepository,
            ICompanyRepository companyRepository,
            _4CreateContext context)
        {
            _context = context;
            EmployeeRepository = employeeRepository;
            CompanyRepository = companyRepository;
        }

        public async Task CreateEmpoyeeAndAddToCompanies(Employee employee, IEnumerable<Guid> companies)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {

                await EmployeeRepository.CreateEmployee(employee);

                foreach (var companyId in companies)
                {
                    await CompanyRepository.AddEmployeesToCompany(new Company()
                    {
                        CompanyId = companyId
                    }, new List<Employee> { employee });
                }

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch(Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }

        }
    }
}
