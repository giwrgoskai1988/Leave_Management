using LM.Application.DTOs.LeaveType;
using LM.Application.Responses;
using MediatR;

namespace LM.Application.Features.LeaveTypes.Requests.Commands
{
    public class CreateLeaveTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveTypeDto LeaveTypeDto { get; set; }
    }
}
