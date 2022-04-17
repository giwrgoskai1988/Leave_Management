using AutoMapper;
using LM.Application.Contracts.Persistence;
using LM.Application.DTOs.LeaveType;
using LM.Application.Features.LeaveTypes.Handlers.Commands;
using LM.Application.Features.LeaveTypes.Requests.Commands;
using LM.Application.Profiles;
using LM.Application.Responses;
using LM.UnitTests.Mocks;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace LM.UnitTests.LeaveTypes.Commands
{
    public class CreateLeaveTypeCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveTypeRepository> _mockRepo;
        private readonly CreateLeaveTypeDto _leaveTypeDto;

        public CreateLeaveTypeCommandHandlerTests()
        {
            _mockRepo = MockLeaveTypeRepository.GetLeaveTypeRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _leaveTypeDto = new CreateLeaveTypeDto()
            {
                DefaultDays = 15,
                Name = "Test DTO"
            };
        }

        [Fact]
        public async Task CreateLeaveType()
        {
            var handler = new CreateLeaveTypeCommandHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new CreateLeaveTypeCommand() { LeaveTypeDto = _leaveTypeDto }, CancellationToken.None);

            var leaveTypes = await _mockRepo.Object.GetAll();

            result.ShouldBeOfType<BaseCommandResponse>();

            leaveTypes.Count.ShouldBe(3);
        }

        [Fact]
        public async Task CreateLeaveType_BadInput()
        {
            var handler = new CreateLeaveTypeCommandHandler(_mockRepo.Object, _mapper);

            //ValidationException ex = await Should.ThrowAsync<ValidationException>(async () =>
            //{
            //    await handler.Handle(new CreateLeaveTypeCommand() { LeaveTypeDto = new CreateLeaveTypeDto { DefaultDays = -23, Name = "" } }, CancellationToken.None);
            //});

            var result = await handler.Handle(new CreateLeaveTypeCommand() { LeaveTypeDto = new CreateLeaveTypeDto { DefaultDays = -23, Name = "" } }, CancellationToken.None);

            var leaveTypes = await _mockRepo.Object.GetAll();

            leaveTypes.Count.ShouldBe(2);

            result.ShouldBeOfType<BaseCommandResponse>();

            result.Success.ShouldBe(false);
        }
    }
}
