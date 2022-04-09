using FluentValidation;

namespace LM.Application.DTOs.LeaveType.Validators
{
    public class CreateLeaveTypeDtoValidator : AbstractValidator<CreateLeaveTypeDto>
    {
        public CreateLeaveTypeDtoValidator()
        {
            Include(new BaseLeaveTypeDtoValidator());
        }
    }
}
