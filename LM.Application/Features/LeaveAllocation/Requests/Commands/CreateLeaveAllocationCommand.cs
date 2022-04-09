using LM.Application.DTOs.LeaveAllocation;
using MediatR;

namespace LM.Application.Features.LeaveAllocation.Requests.Commands
{
    public class CreateLeaveAllocationCommand : IRequest<int>
    {
        public CreateLeaveAllocationDto CreateLeaveAllocationDto { get; set; }
    }
}
