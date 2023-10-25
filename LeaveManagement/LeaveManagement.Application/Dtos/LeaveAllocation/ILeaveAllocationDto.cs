
namespace LeaveManagement.Application.Dtos.LeaveAllocation
{
    public interface ILeaveAllocationDto
    {
        public int NumberOfDays { get; set; }
        public Guid LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
