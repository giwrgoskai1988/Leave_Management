using FluentValidation;
using LM.Application.Contracts.Persistence;
using LM.Application.DTOs.LeaveAllocation;
using LM.Application.DTOs.LeaveAllocation.Validators;

namespace LM.Application.DTOs.LeaveType.Validators
{
    public class CreateLeaveAllocationDtoValidator : AbstractValidator<CreateLeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            Include(new BaseLeaveAllocationValidator(_leaveTypeRepository));
        }
    }
}