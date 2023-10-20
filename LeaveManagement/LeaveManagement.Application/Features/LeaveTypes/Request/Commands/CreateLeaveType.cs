using LeaveManagement.Application.Dtos.LeaveType;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveTypes.Request.Commands
{
    public class CreateLeaveType : IRequest<Guid>
    {
        public LeaveTypeDto? leaveTypeDto { get; set; }
    }
}
