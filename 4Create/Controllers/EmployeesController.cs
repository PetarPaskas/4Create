using _4Create.Domain.Enums;
using _4Create.Domain.Members.Commands.CreateEmployee;
using _4Create.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _4Create.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeesController : ControllerBase
    {
        private readonly ISender _sender;
        public EmployeesController(ISender sender)
        {
            _sender = sender;
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeDto createEmployeeDto)
        {
            var command = new CreateEmployeeCommand(createEmployeeDto);

            var result = await _sender.Send(command);


            if (result.Status.Equals(HandlerStatus.Failure))
                return BadRequest(result.Message);

            return Created("", result.Body);
        }
    }
}
