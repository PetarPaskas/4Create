using _4Create.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Create.Domain.Models.Dto
{
    public class EmployeeCreatedDto
    {
        public Guid EmployeeId { get; set; }
        public string Email { get; set; }
        public EmployeeTitle Title { get; set; }
        public IEnumerable<SharedCompanyDto> Companies { get; set; }
        public EmployeeCreatedDto(Employee employee)
        {
            EmployeeId = employee.EmployeeId;
            Email = employee.Email;
            Title = employee.Title;
            Companies = employee.Companies.Select(x => new SharedCompanyDto(x.Company)).ToList();
        }
        public EmployeeCreatedDto()
        {
            
        }
    }
}
