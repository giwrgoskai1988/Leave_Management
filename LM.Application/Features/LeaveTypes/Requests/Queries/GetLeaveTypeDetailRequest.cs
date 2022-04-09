using LM.Application.DTOs.LeaveType;
using MediatR;

namespace LM.Application.Features.LeaveTypes.Requests
{
    public class GetLeaveTypeDetailRequest:IRequest<LeaveTypeDto>
    {
        public int Id { get; set; }
    }
}
