using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Create.Domain.Models
{
    public class CompanyEmployee : EntityBase
    {
        public Guid CompanyId { get; set; }
        public Guid EmployeeId { get; set; }

        public Company Company { get; set; }
        public Employee Employee { get; set; }
    }
}
