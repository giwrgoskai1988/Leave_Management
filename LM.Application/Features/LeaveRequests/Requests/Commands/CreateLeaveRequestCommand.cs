using LM.Application.DTOs.LeaveRequest;
using MediatR;

namespace LM.Application.Features.LeaveRequests.Requests.Commands
{
    public class CreateLeaveRequestCommand:IRequest<int>
    {
        public CreateLeaveRequestDto CreateLeaveRequestDto { get; set; }
    }
}
