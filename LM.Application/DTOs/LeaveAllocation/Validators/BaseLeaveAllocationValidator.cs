using FluentValidation;
using LM.Application.Persistence.Contracts;

namespace LM.Application.DTOs.LeaveAllocation.Validators
{
    public class BaseLeaveAllocationValidator : AbstractValidator<ILeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public BaseLeaveAllocationValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(x => x.NumberOfDays)
                 .GreaterThan(0);

            RuleFor(x => x.Period)
                .GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("{PropertName} must be after {ComparisonValue}.");

            RuleFor(x => x.LeaveTypeId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    return !(await _leaveTypeRepository.Exists(id));
                })
               .WithMessage("{PropertName} does not exist.");
        }
    }
}
