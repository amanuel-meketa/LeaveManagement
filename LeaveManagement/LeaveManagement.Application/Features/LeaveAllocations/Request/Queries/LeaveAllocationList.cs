using LeaveManagement.Application.Dtos.LeaveAllocation;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveAllocations.Request.Queries
{
    public class LeaveAllocationList : IRequest<List<LeaveAllocationDto>> { }
}
