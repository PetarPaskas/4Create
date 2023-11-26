using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Create.Domain.Models.Dto
{
    public class CompanyCreatedDto
    {
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public ICollection<SharedEmployeeDto> Employees { get; set; }

        public CompanyCreatedDto(Company company)
        {
            CompanyId = company.CompanyId;
            Name = company.Name;
            Employees = company.Employees.Select(x => new SharedEmployeeDto(x.Employee)).ToList();
        }
    }
}
