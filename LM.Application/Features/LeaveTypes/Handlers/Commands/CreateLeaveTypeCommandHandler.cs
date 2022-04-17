using AutoMapper;
using LM.Application.Contracts.Persistence;
using LM.Application.DTOs.LeaveType.Validators;
using LM.Application.Features.LeaveTypes.Requests.Commands;
using LM.Application.Responses;
using LM.Domain;
using MediatR;

namespace LM.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, BaseCommandResponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var leaveType = _mapper.Map<LeaveType>(request.LeaveTypeDto);

                leaveType = await _leaveTypeRepository.Add(leaveType);

                response.Success = true;
                response.Message = "Creation Successfull";
                response.Id = leaveType.Id;
            }

            return response;
        }
    }
}
