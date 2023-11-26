using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Create.Domain.Models
{
    public class Company : EntityBase
    {
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public ICollection<CompanyEmployee> Employees { get; set; }
    }
}
