using _4Create.Domain.Enums;
using _4Create.Domain.Members.Commands.CreateCompany;
using _4Create.Domain.Models.Dto;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _4Create.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CompaniesController : ControllerBase
    {
        private readonly ISender _sender;
        public CompaniesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyDto dto)
        {
            var command = new CreateCompanyCommand(dto);

            var result = await _sender.Send(command);

            if(result.Status.Equals(HandlerStatus.Failure))
                return BadRequest(result.Message);

            return Created("",result.Body);
        }
    }
}
