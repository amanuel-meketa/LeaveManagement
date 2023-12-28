using LeaveManagement.Application.Dtos.LeaveType;
using LeaveManagement.Application.Features.LeaveTypes.Request.Commands;
using LeaveManagement.Application.Features.LeaveTypes.Request.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagement.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LeaveTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypeController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<LeaveTypeDto>>> Get()
        {
            var leaveTypes = await _mediator.Send(new GetLeaveTypeRequest());
            return Ok(leaveTypes);
        }

        [HttpGet("{id}")]
        public async Task<LeaveTypeDto> Get(Guid id)
        {
            var queries = new GetLeaveTypeDetail
            {
                Id = id
            };

            var response = await _mediator.Send(queries);
            return response;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromBody] CreateLeaveTypeDto leaveType)
        {
            var command = new CreateLeaveType
            {
                leaveTypeDto = leaveType
            };

            var response = await _mediator.Send(command);
            var locationUri = $"{Request.Scheme}://{Request.Host.ToUriComponent()}/api/LeaveType/{response}";

            return Created(locationUri, response);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] LeaveTypeDto leaveType)
        {
            var command = new UpdateLeaveType { leaveTypeDto = leaveType };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteleaveType
            { 
               Id = id
            };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
