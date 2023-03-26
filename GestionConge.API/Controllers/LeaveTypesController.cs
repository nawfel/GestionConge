using GestionConge.Application.features.leaveType.commands.createLeaveType;
using GestionConge.Application.features.leaveType.commands.deleteLeaveType;
using GestionConge.Application.features.leaveType.commands.updateLeaveType;
using GestionConge.Application.features.leaveType.queries.GetAllLeaveTypes;
using GestionConge.Application.features.leaveType.queries.GetLeaveTypeDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionConge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypesController : ControllerBase
    {
        private readonly IMediator mediator;

        public LeaveTypesController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // GET: api/<LeaveTypesController>
        [HttpGet]
        public async Task<List<LeaveTypeDto>> Get()
        {
            var leaveTypes = await mediator.Send(new GetLeaveTypeQuery());
            return leaveTypes;
        }
        // GET api/<LeaveTypesController>/5
        [HttpGet("{id}")]
        public async Task<LeaveTypeDetailsDto> Get(int id)
        {
            var leaveType = await mediator.Send(new GetLeaveTypeDetailsQuery(id));
            return leaveType;
        }

        // POST api/<LeaveTypesController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post([FromBody] CreateLeaveTypeCommand leaveType)
        {
            var response = await mediator.Send(leaveType);
            return CreatedAtAction(nameof(Get), new { id = response });

        }

        // PUT api/<LeaveTypesController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> Put(UpdateLeaveTypeCommand leaveType)
        {
            await mediator.Send(leaveType);
            return NoContent();
        }

        // DELETE api/<LeaveTypesController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveTypeCommand { Id= id };
            await mediator.Send(command);
            return NoContent();
        }
    }
}
