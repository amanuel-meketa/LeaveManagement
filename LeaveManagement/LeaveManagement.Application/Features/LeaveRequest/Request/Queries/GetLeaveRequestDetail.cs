using LeaveManagement.Application.Dtos;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveRequest.Request.Queries
{
    public class GetLeaveRequestDetail : IRequest<LeaveRequestDto>
    {
        public Guid Id { get; set; }
    }
}
