using LM.Application.DTOs.LeaveAllocation;
using LM.Application.Features.LeaveAllocation.Requests.Commands;
using LM.Application.Features.LeaveAllocation.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace LM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LeaveAllocationsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public LeaveAllocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocationDto>>> Get()
        {
            return Ok(await _mediator.Send(new GetLeaveAllocationListRequest()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocationDto>> Get(int id)
        {
            return Ok(await _mediator.Send(new GetLeaveAllocatioDetailRequest { Id = id }));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLeaveAllocationDto leaveAllocation)
        {
            return Ok(await _mediator.Send(new CreateLeaveAllocationCommand { CreateLeaveAllocationDto = leaveAllocation }));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveAllocationDto leaveAllocation)
        {
            await _mediator.Send(new UpdateLeaveAllocationCommand { LeaveAllocationDto = leaveAllocation });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteLeaveAllocationCommand { Id = id });

            return NoContent();
        }
    }
}
