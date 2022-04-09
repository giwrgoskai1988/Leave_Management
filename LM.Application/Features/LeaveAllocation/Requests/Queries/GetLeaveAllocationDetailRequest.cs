using LM.Application.DTOs.LeaveAllocation;
using MediatR;

namespace LM.Application.Features.LeaveAllocation.Requests.Queries
{
    public class GetLeaveAllocatioDetailRequest:IRequest<LeaveAllocationDto>
    {
        public int Id { get; set; }
    }
}
