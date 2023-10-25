using LeaveManagement.Domain;
using LeaveManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Persistence.Data
{
    public class LeaveManagmentDbContext : DbContext
    {
        public LeaveManagmentDbContext(DbContextOptions<LeaveManagmentDbContext> options) : base(options)
        {    
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LeaveManagmentDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            { 
               entry.Entity.LastModifiedDate = DateTime.UtcNow;

                if(entry.State == EntityState.Added)
                    entry.Entity.DateCreated = DateTime.UtcNow;
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        DbSet<LeaveType> leaveTypes { get; set; }
        DbSet<LeaveRequest> leaveRequests { get; set; }
        DbSet<LeaveAllocation> leaveAllocations { get; set; }
    }
}
