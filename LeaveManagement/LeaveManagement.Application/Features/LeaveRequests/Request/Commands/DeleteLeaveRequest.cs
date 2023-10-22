using MediatR;

namespace LeaveManagement.Application.Features.LeaveRequests.Request.Commands
{
    public class DeleteLeaveRequest : IRequest
    {
        public Guid Id { get; set; }
    }
}
