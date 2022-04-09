using FluentValidation;

namespace LM.Application.DTOs.LeaveType.Validators
{
    public class UpdateLeaveTypeDtoValidator : AbstractValidator<LeaveTypeDto>
    {
        public UpdateLeaveTypeDtoValidator()
        {
            Include(new BaseLeaveTypeDtoValidator());

            RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} must be present.");
        }
    }
}
