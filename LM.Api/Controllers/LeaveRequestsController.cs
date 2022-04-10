using LM.Application.DTOs.LeaveRequest;
using LM.Application.Features.LeaveAllocation.Requests.Queries;
using LM.Application.Features.LeaveRequests.Requests;
using LM.Application.Features.LeaveRequests.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveRequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestDto>>> Get()
        {
            return Ok(_mediator.Send(new GetLeaveRequestListRequest()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDto>> Get(int id)
        {
            return Ok(_mediator.Send(new GetLeaveAllocatioDetailRequest { Id = id }));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLeaveRequestDto leaveRequest)
        {
            return Ok(await _mediator.Send(new CreateLeaveRequestCommand { CreateLeaveRequestDto = leaveRequest }));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveRequestDto leaveRequest)
        {
            await _mediator.Send(new UpdateLeaveRequestCommand { Id = id, LeaveRequestDto = leaveRequest });

            return NoContent();
        }

        [HttpPut("changeApproval")]
        public async Task<ActionResult> ChangeApproval([FromBody] ChangeLeaveRequestApprovalDto changeLeaveRequestApproval)
        {
            await _mediator.Send(new UpdateLeaveRequestCommand { ChangeLeaveRequestApprovalDto = changeLeaveRequestApproval });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteLeaveRequestCommand { Id = id });

            return NoContent();
        }
    }
}
