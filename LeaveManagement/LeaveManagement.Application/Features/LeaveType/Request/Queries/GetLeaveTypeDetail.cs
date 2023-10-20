using LeaveManagement.Application.Dtos.LeaveType;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveType.Request.Queries
{
    public class GetLeaveTypeDetail : IRequest<LeaveTypeDto>
    {
        public Guid Id { get; set; }
    }
}
