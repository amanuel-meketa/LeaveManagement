using MediatR;

namespace LeaveManagement.Application.Features.LeaveAllocations.Request.Commands
{
    public class DeleteLeaveAllocation : IRequest
    {
        public Guid Id { get; set; }
    }
}
