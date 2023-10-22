using LeaveManagement.Domain;

namespace LeaveManagement.Application.Contracts.Persistence
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<List<LeaveRequest>> GetLeaveRequestDetail();
        Task<LeaveRequest> GetLeaveRequestDetail(Guid id);
        Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool ApprovalStatus);
    }
}
