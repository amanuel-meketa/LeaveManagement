using LeaveManagement.Application.Dtos;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveType.Request.Queries
{
    public class GetLeaveTypeDetail : IRequest<LeaveTypeDto>
    {
        public Guid Id { get; set; }
    }
}
