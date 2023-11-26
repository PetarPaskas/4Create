using _4Create.Domain.Enums;

namespace _4Create.Domain.Models
{
    public class SharedEmployeeDto
    {
        public Guid EmployeeId { get; set; }
        public string Email { get; set; }
        public EmployeeTitle Title { get; set; }
        public SharedEmployeeDto()
        {
            
        }
        public SharedEmployeeDto(Employee employee)
        {
            EmployeeId = employee.EmployeeId;
            Email = employee.Email;
            Title = employee.Title;
        }
    }
}
