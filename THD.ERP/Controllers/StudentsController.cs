using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using THD.ERP.App.Commands.Student;

namespace THD.ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudentsAsync(StudentCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.Count > 0)
            {
                return Ok(response);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentByIdAsync(GetOneStudentCommand command)
        {
            var reponse = await _mediator.Send(command);
            if (reponse is null)
            {
                return BadRequest();
            }
            return Ok(reponse);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudentAsync([FromBody] CreateStudentCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

    }
}
