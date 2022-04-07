using LM.Application.DTOs;
using MediatR;

namespace LM.Application.Features.LeaveTypes.Requests
{
    public class GetLeaveTypeListRequest:IRequest<List<LeaveTypeDto>>
    {

    }
}
