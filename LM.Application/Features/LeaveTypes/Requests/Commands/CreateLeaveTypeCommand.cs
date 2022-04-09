﻿using LM.Application.DTOs.LeaveType;
using MediatR;

namespace LM.Application.Features.LeaveTypes.Requests.Commands
{
    public class CreateLeaveTypeCommand : IRequest<int>
    {
        public CreateLeaveTypeDto LeaveTypeDto { get; set; }
    }
}
