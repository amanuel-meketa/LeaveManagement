using LeaveManagement.Application.Dtos.LeaveType;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveTypes.Request.Queries
{
    public class GetLeaveTypeRequest : IRequest<List<LeaveTypeDto>>
    {
    }
}
