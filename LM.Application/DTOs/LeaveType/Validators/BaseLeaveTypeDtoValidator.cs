using FluentValidation;

namespace LM.Application.DTOs.LeaveType.Validators
{
    public class BaseLeaveTypeDtoValidator : AbstractValidator<ILeaveTypeDto>
    {
        public BaseLeaveTypeDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .NotNull().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(x => x.DefaultDays)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.")
                .LessThan(100).WithMessage("{PropertyName} must be less than 100.");
        }
    }
}
