using _4Create.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Create.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public IEmployeeRepository EmployeeRepository { get; set; }
        public ICompanyRepository CompanyRepository { get; set; }
        Task CreateEmpoyeeAndAddToCompanies(Employee employee, IEnumerable<Guid> companies);

    }
}
