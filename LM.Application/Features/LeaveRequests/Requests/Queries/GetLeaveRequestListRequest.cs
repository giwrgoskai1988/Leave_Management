using LM.Application.DTOs.LeaveRequest;
using MediatR;

namespace LM.Application.Features.LeaveTypes.Requests
{
    public class GetLeaveRequestListRequest:IRequest<List<LeaveRequestListDto>>
    {

    }
}
