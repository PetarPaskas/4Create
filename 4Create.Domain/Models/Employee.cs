using _4Create.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Create.Domain.Models
{
    public class Employee : EntityBase
    {
        public Guid EmployeeId { get; set; }
        public string Email { get; set; }
        public EmployeeTitle Title { get; set; }
        public ICollection<CompanyEmployee> Companies { get; set;}
    }
}
