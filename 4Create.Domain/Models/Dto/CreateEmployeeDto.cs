using _4Create.Domain.Enums;

namespace _4Create.Domain.Models
{
    public class CreateEmployeeDto
    {
        public string Email { get; set; }
        public EmployeeTitle Title { get; set; }
        public IEnumerable<Guid> CompanyIds { get; set; }
    }
}
