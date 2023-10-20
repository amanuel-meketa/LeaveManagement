using MediatR;

namespace LeaveManagement.Application.Features.LeaveRequests.Request.Commands
{
    public class CreateLeaveRequest : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
