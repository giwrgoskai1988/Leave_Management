﻿using LM.Application.DTOs;
using MediatR;

namespace LM.Application.Features.LeaveTypes.Requests
{
    public class GetLeaveRequestDetailRequest:IRequest<LeaveRequestDto>
    {
        public int Id { get; set; }
    }
}
