using LeaveManagement.Application.Dtos.LeaveRequest;
using LeaveManagement.Application.Dtos.LeaveType;
using LeaveManagement.Application.Features.LeaveRequests.Request.Commands;
using LeaveManagement.Application.Features.LeaveRequests.Request.Queries;
using LeaveManagement.Application.Features.LeaveTypes.Request.Commands;
using LeaveManagement.Application.Features.LeaveTypes.Request.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagement.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveRequestController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestDto>>> Get()
        {
            var leaveRequest = await _mediator.Send(new GetLeaveRequestList());
            return Ok(leaveRequest);
        }

        [HttpGet("{id}")]
        public async Task<LeaveRequestDto> Get(Guid id)
        {
            var queries = new GetLeaveRequestDetail
            {
                Id = id
            };

            var response = await _mediator.Send(queries);
            return response;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromBody] CreateLeaveRequestDto leaveRequest)
        {
            var command = new CreateLeaveRequest { leaveRequestDto = leaveRequest };
            var repsonse = await _mediator.Send(command);
            var locationUri = $"{Request.Scheme}://{Request.Host.ToUriComponent()}/LeaveRequest/{Response}";

            return Created(locationUri, repsonse);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UpdateLeaveRequestDto leaveRequest)
        {
            var command = new UpdateLeaveRequest { Id = id, updateLeaveRequestDto = leaveRequest };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteLeaveRequest
            { 
               Id = id
            };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
