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

namespace _4Create.Domain.Members.Commands.CreateEmployee
{
    public sealed class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, HandlerResult<EmployeeCreatedDto>>
    {
        private IUnitOfWork _unitOfWork;

        public CreateEmployeeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; 
        }

        public async Task<HandlerResult<EmployeeCreatedDto>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var dto = request.CreateEmployeeDto;

            var employee = new Employee()
            {
                Email = dto.Email,
                EmployeeId = Guid.NewGuid(),
                Title = dto.Title,                
            };

            try
            {
                await _unitOfWork.CreateEmpoyeeAndAddToCompanies(employee, dto.CompanyIds);

                return new HandlerResult<EmployeeCreatedDto>()
                {
                    Message = "OK",
                    Status = Enums.HandlerStatus.Success,
                    Body = new EmployeeCreatedDto(employee)
                    
                };
            }
            catch(Exception ex)
            {
                return new HandlerResult<EmployeeCreatedDto>()
                {
                    Message = ex.Message,
                    Status = Enums.HandlerStatus.Failure
                };
            }
        }
    }
}
