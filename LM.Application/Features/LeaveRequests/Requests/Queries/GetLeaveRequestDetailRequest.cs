using LM.Application.DTOs.LeaveRequest;
using MediatR;

namespace LM.Application.Features.LeaveRequests.Requests
{
    public class GetLeaveRequestDetailRequest : IRequest<LeaveRequestDto>
    {
        public int Id { get; set; }
    }
}
