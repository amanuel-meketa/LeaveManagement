using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Domain;
using LeaveManagement.Persistence.Data;

namespace LeaveManagement.Persistence.Repositorys
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly LeaveManagmentDbContext _dbContext;

        public LeaveTypeRepository(LeaveManagmentDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
