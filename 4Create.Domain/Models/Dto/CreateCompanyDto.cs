namespace _4Create.Domain.Models.Dto
{
    public class CreateCompanyDto
    {
        public string Name { get; set; }
        public IEnumerable<SharedEmployeeDto> Employees { get; set; }
    }
}
