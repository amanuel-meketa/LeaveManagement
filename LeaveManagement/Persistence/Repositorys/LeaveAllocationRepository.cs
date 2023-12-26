using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Persistence.Repositorys
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly LeaveManagementDbContext _dbContext;

        public LeaveAllocationRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationDetail()
        {
            var leaveAllocations = await _dbContext.LeaveAllocations
                 .Include(l => l.LeaveType)
                 .ToListAsync();
            return leaveAllocations;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationDetail(Guid id)
        {
            var leaveAllocations = await _dbContext.LeaveAllocations
                .Include(l => l.LeaveType)
                .FirstOrDefaultAsync(i => i.Id == id);

            return leaveAllocations;
        }
    }
}
