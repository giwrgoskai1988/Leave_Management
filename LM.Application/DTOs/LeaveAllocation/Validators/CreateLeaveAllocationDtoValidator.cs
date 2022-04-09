using FluentValidation;
using LM.Application.DTOs.LeaveAllocation;
using LM.Application.DTOs.LeaveAllocation.Validators;
using LM.Application.Persistence.Contracts;

namespace LM.Application.DTOs.LeaveType.Validators
{
    public class UpdateLeaveAllocationDtoValidator : AbstractValidator<UpdateLeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            Include(new BaseLeaveAllocationValidator(_leaveTypeRepository));

            RuleFor(x => x.Id).NotNull();
        }
    }
}