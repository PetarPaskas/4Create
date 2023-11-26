using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Create.Domain.Models.Dto
{
    public class SharedCompanyDto
    {
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public SharedCompanyDto(Company company)
        {
            Name = company.Name;
            CompanyId = company.CompanyId;
        }
    }
}
