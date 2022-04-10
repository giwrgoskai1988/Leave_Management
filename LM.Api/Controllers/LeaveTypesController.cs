using LM.Application.DTOs.LeaveType;
using LM.Application.Features.LeaveTypes.Requests;
using LM.Application.Features.LeaveTypes.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<LeaveTypeDto>>> Index()
        {
            var leaveTypes = await _mediator.Send(new GetLeaveTypeListRequest());

            return leaveTypes;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDto>> Get(int id)
        {
            return Ok(await _mediator.Send(new GetLeaveTypeDetailRequest { Id = id }));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLeaveTypeDto leaveType)
        {
            var response = await _mediator.Send(new CreateLeaveTypeCommand { LeaveTypeDto = leaveType });

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] LeaveTypeDto leaveType)
        {
            await _mediator.Send(new UpdateLeaveTypeCommand { LeaveTypeDto = leaveType });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteLeaveTypeCommand { Id = id });

            return NoContent();
        }
    }
}
