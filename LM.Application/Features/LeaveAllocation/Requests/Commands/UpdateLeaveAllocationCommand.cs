using MediatR;

namespace LM.Application.Features.LeaveAllocation.Requests.Commands
{
    public class DeleteLeaveAllocationCommand : IRequest
    {
        public int Id { get; set; }
    }
}
