using LeaveManagement.Application.Dtos.LeaveRequest;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveRequest.Request.Queries
{
    public class GetLeaveRequestList : IRequest<List<LeaveRequestListDto>>
    {
    }
}
