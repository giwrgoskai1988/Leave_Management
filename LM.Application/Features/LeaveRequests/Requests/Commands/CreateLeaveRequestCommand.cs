using LM.Application.DTOs.LeaveRequest;
using LM.Application.Responses;
using MediatR;

namespace LM.Application.Features.LeaveRequests.Requests.Commands
{
    public class CreateLeaveRequestCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveRequestDto CreateLeaveRequestDto { get; set; }
    }
}
