using LeaveManagement.Application.Dtos.Common;

namespace LeaveManagement.Application.Dtos.LeaveAllocation
{
    public class UpdateLeaveAllocationDto :BaseDto
    {
        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
