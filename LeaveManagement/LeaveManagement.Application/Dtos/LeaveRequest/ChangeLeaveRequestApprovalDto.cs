using LeaveManagement.Application.Dtos.Common;

namespace LeaveManagement.Application.Dtos.LeaveRequest
{
    public class ChangeLeaveRequestApprovalDto : BaseDto
    {
        public bool Approved { get; set; }
    }
}
