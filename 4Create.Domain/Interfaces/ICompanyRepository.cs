using _4Create.Domain.Models;
using _4Create.Domain.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Create.Domain.Interfaces
{
    public interface ICompanyRepository
    {
        Task<Company> GetCompany(Company company);
        Task<Company> CreateCompany(Company company);
        Task<Company> AddEmployeesToCompany(Company company, IEnumerable<Employee> employees);
    }
}
