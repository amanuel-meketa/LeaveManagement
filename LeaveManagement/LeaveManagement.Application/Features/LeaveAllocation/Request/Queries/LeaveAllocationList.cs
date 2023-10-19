using LeaveManagement.Application.Dtos;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveAllocation.Request.Queries
{
    public class LeaveAllocationList : IRequest<List<LeaveAllocationDto>> { }
}
