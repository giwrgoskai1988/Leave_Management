using FluentValidation;
using LM.Application.DTOs.LeaveAllocation;
using LM.Application.DTOs.LeaveAllocation.Validators;
using LM.Application.Persistence.Contracts;

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