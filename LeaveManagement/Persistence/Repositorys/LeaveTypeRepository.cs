using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Domain;

namespace LeaveManagement.Persistence.Repositorys
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly LeaveManagementDbContext _dbContext;

        public LeaveTypeRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
