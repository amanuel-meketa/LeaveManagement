using LeaveManagement.Domain;

namespace LeaveManagement.Application.Contracts.Persistence
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<List<LeaveAllocation>> GetLeaveAllocationDetail();
        Task<LeaveAllocation> GetLeaveAllocationDetail(Guid id);
    }
}
