using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Domain;
using LeaveManagement.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Persistence.Repositorys
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly LeaveManagmentDbContext _dbContext;

        public LeaveRequestRepository(LeaveManagmentDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool ApprovalStatus)
        {
            leaveRequest.Approved = ApprovalStatus;
            _dbContext.Entry(leaveRequest).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestDetail()
        {
           var leaveRequests = await _dbContext.leaveRequests
                .Include(l => l.LeaveType)
                .ToListAsync();
            return leaveRequests;
        }

        public async Task<LeaveRequest> GetLeaveRequestDetail(Guid id)
        {
            var leaveRequests = await _dbContext.leaveRequests
                .Include(l => l.LeaveType)
                .FirstOrDefaultAsync(i => i.Id == id);

            return leaveRequests;
        }
    }
}
