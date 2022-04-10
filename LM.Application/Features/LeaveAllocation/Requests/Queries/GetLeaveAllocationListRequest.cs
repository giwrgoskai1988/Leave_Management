using LM.Application.DTOs.LeaveAllocation;
using MediatR;

namespace LM.Application.Features.LeaveAllocation.Requests.Queries
{
    public class GetLeaveAllocationListRequest : IRequest<List<LeaveAllocationDto>>
    {
    }
}
