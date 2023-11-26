using _4Create.Domain.Enums;
using _4Create.Domain.Interfaces;
using _4Create.Domain.Models;
using _4Create.Domain.Models.CQRS;
using _4Create.Domain.Models.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Create.Domain.Members.Commands.CreateCompany
{
    internal class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, HandlerResult<CompanyCreatedDto>>
    {
        private IUnitOfWork _unitOfWork;

        public CreateCompanyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<HandlerResult<CompanyCreatedDto>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var dto = request.CreateCompanyDto;

            Dictionary<EmployeeTitle, SharedEmployeeDto> employeeTitles = new();
            var employees = new List<Employee>();

            foreach (var employee in dto.Employees)
            {
                if (employeeTitles.ContainsKey(employee.Title))
                {
                    return new HandlerResult<CompanyCreatedDto>()
                    {
                        Status = HandlerStatus.Failure,
                        Message = "There were duplicating roles between employees in the same company"
                    }; //Return a result with status failed; reason "duplicate title"

                }
                else
                {
                    employeeTitles.Add(employee.Title, employee);
                    employees.Add(new Employee()
                    {
                        EmployeeId = employee.EmployeeId.Equals(Guid.Empty) ? Guid.NewGuid() : employee.EmployeeId,
                        Email = employee.Email,
                        Title = employee.Title
                    });
                }
            }

            var company = new Company()
            {
                CompanyId = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
                Employees = new List<CompanyEmployee>(),
                Name = dto.Name
            };


            await _unitOfWork.CompanyRepository.AddEmployeesToCompany(company, employees);

            return new HandlerResult<CompanyCreatedDto>()
            {
                Status = HandlerStatus.Success,
                Message = "OK",
                Body = new CompanyCreatedDto(company)
            };

        }

    }
}
