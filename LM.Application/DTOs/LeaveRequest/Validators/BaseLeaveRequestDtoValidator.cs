using FluentValidation;
using LM.Application.Contracts.Persistence;

namespace LM.Application.DTOs.LeaveRequest.Validators
{
    public class BaseLeaveRequestDtoValidator : AbstractValidator<ILeaveRequestDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public BaseLeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(x => x.StartDate)
                .LessThan(x => x.EndDate).WithMessage("{PropertName} must be before {ComparisonValue}.");

            RuleFor(x => x.EndDate)
               .LessThan(x => x.StartDate).WithMessage("{PropertName} must be after {ComparisonValue}.");

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
