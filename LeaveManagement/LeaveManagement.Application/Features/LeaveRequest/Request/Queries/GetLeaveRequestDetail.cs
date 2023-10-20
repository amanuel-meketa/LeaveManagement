using LeaveManagement.Application.Dtos.LeaveRequest;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveRequest.Request.Queries
{
    public class GetLeaveRequestDetail : IRequest<LeaveRequestDto>
    {
        public Guid Id { get; set; }
    }
}
