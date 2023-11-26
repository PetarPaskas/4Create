using _4Create.Domain.Interfaces;
using _4Create.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Create.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly _4CreateContext _context;
        public EmployeeRepository(_4CreateContext context)
        {
            _context = context;
        }
        public async Task<Employee> CreateEmployee(Employee employee)
        {

            _context.Employees.Add(employee);

            await _context.SaveChangesAsync();

            return employee;
        }
    }
}
