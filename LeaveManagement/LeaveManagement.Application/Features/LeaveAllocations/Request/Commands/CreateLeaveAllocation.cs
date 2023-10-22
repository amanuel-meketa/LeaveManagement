using LeaveManagement.Application.Dtos.LeaveAllocation;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveAllocations.Request.Commands
{
    public class CreateLeaveAllocation : IRequest<Guid>
    {
        public CreateLeaveAllocationDto? leaveAllocationDto { get; set; }
    }
}
