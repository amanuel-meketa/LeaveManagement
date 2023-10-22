using LeaveManagement.Application.Dtos.LeaveType;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveTypes.Request.Commands
{
    public class CreateLeaveType : IRequest<Guid>
    {
        public CreateLeaveTypeDto leaveTypeDto { get; set; }
    }
}
