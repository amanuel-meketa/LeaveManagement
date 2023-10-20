using LeaveManagement.Application.Dtos.LeaveAllocation;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveAllocation.Request.Queries
{
    public class LeaveAllocationDetail : IRequest<LeaveAllocationDto>
    {
        public Guid Id { get; set; }
    }
}
