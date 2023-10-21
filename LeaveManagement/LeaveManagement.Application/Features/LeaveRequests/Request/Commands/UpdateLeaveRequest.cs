using LeaveManagement.Application.Dtos.LeaveRequest;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveRequests.Request.Commands
{
    public class UpdateLeaveRequest : IRequest<Unit>
    {
        public UpdateLeaveRequestDto updateLeaveRequestDto { get; set; }
    }
}
