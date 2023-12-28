using LeaveManagement.Application.Dtos.LeaveAllocation;
using LeaveManagement.Application.Features.LeaveAllocations.Request.Commands;
using LeaveManagement.Application.Features.LeaveAllocations.Request.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagement.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LeaveAllocationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LeaveAllocationController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocationDto>>> Get()
        {
            var leaveAllocations = await _mediator.Send(new LeaveAllocationList());
            return Ok(leaveAllocations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocationDto>> Get(Guid id)
        {
            var leaveAllocation = await _mediator.Send(new LeaveAllocationDetail { Id = id });
            return Ok(leaveAllocation);
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Post([FromBody] CreateLeaveAllocationDto leaveAllocation)
        {
            var command = new CreateLeaveAllocation { leaveAllocationDto = leaveAllocation };
            var repsonse = await _mediator.Send(command);
            return Ok(repsonse);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateLeaveAllocationDto leaveAllocation)
        {
            var command = new UpdateLeaveAllocation { updateLeaveAllocationDto = leaveAllocation };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteLeaveAllocation { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
