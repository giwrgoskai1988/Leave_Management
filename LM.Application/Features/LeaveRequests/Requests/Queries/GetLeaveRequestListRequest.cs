﻿using LM.Application.DTOs.LeaveRequest;
using MediatR;

namespace LM.Application.Features.LeaveRequests.Requests
{
    public class GetLeaveRequestListRequest : IRequest<List<LeaveRequestListDto>>
    {

    }
}
