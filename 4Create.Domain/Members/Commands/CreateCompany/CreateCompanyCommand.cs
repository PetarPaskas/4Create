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
    public class CreateCompanyCommand : IRequest<HandlerResult<CompanyCreatedDto>>
    {
        public CreateCompanyDto CreateCompanyDto { get; }
        public CreateCompanyCommand(CreateCompanyDto dto)
        {
            CreateCompanyDto = dto;
        }
    }
}
