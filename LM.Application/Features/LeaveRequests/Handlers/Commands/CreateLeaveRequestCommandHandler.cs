using AutoMapper;
using LM.Application.Contracts.Persistence;
using LM.Application.Contrancts.Infrastructure;
using LM.Application.DTOs.LeaveRequest.Validators;
using LM.Application.Features.LeaveRequests.Requests.Commands;
using LM.Application.Models.Email;
using LM.Application.Responses;
using LM.Domain;
using MediatR;

namespace LM.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;

        public CreateLeaveRequestCommandHandler(
            ILeaveRequestRepository leaveRequestRepository,
            ILeaveTypeRepository leaveTypeRepository,
            IMapper mapper,
            IEmailSender emailSender
            )
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
            _emailSender = emailSender;
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);

            var validationResult = await validator.ValidateAsync(request.CreateLeaveRequestDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation failed.";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }

            var leaveRequest = _mapper.Map<LeaveRequest>(request.CreateLeaveRequestDto);

            leaveRequest = await _leaveRequestRepository.Add(leaveRequest);

            response.Success = true;
            response.Message = "Created Successfully.";
            response.Id = leaveRequest.Id;

            var email = new Email
            {
                To = "test@test.com",
                Body = $"Your leave request for {request.CreateLeaveRequestDto.StartDate:D} to {request.CreateLeaveRequestDto.EndDate:D} has been submitted.",
                Subject = "Leave Request Submitted"
            };

            try
            {
                await _emailSender.SendEmail(email);
            }
            catch (Exception ex)
            {

            }

            return response;

        }
    }
}
