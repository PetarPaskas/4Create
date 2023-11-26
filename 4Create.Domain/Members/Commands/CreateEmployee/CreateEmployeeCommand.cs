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
    public class CreateEmployeeCommand : IRequest<HandlerResult<EmployeeCreatedDto>>
    {
        public CreateEmployeeDto CreateEmployeeDto { get; }
        public CreateEmployeeCommand(CreateEmployeeDto dto)
        {
            CreateEmployeeDto = dto;
        }
    }
}
