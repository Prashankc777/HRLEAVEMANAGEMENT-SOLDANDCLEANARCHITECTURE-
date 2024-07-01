using HRLeaveManagement.Application.Feature.LeaveType.Commands.Create;
using HRLeaveManagement.Application.Feature.LeaveType.Queries.GetAllLeaveTypes;
using HRLeaveManagement.Application.Feature.LeaveType.Queries.GetLeaveTypeDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Hr.LeaveManagement.Api.Controllers;

[Route("api/leaveTypes")]
[ApiController]
public class LeaveTypesController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeaveTypesController(IMediator mediator)
    {
        _mediator = mediator;
    }
   
    [HttpGet]
    public async Task<List<LeaveTypeDto>> Get()
    {
        var leaveTypes = await _mediator.Send(new GetLeaveTypeQuery());
        return leaveTypes;
    }

    
    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveTypeDetailDto>> Get (int id)
    {
        var leaveType = await _mediator.Send(new GetLeaveTypeDetailsQuery(id));
        return leaveType;
    }


    [HttpPost]
    public async Task<IActionResult> Post(CreateLeaveTypeCommand command)
    {
        var response = await _mediator.Send(command);
        return CreatedAtAction(nameof(Get), new {id = response});
    }
    

    
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {

    }

    
    [HttpDelete("{id}")]
    public void Delete(int id)
    {

    }
}