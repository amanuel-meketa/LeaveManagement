using LeaveManagement.Application.Dtos.Common;
using LeaveManagement.Application.Dtos.LeaveType;

namespace LeaveManagement.Application.Dtos.LeaveAllocation
{
    public class LeaveAllocationDto : BaseDto
    {
        public int NumberOfDays { get; set; }
        public LeaveTypeDto? LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
        public string? EmployeeId { get; set; }
    }
}
