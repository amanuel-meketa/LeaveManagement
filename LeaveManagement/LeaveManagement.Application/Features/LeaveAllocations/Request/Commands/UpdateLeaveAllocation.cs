using LeaveManagement.Application.Dtos.LeaveAllocation;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveAllocations.Request.Commands
{
    public class UpdateLeaveAllocation : IRequest<Unit>
    {
        public UpdateLeaveAllocationDto updatellocationDto { get; set; }
    }
}
