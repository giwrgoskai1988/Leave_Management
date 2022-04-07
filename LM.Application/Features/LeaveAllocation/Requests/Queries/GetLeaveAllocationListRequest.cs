using LM.Application.DTOs;
using MediatR;

namespace LM.Application.Features.LeaveAllocation.Requests.Queries
{
    public class GetLeaveAllocationListRequest:IRequest<List<LeaveAllocationDto>>
    {
        public int Id { get; set; }
    }
}
