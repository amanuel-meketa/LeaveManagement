using LeaveManagement.Application.Dtos.Common;

namespace LeaveManagement.Application.Dtos.LeaveAllocation
{
    public class UpdateLeaveAllocationDto : BaseDto, ILeaveAllocationDto 
    {
        public int NumberOfDays { get; set; }
        public Guid LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
