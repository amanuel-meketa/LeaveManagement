using LeaveManagement.Application.Dtos;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveRequest.Request.Queries
{
    public class GetLeaveRequestList : IRequest<List<LeaveRequestDto>>
    {
    }
}
