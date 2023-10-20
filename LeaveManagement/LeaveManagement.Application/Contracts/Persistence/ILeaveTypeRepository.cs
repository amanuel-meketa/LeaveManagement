using LeaveManagement.Domain;

namespace LeaveManagement.Application.Contracts.Persistence
{
    public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
    {
        Task<List<LeaveType>> GetLeaveTypeDetail();
        Task<LeaveType> GetLeaveTypeDetail(Guid id);
    }
}
